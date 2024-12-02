using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;
using ThesisManagementSystem.Forms;

namespace ThesisManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly IUserService userService;

        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = await userService.Login(username, password);

                if (user != null)
                {
                    // Set session information
                    UserSession.UserID = user.UserID;
                    UserSession.Username = user.Username;
                    UserSession.Role = user.Role;

                    // Navigate to the corresponding form
                    switch (user.Role)
                    {
                        case Role.Student:
                            var studentForm = Program.HostInstance.Services.GetRequiredService<StudentForm>();
                            studentForm.Show();
                            break;
                        case Role.Lecturer:
                            var lecturerForm = Program.HostInstance.Services.GetRequiredService<LecturerForm>();
                            lecturerForm.Show();
                            break;
                        case Role.Admin:
                            var adminForm = Program.HostInstance.Services.GetRequiredService<AdminForm>();
                            adminForm.Show();
                            break;
                        default:
                            MessageBox.Show("Invalid user role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Log the error if configured
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

