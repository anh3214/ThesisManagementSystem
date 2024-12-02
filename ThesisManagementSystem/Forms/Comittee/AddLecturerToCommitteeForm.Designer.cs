// AddLecturerToCommitteeForm.Designer.cs
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class AddLecturerToCommitteeForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblAvailableLecturers;
        private DataGridView dgvAvailableLecturers;
        private Button btnAddLecturers;
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
            this.lblAvailableLecturers = new Label();
            this.dgvAvailableLecturers = new DataGridView();
            this.btnAddLecturers = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableLecturers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAvailableLecturers
            // 
            this.lblAvailableLecturers.AutoSize = true;
            this.lblAvailableLecturers.Location = new Point(20, 20);
            this.lblAvailableLecturers.Name = "lblAvailableLecturers";
            this.lblAvailableLecturers.Size = new Size(120, 15);
            this.lblAvailableLecturers.TabIndex = 0;
            this.lblAvailableLecturers.Text = "Available Lecturers:";
            // 
            // dgvAvailableLecturers
            // 
            this.dgvAvailableLecturers.AllowUserToAddRows = false;
            this.dgvAvailableLecturers.AllowUserToDeleteRows = false;
            this.dgvAvailableLecturers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableLecturers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableLecturers.Location = new Point(20, 50);
            this.dgvAvailableLecturers.Name = "dgvAvailableLecturers";
            this.dgvAvailableLecturers.ReadOnly = false; // Đảm bảo DataGridView không phải chế độ chỉ đọc
            this.dgvAvailableLecturers.EditMode = DataGridViewEditMode.EditOnEnter; // Bật chế độ chỉnh sửa khi click vào checkbox
            this.dgvAvailableLecturers.CellValueChanged += DgvLecturers_CellValueChanged;
            this.dgvAvailableLecturers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableLecturers.Size = new Size(600, 300);
            this.dgvAvailableLecturers.TabIndex = 1;
            // 
            // btnAddLecturers
            // 
            this.btnAddLecturers.Location = new Point(440, 370);
            this.btnAddLecturers.Name = "btnAddLecturers";
            this.btnAddLecturers.Size = new Size(90, 30);
            this.btnAddLecturers.TabIndex = 2;
            this.btnAddLecturers.Text = "Add Lecturers";
            this.btnAddLecturers.UseVisualStyleBackColor = true;
            this.btnAddLecturers.Click += new EventHandler(this.btnAddLecturers_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(540, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // AddLecturerToCommitteeForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(650, 420);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddLecturers);
            this.Controls.Add(this.dgvAvailableLecturers);
            this.Controls.Add(this.lblAvailableLecturers);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddLecturerToCommitteeForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Lecturers to Committee";
            this.Load += new EventHandler(this.AddLecturerToCommitteeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableLecturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DgvLecturers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "Role" không
            if (e.RowIndex >= 0 && dgvAvailableLecturers.Columns[e.ColumnIndex].Name == "Role")
            {
                // Lấy giá trị chuỗi từ cột Role
                string roleString = dgvAvailableLecturers.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse(roleString, out RoleCommitteeMember selectedRole))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    var currentRow = this.dgvAvailableLecturers.Rows[e.RowIndex].DataBoundItem;
                    dgvAvailableLecturers.Rows[e.RowIndex].Cells["Role"].Value = selectedRole;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{roleString}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
