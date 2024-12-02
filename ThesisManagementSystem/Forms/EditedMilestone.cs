using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class EditMilestoneForm : Form
    {
        public Milestone EditedMilestone { get; private set; }

        public EditMilestoneForm() => InitializeComponent();
        public void SetUpMilestone(Milestone milestone)
        {
            txtName.Text = milestone.Name;
            txtDescription.Text = milestone.Description;
            dtpDeadline.Value = milestone.Deadline;
            EditedMilestone = milestone;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate and update the milestone
            EditedMilestone.Name = txtName.Text;
            EditedMilestone.Description = txtDescription.Text;
            EditedMilestone.Deadline = dtpDeadline.Value;
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
