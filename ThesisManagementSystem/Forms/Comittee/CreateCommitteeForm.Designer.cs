using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class CreateCommitteeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCommitteeName;
        private TextBox txtCommitteeName;
        private Label lblDefenseDate;
        private DateTimePicker dtpDefenseDate;
        private Label lblLecturers;
        private DataGridView dgvLecturers;
        private Button btnAddLecturer;
        private Button btnRemoveLecturer;
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
            this.lblCommitteeName = new Label();
            this.txtCommitteeName = new TextBox();
            this.lblDefenseDate = new Label();
            this.dtpDefenseDate = new DateTimePicker();
            this.lblLecturers = new Label();
            this.dgvLecturers = new DataGridView();
            this.btnAddLecturer = new Button();
            this.btnRemoveLecturer = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            this.SuspendLayout();

            // 
            // lblCommitteeName
            // 
            this.lblCommitteeName.AutoSize = true;
            this.lblCommitteeName.Location = new Point(30, 30);
            this.lblCommitteeName.Name = "lblCommitteeName";
            this.lblCommitteeName.Size = new Size(98, 15);
            this.lblCommitteeName.TabIndex = 0;
            this.lblCommitteeName.Text = "Committee Name:";

            // 
            // txtCommitteeName
            // 
            this.txtCommitteeName.Location = new Point(150, 27);
            this.txtCommitteeName.Name = "txtCommitteeName";
            this.txtCommitteeName.Size = new Size(200, 23);
            this.txtCommitteeName.TabIndex = 1;

            // 
            // lblDefenseDate
            // 
            this.lblDefenseDate.AutoSize = true;
            this.lblDefenseDate.Location = new Point(30, 70);
            this.lblDefenseDate.Name = "lblDefenseDate";
            this.lblDefenseDate.Size = new Size(86, 15);
            this.lblDefenseDate.TabIndex = 2;
            this.lblDefenseDate.Text = "Defense Date:";

            // 
            // dtpDefenseDate
            // 
            this.dtpDefenseDate.Format = DateTimePickerFormat.Short;
            this.dtpDefenseDate.Location = new Point(150, 67);
            this.dtpDefenseDate.Name = "dtpDefenseDate";
            this.dtpDefenseDate.Size = new Size(200, 23);
            this.dtpDefenseDate.TabIndex = 3;

            // 
            // lblLecturers
            // 
            this.lblLecturers.AutoSize = true;
            this.lblLecturers.Location = new Point(30, 110);
            this.lblLecturers.Name = "lblLecturers";
            this.lblLecturers.Size = new Size(59, 15);
            this.lblLecturers.TabIndex = 4;
            this.lblLecturers.Text = "Lecturers:";

            // 
            // dgvLecturers
            // 
            this.dgvLecturers.AllowUserToAddRows = false;
            this.dgvLecturers.AllowUserToDeleteRows = false;
            this.dgvLecturers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLecturers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturers.Location = new Point(30, 130);
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLecturers.ReadOnly = false; // Đảm bảo DataGridView không phải chế độ chỉ đọc
            this.dgvLecturers.EditMode = DataGridViewEditMode.EditOnEnter; // Bật chế độ chỉnh sửa khi click vào checkbox
            this.dgvLecturers.CellValueChanged += DgvLecturers_CellValueChanged;
            this.dgvLecturers.Size = new Size(500, 200);
            this.dgvLecturers.TabIndex = 5;


            // 
            // btnAddLecturer
            // 
            this.btnAddLecturer.Location = new Point(550, 130);
            this.btnAddLecturer.Name = "btnAddLecturer";
            this.btnAddLecturer.Size = new Size(120, 30);
            this.btnAddLecturer.TabIndex = 6;
            this.btnAddLecturer.Text = "Add Lecturer";
            this.btnAddLecturer.UseVisualStyleBackColor = true;
            this.btnAddLecturer.Click += new EventHandler(this.btnAddLecturer_Click);

            // 
            // btnRemoveLecturer
            // 
            this.btnRemoveLecturer.Location = new Point(550, 170);
            this.btnRemoveLecturer.Name = "btnRemoveLecturer";
            this.btnRemoveLecturer.Size = new Size(120, 30);
            this.btnRemoveLecturer.TabIndex = 7;
            this.btnRemoveLecturer.Text = "Remove Lecturer";
            this.btnRemoveLecturer.UseVisualStyleBackColor = true;
            this.btnRemoveLecturer.Click += new EventHandler(this.btnRemoveLecturer_Click);

            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(150, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(75, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(275, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // 
            // CreateCommitteeForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveLecturer);
            this.Controls.Add(this.btnAddLecturer);
            this.Controls.Add(this.dgvLecturers);
            this.Controls.Add(this.lblLecturers);
            this.Controls.Add(this.dtpDefenseDate);
            this.Controls.Add(this.lblDefenseDate);
            this.Controls.Add(this.txtCommitteeName);
            this.Controls.Add(this.lblCommitteeName);
            this.Name = "CreateCommitteeForm";
            this.Text = "Create Committee";
            this.Load += new EventHandler(this.CreateCommitteeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void DgvLecturers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "Role" không
            if (e.RowIndex >= 0 && dgvLecturers.Columns[e.ColumnIndex].Name == "Role")
            {
                // Lấy giá trị chuỗi từ cột Role
                string roleString = dgvLecturers.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse(roleString, out RoleCommitteeMember selectedRole))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    var currentRow = this.dgvLecturers.Rows[e.RowIndex].DataBoundItem;
                    dgvLecturers.Rows[e.RowIndex].Cells["Role"].Value = selectedRole;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{roleString}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
