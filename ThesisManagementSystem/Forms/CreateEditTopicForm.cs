using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class CreateEditTopicForm : Form
    {
        private readonly ILecturerService _lecturerService;
        private readonly ITopicService _topicService;
        private readonly Topic _existingTopic;
        private readonly bool _isEditMode;

        public string TopicTitle { get; private set; }
        public string TopicDescription { get; private set; }
        public Guid SelectedLecturerID { get; private set; }

        public CreateEditTopicForm(Topic topic, ILecturerService lecturerService, ITopicService topicService)
        {
            InitializeComponent();
            _lecturerService = lecturerService;
            _topicService = topicService;
            _existingTopic = topic;
            _isEditMode = topic != null;
            LoadLecturersAsync();
        }

        private async void LoadLecturersAsync()
        {
            try
            {
                var lecturers = await _lecturerService.GetAllLecturers();
                cmbLecturers.DataSource = lecturers.Select(l => new
                {
                    l.LecturerID,
                    FullName = l.Name // Assuming Lecturer has a Name property
                }).ToList();
                cmbLecturers.DisplayMember = "FullName";
                cmbLecturers.ValueMember = "LecturerID";

                if (_isEditMode)
                {
                    if (_existingTopic != null)
                        cmbLecturers.SelectedValue = _existingTopic.LecturerID;
                    this.Text = "Edit Topic";
                    txtTitle.Text = _existingTopic.Title;
                    txtDescription.Text = _existingTopic.Description;
                    // Lecturer will be selected after the list is loaded
                    cmbLecturers.SelectedValue = _existingTopic.LecturerID;

                    // Disable ComboBox and show Label
                    cmbLecturers.Visible = false;
                    lblLecturerDisplay.Visible = true;

                    // Get the current lecturer's name
                    var lecturer = await _lecturerService.GetLecturerById(_existingTopic.LecturerID);
                    lblLecturerDisplay.Text = $"Lecturer in charge: {lecturer?.Name ?? "Unknown"}";
                }
                else
                {
                    this.Text = "Add Topic";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the list of lecturers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate input data
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the topic title.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isEditMode && cmbLecturers.SelectedItem == null)
            {
                MessageBox.Show("Please select a lecturer in charge.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get data
            TopicTitle = txtTitle.Text.Trim();
            TopicDescription = txtDescription.Text.Trim();

            if (!_isEditMode)
            {
                SelectedLecturerID = (Guid)cmbLecturers.SelectedValue;
            }
            else
            {
                // Do not change LecturerID in edit mode
                SelectedLecturerID = _existingTopic.LecturerID;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
