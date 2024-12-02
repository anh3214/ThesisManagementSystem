using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class SubmitDocumentForm : Form
    {
        private readonly Guid _registrationId;
        private readonly IMilestoneService _milestoneService;
        private readonly ISubmissionService _submissionService;

        public SubmitDocumentForm(Guid registrationId, IMilestoneService milestoneService, ISubmissionService submissionService)
        {
            InitializeComponent();
            _registrationId = registrationId;
            _milestoneService = milestoneService;
            _submissionService = submissionService;
        }

        private async void SubmitDocumentForm_Load(object sender, EventArgs e)
        {
            // Load milestones
            var milestones = await _milestoneService.GetAllMilestones();
            cmbMilestones.DataSource = milestones;
            cmbMilestones.DisplayMember = "Name";
            cmbMilestones.ValueMember = "MilestoneID";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbMilestones.SelectedItem == null)
            {
                MessageBox.Show("Please select a milestone.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumentPath.Text))
            {
                MessageBox.Show("Please enter the document URL.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMilestoneId = (Guid)cmbMilestones.SelectedValue;

            // Check if there is already a submission for the selected milestone and registration
            var existingSubmissions = await _submissionService.GetSubmissionByWhereClause(
                s => s.RegistrationID == _registrationId && s.MilestoneID == selectedMilestoneId);

            if (existingSubmissions.Any())
            {
                MessageBox.Show("A submission for this milestone already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.IsWellFormedUriString(txtDocumentPath.Text, UriKind.Absolute))
            {
                MessageBox.Show("The entered URL is not valid.", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newSubmission = new Submission
            {
                SubmissionID = Guid.NewGuid(),
                RegistrationID = _registrationId,
                MilestoneID = selectedMilestoneId,
                SubmissionDate = DateTime.Now,
                DocumentPath = txtDocumentPath.Text
            };

            await _submissionService.AddSubmissionAsync(newSubmission);

            MessageBox.Show("Document submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}