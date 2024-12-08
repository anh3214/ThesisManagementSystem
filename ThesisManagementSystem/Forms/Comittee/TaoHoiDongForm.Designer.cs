using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class TaoHoiDongForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenHoiDong;
        private TextBox txtTenHoiDong;
        private Label lblNgayBaoVe;
        private DateTimePicker dtpNgayBaoVe;
        private Label lblGiangVien;
        private DataGridView dgvGiangVien;
        private Button btnThemGiangVien;
        private Button btnXoaGiangVien;
        private Button btnLuu;
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
            this.lblGiangVien = new Label();
            this.dgvGiangVien = new DataGridView();
            this.btnThemGiangVien = new Button();
            this.btnXoaGiangVien = new Button();
            this.btnLuu = new Button();
            this.btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVien)).BeginInit();
            this.SuspendLayout();

            // Set background color and image for the form
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = System.Drawing.Image.FromFile("path_to_your_image.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 
            // lblTenHoiDong
            // 
            this.lblTenHoiDong.AutoSize = true;
            this.lblTenHoiDong.Location = new Point(30, 30);
            this.lblTenHoiDong.Name = "lblTenHoiDong";
            this.lblTenHoiDong.Size = new Size(98, 15);
            this.lblTenHoiDong.TabIndex = 0;
            this.lblTenHoiDong.Text = "Tên Hội Đồng:";

            // 
            // txtTenHoiDong
            // 
            this.txtTenHoiDong.Location = new Point(150, 27);
            this.txtTenHoiDong.Name = "txtTenHoiDong";
            this.txtTenHoiDong.Size = new Size(200, 23);
            this.txtTenHoiDong.TabIndex = 1;

            // 
            // lblNgayBaoVe
            // 
            this.lblNgayBaoVe.AutoSize = true;
            this.lblNgayBaoVe.Location = new Point(30, 70);
            this.lblNgayBaoVe.Name = "lblNgayBaoVe";
            this.lblNgayBaoVe.Size = new Size(80, 15);
            this.lblNgayBaoVe.TabIndex = 2;
            this.lblNgayBaoVe.Text = "Ngày Bảo Vệ:";

            // 
            // dtpNgayBaoVe
            // 
            this.dtpNgayBaoVe.Format = DateTimePickerFormat.Short;
            this.dtpNgayBaoVe.Location = new Point(150, 67);
            this.dtpNgayBaoVe.Name = "dtpNgayBaoVe";
            this.dtpNgayBaoVe.Size = new Size(200, 23);
            this.dtpNgayBaoVe.TabIndex = 3;

            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new Point(30, 110);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new Size(72, 15);
            this.lblGiangVien.TabIndex = 4;
            this.lblGiangVien.Text = "Giảng Viên:";

            // 
            // dgvGiangVien
            // 
            this.dgvGiangVien.AllowUserToAddRows = false;
            this.dgvGiangVien.AllowUserToDeleteRows = false;
            this.dgvGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiangVien.Location = new Point(30, 130);
            this.dgvGiangVien.Name = "dgvGiangVien";
            this.dgvGiangVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiangVien.ReadOnly = false; // Ensure DataGridView is not read-only
            this.dgvGiangVien.EditMode = DataGridViewEditMode.EditOnEnter; // Enable edit mode on enter
            this.dgvGiangVien.CellValueChanged += DgvGiangVien_CellValueChanged;
            this.dgvGiangVien.Size = new Size(500, 200);
            this.dgvGiangVien.TabIndex = 5;

            // 
            // btnThemGiangVien
            // 
            this.btnThemGiangVien.Location = new Point(550, 130);
            this.btnThemGiangVien.Name = "btnThemGiangVien";
            this.btnThemGiangVien.Size = new Size(120, 30);
            this.btnThemGiangVien.TabIndex = 6;
            this.btnThemGiangVien.Text = "Thêm Giảng Viên";
            this.btnThemGiangVien.UseVisualStyleBackColor = true;
            this.btnThemGiangVien.Click += new EventHandler(this.btnThemGiangVien_Click);

            // 
            // btnXoaGiangVien
            // 
            this.btnXoaGiangVien.Location = new Point(550, 170);
            this.btnXoaGiangVien.Name = "btnXoaGiangVien";
            this.btnXoaGiangVien.Size = new Size(120, 30);
            this.btnXoaGiangVien.TabIndex = 7;
            this.btnXoaGiangVien.Text = "Xóa Giảng Viên";
            this.btnXoaGiangVien.UseVisualStyleBackColor = true;
            this.btnXoaGiangVien.Click += new EventHandler(this.btnXoaGiangVien_Click);

            // 
            // btnLuu
            // 
            this.btnLuu.Location = new Point(150, 350);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new Size(75, 30);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new EventHandler(this.btnLuu_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(275, 350);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(75, 30);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // 
            // TaoHoiDongForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 400);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoaGiangVien);
            this.Controls.Add(this.btnThemGiangVien);
            this.Controls.Add(this.dgvGiangVien);
            this.Controls.Add(this.lblGiangVien);
            this.Controls.Add(this.dtpNgayBaoVe);
            this.Controls.Add(this.lblNgayBaoVe);
            this.Controls.Add(this.txtTenHoiDong);
            this.Controls.Add(this.lblTenHoiDong);
            this.Name = "TaoHoiDongForm";
            this.Text = "Tạo Hội Đồng";
            this.Load += new EventHandler(this.TaoHoiDongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiangVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void DgvGiangVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem thay đổi có ở cột "VaiTro" không
            if (e.RowIndex >= 0 && dgvGiangVien.Columns[e.ColumnIndex].Name == "Role")
            {
                // Lấy giá trị chuỗi từ cột VaiTro
                string vaiTroChuoi = dgvGiangVien.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                // Chuyển đổi chuỗi sang Enum
                if (Enum.TryParse(vaiTroChuoi, out RoleCommitteeMember vaiTroChon))
                {
                    // Cập nhật vào danh sách dữ liệu nguồn
                    var currentRow = this.dgvGiangVien.Rows[e.RowIndex].DataBoundItem;
                    dgvGiangVien.Rows[e.RowIndex].Cells["Role"].Value = vaiTroChon;
                }
                else
                {
                    MessageBox.Show($"Không thể chuyển đổi vai trò '{vaiTroChuoi}' thành RoleCommitteeMember.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
