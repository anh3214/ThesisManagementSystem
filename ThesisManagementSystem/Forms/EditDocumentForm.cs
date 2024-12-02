using System;
using System.Windows.Forms;

namespace ThesisManagementSystem.Forms
{
    public partial class EditDocumentForm : Form
    {
        public string NewDocumentPath { get; private set; }

        public EditDocumentForm(string currentDocumentPath)
        {
            InitializeComponent();
            txtCurrentDocument.Text = currentDocumentPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewDocument.Text))
            {
                MessageBox.Show("Please enter a new document URL.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.IsWellFormedUriString(txtNewDocument.Text, UriKind.Absolute))
            {
                MessageBox.Show("The entered URL is not valid.", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewDocumentPath = txtNewDocument.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
