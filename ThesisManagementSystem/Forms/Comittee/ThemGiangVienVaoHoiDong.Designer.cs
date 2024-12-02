using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class ThemGiangVienVaoHoiDongForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGiangVienKhongCo;
        private DataGridView dgvGiangVienKhongCo;
        private Button btnThemGiangVien;
        private Button btnHuy;

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
            this.lblGiangVienKhongCo = new Label();
            this.dgvGiangVienKhongCo = new DataGridView();
            this.btnThemGiangVien = new Button();
            this.btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVienKhongCo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGiangVienKhongCo
            // 
            this.lblGiangVienKhongCo.AutoSize = true;
            this.lblGiangVienKhongCo.Location = new Point(20, 20);
            this.lblGiangVienKhongCo.Name = "lblGiangVienKhongCo";
            this.lblGiangVienKhongCo.Size = new Size(135, 15);
            this.lblGiangVienKhongCo.TabIndex = 0;
            this.lblGiangVienKhongCo.Text = "Giảng Viên Có Sẵn:";
            // 
            // dgvGiangVienKhongCo
            // 
            this.dgvGiangVienKhongCo.AllowUserToAddRows = false;
            this.dgvGiangVienKhongCo.AllowUserToDeleteRows = false;
            this.dgvGiangVienKhongCo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiangVienKhongCo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiangVienKhongCo.Location = new Point(20, 50);
            this.dgvGiangVienKhongCo.Name = "dgvGiangVienKhongCo";
            this.dgvGiangVienKhongCo.ReadOnly = false; // Đảm bảo DataGridView không phải chế độ chỉ đọc
            this.dgvGiangVienKhongCo.EditMode = DataGridViewEditMode.EditOnEnter; // Bật chế độ chỉnh sửa khi click vào checkbox
            this.dgvGiangVienKhongCo.CellValueChanged += DgvGiangVienKhongCo_CellValueChanged;
            this.dgvGiangVienKhongCo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiangVienKhongCo.Size = new Size(600, 300);
            this.dgvGiangVienKhongCo.TabIndex = 1;
            // 
            // btnThemGiangVien
            // 
            this.btnThemGiangVien.Location = new Point(440, 370);
            this.btnThemGiangVien.Name = "btnThemGiangVien";
            this.btnThemGiangVien.Size = new Size(90, 30);
            this.btnThemGiangVien.TabIndex = 2;
            this.btnThemGiangVien.Text = "Thêm Giảng Viên";
            this.btnThemGiangVien.UseVisualStyleBackColor = true;
            this.btnThemGiangVien.Click += new EventHandler(this.btnThemGiangVien_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(540, 370);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(80, 30);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);
            // 
            // ThemGiangVienVaoHoiDongForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(650, 420);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThemGiangVien);
            this.Controls.Add(this.dgvGiangVienKhongCo);
            this.Controls.Add(this.lblGiangVienKhongCo);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ThemGiangVienVaoHoiDongForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thêm Giảng Viên Vào Hội Đồng";
            this.Load += new EventHandler(this.ThemGiangVienVaoHoiDongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVienKhongCo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DgvGiangVienKhongCo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "VaiTro" không
            if (e.RowIndex >= 0 && dgvGiangVienKhongCo.Columns[e.ColumnIndex].Name == "VaiTro")
            {
                // Lấy giá trị chuỗi từ cột VaiTro
                string vaiTroChuoi = dgvGiangVienKhongCo.Rows[e.RowIndex].Cells["VaiTro"].Value?.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse<RoleCommitteeMember>(vaiTroChuoi, out var vaiTroChon))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    dgvGiangVienKhongCo.Rows[e.RowIndex].Cells["VaiTro"].Value = vaiTroChon;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{vaiTroChuoi}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
