namespace ThesisManagementSystem.Forms
{
    partial class QuanLyAdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabNguoiDung;
        private TabPage tabMocThoiGian;
        private TabPage tabHoiDong;
        private TabPage tabDangKy;
        private TabPage tabNhom;
        private DataGridView dgvNguoiDung;
        private DataGridView dgvMocThoiGian;
        private DataGridView dgvHoiDong;
        private DataGridView dgvDangKy;
        private DataGridView dgvNhom;
        private Button btnTaoHoiDong;
        private Button btnChinhSuaHoiDong;
        private Button btnCapNhatTrangThaiDangKy;
        private Button btnTaoNguoiDung;
        private Button btnChinhSuaNguoiDung;
        private Button btnXoaNguoiDung;
        private Button btnTaoMocThoiGian;
        private Button btnChinhSuaMocThoiGian;
        private Button btnDangXuat;
        private Button btnChinhSuaNhom;
        private FlowLayoutPanel flowLayoutPanelNguoiDungButtons;
        private FlowLayoutPanel flowLayoutPanelMocThoiGianButtons;
        private FlowLayoutPanel flowLayoutPanelHoiDongButtons;
        private FlowLayoutPanel flowLayoutPanelDangKyButtons;
        private FlowLayoutPanel flowLayoutPanelNhomButtons;
        private Panel panelTren;

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
            tabControl = new TabControl();
            tabNguoiDung = new TabPage();
            dgvNguoiDung = new DataGridView();
            flowLayoutPanelNguoiDungButtons = new FlowLayoutPanel();
            btnTaoNguoiDung = new Button();
            btnChinhSuaNguoiDung = new Button();
            btnXoaNguoiDung = new Button();
            tabMocThoiGian = new TabPage();
            dgvMocThoiGian = new DataGridView();
            flowLayoutPanelMocThoiGianButtons = new FlowLayoutPanel();
            btnTaoMocThoiGian = new Button();
            btnChinhSuaMocThoiGian = new Button();
            tabHoiDong = new TabPage();
            dgvHoiDong = new DataGridView();
            flowLayoutPanelHoiDongButtons = new FlowLayoutPanel();
            btnTaoHoiDong = new Button();
            btnChinhSuaHoiDong = new Button();
            tabDangKy = new TabPage();
            dgvDangKy = new DataGridView();
            flowLayoutPanelDangKyButtons = new FlowLayoutPanel();
            btnCapNhatTrangThaiDangKy = new Button();
            tabNhom = new TabPage();
            dgvNhom = new DataGridView();
            flowLayoutPanelNhomButtons = new FlowLayoutPanel();
            btnChinhSuaNhom = new Button();
            btnDangXuat = new Button();
            panelTren = new Panel();
            tabControl.SuspendLayout();
            tabNguoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).BeginInit();
            flowLayoutPanelNguoiDungButtons.SuspendLayout();
            tabMocThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMocThoiGian).BeginInit();
            flowLayoutPanelMocThoiGianButtons.SuspendLayout();
            tabHoiDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).BeginInit();
            flowLayoutPanelHoiDongButtons.SuspendLayout();
            tabDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDangKy).BeginInit();
            flowLayoutPanelDangKyButtons.SuspendLayout();
            tabNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhom).BeginInit();
            flowLayoutPanelNhomButtons.SuspendLayout();
            panelTren.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabNguoiDung);
            tabControl.Controls.Add(tabMocThoiGian);
            tabControl.Controls.Add(tabHoiDong);
            tabControl.Controls.Add(tabDangKy);
            tabControl.Controls.Add(tabNhom);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 550);
            tabControl.TabIndex = 0;
            // 
            // tabNguoiDung
            // 
            tabNguoiDung.BackColor = Color.WhiteSmoke;
            tabNguoiDung.Controls.Add(dgvNguoiDung);
            tabNguoiDung.Controls.Add(flowLayoutPanelNguoiDungButtons);
            tabNguoiDung.Location = new Point(4, 24);
            tabNguoiDung.Name = "tabNguoiDung";
            tabNguoiDung.Size = new Size(792, 522);
            tabNguoiDung.TabIndex = 0;
            tabNguoiDung.Text = "Người Dùng";
            // 
            // dgvNguoiDung
            // 
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.Dock = DockStyle.Fill;
            dgvNguoiDung.Location = new Point(0, 0);
            dgvNguoiDung.Name = "dgvNguoiDung";
            dgvNguoiDung.Size = new Size(792, 422);
            dgvNguoiDung.TabIndex = 0;
            // 
            // flowLayoutPanelNguoiDungButtons
            // 
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnTaoNguoiDung);
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnChinhSuaNguoiDung);
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnXoaNguoiDung);
            flowLayoutPanelNguoiDungButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNguoiDungButtons.Location = new Point(0, 422);
            flowLayoutPanelNguoiDungButtons.Name = "flowLayoutPanelNguoiDungButtons";
            flowLayoutPanelNguoiDungButtons.Size = new Size(792, 100);
            flowLayoutPanelNguoiDungButtons.TabIndex = 1;
            // 
            // btnTaoNguoiDung
            // 
            btnTaoNguoiDung.BackColor = Color.LightSteelBlue;
            btnTaoNguoiDung.ForeColor = Color.White;
            btnTaoNguoiDung.Location = new Point(3, 3);
            btnTaoNguoiDung.Name = "btnTaoNguoiDung";
            btnTaoNguoiDung.Size = new Size(75, 23);
            btnTaoNguoiDung.TabIndex = 0;
            btnTaoNguoiDung.Text = "Tạo Người Dùng";
            btnTaoNguoiDung.UseVisualStyleBackColor = false;
            btnTaoNguoiDung.Click += btnTaoNguoiDung_Click;
            // 
            // btnChinhSuaNguoiDung
            // 
            btnChinhSuaNguoiDung.BackColor = Color.LightSteelBlue;
            btnChinhSuaNguoiDung.ForeColor = Color.White;
            btnChinhSuaNguoiDung.Location = new Point(84, 3);
            btnChinhSuaNguoiDung.Name = "btnChinhSuaNguoiDung";
            btnChinhSuaNguoiDung.Size = new Size(75, 23);
            btnChinhSuaNguoiDung.TabIndex = 1;
            btnChinhSuaNguoiDung.Text = "Chỉnh Sửa Người Dùng";
            btnChinhSuaNguoiDung.UseVisualStyleBackColor = false;
            btnChinhSuaNguoiDung.Click += btnChinhSuaNguoiDung_Click;
            // 
            // btnXoaNguoiDung
            // 
            btnXoaNguoiDung.BackColor = Color.LightSteelBlue;
            btnXoaNguoiDung.ForeColor = Color.White;
            btnXoaNguoiDung.Location = new Point(165, 3);
            btnXoaNguoiDung.Name = "btnXoaNguoiDung";
            btnXoaNguoiDung.Size = new Size(75, 23);
            btnXoaNguoiDung.TabIndex = 2;
            btnXoaNguoiDung.Text = "Xóa Người Dùng";
            btnXoaNguoiDung.UseVisualStyleBackColor = false;
            btnXoaNguoiDung.Click += btnXoaNguoiDung_Click;
            // 
            // tabMocThoiGian
            // 
            tabMocThoiGian.BackColor = Color.LightCyan;
            tabMocThoiGian.Controls.Add(dgvMocThoiGian);
            tabMocThoiGian.Controls.Add(flowLayoutPanelMocThoiGianButtons);
            tabMocThoiGian.Location = new Point(4, 24);
            tabMocThoiGian.Name = "tabMocThoiGian";
            tabMocThoiGian.Size = new Size(792, 522);
            tabMocThoiGian.TabIndex = 1;
            tabMocThoiGian.Text = "Mốc Thời Gian";
            // 
            // dgvMocThoiGian
            // 
            dgvMocThoiGian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMocThoiGian.Dock = DockStyle.Fill;
            dgvMocThoiGian.Location = new Point(0, 0);
            dgvMocThoiGian.Name = "dgvMocThoiGian";
            dgvMocThoiGian.Size = new Size(792, 422);
            dgvMocThoiGian.TabIndex = 0;
            // 
            // flowLayoutPanelMocThoiGianButtons
            // 
            flowLayoutPanelMocThoiGianButtons.Controls.Add(btnTaoMocThoiGian);
            flowLayoutPanelMocThoiGianButtons.Controls.Add(btnChinhSuaMocThoiGian);
            flowLayoutPanelMocThoiGianButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelMocThoiGianButtons.Location = new Point(0, 422);
            flowLayoutPanelMocThoiGianButtons.Name = "flowLayoutPanelMocThoiGianButtons";
            flowLayoutPanelMocThoiGianButtons.Size = new Size(792, 100);
            flowLayoutPanelMocThoiGianButtons.TabIndex = 1;
            // 
            // btnTaoMocThoiGian
            // 
            btnTaoMocThoiGian.BackColor = Color.LightSteelBlue;
            btnTaoMocThoiGian.ForeColor = Color.White;
            btnTaoMocThoiGian.Location = new Point(3, 3);
            btnTaoMocThoiGian.Name = "btnTaoMocThoiGian";
            btnTaoMocThoiGian.Size = new Size(75, 23);
            btnTaoMocThoiGian.TabIndex = 0;
            btnTaoMocThoiGian.Text = "Tạo Mốc Thời Gian";
            btnTaoMocThoiGian.UseVisualStyleBackColor = false;
            btnTaoMocThoiGian.Click += btnTaoMocThoiGian_Click;
            // 
            // btnChinhSuaMocThoiGian
            // 
            btnChinhSuaMocThoiGian.BackColor = Color.LightSteelBlue;
            btnChinhSuaMocThoiGian.ForeColor = Color.White;
            btnChinhSuaMocThoiGian.Location = new Point(84, 3);
            btnChinhSuaMocThoiGian.Name = "btnChinhSuaMocThoiGian";
            btnChinhSuaMocThoiGian.Size = new Size(75, 23);
            btnChinhSuaMocThoiGian.TabIndex = 1;
            btnChinhSuaMocThoiGian.Text = "Chỉnh Sửa Mốc Thời Gian";
            btnChinhSuaMocThoiGian.UseVisualStyleBackColor = false;
            btnChinhSuaMocThoiGian.Click += btnChinhSuaMocThoiGian_Click;
            // 
            // tabHoiDong
            // 
            tabHoiDong.BackColor = Color.MistyRose;
            tabHoiDong.Controls.Add(dgvHoiDong);
            tabHoiDong.Controls.Add(flowLayoutPanelHoiDongButtons);
            tabHoiDong.Location = new Point(4, 24);
            tabHoiDong.Name = "tabHoiDong";
            tabHoiDong.Size = new Size(792, 522);
            tabHoiDong.TabIndex = 2;
            tabHoiDong.Text = "Hội Đồng";
            // 
            // dgvHoiDong
            // 
            dgvHoiDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiDong.Dock = DockStyle.Fill;
            dgvHoiDong.Location = new Point(0, 0);
            dgvHoiDong.Name = "dgvHoiDong";
            dgvHoiDong.Size = new Size(792, 422);
            dgvHoiDong.TabIndex = 0;
            // 
            // flowLayoutPanelHoiDongButtons
            // 
            flowLayoutPanelHoiDongButtons.Controls.Add(btnTaoHoiDong);
            flowLayoutPanelHoiDongButtons.Controls.Add(btnChinhSuaHoiDong);
            flowLayoutPanelHoiDongButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelHoiDongButtons.Location = new Point(0, 422);
            flowLayoutPanelHoiDongButtons.Name = "flowLayoutPanelHoiDongButtons";
            flowLayoutPanelHoiDongButtons.Size = new Size(792, 100);
            flowLayoutPanelHoiDongButtons.TabIndex = 1;
            // 
            // btnTaoHoiDong
            // 
            btnTaoHoiDong.BackColor = Color.LightSteelBlue;
            btnTaoHoiDong.ForeColor = Color.White;
            btnTaoHoiDong.Location = new Point(3, 3);
            btnTaoHoiDong.Name = "btnTaoHoiDong";
            btnTaoHoiDong.Size = new Size(75, 23);
            btnTaoHoiDong.TabIndex = 0;
            btnTaoHoiDong.Text = "Tạo Hội Đồng";
            btnTaoHoiDong.UseVisualStyleBackColor = false;
            btnTaoHoiDong.Click += btnTaoHoiDong_Click;
            // 
            // btnChinhSuaHoiDong
            // 
            btnChinhSuaHoiDong.BackColor = Color.LightSteelBlue;
            btnChinhSuaHoiDong.ForeColor = Color.White;
            btnChinhSuaHoiDong.Location = new Point(84, 3);
            btnChinhSuaHoiDong.Name = "btnChinhSuaHoiDong";
            btnChinhSuaHoiDong.Size = new Size(75, 23);
            btnChinhSuaHoiDong.TabIndex = 1;
            btnChinhSuaHoiDong.Text = "Chỉnh Sửa Hội Đồng";
            btnChinhSuaHoiDong.UseVisualStyleBackColor = false;
            btnChinhSuaHoiDong.Click += btnChinhSuaHoiDong_Click;
            // 
            // tabDangKy
            // 
            tabDangKy.BackColor = Color.Honeydew;
            tabDangKy.Controls.Add(dgvDangKy);
            tabDangKy.Controls.Add(flowLayoutPanelDangKyButtons);
            tabDangKy.Location = new Point(4, 24);
            tabDangKy.Name = "tabDangKy";
            tabDangKy.Size = new Size(792, 522);
            tabDangKy.TabIndex = 3;
            tabDangKy.Text = "Đăng Ký";
            // 
            // dgvDangKy
            // 
            dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDangKy.Dock = DockStyle.Fill;
            dgvDangKy.Location = new Point(0, 0);
            dgvDangKy.Name = "dgvDangKy";
            dgvDangKy.Size = new Size(792, 422);
            dgvDangKy.TabIndex = 0;
            // 
            // flowLayoutPanelDangKyButtons
            // 
            flowLayoutPanelDangKyButtons.Controls.Add(btnCapNhatTrangThaiDangKy);
            flowLayoutPanelDangKyButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelDangKyButtons.Location = new Point(0, 422);
            flowLayoutPanelDangKyButtons.Name = "flowLayoutPanelDangKyButtons";
            flowLayoutPanelDangKyButtons.Size = new Size(792, 100);
            flowLayoutPanelDangKyButtons.TabIndex = 1;
            // 
            // btnCapNhatTrangThaiDangKy
            // 
            btnCapNhatTrangThaiDangKy.BackColor = Color.LightSteelBlue;
            btnCapNhatTrangThaiDangKy.ForeColor = Color.White;
            btnCapNhatTrangThaiDangKy.Location = new Point(3, 3);
            btnCapNhatTrangThaiDangKy.Name = "btnCapNhatTrangThaiDangKy";
            btnCapNhatTrangThaiDangKy.Size = new Size(75, 23);
            btnCapNhatTrangThaiDangKy.TabIndex = 0;
            btnCapNhatTrangThaiDangKy.Text = "Cập Nhật Trạng Thái Đăng Ký";
            btnCapNhatTrangThaiDangKy.UseVisualStyleBackColor = false;
            btnCapNhatTrangThaiDangKy.Click += btnCapNhatTrangThaiDangKy_Click;
            // 
            // tabNhom
            // 
            tabNhom.BackColor = Color.LavenderBlush;
            tabNhom.Controls.Add(dgvNhom);
            tabNhom.Controls.Add(flowLayoutPanelNhomButtons);
            tabNhom.Location = new Point(4, 24);
            tabNhom.Name = "tabNhom";
            tabNhom.Size = new Size(792, 522);
            tabNhom.TabIndex = 4;
            tabNhom.Text = "Nhóm";
            // 
            // dgvNhom
            // 
            dgvNhom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhom.Dock = DockStyle.Fill;
            dgvNhom.Location = new Point(0, 0);
            dgvNhom.Name = "dgvNhom";
            dgvNhom.Size = new Size(792, 422);
            dgvNhom.TabIndex = 0;
            // 
            // flowLayoutPanelNhomButtons
            // 
            flowLayoutPanelNhomButtons.Controls.Add(btnChinhSuaNhom);
            flowLayoutPanelNhomButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNhomButtons.Location = new Point(0, 422);
            flowLayoutPanelNhomButtons.Name = "flowLayoutPanelNhomButtons";
            flowLayoutPanelNhomButtons.Size = new Size(792, 100);
            flowLayoutPanelNhomButtons.TabIndex = 1;
            // 
            // btnChinhSuaNhom
            // 
            btnChinhSuaNhom.BackColor = Color.LightSteelBlue;
            btnChinhSuaNhom.ForeColor = Color.White;
            btnChinhSuaNhom.Location = new Point(3, 3);
            btnChinhSuaNhom.Name = "btnChinhSuaNhom";
            btnChinhSuaNhom.Size = new Size(75, 23);
            btnChinhSuaNhom.TabIndex = 0;
            btnChinhSuaNhom.Text = "Chỉnh Sửa Nhóm";
            btnChinhSuaNhom.UseVisualStyleBackColor = false;
            btnChinhSuaNhom.Click += btnChinhSuaNhom_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.AutoSize = true;
            btnDangXuat.BackColor = Color.Red;
            btnDangXuat.Dock = DockStyle.Right;
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(725, 0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(75, 50);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // panelTren
            // 
            panelTren.BackColor = Color.LightGray;
            panelTren.Controls.Add(btnDangXuat);
            panelTren.Dock = DockStyle.Top;
            panelTren.Location = new Point(0, 0);
            panelTren.Name = "panelTren";
            panelTren.Size = new Size(800, 50);
            panelTren.TabIndex = 1;
            // 
            // QuanLyAdminForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(tabControl);
            Controls.Add(panelTren);
            Name = "QuanLyAdminForm";
            Text = "Quản Lý Hệ Thống";
            tabControl.ResumeLayout(false);
            tabNguoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).EndInit();
            flowLayoutPanelNguoiDungButtons.ResumeLayout(false);
            tabMocThoiGian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMocThoiGian).EndInit();
            flowLayoutPanelMocThoiGianButtons.ResumeLayout(false);
            tabHoiDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).EndInit();
            flowLayoutPanelHoiDongButtons.ResumeLayout(false);
            tabDangKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDangKy).EndInit();
            flowLayoutPanelDangKyButtons.ResumeLayout(false);
            tabNhom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhom).EndInit();
            flowLayoutPanelNhomButtons.ResumeLayout(false);
            panelTren.ResumeLayout(false);
            panelTren.PerformLayout();
            ResumeLayout(false);
        }
    }
}
