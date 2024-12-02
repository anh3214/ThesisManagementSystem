using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.BLL.Services;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class StudentForm : Form
    {
        private readonly Guid _studentId;
        private readonly IStudentService _studentService;
        private readonly IStudentGroupService _studentGroupService;
        private readonly IRegistrationService _registrationService;
        private readonly ITopicService _topicService;
        private readonly IMilestoneService _milestoneService;
        private readonly IEvaluateService _evaluateService;
        private readonly ISubmissionService _submissionService;
        private readonly IDefenseScoreService _defenseScoreService;

        public StudentForm(
            IStudentService studentService,
            IStudentGroupService studentGroupService,
            IRegistrationService registrationService,
            ITopicService topicService,
            IMilestoneService milestoneService,
            ISubmissionService submissionService,
            IEvaluateService evaluateService,
            IDefenseScoreService defenseScoreService)
        {
            InitializeComponent();
            _studentId = UserSession.UserID;
            _studentService = studentService;
            _submissionService = submissionService;
            _milestoneService = milestoneService;
            _studentGroupService = studentGroupService;
            _registrationService = registrationService;
            _topicService = topicService;
            _evaluateService = evaluateService;
            _defenseScoreService = defenseScoreService;
        }

        private async void StudentForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            await SetButtonVisibilityAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await LoadStudentInfo();
                await LoadGroupInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadResults(Guid registationID)
        {
            var results = await _evaluateService.FindAsync(x => x.RegistrationID.Equals(registationID));
            // Chuyển đổi dữ liệu Evaluation vào dgvResults
            dgvResults.Rows.Clear();

            foreach (var eval in results)
            {
                dgvResults.Rows.Add(
                    "Evaluation",
                    eval.Score,
                    0m, // Điểm dự án không áp dụng cho Evaluation
                    eval.Comments,
                    eval.EvaluationDate.ToString("dd/MM/yyyy"),
                    eval.Evaluator.Name,
                    eval.Role
                );
            }

            // Chuyển đổi dữ liệu DefenseScore vào dgvDefenseScores
            var defense = await _defenseScoreService.GetScore(registationID);
            dgvDefenseScores.Rows.Clear();
            if (defense != null)
            {
                foreach (var ds in defense.DefenseScores)
                {
                    dgvDefenseScores.Rows.Add(
                        "Project Defense",
                        ds.Score,
                        ds.Comments
                    );
                }
            }
        }

        private async Task LoadStudentInfo()
        {
            // Load student information from the database (assuming there is a StudentService)
            var student = await _studentService.GetStudentById(_studentId);
            lblName.Text = $"Name: {student.Name}";
            lblClass.Text = $"Class: {student.Class}";
        }

        private async Task LoadGroupInfo()
        {
            var student = await _studentService.GetStudentById(_studentId);
            if (student.GroupID != null)
            {
                // If already in a group
                var group = await _studentGroupService.GetGroupById(student.GroupID.Value);
                if (group != null)
                {
                    txtGroupName.Text = group.GroupName;
                    txtGroupName.ReadOnly = true;
                    btnCreateGroup.Enabled = false;
                    if (group.Registration.Count != 0)
                    {
                        dgvAvailableTopics.DataSource = group.Registration.Select(s => new
                        {
                            s.TopicID,
                            s.Topic.Title,
                            s.Status,
                            s.Topic.Description,
                            s.RegistrationDate
                        }).ToList();

                        dgvAvailableTopics.Columns["TopicID"].Visible = false;
                        var idRegistion = group.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).RegistrationID;
                        await LoadResults(idRegistion);
                        var submissions = await _submissionService.GetSubmissionByWhereClause(x => x.RegistrationID.Equals(idRegistion));
                        dgvMilestones.DataSource = submissions.Select(s => new
                        {
                            s.SubmissionID,
                            s.RegistrationID,
                            MilestoneName = s.Milestone.Name,
                            s.SubmissionDate,
                            s.DocumentPath
                        }).ToList();

                        dgvMilestones.Columns["SubmissionID"].Visible = false;
                        dgvMilestones.Columns["RegistrationID"].Visible = false;
                    }
                    else
                        dgvAvailableTopics.DataSource = null;
                    // Display group members
                    dgvGroupMembers.DataSource = group.Students.Select(s => new
                    {
                        StudentName = s.Name,
                        Class = s.Class,
                    }).ToList();

                }
            }
            else
            {
                // If not in a group
                txtGroupName.ReadOnly = false;
                btnCreateGroup.Enabled = true;
                dgvGroupMembers.DataSource = null;
            }
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            var groupName = txtGroupName.Text;
            if (!string.IsNullOrEmpty(groupName))
            {
                var newGroup = new StudentGroup
                {
                    GroupID = Guid.NewGuid(),
                    GroupName = groupName,
                    CreatedDate = DateTime.Now,
                    GroupLeaderID = _studentId
                };

                await _studentGroupService.AddGroup(newGroup);

                var student = await _studentService.GetStudentById(_studentId);
                if (student != null)
                {
                    student.GroupID = newGroup.GroupID;
                    await _studentService.Update(student);
                }

                await LoadGroupInfo();
            }
            else
            {
                MessageBox.Show("Please enter a group name.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAddMember_Click(object sender, EventArgs e)
        {
            // Get information from TextBox
            var studentIdInput = txtStudentToAdd.Text;

            if (!string.IsNullOrEmpty(studentIdInput))
            {
                // Find student by ID or name
                var student = await _studentService.GetByStudentIdOrName(studentIdInput);

                if (student != null)
                {
                    // Check if the student is already in a group
                    if (student.GroupID == null || student.GroupID.Equals(Guid.Empty))
                    {
                        // Update the student's GroupID to add to the current group
                        student.GroupID = await _studentGroupService.GetGroupByLeaderId(_studentId);

                        if (student.GroupID.HasValue)
                        {
                            await _studentService.Update(student);
                            MessageBox.Show("Member has been added to the group.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadGroupInfo(); // Reload group information
                        }
                        else
                        {
                            MessageBox.Show("Group not found to add member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This student is already in another group.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Student not found with the entered information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter the student ID or name.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnRegisterTopic_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the student's group
                var (isLeader, groupID) = await _studentGroupService.IsLeaderAsync(_studentId);

                if (!isLeader)
                {
                    MessageBox.Show("You are not leader.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var group = await _studentGroupService.GetGroupById(groupID);
                // Check if the group has already registered a topic
                var existingRegistration = group.Registration;
                if (existingRegistration != null && existingRegistration.Any(x => x.Status.Equals(RegistrationStatus.Approved)))
                {
                    MessageBox.Show("Your group has already registered a topic.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Get the list of available topics
                var registeredTopicIds = existingRegistration?.Select(r => r.TopicID).ToList() ?? new List<Guid>();
                var availableTheses = await _topicService.GetTopicByWhereClause(
                    x => !registeredTopicIds.Contains(x.TopicID) && x.LecturerID.Equals(group.AdvisorID),
                    nameof(Topic.Lecturer)
                );
                if (!availableTheses.Any())
                {
                    MessageBox.Show("There are currently no topics available for registration.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Display the list of topics in a new Form to select
                var selectThesisForm = new SelectThesisForm(availableTheses);
                if (selectThesisForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedThesis = selectThesisForm.SelectedThesis;
                    if (selectedThesis != null)
                    {
                        // Register the topic for the group
                        await _registrationService.RegisterThesisForGroupAsync(group.GroupID, selectedThesis.TopicID);
                        MessageBox.Show("Topic registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update group information to display the registered topic
                        await LoadDataAsync();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while registering topic: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubmitDocument_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the student's group
                var (isLeader, groupID) = await _studentGroupService.IsLeaderAsync(_studentId);

                if (!isLeader)
                {
                    MessageBox.Show("You are not leader.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var group = await _studentGroupService.GetGroupById(groupID);
                var registration = group.Registration.FirstOrDefault(r => r.Status == RegistrationStatus.Approved);

                if (registration == null)
                {
                    MessageBox.Show("Your group has not registered a topic yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Open the SubmitDocumentForm
                var submitDocumentForm = new SubmitDocumentForm(registration.RegistrationID, _milestoneService, _submissionService);
                submitDocumentForm.ShowDialog();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while submitting document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {
            if (dgvMilestones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a submission to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assuming the first selected row
            var selectedRow = dgvMilestones.SelectedRows[0];
            string currentDocumentPath = selectedRow.Cells["DocumentPath"].Value.ToString();

            using (EditDocumentForm editForm = new EditDocumentForm(currentDocumentPath))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    string newDocumentPath = editForm.NewDocumentPath;

                    // Update the document path in the DataGridView
                    selectedRow.Cells["DocumentPath"].Value = newDocumentPath;

                    UpdateSubmissionDocument((Guid)selectedRow.Cells["SubmissionID"].Value, newDocumentPath);

                    MessageBox.Show("Document updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void UpdateSubmissionDocument(Guid submissionId, string newDocumentPath)
        {
            try
            {
                // Retrieve the submission by its ID
                var submissions = await _submissionService.GetSubmissionByWhereClause(s => s.SubmissionID == submissionId);
                var submission = submissions.FirstOrDefault();

                if (submission == null)
                {
                    MessageBox.Show("Submission not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the document path
                submission.DocumentPath = newDocumentPath;

                // Save the changes
                await _submissionService.UpdateSubmissionAsync(submission);

                MessageBox.Show("Document updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SetButtonVisibilityAsync()
        {
            var (isLeader, _) = await _studentGroupService.IsLeaderAsync(_studentId);
            btnEditDocument.Visible = isLeader;
            btnAddMember.Visible = isLeader;
            btnRegisterTopic.Visible = isLeader;
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
    }
}
