using System.Windows.Forms;

namespace ThesisManagementSystem.Forms
{
    partial class EditDocumentForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblCurrentDocument;
        private TextBox txtCurrentDocument;
        private Label lblNewDocument;
        private TextBox txtNewDocument;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCurrentDocument = new Label();
            txtCurrentDocument = new TextBox();
            lblNewDocument = new Label();
            txtNewDocument = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // 
            // lblCurrentDocument
            // 
            lblCurrentDocument.AutoSize = true;
            lblCurrentDocument.Location = new Point(12, 15);
            lblCurrentDocument.Name = "lblCurrentDocument";
            lblCurrentDocument.Size = new Size(107, 15);
            lblCurrentDocument.TabIndex = 0;
            lblCurrentDocument.Text = "Current Document:";

            // 
            // txtCurrentDocument
            // 
            txtCurrentDocument.Location = new Point(125, 12);
            txtCurrentDocument.Name = "txtCurrentDocument";
            txtCurrentDocument.ReadOnly = true;
            txtCurrentDocument.Size = new Size(300, 23);
            txtCurrentDocument.TabIndex = 1;

            // 
            // lblNewDocument
            // 
            lblNewDocument.AutoSize = true;
            lblNewDocument.Location = new Point(12, 50);
            lblNewDocument.Name = "lblNewDocument";
            lblNewDocument.Size = new Size(123, 15);
            lblNewDocument.TabIndex = 3;
            lblNewDocument.Text = "New Document URL:";

            // 
            // txtNewDocument
            // 
            txtNewDocument.Location = new Point(125, 47);
            txtNewDocument.Name = "txtNewDocument";
            txtNewDocument.Size = new Size(300, 23);
            txtNewDocument.TabIndex = 4;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(125, 85);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(206, 85);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // EditDocumentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 120);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNewDocument);
            Controls.Add(lblNewDocument);
            Controls.Add(txtCurrentDocument);
            Controls.Add(lblCurrentDocument);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditDocumentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Document";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
