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
    public partial class EditUserForm : Form
    {
        private readonly IUserService _userService;
        private Guid _userID;
        private User _user;

        public EditUserForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        // Phương thức để thiết lập UserID và tải dữ liệu người dùng
        public async void SetUserID(Guid userID)
        {
            _userID = userID;
            await LoadUserData();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            // Có thể thiết lập các thuộc tính khác nếu cần
        }

        private async Task LoadUserData()
        {
            _user = await _userService.GetUserById(_userID);
            if (_user == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtUsername.Text = _user.Username;
            cmbRole.SelectedItem = _user.Role.ToString();

            // Hiển thị các trường bổ sung dựa trên vai trò
            cmbRole_SelectedIndexChanged(null, null);

            if (_user.Role == Role.Lecturer)
            {
                txtName.Text = _user.Lecturer?.Name; // Sửa dòng này để lấy Name từ Lecturer
                txtDepartment.Text = _user.Lecturer?.Department;
            }
            else if (_user.Role == Role.Student)
            {
                txtName.Text = _user.Student?.Name; // Sửa dòng này để lấy Name từ Student
                txtClass.Text = _user.Student?.Class;
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem.ToString();

            // Ẩn tất cả các trường bổ sung trước
            lblName.Visible = false;
            txtName.Visible = false;
            lblDepartment.Visible = false;
            txtDepartment.Visible = false;
            lblClass.Visible = false;
            txtClass.Visible = false;

            if (selectedRole == "Lecturer")
            {
                lblName.Visible = true;
                txtName.Visible = true;
                lblDepartment.Visible = true;
                txtDepartment.Visible = true;
            }
            else if (selectedRole == "Student")
            {
                lblName.Visible = true;
                txtName.Visible = true;
                lblClass.Visible = true;
                txtClass.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();
            string name = txtName.Text.Trim(); // Thêm dòng này để lấy giá trị từ TextBox Name
            string department = txtDepartment.Text.Trim();
            string className = txtClass.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(username) ||
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

            // Cập nhật đối tượng User
            _user.Username = username;
            if (!string.IsNullOrEmpty(password))
            {
                _user.Password = password; // Nên mã hóa mật khẩu trước khi lưu
            }

            try
            {
                // Gọi service để cập nhật người dùng
                _userService.EditUser(_user,
                                      name: name, // Truyền Name vào
                                      className: role == "Student" ? className : null,
                                      department: role == "Lecturer" ? department : null);

                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có và hiển thị thông báo cho người dùng
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
