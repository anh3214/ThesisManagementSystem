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
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.lblVaiTro = new Label();
            this.cmbVaiTro = new ComboBox();
            this.lblKhoa = new Label();
            this.txtKhoa = new TextBox();
            this.lblLop = new Label();
            this.txtLop = new TextBox();
            this.btnLuu = new Button();
            this.btnHuy = new Button();
            this.SuspendLayout();

            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new Point(30, 30);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new Size(89, 15);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";

            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new Point(130, 27);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new Size(200, 23);
            this.txtTenDangNhap.TabIndex = 1;

            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new Point(30, 70);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new Size(63, 15);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu:";

            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new Point(130, 67);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new Size(200, 23);
            this.txtMatKhau.TabIndex = 3;

            // 
            // lblHoTen
            // 
            this.lblHoTen = new Label();
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new Point(30, 110);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new Size(51, 15);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "Họ Tên:";
            this.lblHoTen.Visible = false;

            // 
            // txtHoTen
            // 
            this.txtHoTen = new TextBox();
            this.txtHoTen.Location = new Point(130, 107);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new Size(200, 23);
            this.txtHoTen.TabIndex = 5;
            this.txtHoTen.Visible = false;

            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new Point(30, 110);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new Size(48, 15);
            this.lblVaiTro.TabIndex = 4;
            this.lblVaiTro.Text = "Vai trò:";

            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbVaiTro.FormattingEnabled = true;
            this.cmbVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Giảng viên",
            "Sinh viên"});
            this.cmbVaiTro.Location = new Point(130, 107);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new Size(200, 23);
            this.cmbVaiTro.TabIndex = 5;
            this.cmbVaiTro.SelectedIndexChanged += new EventHandler(this.cmbVaiTro_SelectedIndexChanged);

            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new Point(30, 150);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new Size(36, 15);
            this.lblKhoa.TabIndex = 6;
            this.lblKhoa.Text = "Khoa:";
            this.lblKhoa.Visible = false;

            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new Point(130, 147);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.Size = new Size(200, 23);
            this.txtKhoa.TabIndex = 7;
            this.txtKhoa.Visible = false;

            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new Point(30, 190);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new Size(31, 15);
            this.lblLop.TabIndex = 8;
            this.lblLop.Text = "Lớp:";
            this.lblLop.Visible = false;

            // 
            // txtLop
            // 
            this.txtLop.Location = new Point(130, 187);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new Size(200, 23);
            this.txtLop.TabIndex = 9;
            this.txtLop.Visible = false;

            // 
            // btnLuu
            // 
            this.btnLuu.Location = new Point(130, 230);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new Size(75, 30);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new EventHandler(this.btnLuu_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(245, 230);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(75, 30);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // 
            // ChinhSuaNguoiDungForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(360, 280);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.txtKhoa);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cmbVaiTro);
            this.Controls.Add(this.lblVaiTro);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);

            this.Name = "ChinhSuaNguoiDungForm";
            this.Text = "Chỉnh sửa người dùng";
            this.Load += new EventHandler(this.ChinhSuaNguoiDungForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
