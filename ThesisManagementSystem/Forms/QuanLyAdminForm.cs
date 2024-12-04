using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class QuanLyAdminForm : Form
    {
        private readonly IUserService _dichVuNguoiDung;
        private readonly IMilestoneService _dichVuMocThoiGian;
        private readonly ICommitteeService _dichVuHoiDong;
        private readonly IRegistrationService _dichVuDangKy;
        private readonly IServiceProvider _nhaCungCapDichVu;
        private readonly IStudentGroupService _dichVuNhomSinhVien;

        public QuanLyAdminForm(
            IUserService dichVuNguoiDung,
            IMilestoneService dichVuMocThoiGian,
            ICommitteeService dichVuHoiDong,
            IRegistrationService dichVuDangKy,
            IServiceProvider nhaCungCapDichVu,
            IStudentGroupService dichVuNhomSinhVien)
        {
            InitializeComponent();
            _dichVuNguoiDung = dichVuNguoiDung;
            _dichVuMocThoiGian = dichVuMocThoiGian;
            _dichVuHoiDong = dichVuHoiDong;
            _dichVuDangKy = dichVuDangKy;
            _nhaCungCapDichVu = nhaCungCapDichVu;
            _dichVuNhomSinhVien = dichVuNhomSinhVien;
        }

        private async void QuanLyAdminForm_Load(object sender, EventArgs e)
        {
            await TaiNguoiDung();
            await TaiMocThoiGian();
            await TaiHoiDong();
            await TaiDangKy();
            await TaiNhom();
        }

        #region Phương Thức Tải Dữ Liệu

        private async Task TaiNguoiDung()
        {
            var nguoiDung = await _dichVuNguoiDung.GetAllUsersWithRoles();
            dgvNguoiDung.DataSource = nguoiDung
                .Where(x => !x.UserID.Equals(UserSession.UserID))
                .Select(u => new
                {
                    u.UserID,
                    u.Username,
                    VaiTro = u.Role switch
                    {
                        Role.Student => "Sinh viên",
                        Role.Lecturer => "Giảng viên",
                        _ => "Quản trị viên"
                    },
                    Ten = u.Role == Role.Student ? u.Student?.Name :
                          u.Role == Role.Lecturer ? u.Lecturer?.Name : "N/A",
                    ThongTinBoSung = u.Role == Role.Student ? u.Student?.Class :
                                      u.Role == Role.Lecturer ? u.Lecturer?.Department : "N/A"
                })
                .ToList();
            dgvNguoiDung.Columns["UserID"].Visible = false;
        }

        private async Task TaiNhom()
        {
            var nhom = await _dichVuNhomSinhVien.GetAllGroups();
            dgvNhom.DataSource = nhom.Select(g => new
            {
                g.GroupID,
                g.GroupName,
                TenNguoiHuongDan = g.Advisor?.Name ?? "N/A",
                TenHoiDong = g.Committee?.Name ?? "N/A",
                TenNguoiDaiDien = g.GroupLeader?.User?.Username ?? "N/A",
                NgayTao = g.CreatedDate.ToString("dd/MM/yyyy")
            }).ToList();
            dgvNhom.Columns["GroupID"].Visible = false;
        }

        private async Task TaiMocThoiGian()
        {
            var mocThoiGian = await _dichVuMocThoiGian.GetAllMilestones();
            dgvMocThoiGian.DataSource = mocThoiGian.Select(m => new
            {
                m.MilestoneID,
                m.Name,
                m.Description,
                m.Deadline
            }).ToList();
            dgvMocThoiGian.Columns["MilestoneID"].Visible = false;
        }

        private async Task TaiHoiDong()
        {
            var hoiDong = await _dichVuHoiDong.GetAllCommitteesWithLecturers();
            dgvHoiDong.DataSource = hoiDong.Select(c => new
            {
                c.CommitteeID,
                c.Name,
                NgayBaoVe = c.DefenseDate.ToString("dd/MM/yyyy"),
                GiangVien = string.Join(", ", c.CommitteeMembers.Select(cm => cm.Lecturer.Name + $" ({cm.Role})"))
            }).ToList();

            dgvHoiDong.Columns["CommitteeID"].Visible = false;
        }

        private async Task TaiDangKy()
        {
            var dangKy = await _dichVuDangKy.GetAllRegistrationsWithGroupAndGroupLeaderAndUser();
            dgvDangKy.DataSource = dangKy.Select(r => new
            {
                r.RegistrationID,
                TenDangNhap = r.Group?.GroupLeader?.User?.Username,
                VaiTro = r.Group?.GroupLeader?.User?.Role.ToString(),
                TrangThai = r.Status.ToString(),
                NgayDangKy = r.RegistrationDate.ToString("dd/MM/yyyy")
            }).ToList();
            dgvDangKy.Columns["RegistrationID"].Visible = false;
        }

        #endregion

        #region Sự Kiện Click của Nút Bấm

        private async void btnTaoHoiDong_Click(object sender, EventArgs e)
        {
            var taoHoiDongForm = _nhaCungCapDichVu.GetRequiredService<TaoHoiDongForm>();
            if (taoHoiDongForm.ShowDialog() == DialogResult.OK)
            {
                await TaiHoiDong();
            }
        }

        private async void btnChinhSuaHoiDong_Click(object sender, EventArgs e)
        {
            if (dgvHoiDong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hội đồng để chỉnh sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maHoiDongChon = (Guid)dgvHoiDong.CurrentRow.Cells["CommitteeID"].Value;
            var chinhSuaHoiDongForm = _nhaCungCapDichVu.GetRequiredService<ChinhSuaHoiDongForm>();
            chinhSuaHoiDongForm.SetHoiDongID(maHoiDongChon);

            if (chinhSuaHoiDongForm.ShowDialog() == DialogResult.OK)
            {
                await TaiHoiDong();
            }
        }

        private async void btnCapNhatTrangThaiDangKy_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đăng ký.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maDangKy = (Guid)dgvDangKy.CurrentRow.Cells["RegistrationID"].Value;
            var trangThaiHienTai = dgvDangKy.CurrentRow.Cells["TrangThai"].Value.ToString();

            var capNhatTrangThaiForm = new CapNhatTrangThaiForm();
            capNhatTrangThaiForm.CaiDatTrangThaiHienTai(trangThaiHienTai);
            if (capNhatTrangThaiForm.ShowDialog() == DialogResult.OK)
            {
                var trangThaiMoi = capNhatTrangThaiForm.TrangThaiDaChon;
                try
                {
                    await _dichVuDangKy.UpdateRegistrationStatus(maDangKy, trangThaiMoi);
                    MessageBox.Show("Cập nhật trạng thái đăng ký thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiDangKy();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnTaoNguoiDung_Click(object sender, EventArgs e)
        {
            var taoNguoiDungForm = _nhaCungCapDichVu.GetRequiredService<TaoNguoiDungForm>();
            if (taoNguoiDungForm.ShowDialog() == DialogResult.OK)
            {
                await TaiNguoiDung();
            }
        }

        private async void btnChinhSuaNguoiDung_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để chỉnh sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maNguoiDungChon = (Guid)dgvNguoiDung.CurrentRow.Cells["UserID"].Value;
            var chinhSuaNguoiDungForm = _nhaCungCapDichVu.GetRequiredService<ChinhSuaNguoiDungForm>();
            chinhSuaNguoiDungForm.SetMaNguoiDung(maNguoiDungChon);

            if (chinhSuaNguoiDungForm.ShowDialog() == DialogResult.OK)
            {
                await TaiNguoiDung();
            }
        }

        private async void btnXoaNguoiDung_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maNguoiDungChon = (Guid)dgvNguoiDung.CurrentRow.Cells["UserID"].Value;
            var tenNguoiDungChon = dgvNguoiDung.CurrentRow.Cells["Username"].Value.ToString();

            var xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{tenNguoiDungChon}'?",
                                         "Xác Nhận Xóa",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan == DialogResult.Yes)
            {
                try
                {
                    await _dichVuNguoiDung.DeleteUser(maNguoiDungChon);
                    MessageBox.Show("Xóa người dùng thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiNguoiDung();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý logic đăng xuất tại đây
            UserSession.Logout();
            this.Close();
            var dichVuNguoiDung = Program.HostInstance.Services.GetRequiredService<IUserService>();
            var dangNhapForm = new DangNhapForm(dichVuNguoiDung);
            dangNhapForm.Show();
        }

        private async void btnTaoMocThoiGian_Click(object sender, EventArgs e)
        {
            var taoMocThoiGianForm = _nhaCungCapDichVu.GetRequiredService<TaoCotMocForm>();
            if (taoMocThoiGianForm.ShowDialog() == DialogResult.OK)
            {
                var mocThoiGianMoi = taoMocThoiGianForm.CotMocMoi;
                await _dichVuMocThoiGian.CreateMilestone(mocThoiGianMoi);
                await TaiMocThoiGian();
            }
        }

        private async void btnChinhSuaMocThoiGian_Click(object sender, EventArgs e)
        {
            if (dgvMocThoiGian.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mốc thời gian để chỉnh sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maMocThoiGianChon = (Guid)dgvMocThoiGian.CurrentRow.Cells["MilestoneID"].Value;
            var mocThoiGianChon = await _dichVuMocThoiGian.GetByIdAsync(maMocThoiGianChon);

            var chinhSuaMocThoiGianForm = new ChinhSuaMocThoiGianForm();
            chinhSuaMocThoiGianForm.ThietLapMocThoiGian(mocThoiGianChon);

            if (chinhSuaMocThoiGianForm.ShowDialog() == DialogResult.OK)
            {
                var mocThoiGianChinhSua = chinhSuaMocThoiGianForm.MocThoiGianDuocChinhSua;
                await _dichVuMocThoiGian.UpdateMilestone(mocThoiGianChinhSua);
                await TaiMocThoiGian();
            }
        }

        private async void btnChinhSuaNhom_Click(object sender, EventArgs e)
        {
            if (dgvNhom.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm để chỉnh sửa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maNhomChon = (Guid)dgvNhom.CurrentRow.Cells["GroupID"].Value;
            var chinhSuaNhomForm = _nhaCungCapDichVu.GetRequiredService<ChinhSuaNhomForm>();
            chinhSuaNhomForm.SetMaNhom(maNhomChon);

            if (chinhSuaNhomForm.ShowDialog() == DialogResult.OK)
            {
                await TaiNhom();
            }
        }

        #endregion
    }
}
