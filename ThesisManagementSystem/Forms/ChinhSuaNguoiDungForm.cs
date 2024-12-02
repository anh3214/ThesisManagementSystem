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
    public partial class ChinhSuaNguoiDungForm : Form
    {
        private readonly IUserService _nguoiDungService;
        private Guid _maNguoiDung;
        private User _nguoiDung;

        public ChinhSuaNguoiDungForm(IUserService nguoiDungService)
        {
            InitializeComponent();
            _nguoiDungService = nguoiDungService;
        }

        // Phương thức để thiết lập mã người dùng và tải dữ liệu
        public async void SetMaNguoiDung(Guid maNguoiDung)
        {
            _maNguoiDung = maNguoiDung;
            await TaiDuLieuNguoiDung();
        }

        private void ChinhSuaNguoiDungForm_Load(object sender, EventArgs e)
        {
            // Có thể thiết lập các thuộc tính khác nếu cần
        }

        private async Task TaiDuLieuNguoiDung()
        {
            _nguoiDung = await _nguoiDungService.GetUserById(_maNguoiDung);
            if (_nguoiDung == null)
            {
                MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtTenDangNhap.Text = _nguoiDung.Username;
            cmbVaiTro.SelectedItem = _nguoiDung.Role.ToString();

            // Hiển thị các trường bổ sung dựa trên vai trò
            cmbVaiTro_SelectedIndexChanged(null, null);

            if (_nguoiDung.Role == Role.Lecturer)
            {
                txtHoTen.Text = _nguoiDung.Lecturer?.Name;
                txtKhoa.Text = _nguoiDung.Lecturer?.Department;
            }
            else if (_nguoiDung.Role == Role.Student)
            {
                txtHoTen.Text = _nguoiDung.Student?.Name;
                txtLop.Text = _nguoiDung.Student?.Class;
            }
        }

        private void cmbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vaiTroChon = cmbVaiTro.SelectedItem.ToString();

            // Ẩn tất cả các trường bổ sung trước
            lblHoTen.Visible = false;
            txtHoTen.Visible = false;
            lblKhoa.Visible = false;
            txtKhoa.Visible = false;
            lblLop.Visible = false;
            txtLop.Visible = false;

            if (vaiTroChon == "Giảng viên")
            {
                lblHoTen.Visible = true;
                txtHoTen.Visible = true;
                lblKhoa.Visible = true;
                txtKhoa.Visible = true;
            }
            else if (vaiTroChon == "Sinh viên")
            {
                lblHoTen.Visible = true;
                txtHoTen.Visible = true;
                lblLop.Visible = true;
                txtLop.Visible = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string vaiTro = cmbVaiTro.SelectedItem?.ToString();
            string hoTen = txtHoTen.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            string lop = txtLop.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(vaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thông tin bổ sung dựa trên vai trò
            if ((vaiTro == "Giảng viên" || vaiTro == "Sinh viên") && string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vaiTro == "Giảng viên" && string.IsNullOrEmpty(khoa))
            {
                MessageBox.Show("Vui lòng nhập Khoa cho Giảng viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vaiTro == "Sinh viên" && string.IsNullOrEmpty(lop))
            {
                MessageBox.Show("Vui lòng nhập Lớp cho Sinh viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật thông tin người dùng
            _nguoiDung.Username = tenDangNhap;
            if (!string.IsNullOrEmpty(matKhau))
            {
                _nguoiDung.Password = matKhau; // Nên mã hóa mật khẩu trước khi lưu
            }

            try
            {
                // Gọi service để cập nhật người dùng
                _nguoiDungService.EditUser(_nguoiDung,
                                            hoTen,
                                           vaiTro == "Sinh viên" ? lop : null,
                                           vaiTro == "Giảng viên" ? khoa : null);

                MessageBox.Show("Cập nhật người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có và hiển thị thông báo cho người dùng
                MessageBox.Show($"Lỗi khi cập nhật người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
