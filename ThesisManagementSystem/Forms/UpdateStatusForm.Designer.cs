namespace ThesisManagementSystem.Forms
{
    partial class UpdateStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private Button btnOK;
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
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new Point(80, 20);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(200, 23);
            this.cmbStatus.TabIndex = 0;

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(20, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(45, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";

            // 
            // btnOK
            // 
            this.btnOK.Location = new Point(124, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(205, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // 
            // UpdateStatusForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(304, 102);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Name = "UpdateStatusForm";
            this.Text = "Update Registration Status";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}