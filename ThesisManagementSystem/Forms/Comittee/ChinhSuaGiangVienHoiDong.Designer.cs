using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class ChinhSuaGiangVienHoiDongForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenHoiDong;
        private TextBox txtTenHoiDong;
        private Label lblNgayBaoVe;
        private DateTimePicker dtpNgayBaoVe;
        private Label lblGiangVienTrongHoiDong;
        private DataGridView dgvGiangVienTrongHoiDong;
        private Button btnLuuThayDoi;
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
            this.lblTenHoiDong = new Label();
            this.txtTenHoiDong = new TextBox();
            this.lblNgayBaoVe = new Label();
            this.dtpNgayBaoVe = new DateTimePicker();
            this.lblGiangVienTrongHoiDong = new Label();
            this.dgvGiangVienTrongHoiDong = new DataGridView();
            this.btnLuuThayDoi = new Button();
            this.btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVienTrongHoiDong)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTenHoiDong
            // 
            this.lblTenHoiDong.AutoSize = true;
            this.lblTenHoiDong.Location = new Point(30, 20);
            this.lblTenHoiDong.Name = "lblTenHoiDong";
            this.lblTenHoiDong.Size = new Size(98, 15);
            this.lblTenHoiDong.TabIndex = 0;
            this.lblTenHoiDong.Text = "Tên Hội Đồng:";

            // 
            // txtTenHoiDong
            // 
            this.txtTenHoiDong.Location = new Point(150, 17);
            this.txtTenHoiDong.Name = "txtTenHoiDong";
            this.txtTenHoiDong.Size = new Size(200, 23);
            this.txtTenHoiDong.TabIndex = 1;

            // 
            // lblNgayBaoVe
            // 
            this.lblNgayBaoVe.AutoSize = true;
            this.lblNgayBaoVe.Location = new Point(30, 60);
            this.lblNgayBaoVe.Name = "lblNgayBaoVe";
            this.lblNgayBaoVe.Size = new Size(86, 15);
            this.lblNgayBaoVe.TabIndex = 2;
            this.lblNgayBaoVe.Text = "Ngày Bảo Vệ:";

            // 
            // dtpNgayBaoVe
            // 
            this.dtpNgayBaoVe.Format = DateTimePickerFormat.Short;
            this.dtpNgayBaoVe.Location = new Point(150, 57);
            this.dtpNgayBaoVe.Name = "dtpNgayBaoVe";
            this.dtpNgayBaoVe.Size = new Size(200, 23);
            this.dtpNgayBaoVe.TabIndex = 3;

            // 
            // lblGiangVienTrongHoiDong
            // 
            this.lblGiangVienTrongHoiDong.AutoSize = true;
            this.lblGiangVienTrongHoiDong.Location = new Point(30, 100);
            this.lblGiangVienTrongHoiDong.Name = "lblGiangVienTrongHoiDong";
            this.lblGiangVienTrongHoiDong.Size = new Size(150, 15);
            this.lblGiangVienTrongHoiDong.TabIndex = 4;
            this.lblGiangVienTrongHoiDong.Text = "Giảng Viên Trong Hội Đồng:";

            // 
            // dgvGiangVienTrongHoiDong
            // 
            this.dgvGiangVienTrongHoiDong.AllowUserToAddRows = false;
            this.dgvGiangVienTrongHoiDong.AllowUserToDeleteRows = false;
            this.dgvGiangVienTrongHoiDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiangVienTrongHoiDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiangVienTrongHoiDong.Location = new Point(30, 120);
            this.dgvGiangVienTrongHoiDong.Name = "dgvGiangVienTrongHoiDong";
            this.dgvGiangVienTrongHoiDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiangVienTrongHoiDong.Size = new Size(600, 200);
            this.dgvGiangVienTrongHoiDong.TabIndex = 5;

            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.Location = new Point(440, 370);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new Size(100, 30);
            this.btnLuuThayDoi.TabIndex = 6;
            this.btnLuuThayDoi.Text = "Lưu Thay Đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = true;
            this.btnLuuThayDoi.Click += new EventHandler(this.btnLuuThayDoi_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(550, 370);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(70, 30);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // 
            // ChinhSuaGiangVienHoiDongForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(650, 420);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuuThayDoi);
            this.Controls.Add(this.dgvGiangVienTrongHoiDong);
            this.Controls.Add(this.lblGiangVienTrongHoiDong);
            this.Controls.Add(this.dtpNgayBaoVe);
            this.Controls.Add(this.lblNgayBaoVe);
            this.Controls.Add(this.txtTenHoiDong);
            this.Controls.Add(this.lblTenHoiDong);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChinhSuaGiangVienHoiDongForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chỉnh Sửa Giảng Viên Trong Hội Đồng";
            this.Load += new EventHandler(this.ChinhSuaGiangVienHoiDongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVienTrongHoiDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void DgvGiangVienTrongHoiDong_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "VaiTro" không
            if (e.RowIndex >= 0 && dgvGiangVienTrongHoiDong.Columns[e.ColumnIndex].Name == "VaiTro")
            {
                // Lấy giá trị chuỗi từ cột VaiTro
                string vaiTroChuoi = dgvGiangVienTrongHoiDong.Rows[e.RowIndex].Cells["VaiTro"].Value?.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse<RoleCommitteeMember>(vaiTroChuoi, out var vaiTroChon))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    dgvGiangVienTrongHoiDong.Rows[e.RowIndex].Cells["VaiTro"].Value = vaiTroChon;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{vaiTroChuoi}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
