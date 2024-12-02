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
    public partial class CreateUserForm : Form
    {
        private readonly IUserService _userService;

        public CreateUserForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem.ToString();

            // Ẩn tất cả các trường bổ sung trước
            lblDepartment.Visible = false;
            txtDepartment.Visible = false;
            lblName.Visible = true;
            txtName.Visible = true;
            lblClass.Visible = false;
            txtClass.Visible = false;
            txtMSSV.Visible = false;

            if (selectedRole == "Lecturer")
            {
                lblDepartment.Visible = true;
                txtDepartment.Visible = true;
            }
            else if (selectedRole == "Student")
            {
                lblClass.Visible = true;
                txtClass.Visible = true;
                txtMSSV.Visible = true;
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();
            string name = txtName.Text.Trim(); // Thêm dòng này để lấy giá trị từ TextBox Name
            string department = txtDepartment.Text.Trim();
            string className = txtClass.Text.Trim();
            string msvv = txtMSSV.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thông tin bổ sung dựa trên vai trò
            if ((role == "Lecturer" || role == "Student") && string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == "Lecturer" && string.IsNullOrEmpty(department))
            {
                MessageBox.Show("Please enter Department for Lecturer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == "Student" && string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Please enter Class for Student.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng User mới
            var newUser = new User
            {
                UserID = Guid.NewGuid(),
                Username = username,
                Password = password, // Nên mã hóa mật khẩu trước khi lưu
                Role = Enum.Parse<Role>(role)
            };

            try
            {
                // Gọi service để thêm người dùng
                await _userService.Register(newUser,
                                      name: name, // Truyền Name vào
                                      classValue: role == "Student" ? className : null,
                                      department: role == "Lecturer" ? department : null,
                                      msvv);

                MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có và hiển thị thông báo cho người dùng
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
