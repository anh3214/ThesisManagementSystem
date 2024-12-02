// EditGroupForm.cs
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class EditGroupForm : Form
    {
        private readonly IStudentGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ICommitteeService _committeeService;
        private readonly IDefenseScoreService _defenseScoreService;
        private Guid _groupID;

        public EditGroupForm(
            IStudentGroupService groupService, 
            IUserService userService, 
            ICommitteeService committeeService,
            IDefenseScoreService defenseScoreService)
        {
            InitializeComponent();
            _groupService = groupService;
            _userService = userService;
            _committeeService = committeeService;
            _defenseScoreService = defenseScoreService;
        }

        // Phương thức để thiết lập GroupID và tải thông tin nhóm
        public async void SetGroupID(Guid groupID)
        {
            _groupID = groupID;
            await LoadGroupDetails();
        }

        // Phương thức để tải thông tin nhóm vào các điều khiển trên form
        private async Task LoadGroupDetails()
        {
            try
            {
                var group = await _groupService.GetGroupById(_groupID);
                if (group != null)
                {
                    txtGroupName.Text = group.GroupName;

                    // Load Advisor vào ComboBox
                    var advisors = await _userService.GetAllLecturers();
                    cmbAdvisors.DataSource = advisors;
                    cmbAdvisors.DisplayMember = "Name";
                    cmbAdvisors.ValueMember = "LecturerID";
                    cmbAdvisors.SelectedValue = group.AdvisorID != null ? group.AdvisorID : Guid.Empty;

                    // Load Committees vào ComboBox
                    var committees = await _committeeService.GetAllCommitteesWithLecturers();
                    cmbCommittees.DataSource = committees;
                    cmbCommittees.DisplayMember = "Name";
                    cmbCommittees.ValueMember = "CommitteeID";
                    cmbCommittees.SelectedValue = group.CommiteID != null ? group.CommiteID : Guid.Empty;
                }
                else
                {
                    MessageBox.Show("Group not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading group details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        // Sự kiện Click cho nút Save
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var groupName = txtGroupName.Text.Trim();
            var selectedAdvisorID = cmbAdvisors.SelectedValue as Guid?;
            var selectedCommitteeID = cmbCommittees.SelectedValue as Guid?;
            var defenseDate = dtpDefenseDate.Value;

            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Group name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var group = await _groupService.GetGroupById(_groupID);
                if (group != null)
                {
                    group.GroupName = groupName;
                    
                    group.AdvisorID = selectedAdvisorID ?? Guid.Empty;
                    group.CommiteID = selectedCommitteeID ?? Guid.Empty;
                    if (group.Registration.Count != 0)
                    {
                        var idRegitation = group.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).RegistrationID;
                        var defense = new Defense()
                        {
                            RegistrationID = idRegitation,
                            CommitteeID = selectedCommitteeID ?? Guid.Empty,
                            DefenseDate = defenseDate
                        };
                        var (ishasDefes, idDefense) = await _defenseScoreService.CheckHaveDefense(idRegitation);
                        if (ishasDefes)
                        {
                            defense.DefenseID = idDefense;
                            await _defenseScoreService.Update(defense);
                        }
                        else
                            await _defenseScoreService.AddSync(defense);
                    }
                    
                    await _groupService.UpdateGroup(group);
                    MessageBox.Show("Group updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Group not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating group: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện Click cho nút Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
