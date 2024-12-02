using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class CreateMilestoneForm : Form
    {
        public Milestone NewMilestone { get; private set; }

        public CreateMilestoneForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate and create a new milestone
            NewMilestone = new Milestone
            {
                MilestoneID = Guid.NewGuid(),
                Name = txtName.Text,
                Description = txtDescription.Text,
                Deadline = dtpDeadline.Value
            };
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
