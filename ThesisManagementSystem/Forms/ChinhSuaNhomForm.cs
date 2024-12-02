using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class ChinhSuaNhomForm : Form
    {
        private readonly IStudentGroupService _nhomSinhVienService;
        private readonly IUserService _giangVienService;
        private readonly ICommitteeService _hoiDongService;
        private readonly IDefenseScoreService _baoVeService;
        private Guid _maNhom;

        public ChinhSuaNhomForm(
            IStudentGroupService nhomSinhVienService,
            IUserService giangVienService,
            ICommitteeService hoiDongService,
            IDefenseScoreService baoVeService)
        {
            InitializeComponent();
            _nhomSinhVienService = nhomSinhVienService;
            _giangVienService = giangVienService;
            _hoiDongService = hoiDongService;
            _baoVeService = baoVeService;
        }

        public async void SetMaNhom(Guid maNhom)
        {
            _maNhom = maNhom;
            await TaiChiTietNhom();
        }

        private async Task TaiChiTietNhom()
        {
            try
            {
                var nhom = await _nhomSinhVienService.GetGroupById(_maNhom);
                if (nhom != null)
                {
                    txtTenNhom.Text = nhom.GroupName;

                    var giangViens = await _giangVienService.GetAllLecturers();
                    cmbGiangVien.DataSource = giangViens;
                    cmbGiangVien.DisplayMember = "Name";
                    cmbGiangVien.ValueMember = "LecturerID";
                    cmbGiangVien.SelectedValue = nhom.AdvisorID ?? Guid.Empty;

                    var hoiDongs = await _hoiDongService.GetAllCommitteesWithLecturers();
                    cmbHoiDong.DataSource = hoiDongs;
                    cmbHoiDong.DisplayMember = "Name";
                    cmbHoiDong.ValueMember = "CommitteeID";
                    cmbHoiDong.SelectedValue = nhom.CommiteID ?? Guid.Empty;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhóm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNhom = txtTenNhom.Text.Trim();
            Guid? maGiangVien = cmbGiangVien.SelectedValue as Guid?;
            Guid? maHoiDong = cmbHoiDong.SelectedValue as Guid?;
            DateTime ngayBaoVe = dtpNgayBaoVe.Value;

            if (string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Tên nhóm không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nhom = await _nhomSinhVienService.GetGroupById(_maNhom);
                if (nhom != null)
                {
                    nhom.GroupName = tenNhom;
                    nhom.AdvisorID = maGiangVien ?? Guid.Empty;
                    nhom.CommiteID = maHoiDong ?? Guid.Empty;

                    if (nhom.Registration.Count > 0)
                    {
                        var idDangKy = nhom.Registration.First(x => x.Status == RegistrationStatus.Approved).RegistrationID;
                        var baoVe = new Defense
                        {
                            RegistrationID = idDangKy,
                            CommitteeID = maHoiDong ?? Guid.Empty,
                            DefenseDate = ngayBaoVe
                        };

                        var (coBaoVe, baove) = await _baoVeService.CheckHaveDefense(idDangKy);
                        if (coBaoVe)
                        {
                            baove.RegistrationID = idDangKy;
                            baove.CommitteeID = maHoiDong ?? Guid.Empty;
                            baove.DefenseDate = ngayBaoVe;

                            await _baoVeService.Update(baove);
                        }
                        else
                        {
                            await _baoVeService.AddSync(baoVe);
                        }
                    }

                    await _nhomSinhVienService.UpdateGroup(nhom);
                    MessageBox.Show("Cập nhật nhóm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhóm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
