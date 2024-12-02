// EditGroupForm.Designer.cs
namespace ThesisManagementSystem.Forms
{
    partial class EditGroupForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGroupName;
        private TextBox txtGroupName;
        private Label lblAdvisor;
        private ComboBox cmbAdvisors;
        private Label lblCommittee;
        private ComboBox cmbCommittees;
        private Label lblDefenseDate; // Label mới cho Defense Date
        private DateTimePicker dtpDefenseDate; // DateTimePicker mới cho Defense Date
        private Button btnSave;
        private Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize the components and layout of the EditGroupForm.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblAdvisor = new System.Windows.Forms.Label();
            this.cmbAdvisors = new System.Windows.Forms.ComboBox();
            this.lblCommittee = new System.Windows.Forms.Label();
            this.cmbCommittees = new System.Windows.Forms.ComboBox();
            this.lblDefenseDate = new System.Windows.Forms.Label(); // Initialize Label mới
            this.dtpDefenseDate = new System.Windows.Forms.DateTimePicker(); // Initialize DateTimePicker mới
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(12, 15);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(80, 15);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Group Name:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(98, 12);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(200, 23);
            this.txtGroupName.TabIndex = 1;
            // 
            // lblAdvisor
            // 
            this.lblAdvisor.AutoSize = true;
            this.lblAdvisor.Location = new System.Drawing.Point(12, 50);
            this.lblAdvisor.Name = "lblAdvisor";
            this.lblAdvisor.Size = new System.Drawing.Size(52, 15);
            this.lblAdvisor.TabIndex = 2;
            this.lblAdvisor.Text = "Advisor:";
            // 
            // cmbAdvisors
            // 
            this.cmbAdvisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdvisors.FormattingEnabled = true;
            this.cmbAdvisors.Location = new System.Drawing.Point(98, 47);
            this.cmbAdvisors.Name = "cmbAdvisors";
            this.cmbAdvisors.Size = new System.Drawing.Size(200, 23);
            this.cmbAdvisors.TabIndex = 3;
            // 
            // lblCommittee
            // 
            this.lblCommittee.AutoSize = true;
            this.lblCommittee.Location = new System.Drawing.Point(12, 85);
            this.lblCommittee.Name = "lblCommittee";
            this.lblCommittee.Size = new System.Drawing.Size(68, 15);
            this.lblCommittee.TabIndex = 4;
            this.lblCommittee.Text = "Committee:";
            // 
            // cmbCommittees
            // 
            this.cmbCommittees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommittees.FormattingEnabled = true;
            this.cmbCommittees.Location = new System.Drawing.Point(98, 82);
            this.cmbCommittees.Name = "cmbCommittees";
            this.cmbCommittees.Size = new System.Drawing.Size(200, 23);
            this.cmbCommittees.TabIndex = 5;
            // 
            // lblDefenseDate
            // 
            this.lblDefenseDate.AutoSize = true;
            this.lblDefenseDate.Location = new System.Drawing.Point(12, 120);
            this.lblDefenseDate.Name = "lblDefenseDate";
            this.lblDefenseDate.Size = new System.Drawing.Size(80, 15);
            this.lblDefenseDate.TabIndex = 6;
            this.lblDefenseDate.Text = "Defense Date:";
            // 
            // dtpDefenseDate
            // 
            this.dtpDefenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDefenseDate.Location = new System.Drawing.Point(98, 117);
            this.dtpDefenseDate.Name = "dtpDefenseDate";
            this.dtpDefenseDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDefenseDate.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(142, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 200); // Tăng kích thước để chứa Defense Date
            this.Controls.Add(this.dtpDefenseDate);
            this.Controls.Add(this.lblDefenseDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbCommittees);
            this.Controls.Add(this.lblCommittee);
            this.Controls.Add(this.cmbAdvisors);
            this.Controls.Add(this.lblAdvisor);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Group";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
