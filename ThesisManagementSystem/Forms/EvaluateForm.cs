using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class EvaluateForm : Form
    {
        private readonly StudentGroup _group;
        private readonly Guid _registationId;
        private readonly Guid _milestoneId;
        private readonly Guid _lecturerId;
        private readonly IMilestoneService _milestoneService;
        private readonly IEvaluateService _evaluateService;

        public EvaluateForm(
            StudentGroup group, 
            Guid registationId,  
            Guid milestoneId, 
            Guid lecturerId, 
            IMilestoneService milestoneService, 
            IEvaluateService evaluateService)
        {
            InitializeComponent();
            _group = group;
            _milestoneId = milestoneId;
            _registationId = registationId;
            _lecturerId = lecturerId;
            _milestoneService = milestoneService;
            _evaluateService = evaluateService;
            LoadEvaluationDetailsAsync();
        }

        private async void LoadEvaluationDetailsAsync()
        {
            try
            {
                var milestone = await _milestoneService.GetByIdAsync(_milestoneId);

                if (milestone != null && _group != null)
                {
                    lblMilestoneName.Text = $"Milestone: {milestone.Name}";
                    lblGroupName.Text = $"Group: {_group.GroupName}";
                    // You can add other information if needed
                }
                else
                {
                    MessageBox.Show("Milestone or Group information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading evaluation details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the score from the user
            if (!int.TryParse(txtScore.Text.Trim(), out int score))
            {
                MessageBox.Show("Please enter a valid score.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a new evaluation object
                var evaluation = new Evaluation
                {
                    RegistrationID = _registationId,
                    EvaluatorID = _lecturerId,
                    Score = score,
                    MilestoneId = _milestoneId,
                    Comments = txtComments.Text.Trim(),
                    EvaluationDate = DateTime.UtcNow
                };

                await _evaluateService.AddAsync(evaluation);

                MessageBox.Show("Evaluation successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while evaluating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
