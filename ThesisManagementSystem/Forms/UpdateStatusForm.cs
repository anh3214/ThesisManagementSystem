using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class UpdateStatusForm : Form
    {
        public RegistrationStatus SelectedStatus { get; private set; }

        public UpdateStatusForm()
        {
            InitializeComponent();
            cmbStatus.Items.AddRange(["Approved", "Rejected"]);
        }
        public void SetUp(string currentStatus)
        {
            cmbStatus.SelectedItem = currentStatus;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem != null)
            {
                try
                {
                    SelectedStatus = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), cmbStatus.SelectedItem.ToString());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Invalid status selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
