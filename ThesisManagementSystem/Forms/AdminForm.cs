using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
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
    public partial class AdminForm : Form
    {
        private readonly IUserService _userService;
        private readonly IMilestoneService _milestoneService;
        private readonly ICommitteeService _committeeService;
        private readonly IRegistrationService _registrationService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IStudentGroupService _groupService;

        public AdminForm(
            IUserService userService,
            IMilestoneService milestoneService,
            ICommitteeService committeeService,
            IRegistrationService registrationService,
            IServiceProvider serviceProvider,
            IStudentGroupService studentGroupService)
        {
            InitializeComponent();
            _userService = userService;
            _milestoneService = milestoneService;
            _committeeService = committeeService;
            _registrationService = registrationService;
            _serviceProvider = serviceProvider;
            _groupService = studentGroupService;
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            await LoadUsers();
            await LoadMilestones();
            await LoadCommittees();
            await LoadRegistrations();
            await LoadGroups();
        }

        #region Load Data Methods

        private async Task LoadUsers()
        {
            var users = await _userService.GetAllUsersWithRoles();
            dgvUsers.DataSource = users.Where(x => !x.UserID.Equals(UserSession.UserID)).Select(u => new
            {
                u.UserID,
                u.Username,
                Role = u.Role.ToString(),
                Name = u.Role == Role.Student ? u.Student?.Name : u.Role == Role.Lecturer ? u.Lecturer?.Name : "N/A",
                AdditionalInfo = u.Role == Role.Student ? u.Student?.Class : u.Role == Role.Lecturer ? u.Lecturer?.Department : "N/A"
            }).ToList();
        }
        private async Task LoadGroups()
        {
            var groups = await _groupService.GetAllGroups();
            dgvGroups.DataSource = groups.Select(g => new
            {
                g.GroupID,
                g.GroupName,
                AdvisorName = g.Advisor?.Name ?? "N/A",
                CommitteeName = g.Committee?.Name ?? "N/A",
                LeaderName = g.GroupLeader?.User?.Username ?? "N/A",
                CreatedDate = g.CreatedDate.ToString("dd/MM/yyyy")
            }).ToList();
            dgvGroups.Columns["GroupID"].Visible = false;
        }
        private async Task LoadMilestones()
        {
            var milestones = await _milestoneService.GetAllMilestones();
            dgvMilestones.DataSource = milestones.Select(m => new
            {
                m.MilestoneID,
                m.Name,
                m.Description,
                m.Deadline
            }).ToList();
        }

        private async Task LoadCommittees()
        {
            var committees = await _committeeService.GetAllCommitteesWithLecturers();
            dgvCommittees.DataSource = committees.Select(c => new
            {
                c.CommitteeID,
                c.Name,
                DefenseDate = c.DefenseDate.ToString("dd/MM/yyyy"),
                Lecturers = string.Join(", ", c.CommitteeMembers.Select(cm => cm.Lecturer.Name + $" ({cm.Role})"))
            }).ToList();

            dgvCommittees.Columns["CommitteeID"].Visible = false;
        }

        private async Task LoadRegistrations()
        {
            var registrations = await _registrationService.GetAllRegistrationsWithGroupAndGroupLeaderAndUser();
            dgvRegistrations.DataSource = registrations.Select(r => new
            {
                r.RegistrationID,
                Username = r.Group?.GroupLeader?.User?.Username,
                Role = r.Group?.GroupLeader?.User?.Role.ToString(),
                Status = r.Status.ToString(),
                RegistrationDate = r.RegistrationDate.ToString("dd/MM/yyyy")
            }).ToList();
            dgvRegistrations.Columns["RegistrationID"].Visible = false;
        }

        #endregion

        #region Button Click Events

        private async void btnCreateCommittee_Click(object sender, EventArgs e)
        {
            var createCommitteeForm = _serviceProvider.GetRequiredService<CreateCommitteeForm>();
            if (createCommitteeForm.ShowDialog() == DialogResult.OK)
            {
                await LoadCommittees();
            }
        }

        private async void btnEditCommittee_Click(object sender, EventArgs e)
        {
            if (dgvCommittees.CurrentRow == null)
            {
                MessageBox.Show("Please select a committee to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCommitteeID = (Guid)dgvCommittees.CurrentRow.Cells["CommitteeID"].Value;
            var editCommitteeForm = _serviceProvider.GetRequiredService<EditCommitteeForm>();
            editCommitteeForm.SetCommitteeID(selectedCommitteeID);

            if (editCommitteeForm.ShowDialog() == DialogResult.OK)
            {
                await LoadCommittees();
            }
        }

        private async void btnUpdateRegistrationStatus_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null)
            {
                MessageBox.Show("Please select a registration.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var registrationID = (Guid)dgvRegistrations.CurrentRow.Cells["RegistrationID"].Value;
            var currentStatus = dgvRegistrations.CurrentRow.Cells["Status"].Value.ToString();

            var statusForm = new UpdateStatusForm();
            statusForm.SetUp(currentStatus);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                var newStatus = statusForm.SelectedStatus;
                try
                {
                    await _registrationService.UpdateRegistrationStatus(registrationID, newStatus);
                    MessageBox.Show("Registration status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadRegistrations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating registration status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            var createUserForm = _serviceProvider.GetRequiredService<CreateUserForm>();
            if (createUserForm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsers();
            }
        }

        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUserID = (Guid)dgvUsers.CurrentRow.Cells["UserID"].Value;
            var editUserForm = _serviceProvider.GetRequiredService<EditUserForm>();
            editUserForm.SetUserID(selectedUserID);

            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsers();
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUserID = (Guid)dgvUsers.CurrentRow.Cells["UserID"].Value;
            var selectedUsername = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();

            var confirmResult = MessageBox.Show($"Are you sure to delete user '{selectedUsername}'?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _userService.DeleteUser(selectedUserID);
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Handle logout logic here
            UserSession.Logout();
            this.Close();
            var userService = Program.HostInstance.Services.GetRequiredService<IUserService>();
            var loginForm = new LoginForm(userService);
            loginForm.Show();
        }

        private async void btnCreateMilestone_Click(object sender, EventArgs e)
        {
            var createMilestoneForm = _serviceProvider.GetRequiredService<CreateMilestoneForm>();
            if (createMilestoneForm.ShowDialog() == DialogResult.OK)
            {
                var newMilestone = createMilestoneForm.NewMilestone;
                await _milestoneService.CreateMilestone(newMilestone);
                await LoadMilestones();
            }
        }

        private async void btnEditMilestone_Click(object sender, EventArgs e)
        {
            if (dgvMilestones.CurrentRow == null)
            {
                MessageBox.Show("Please select a milestone to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMilestoneID = (Guid)dgvMilestones.CurrentRow.Cells["MilestoneID"].Value;
            var selectedMilestone = await _milestoneService.GetByIdAsync(selectedMilestoneID);

            var editMilestoneForm = new EditMilestoneForm();
            editMilestoneForm.SetUpMilestone(selectedMilestone);

            if (editMilestoneForm.ShowDialog() == DialogResult.OK)
            {
                var editedMilestone = editMilestoneForm.EditedMilestone;
                await _milestoneService.UpdateMilestone(editedMilestone);
                await LoadMilestones();
            }
        }

        private async void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null)
            {
                MessageBox.Show("Please select a group to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedGroupID = (Guid)dgvGroups.CurrentRow.Cells["GroupID"].Value;
            var editGroupForm = _serviceProvider.GetRequiredService<EditGroupForm>();
            editGroupForm.SetGroupID(selectedGroupID);

            if (editGroupForm.ShowDialog() == DialogResult.OK)
            {
                await LoadGroups();
            }
        }
        #endregion
    }
}
