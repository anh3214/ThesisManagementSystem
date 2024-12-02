namespace ThesisManagementSystem.Forms
{
    partial class SubmitDocumentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbMilestones;
        private System.Windows.Forms.TextBox txtDocumentPath;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMilestone;
        private System.Windows.Forms.Label lblDocumentPath;

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
            this.cmbMilestones = new System.Windows.Forms.ComboBox();
            this.txtDocumentPath = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.lblDocumentPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbMilestones
            // 
            this.cmbMilestones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMilestones.FormattingEnabled = true;
            this.cmbMilestones.Location = new System.Drawing.Point(120, 30);
            this.cmbMilestones.Name = "cmbMilestones";
            this.cmbMilestones.Size = new System.Drawing.Size(200, 21);
            this.cmbMilestones.TabIndex = 0;
            // 
            // txtDocumentPath
            // 
            this.txtDocumentPath.Location = new System.Drawing.Point(120, 70);
            this.txtDocumentPath.Name = "txtDocumentPath";
            this.txtDocumentPath.Size = new System.Drawing.Size(200, 20);
            this.txtDocumentPath.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(120, 110);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblMilestone
            // 
            this.lblMilestone.AutoSize = true;
            this.lblMilestone.Location = new System.Drawing.Point(30, 33);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(54, 13);
            this.lblMilestone.TabIndex = 3;
            this.lblMilestone.Text = "Milestone:";
            // 
            // lblDocumentPath
            // 
            this.lblDocumentPath.AutoSize = true;
            this.lblDocumentPath.Location = new System.Drawing.Point(30, 73);
            this.lblDocumentPath.Name = "lblDocumentPath";
            this.lblDocumentPath.Size = new System.Drawing.Size(84, 13);
            this.lblDocumentPath.TabIndex = 4;
            this.lblDocumentPath.Text = "Document URL:";
            // 
            // SubmitDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 160);
            this.Controls.Add(this.lblDocumentPath);
            this.Controls.Add(this.lblMilestone);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDocumentPath);
            this.Controls.Add(this.cmbMilestones);
            this.Name = "SubmitDocumentForm";
            this.Text = "Submit Document";
            this.Load += new System.EventHandler(this.SubmitDocumentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}