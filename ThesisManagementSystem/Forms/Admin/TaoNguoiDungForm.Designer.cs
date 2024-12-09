using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class TaoNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblVaiTro;
        private ComboBox cmbVaiTro;
        private Label lblBoMon;
        private TextBox txtBoMon;
        private Label lblLop;
        private TextBox txtLop;
        private Label lblMSSV;
        private TextBox txtMSSV;
        private Button btnTaoMoi;
        private Button btnHuy;
        private Label lblHoTen;
        private TextBox txtHoTen;

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
            lblBoMon = new Label();
            txtBoMon = new TextBox();
            lblLop = new Label();
            txtLop = new TextBox();
            txtMSSV = new TextBox();
            btnTaoMoi = new Button();
            btnHuy = new Button();
            lblHoTen = new Label();
            lblMSSV = new Label();
            txtHoTen = new TextBox();
            SuspendLayout();

            // Set background color and image for the form
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

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
            txtTenDangNhap.Location = new Point(120, 27);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 23);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(30, 70);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(58, 15);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(120, 67);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(200, 23);
            txtMatKhau.TabIndex = 3;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(30, 150);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(44, 15);
            lblVaiTro.TabIndex = 6;
            lblVaiTro.Text = "Vai trò:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Items.AddRange(new object[] { "Admin", "Giảng viên", "Sinh viên" });
            cmbVaiTro.Location = new Point(120, 147);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(200, 23);
            cmbVaiTro.TabIndex = 7;
            cmbVaiTro.SelectedIndexChanged += cmbVaiTro_SelectedIndexChanged;
            // 
            // lblBoMon
            // 
            lblBoMon.AutoSize = true;
            lblBoMon.Location = new Point(30, 190);
            lblBoMon.Name = "lblBoMon";
            lblBoMon.Size = new Size(53, 15);
            lblBoMon.TabIndex = 8;
            lblBoMon.Text = "Bộ môn:";
            lblBoMon.Visible = false;
            // 
            // txtBoMon
            // 
            txtBoMon.Location = new Point(120, 187);
            txtBoMon.Name = "txtBoMon";
            txtBoMon.Size = new Size(200, 23);
            txtBoMon.TabIndex = 9;
            txtBoMon.Visible = false;
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
            txtLop.Location = new Point(120, 227);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(200, 23);
            txtLop.TabIndex = 11;
            txtLop.Visible = false;
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(120, 267);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(200, 23);
            txtMSSV.TabIndex = 13;
            txtMSSV.Visible = false;
            // 
            // btnTaoMoi
            // 
            btnTaoMoi.Location = new Point(120, 310);
            btnTaoMoi.Name = "btnTaoMoi";
            btnTaoMoi.Size = new Size(75, 30);
            btnTaoMoi.TabIndex = 14;
            btnTaoMoi.Text = "Tạo mới";
            btnTaoMoi.UseVisualStyleBackColor = true;
            btnTaoMoi.Click += btnTaoMoi_Click;
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
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 110);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(46, 15);
            lblHoTen.TabIndex = 4;
            lblHoTen.Text = "Họ tên:";
            lblHoTen.Visible = false;
            // 
            // lblMSSV
            // 
            lblMSSV.AutoSize = true;
            lblMSSV.Location = new Point(32, 270);
            lblMSSV.Name = "lblMSSV";
            lblMSSV.Size = new Size(42, 15);
            lblMSSV.TabIndex = 4;
            lblMSSV.Text = "MSSV:";
            lblMSSV.Visible = false;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(120, 107);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 5;
            txtHoTen.Visible = false;
            // 
            // CreateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 360);
            Controls.Add(btnHuy);
            Controls.Add(btnTaoMoi);
            Controls.Add(txtMSSV);
            Controls.Add(lblMSSV);
            Controls.Add(txtLop);
            Controls.Add(lblLop);
            Controls.Add(txtBoMon);
            Controls.Add(lblBoMon);
            Controls.Add(cmbVaiTro);
            Controls.Add(lblVaiTro);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Name = "CreateUserForm";
            Text = "Tạo người dùng";
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
