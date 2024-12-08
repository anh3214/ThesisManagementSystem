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
    public partial class TaoNguoiDungForm : Form
    {
        private readonly IUserService _userService;

        public TaoNguoiDungForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void cmbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vaiTroDuocChon = cmbVaiTro.SelectedItem.ToString();

            // Ẩn tất cả các trường bổ sung trước
            lblBoMon.Visible = false;
            txtBoMon.Visible = false;
            lblHoTen.Visible = true;
            txtHoTen.Visible = true;
            lblLop.Visible = false;
            txtLop.Visible = false;
            txtMSSV.Visible = false;

            if (vaiTroDuocChon == "Giảng viên")
            {
                lblBoMon.Visible = true;
                txtBoMon.Visible = true;
            }
            else if (vaiTroDuocChon == "Sinh viên")
            {
                lblLop.Visible = true;
                txtLop.Visible = true;
                lblMSSV.Visible = true;
                txtMSSV.Visible = true;
            }
        }

        private async void btnTaoMoi_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string vaiTro = cmbVaiTro.SelectedItem?.ToString();
            string hoTen = txtHoTen.Text.Trim();
            string boMon = txtBoMon.Text.Trim();
            string lop = txtLop.Text.Trim();
            string mssv = txtMSSV.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenDangNhap) ||
                string.IsNullOrEmpty(matKhau) ||
                string.IsNullOrEmpty(vaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thông tin bổ sung dựa trên vai trò
            if ((vaiTro == "Giảng viên" || vaiTro == "Sinh viên") && string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vaiTro == "Giảng viên" && string.IsNullOrEmpty(boMon))
            {
                MessageBox.Show("Vui lòng nhập Bộ môn cho Giảng viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vaiTro == "Sinh viên" && string.IsNullOrEmpty(lop))
            {
                MessageBox.Show("Vui lòng nhập Lớp cho Sinh viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Tạo đối tượng User mới
            var nguoiDungMoi = new User
            {
                UserID = Guid.NewGuid(),
                Username = tenDangNhap,
                Password = matKhau, // Nên mã hóa mật khẩu trước khi lưu
                Role = vaiTro switch
                    {
                        "Sinh viên" => Role.Student,
                        "Giảng viên" => Role.Lecturer,
                        "Admin" => Role.Admin,
                        _ => throw new InvalidOperationException("Vai trò không hợp lệ.")
                    }
            };

            try
            {
                // Gọi service để thêm người dùng
                await _userService.Register(nguoiDungMoi,
                                      name: hoTen,
                                      classValue: vaiTro == "Sinh viên" ? lop : null,
                                      department: vaiTro == "Giảng viên" ? boMon : null,
                                      mssv);

                MessageBox.Show("Tạo người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có và hiển thị thông báo cho người dùng
                MessageBox.Show($"Lỗi khi tạo người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
