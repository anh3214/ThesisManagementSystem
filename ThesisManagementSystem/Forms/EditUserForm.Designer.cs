namespace ThesisManagementSystem.Forms
{
    partial class EditUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblDepartment;
        private TextBox txtDepartment;
        private Label lblClass;
        private TextBox txtClass;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private TextBox txtName;

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
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.lblDepartment = new Label();
            this.txtDepartment = new TextBox();
            this.lblClass = new Label();
            this.txtClass = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new Point(30, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(63, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";

            // 
            // txtUsername
            // 
            this.txtUsername.Location = new Point(120, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(200, 23);
            this.txtUsername.TabIndex = 1;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(30, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(60, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(120, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName = new Label();
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(30, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(42, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            this.lblName.Visible = false; // Ẩn mặc định

            // 
            // txtName
            // 
            this.txtName = new TextBox();
            this.txtName.Location = new Point(120, 107);
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(200, 23);
            this.txtName.TabIndex = 5;
            this.txtName.Visible = false; // Ẩn mặc định
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new Point(30, 110);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(34, 15);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Role:";

            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "Lecturer",
            "Student"});
            this.cmbRole.Location = new Point(120, 107);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(200, 23);
            this.cmbRole.TabIndex = 5;
            this.cmbRole.SelectedIndexChanged += new EventHandler(this.cmbRole_SelectedIndexChanged);

            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new Point(30, 150);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new Size(75, 15);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "Department:";
            this.lblDepartment.Visible = false;

            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new Point(120, 147);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new Size(200, 23);
            this.txtDepartment.TabIndex = 7;
            this.txtDepartment.Visible = false;

            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new Point(30, 190);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new Size(33, 15);
            this.lblClass.TabIndex = 8;
            this.lblClass.Text = "Class:";
            this.lblClass.Visible = false;

            // 
            // txtClass
            // 
            this.txtClass.Location = new Point(120, 187);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new Size(200, 23);
            this.txtClass.TabIndex = 9;
            this.txtClass.Visible = false;

            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(120, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(75, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(245, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(360, 280);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Name = "EditUserForm";
            this.Text = "Edit User";
            this.Load += new EventHandler(this.EditUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}