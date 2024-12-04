namespace ThesisManagementSystem.Forms
{
    partial class ChinhSuaNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblVaiTro;
        private ComboBox cmbVaiTro;
        private Label lblKhoa;
        private TextBox txtKhoa;
        private Label lblLop;
        private TextBox txtLop;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblMSSV;
        private TextBox txtMSSV;

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
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblVaiTro = new Label();
            cmbVaiTro = new ComboBox();
            lblKhoa = new Label();
            txtKhoa = new TextBox();
            lblLop = new Label();
            txtLop = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblMSSV = new Label();
            txtMSSV = new TextBox();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(30, 30);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(89, 15);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(130, 27);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 23);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(30, 70);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(60, 15);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(130, 67);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(200, 23);
            txtMatKhau.TabIndex = 3;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(30, 110);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(43, 15);
            lblVaiTro.TabIndex = 4;
            lblVaiTro.Text = "Vai trò:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Items.AddRange(new object[] { "Admin", "Giảng viên", "Sinh viên" });
            cmbVaiTro.Location = new Point(130, 107);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(200, 23);
            cmbVaiTro.TabIndex = 5;
            cmbVaiTro.SelectedIndexChanged += cmbVaiTro_SelectedIndexChanged;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 150);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(48, 15);
            lblHoTen.TabIndex = 6;
            lblHoTen.Text = "Họ Tên:";
            lblHoTen.Visible = false;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(130, 147);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 7;
            txtHoTen.Visible = false;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(30, 190);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(37, 15);
            lblKhoa.TabIndex = 8;
            lblKhoa.Text = "Khoa:";
            lblKhoa.Visible = false;
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(130, 187);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.Size = new Size(200, 23);
            txtKhoa.TabIndex = 9;
            txtKhoa.Visible = false;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(30, 230);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(30, 15);
            lblLop.TabIndex = 10;
            lblLop.Text = "Lớp:";
            lblLop.Visible = false;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(130, 227);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(200, 23);
            txtLop.TabIndex = 11;
            txtLop.Visible = false;
            // 
            // lblMSSV
            // 
            lblMSSV.AutoSize = true;
            lblMSSV.Location = new Point(30, 270);
            lblMSSV.Name = "lblMSSV";
            lblMSSV.Size = new Size(37, 15);
            lblMSSV.TabIndex = 12;
            lblMSSV.Text = "MSSV:";
            lblMSSV.Visible = false;
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(130, 267);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(200, 23);
            txtMSSV.TabIndex = 13;
            txtMSSV.Visible = false;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(130, 310);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 30);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(245, 310);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(75, 30);
            btnHuy.TabIndex = 15;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // ChinhSuaNguoiDungForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 360);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtMSSV);
            Controls.Add(lblMSSV);
            Controls.Add(txtLop);
            Controls.Add(lblLop);
            Controls.Add(txtKhoa);
            Controls.Add(lblKhoa);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(cmbVaiTro);
            Controls.Add(lblVaiTro);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            Name = "ChinhSuaNguoiDungForm";
            Text = "Chỉnh sửa người dùng";
            Load += ChinhSuaNguoiDungForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
