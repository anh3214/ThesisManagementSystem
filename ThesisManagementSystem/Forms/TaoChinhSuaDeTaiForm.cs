using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class TaoChinhSuaDeTaiForm : Form
    {
        private readonly ILecturerService _giangVienService;
        private readonly ITopicService _deTaiService;
        private readonly Topic _deTaiHienTai;
        private readonly bool _cheDoChinhSua;

        public string TieuDeDeTai { get; private set; }
        public string MoTaDeTai { get; private set; }
        public Guid MaGiangVien { get; private set; }

        public TaoChinhSuaDeTaiForm(Topic deTai, ILecturerService giangVienService, ITopicService deTaiService)
        {
            InitializeComponent();
            _giangVienService = giangVienService;
            _deTaiService = deTaiService;
            _deTaiHienTai = deTai;
            _cheDoChinhSua = deTai != null;
            TaiDanhSachGiangVienAsync();
        }

        private async void TaiDanhSachGiangVienAsync()
        {
            try
            {
                var giangViens = await _giangVienService.GetAllLecturers();
                cmbGiangVien.DataSource = giangViens.Select(gv => new
                {
                    gv.LecturerID,
                    HoTen = gv.Name // Giả sử Lecturer có thuộc tính Name
                }).ToList();
                cmbGiangVien.DisplayMember = "HoTen";
                cmbGiangVien.ValueMember = "LecturerID";

                if (_cheDoChinhSua)
                {
                    if (_deTaiHienTai != null)
                        cmbGiangVien.SelectedValue = _deTaiHienTai.LecturerID;
                    this.Text = "Chỉnh sửa Đề tài";
                    txtTieuDe.Text = _deTaiHienTai.Title;
                    txtMoTa.Text = _deTaiHienTai.Description;
                    cmbGiangVien.SelectedValue = _deTaiHienTai.LecturerID;

                    // Ẩn ComboBox và hiển thị Label
                    cmbGiangVien.Visible = false;
                    lblHienThiGiangVien.Visible = true;

                    // Lấy tên giảng viên hiện tại
                    var giangVien = await _giangVienService.GetLecturerById(_deTaiHienTai.LecturerID);
                    lblHienThiGiangVien.Text = $"Giảng viên phụ trách: {giangVien?.Name ?? "Không xác định"}";
                }
                else
                {
                    this.Text = "Thêm Đề tài";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách giảng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề của đề tài.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_cheDoChinhSua && cmbGiangVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giảng viên phụ trách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu
            TieuDeDeTai = txtTieuDe.Text.Trim();
            MoTaDeTai = txtMoTa.Text.Trim();

            if (!_cheDoChinhSua)
            {
                MaGiangVien = (Guid)cmbGiangVien.SelectedValue;
            }
            else
            {
                // Không thay đổi LecturerID trong chế độ chỉnh sửa
                MaGiangVien = _deTaiHienTai.LecturerID;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
