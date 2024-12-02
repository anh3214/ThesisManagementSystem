namespace ThesisManagementSystem.Forms
{
    partial class EditLecturerInCommitteeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblLecturersInCommittee;
        private DataGridView dgvLecturersInCommittee;
        private Button btnSaveChanges;
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
            this.lblLecturersInCommittee = new Label();
            this.dgvLecturersInCommittee = new DataGridView();
            this.btnSaveChanges = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturersInCommittee)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLecturersInCommittee
            // 
            this.lblLecturersInCommittee.AutoSize = true;
            this.lblLecturersInCommittee.Location = new Point(20, 20);
            this.lblLecturersInCommittee.Name = "lblLecturersInCommittee";
            this.lblLecturersInCommittee.Size = new Size(130, 15);
            this.lblLecturersInCommittee.TabIndex = 0;
            this.lblLecturersInCommittee.Text = "Lecturers in Committee:";
            // 
            // dgvLecturersInCommittee
            // 
            this.dgvLecturersInCommittee.AllowUserToAddRows = false;
            this.dgvLecturersInCommittee.AllowUserToDeleteRows = false;
            this.dgvLecturersInCommittee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLecturersInCommittee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturersInCommittee.Location = new Point(20, 50);
            this.dgvLecturersInCommittee.Name = "dgvLecturersInCommittee";
            this.dgvLecturersInCommittee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLecturersInCommittee.Size = new Size(600, 300);
            this.dgvLecturersInCommittee.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new Point(440, 370);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new Size(100, 30);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(550, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(70, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // EditLecturerInCommitteeForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(650, 420);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.dgvLecturersInCommittee);
            this.Controls.Add(this.lblLecturersInCommittee);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditLecturerInCommitteeForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Lecturers in Committee";
            this.Load += new EventHandler(this.EditLecturerInCommitteeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturersInCommittee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
