using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;
using ThesisManagementSystem.Forms;

namespace ThesisManagementSystem
{
    public partial class DangNhapForm : Form
    {
        private readonly IUserService _nguoiDungService;

        public DangNhapForm(IUserService nguoiDungService)
        {
            InitializeComponent();
            _nguoiDungService = nguoiDungService;
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nguoiDung = await _nguoiDungService.Login(tenDangNhap, matKhau);

                if (nguoiDung != null)
                {
                    // Cài đặt thông tin phiên đăng nhập
                    UserSession.UserID = nguoiDung.UserID;
                    UserSession.Username = nguoiDung.Username;
                    UserSession.Role = nguoiDung.Role;

                    // Điều hướng đến giao diện phù hợp
                    switch (nguoiDung.Role)
                    {
                        case Role.Student:
                            var formSinhVien = Program.HostInstance.Services.GetRequiredService<SinhVienForm>();
                            formSinhVien.Show();
                            break;
                        case Role.Lecturer:
                            var formGiangVien = Program.HostInstance.Services.GetRequiredService<GiangVienForm>();
                            formGiangVien.Show();
                            break;
                        case Role.Admin:
                            var formAdmin = Program.HostInstance.Services.GetRequiredService<QuanLyAdminForm>();
                            formAdmin.Show();
                            break;
                        default:
                            MessageBox.Show("Quyền người dùng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
