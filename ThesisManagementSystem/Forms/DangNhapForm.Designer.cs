namespace ThesisManagementSystem
{
    partial class DangNhapForm
    {
        private System.ComponentModel.IContainer components = null;

        // Các điều khiển
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;

        /// <summary>
        /// Dọn dẹp các tài nguyên đang được sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên cần được giải phóng; ngược lại, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Mã do Windows Form Designer tạo

        private void InitializeComponent()
        {
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(31, 22);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(93, 15);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(140, 20);
            txtTenDangNhap.Margin = new Padding(3, 2, 3, 2);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(193, 23);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(31, 60);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(62, 15);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(140, 58);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(193, 23);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(140, 98);
            btnDangNhap.Margin = new Padding(3, 2, 3, 2);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(88, 26);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // DangNhapForm
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 150);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DangNhapForm";
            Text = "Đăng nhập hệ thống";
            Load += DangNhapForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
