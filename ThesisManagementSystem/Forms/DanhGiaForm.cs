using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class DanhGiaForm : Form
    {
        private readonly StudentGroup _nhom;
        private readonly Guid _maDangKy;
        private readonly Guid _maMocThoiGian;
        private readonly Guid _maGiangVien;
        private readonly IMilestoneService _mocThoiGianService;
        private readonly IEvaluateService _danhGiaService;

        public DanhGiaForm(
            StudentGroup nhom,
            Guid maDangKy,
            Guid maMocThoiGian,
            Guid maGiangVien,
            IMilestoneService mocThoiGianService,
            IEvaluateService danhGiaService)
        {
            InitializeComponent();
            _nhom = nhom;
            _maMocThoiGian = maMocThoiGian;
            _maDangKy = maDangKy;
            _maGiangVien = maGiangVien;
            _mocThoiGianService = mocThoiGianService;
            _danhGiaService = danhGiaService;
            TaiChiTietDanhGiaAsync();
        }

        private async void TaiChiTietDanhGiaAsync()
        {
            try
            {
                var moc = await _mocThoiGianService.GetByIdAsync(_maMocThoiGian);

                if (moc != null && _nhom != null)
                {
                    lblTenMocThoiGian.Text = $"Mốc thời gian: {moc.Name}";
                    lblTenNhom.Text = $"Nhóm: {_nhom.GroupName}";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin mốc thời gian hoặc nhóm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đánh giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDiem.Text.Trim(), out int diem))
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var danhGia = new Evaluation
                {
                    RegistrationID = _maDangKy,
                    EvaluatorID = _maGiangVien,
                    Score = diem,
                    MilestoneId = _maMocThoiGian,
                    Comments = txtNhanXet.Text.Trim(),
                    EvaluationDate = DateTime.UtcNow
                };

                await _danhGiaService.AddAsync(danhGia);

                MessageBox.Show("Đánh giá thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đánh giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
