using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class ChinhSuaHoiDongForm : Form
    {
        private readonly ICommitteeService _dichVuHoiDong;
        private readonly ILecturerService _dichVuGiangVien;
        private Guid _hoiDongID;
        private Committee _hoiDong;
        private readonly IServiceProvider _nhaCungCapDichVu;

        public ChinhSuaHoiDongForm(ICommitteeService dichVuHoiDong, ILecturerService dichVuGiangVien, IServiceProvider nhaCungCapDichVu)
        {
            InitializeComponent();
            _dichVuHoiDong = dichVuHoiDong;
            _dichVuGiangVien = dichVuGiangVien;
            _nhaCungCapDichVu = nhaCungCapDichVu;
        }

        /// <summary>
        /// Thiết lập ID của Hội Đồng và tải dữ liệu.
        /// </summary>
        /// <param name="hoiDongID">ID của Hội Đồng muốn chỉnh sửa.</param>
        public void SetHoiDongID(Guid hoiDongID)
        {
            _hoiDongID = hoiDongID;
        }

        private async void ChinhSuaHoiDongForm_Load(object sender, EventArgs e)
        {
            KhoiTaoDgvGiangVien();
            await TaiDuLieuHoiDong();
        }

        /// <summary>
        /// Khởi tạo các cột cho DataGridView.
        /// </summary>
        private void KhoiTaoDgvGiangVien()
        {
            dgvGiangVien.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa tất cả các cột hiện có
            dgvGiangVien.Columns.Clear();

            // Thêm cột chọn Giảng Viên
            var chonColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Chọn",
                Name = "Chon",
                Width = 50
            };
            dgvGiangVien.Columns.Add(chonColumn);

            // Thêm cột LecturerID (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvGiangVien.Columns.Add(idColumn);

            // Thêm cột Tên Giảng Viên
            var tenGiangVienColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Giảng Viên",
                Name = "TenGiangVien",
                ReadOnly = true
            };
            dgvGiangVien.Columns.Add(tenGiangVienColumn);

            // Thêm cột Khoa
            var khoaColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa",
                Name = "Khoa",
                ReadOnly = true
            };
            dgvGiangVien.Columns.Add(khoaColumn);

            // Thêm cột Vai Trò (ComboBox)
            var vaiTroColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Vai Trò",
                Name = "VaiTro",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvGiangVien.Columns.Add(vaiTroColumn);
        }

        /// <summary>
        /// Tải dữ liệu của Hội Đồng hiện tại.
        /// </summary>
        private async Task TaiDuLieuHoiDong()
        {
            try
            {
                _hoiDong = await _dichVuHoiDong.GetCommitteeByID(_hoiDongID);
                if (_hoiDong == null)
                {
                    MessageBox.Show("Không tìm thấy Hội Đồng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtTenHoiDong.Text = _hoiDong.Name;
                dtpNgayBaoVe.Value = _hoiDong.DefenseDate;

                // Tải danh sách Giảng Viên vào DataGridView
                await NapDanhSachGiangVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tải danh sách Giảng Viên vào DataGridView.
        /// </summary>
        private async Task NapDanhSachGiangVien()
        {
            dgvGiangVien.Rows.Clear();

            foreach (var cm in _hoiDong.CommitteeMembers)
            {
                var giangVien = await _dichVuGiangVien.GetLecturerById(cm.LecturerID);
                if (giangVien != null)
                {
                    dgvGiangVien.Rows.Add(false, cm.LecturerID, giangVien.Name, giangVien.Department, cm.Role);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi giá trị trong cột Vai Trò.
        /// </summary>
        private void DgvGiangVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "VaiTro" không
            if (e.RowIndex >= 0 && dgvGiangVien.Columns[e.ColumnIndex].Name == "VaiTro")
            {
                // Lấy giá trị chuỗi từ cột VaiTro
                string vaiTroChuoi = dgvGiangVien.Rows[e.RowIndex].Cells["VaiTro"].Value?.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse<RoleCommitteeMember>(vaiTroChuoi, out var vaiTroChon))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    dgvGiangVien.Rows[e.RowIndex].Cells["VaiTro"].Value = vaiTroChon;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{vaiTroChuoi}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Thêm Giảng Viên.
        /// </summary>
        private async void btnThemGiangVien_Click(object sender, EventArgs e)
        {
            // Mở form thêm Giảng Viên vào Hội Đồng
            var themGiangVienForm = _nhaCungCapDichVu.GetRequiredService<ThemGiangVienVaoHoiDongForm>();
            themGiangVienForm.SetHoiDongID(_hoiDongID);
            if (themGiangVienForm.ShowDialog() == DialogResult.OK)
            {
                // Tải lại dữ liệu Hội Đồng sau khi thêm
                await TaiDuLieuHoiDong();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Xóa Giảng Viên.
        /// </summary>
        private async void btnXoaGiangVien_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các Giảng Viên được chọn để xóa
            var giangVienDuocChon = dgvGiangVien.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Chon"].Value))
                .Select(r => new
                {
                    LecturerID = (Guid)r.Cells["LecturerID"].Value,
                    TenGiangVien = r.Cells["TenGiangVien"].Value.ToString()
                })
                .ToList();

            if (giangVienDuocChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một Giảng Viên để xóa.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa {giangVienDuocChon.Count} Giảng Viên này khỏi Hội Đồng?",
                                         "Xác Nhận Xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                foreach (var giangVien in giangVienDuocChon)
                {
                    try
                    {
                        await _dichVuHoiDong.RemoveLecturerFromCommittee(_hoiDongID, giangVien.LecturerID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Giảng Viên '{giangVien.TenGiangVien}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Giảng Viên đã được xóa thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDuLieuHoiDong();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu.
        /// </summary>
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string tenHoiDong = txtTenHoiDong.Text.Trim();
            DateTime ngayBaoVe = dtpNgayBaoVe.Value.Date;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(tenHoiDong))
            {
                MessageBox.Show("Vui lòng nhập tên Hội Đồng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngayBaoVe < DateTime.Today)
            {
                MessageBox.Show("Ngày bảo vệ không thể ở quá khứ.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng Chủ Tịch và Thư Ký
            var soLuongChuTich = _hoiDong.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.ChuTich);
            var soLuongThuKy = _hoiDong.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.ThuKy);

            if (soLuongChuTich != 1)
            {
                MessageBox.Show("Hội Đồng phải có chính xác một Chủ Tịch.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuongThuKy != 1)
            {
                MessageBox.Show("Hội Đồng phải có chính xác một Thư Ký.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật Hội Đồng
            _hoiDong.Name = tenHoiDong;
            _hoiDong.DefenseDate = ngayBaoVe;

            try
            {
                await _dichVuHoiDong.EditCommittee(_hoiDong);
                MessageBox.Show("Hội Đồng đã được cập nhật thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Hủy.
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
