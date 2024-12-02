using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class LecturerForm : Form
    {
        private readonly Guid _lecturerId;
        private readonly ILecturerService _lecturerService;
        private readonly ITopicService _topicService;
        private readonly IStudentGroupService _studentGroups;
        private readonly IMilestoneService _milestoneService;
        private readonly ISubmissionService _submissionService;
        private readonly IEvaluateService _evaluateService;
        private bool isLoading = true;

        public LecturerForm(
            ILecturerService lecturerService,
            ITopicService topicService,
            IStudentGroupService studentGroupService,
            IMilestoneService milestoneService,
            ISubmissionService submissionService,
            IEvaluateService evaluateService)
        {
            _lecturerId = UserSession.UserID;
            _lecturerService = lecturerService;
            _topicService = topicService;
            _evaluateService = evaluateService;
            _studentGroups = studentGroupService;
            _milestoneService = milestoneService;
            _submissionService = submissionService;
            InitializeComponent();
        }

        private async void LecturerForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadLecturerInfo();
            await LoadTopics();
            await LoadCommitteeGroups();
            await LoadGroups();
        }

        private async Task LoadLecturerInfo()
        {
            try
            {
                var lecturer = await _lecturerService.GetLecturerById(_lecturerId);

                if (lecturer != null)
                {
                    lblLecturerName.Text = $"Name: {lecturer.Name}";
                    lblDepartment.Text = $"Department: {lecturer.Department}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading lecturer information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTopics()
        {
            try
            {
                var topics = await _topicService.GetTopicByWhereClause(x => x.LecturerID.Equals(_lecturerId));
                var topicList = topics.Select(tItem => new
                {
                    tItem.TopicID,
                    tItem.Title,
                    tItem.Description,
                    CreatedDate = tItem.CreatedDate.ToLocalTime().ToString("dd/MM/yyyy")
                }).OrderBy(x => DateTime.Parse(x.CreatedDate)).ToList();

                dgvTopics.DataSource = topicList;

                dgvTopics.Columns["TopicID"].Visible = false;
                dgvTopics.Columns["Title"].HeaderText = "Title";
                dgvTopics.Columns["Description"].HeaderText = "Description";
                dgvTopics.Columns["CreatedDate"].HeaderText = "Created Date";

                dgvTopics.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvTopics.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the list of topics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadGroups()
        {
            try
            {
                var groups = await _studentGroups
                    .GetGroupsByWhereClause(x => x.AdvisorID.Equals(UserSession.UserID));

                var groupList = groups.Select(sg => new
                {
                    sg.GroupID,
                    sg.GroupName,
                    Leader = sg.GroupLeader.Name,
                    CreatedDate = sg.CreatedDate.ToLocalTime().ToString("dd/MM/yyyy")
                }).ToList();

                dgvGroups.DataSource = groupList;

                dgvGroups.Columns["GroupID"].Visible = false;
                dgvGroups.Columns["GroupName"].HeaderText = "Group Name";
                dgvGroups.Columns["Leader"].HeaderText = "Group Leader";
                dgvGroups.Columns["CreatedDate"].HeaderText = "Created Date";

                dgvGroups.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvGroups.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the list of groups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadMilestones()
        {
            try
            {
                var milestones = await _milestoneService.GetAllMilestones();
                var milestoneList = milestones.Select(m => new
                {
                    m.MilestoneID,
                    m.Name,
                    Deadline = m.Deadline.ToLocalTime().ToString("dd/MM/yyyy")
                }).ToList();

                dgvMilestones.DataSource = milestoneList;

                dgvMilestones.Columns["MilestoneID"].Visible = false;
                dgvMilestones.Columns["Name"].HeaderText = "Milestone Name";
                dgvMilestones.Columns["Deadline"].HeaderText = "Deadline";

                dgvMilestones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvMilestones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the list of milestones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCommitteeGroups()
        {
            try
            {
                var (isChairman,_) = await _lecturerService.GetChairmanCommitteeAsync(UserSession.UserID);
                var committeeGroups = await _studentGroups.GetGroupsInCommitteeAsync(UserSession.UserID);
                var committeeGroupsList = committeeGroups.Select(g => new
                {
                    g.GroupID,
                    g.GroupName,
                    StudentCount = g.Students.Count,
                    TopicTitle = g.Registration.FirstOrDefault(x => x.Status == RegistrationStatus.Approved)?.Topic.Title ?? "No Approved Topic"
                }).ToList();
                dgvCommitteeGroups.DataSource = committeeGroupsList;
                dgvCommitteeGroups.Columns["GroupID"].Visible = false;
                dgvCommitteeGroups.ClearSelection();
                isLoading = false;
                // Enable or disable the Evaluate Group button based on role
                btnEvaluateGroup.Enabled = isChairman;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading committee groups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSubmissions(Guid groupId)
        {
            try
            {
                var submissions = await _submissionService
                    .GetSubmissionByWhereClause(s => s.Registration.GroupID == groupId)
                    .ContinueWith(t => t.Result.Select(s => new
                    {
                        s.SubmissionID,
                        Milestone = s.Milestone.Name,
                        SubmissionDate = s.SubmissionDate.ToLocalTime().ToString("dd/MM/yyyy"),
                        s.DocumentPath
                    }).ToList());
                if(submissions.Count > 0)
                {
                    dgvSubmissions.DataSource = submissions;

                    dgvSubmissions.Columns["SubmissionID"].Visible = false;
                    dgvSubmissions.Columns["Milestone"].HeaderText = "Milestone";
                    dgvSubmissions.Columns["SubmissionDate"].HeaderText = "Submission Date";
                    dgvSubmissions.Columns["DocumentPath"].HeaderText = "Document Path";

                    dgvSubmissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvSubmissions.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the list of submissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateTopic_Click(object sender, EventArgs e)
        {
            using var createForm = new CreateEditTopicForm(null, _lecturerService, _topicService);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                string title = createForm.TopicTitle;
                string description = createForm.TopicDescription;
                Guid lecturerId = createForm.SelectedLecturerID;

                try
                {
                    bool exists = (await _topicService
                        .GetTopicByWhereClause(x => x.Title.Equals(title)))
                        .Any();

                    if (exists)
                    {
                        MessageBox.Show("A topic with this title already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newTopic = new Topic
                    {
                        LecturerID = lecturerId,
                        Title = title,
                        Description = description,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _topicService.AddAsync(newTopic);

                    MessageBox.Show("Topic created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTopics();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while creating the topic: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task LoadGroupDetails(Guid groupId)
        {
            try
            {
                var groupDetails = await _studentGroups.GetGroupById(groupId);

                if (groupDetails != null)
                {
                    var members = await _studentGroups.GetGroupMembersAsync(groupId);
                    var memberNames = string.Join("\r\n- ", members.Select(m => m.Name));

                    var idTopic = groupDetails.Registration.Count > 0? groupDetails.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).TopicID : Guid.Empty;
                    var topic = (await _topicService.GetTopicByWhereClause(x => x.TopicID.Equals(idTopic))).FirstOrDefault();

                    var submissions = await _submissionService.GetSubmissionByWhereClause(x => x.Registration.GroupID.Equals(groupId));

                    StringBuilder details = new();
                    details.AppendLine($"Group Name: {groupDetails.GroupName}");
                    details.AppendLine($"Group Leader: {groupDetails.GroupLeader?.Name}");
                    details.AppendLine($"Created Date: {groupDetails.CreatedDate.ToShortDateString()}");
                    details.AppendLine();
                    details.AppendLine("Group Members:");
                    details.AppendLine($"- {memberNames}");
                    details.AppendLine();

                    if (topic != null)
                    {
                        details.AppendLine("Topic:");
                        details.AppendLine($"Title: {topic.Title}");
                        details.AppendLine($"Description: {topic.Description}");
                        details.AppendLine($"Supervisor: {topic.Lecturer?.Name}");
                        details.AppendLine();
                    }
                    else
                    {
                        details.AppendLine("Topic: No topic assigned.");
                        details.AppendLine();
                    }

                    details.AppendLine("Submissions:");
                    if (submissions.Any())
                    {
                        foreach (var submission in submissions)
                        {
                            details.AppendLine($"- Milestone: {submission.Milestone.Name}, Submission Date: {submission.SubmissionDate}, Document Path: {submission.DocumentPath}");
                        }
                    }
                    else
                    {
                        details.AppendLine("No submissions found.");
                    }

                    txtGroupDetails.Text = details.ToString();
                }
                else
                {
                    txtGroupDetails.Text = "No group information found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading group details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async void btnEditTopic_Click(object sender, EventArgs e)
        {
            if (dgvTopics.CurrentRow == null)
            {
                MessageBox.Show("Please select a topic to edit.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid topicId = (Guid)dgvTopics.CurrentRow.Cells["TopicID"].Value;
            var selectedTopic = await _topicService.GetTopicbyId(topicId);
            if (selectedTopic == null)
            {
                MessageBox.Show("Could not find the topic information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var editForm = new CreateEditTopicForm(selectedTopic, _lecturerService, _topicService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedTopic.Title = editForm.TopicTitle;
                selectedTopic.Description = editForm.TopicDescription;

                try
                {
                    await _topicService.UpdateAsync(selectedTopic);
                    MessageBox.Show("Topic updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTopics();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the topic: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            if (dgvTopics.CurrentRow == null)
            {
                MessageBox.Show("Please select a topic to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var topicId = (Guid)dgvTopics.CurrentRow.Cells["TopicID"].Value;
            var selectedTopic = await _topicService.GetTopicbyId(topicId);
            if (selectedTopic == null)
            {
                MessageBox.Show("Could not find the topic information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the topic \"{selectedTopic.Title}\"?",
                                                 "Delete Confirmation",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _topicService.DeleteAsync(selectedTopic.TopicID);
                    MessageBox.Show("Topic deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTopics();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the topic: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadTopics();
            await LoadGroups();
            //await LoadCommitteeGroups();
        }
        private async void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                Guid groupId = (Guid)dgvGroups.SelectedRows[0].Cells["GroupID"].Value;
                await LoadMilestones();
                await LoadSubmissions(groupId);
                await LoadGroupDetails(groupId);
            }
            else
            {
                dgvMilestones.DataSource = null;
                dgvSubmissions.DataSource = null;
                txtGroupDetails.Text = string.Empty;
            }
        }
        private async void btnEvaluate_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a group to evaluate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvMilestones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a milestone to evaluate.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid groupId = (Guid)dgvGroups.SelectedRows[0].Cells["GroupID"].Value;
            Guid milestoneId = (Guid)dgvMilestones.SelectedRows[0].Cells["MilestoneID"].Value;

            var group = await _studentGroups.GetGroupById(groupId);

            var registationId = group.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).RegistrationID;

            var existingEvaluation = await _evaluateService.GetEvaluationAsync(groupId, registationId,milestoneId, _lecturerId);
            if (existingEvaluation.Any())
            {
                MessageBox.Show("This milestone has already been evaluated for the selected group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using EvaluateForm evaluateForm = new(group, registationId, milestoneId, _lecturerId, _milestoneService, _evaluateService);
            if (evaluateForm.ShowDialog() == DialogResult.OK)
            {
                await LoadMilestones();
                await LoadSubmissions(groupId);
            }
        }
        private void btnEvaluateGroup_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void dgvCommitteeGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;
            var selectedRow = dgvCommitteeGroups.SelectedRows[0];
            var groupId = (Guid)selectedRow.Cells["GroupID"].Value;

            // Load the details of the selected group
            await LoadGroupDetails(groupId);
        }

    }
}
