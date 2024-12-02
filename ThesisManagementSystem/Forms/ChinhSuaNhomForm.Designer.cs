namespace ThesisManagementSystem.Forms
{
    partial class ChinhSuaNhomForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenNhom;
        private TextBox txtTenNhom;
        private Label lblGiangVien;
        private ComboBox cmbGiangVien;
        private Label lblHoiDong;
        private ComboBox cmbHoiDong;
        private Label lblNgayBaoVe; // Nhãn mới cho Ngày Bảo Vệ
        private DateTimePicker dtpNgayBaoVe; // DateTimePicker mới cho Ngày Bảo Vệ
        private Button btnLuu;
        private Button btnHuy;

        /// <summary>
        /// Dọn dẹp tài nguyên đang sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu tài nguyên được giải phóng; ngược lại, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Khởi tạo các điều khiển và giao diện của ChinhSuaNhomForm.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenNhom = new System.Windows.Forms.Label();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.cmbGiangVien = new System.Windows.Forms.ComboBox();
            this.lblHoiDong = new System.Windows.Forms.Label();
            this.cmbHoiDong = new System.Windows.Forms.ComboBox();
            this.lblNgayBaoVe = new System.Windows.Forms.Label();
            this.dtpNgayBaoVe = new System.Windows.Forms.DateTimePicker();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTenNhom
            // 
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Location = new System.Drawing.Point(12, 15);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(65, 15);
            this.lblTenNhom.TabIndex = 0;
            this.lblTenNhom.Text = "Tên Nhóm:";
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Location = new System.Drawing.Point(98, 12);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(200, 23);
            this.txtTenNhom.TabIndex = 1;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(12, 50);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(70, 15);
            this.lblGiangVien.TabIndex = 2;
            this.lblGiangVien.Text = "Giảng Viên:";
            // 
            // cmbGiangVien
            // 
            this.cmbGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiangVien.FormattingEnabled = true;
            this.cmbGiangVien.Location = new System.Drawing.Point(98, 47);
            this.cmbGiangVien.Name = "cmbGiangVien";
            this.cmbGiangVien.Size = new System.Drawing.Size(200, 23);
            this.cmbGiangVien.TabIndex = 3;
            // 
            // lblHoiDong
            // 
            this.lblHoiDong.AutoSize = true;
            this.lblHoiDong.Location = new System.Drawing.Point(12, 85);
            this.lblHoiDong.Name = "lblHoiDong";
            this.lblHoiDong.Size = new System.Drawing.Size(62, 15);
            this.lblHoiDong.TabIndex = 4;
            this.lblHoiDong.Text = "Hội Đồng:";
            // 
            // cmbHoiDong
            // 
            this.cmbHoiDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoiDong.FormattingEnabled = true;
            this.cmbHoiDong.Location = new System.Drawing.Point(98, 82);
            this.cmbHoiDong.Name = "cmbHoiDong";
            this.cmbHoiDong.Size = new System.Drawing.Size(200, 23);
            this.cmbHoiDong.TabIndex = 5;
            // 
            // lblNgayBaoVe
            // 
            this.lblNgayBaoVe.AutoSize = true;
            this.lblNgayBaoVe.Location = new System.Drawing.Point(12, 120);
            this.lblNgayBaoVe.Name = "lblNgayBaoVe";
            this.lblNgayBaoVe.Size = new System.Drawing.Size(80, 15);
            this.lblNgayBaoVe.TabIndex = 6;
            this.lblNgayBaoVe.Text = "Ngày Bảo Vệ:";
            // 
            // dtpNgayBaoVe
            // 
            this.dtpNgayBaoVe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBaoVe.Location = new System.Drawing.Point(98, 117);
            this.dtpNgayBaoVe.Name = "dtpNgayBaoVe";
            this.dtpNgayBaoVe.Size = new System.Drawing.Size(200, 23);
            this.dtpNgayBaoVe.TabIndex = 7;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(142, 160);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(223, 160);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // ChinhSuaNhomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 200);
            this.Controls.Add(this.dtpNgayBaoVe);
            this.Controls.Add(this.lblNgayBaoVe);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cmbHoiDong);
            this.Controls.Add(this.lblHoiDong);
            this.Controls.Add(this.cmbGiangVien);
            this.Controls.Add(this.lblGiangVien);
            this.Controls.Add(this.txtTenNhom);
            this.Controls.Add(this.lblTenNhom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChinhSuaNhomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa nhóm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
