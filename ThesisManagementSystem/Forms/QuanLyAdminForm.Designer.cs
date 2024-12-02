using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

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
        private TabPage tabNhom; // Thêm tab Nhóm
        private DataGridView dgvNguoiDung;
        private DataGridView dgvMocThoiGian;
        private DataGridView dgvHoiDong;
        private DataGridView dgvDangKy;
        private DataGridView dgvNhom; // DataGridView cho Nhóm
        private Button btnTaoHoiDong;
        private Button btnChinhSuaHoiDong;
        private Button btnCapNhatTrangThaiDangKy;
        private Button btnTaoNguoiDung;
        private Button btnChinhSuaNguoiDung;
        private Button btnXoaNguoiDung;
        private Button btnTaoMocThoiGian;
        private Button btnChinhSuaMocThoiGian;
        private Button btnDangXuat;
        private Button btnChinhSuaNhom; // Nút chỉnh sửa nhóm
        private FlowLayoutPanel flowLayoutPanelNguoiDungButtons;
        private FlowLayoutPanel flowLayoutPanelMocThoiGianButtons;
        private FlowLayoutPanel flowLayoutPanelHoiDongButtons;
        private FlowLayoutPanel flowLayoutPanelDangKyButtons;
        private FlowLayoutPanel flowLayoutPanelNhomButtons; // FlowLayoutPanel cho Nhóm
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
            // Khởi tạo các thành phần
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
            tabNhom = new TabPage(); // Khởi tạo tab Nhóm
            dgvNhom = new DataGridView(); // Khởi tạo DataGridView cho Nhóm
            flowLayoutPanelNhomButtons = new FlowLayoutPanel(); // Khởi tạo FlowLayoutPanel cho Nhóm
            btnChinhSuaNhom = new Button(); // Khởi tạo nút chỉnh sửa nhóm
            btnDangXuat = new Button();
            panelTren = new Panel();

            // Suspend Layouts
            tabControl.SuspendLayout();
            tabNguoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).BeginInit();
            flowLayoutPanelNguoiDungButtons.SuspendLayout();
            tabMocThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMocThoiGian).BeginInit();
            tabHoiDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).BeginInit();
            flowLayoutPanelHoiDongButtons.SuspendLayout();
            tabDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDangKy).BeginInit();
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
            tabControl.Controls.Add(tabNhom); // Thêm tabNhom vào tabControl
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(784, 391);
            tabControl.TabIndex = 1;

            // 
            // tabNguoiDung
            // 
            tabNguoiDung.Controls.Add(dgvNguoiDung);
            tabNguoiDung.Controls.Add(flowLayoutPanelNguoiDungButtons);
            tabNguoiDung.Location = new System.Drawing.Point(4, 24);
            tabNguoiDung.Name = "tabNguoiDung";
            tabNguoiDung.Padding = new Padding(3);
            tabNguoiDung.Size = new System.Drawing.Size(776, 363);
            tabNguoiDung.TabIndex = 0;
            tabNguoiDung.Text = "Người Dùng";
            tabNguoiDung.UseVisualStyleBackColor = true;

            // 
            // dgvNguoiDung
            // 
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNguoiDung.Dock = DockStyle.Fill;
            dgvNguoiDung.Location = new System.Drawing.Point(3, 3);
            dgvNguoiDung.Name = "dgvNguoiDung";
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.RowHeadersVisible = false;
            dgvNguoiDung.Size = new System.Drawing.Size(770, 313);
            dgvNguoiDung.TabIndex = 0;

            // 
            // flowLayoutPanelNguoiDungButtons
            // 
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnTaoNguoiDung);
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnChinhSuaNguoiDung);
            flowLayoutPanelNguoiDungButtons.Controls.Add(btnXoaNguoiDung);
            flowLayoutPanelNguoiDungButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNguoiDungButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelNguoiDungButtons.WrapContents = false;
            flowLayoutPanelNguoiDungButtons.AutoSize = true;
            flowLayoutPanelNguoiDungButtons.Padding = new Padding(10);
            flowLayoutPanelNguoiDungButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnTaoNguoiDung
            // 
            btnTaoNguoiDung.AutoSize = true;
            btnTaoNguoiDung.Margin = new Padding(0, 0, 10, 0);
            btnTaoNguoiDung.Name = "btnTaoNguoiDung";
            btnTaoNguoiDung.Size = new System.Drawing.Size(120, 30);
            btnTaoNguoiDung.TabIndex = 1;
            btnTaoNguoiDung.Text = "Tạo Người Dùng";
            btnTaoNguoiDung.UseVisualStyleBackColor = true;
            btnTaoNguoiDung.Click += btnTaoNguoiDung_Click;

            // 
            // btnChinhSuaNguoiDung
            // 
            btnChinhSuaNguoiDung.AutoSize = true;
            btnChinhSuaNguoiDung.Margin = new Padding(0, 0, 10, 0);
            btnChinhSuaNguoiDung.Name = "btnChinhSuaNguoiDung";
            btnChinhSuaNguoiDung.Size = new System.Drawing.Size(150, 30);
            btnChinhSuaNguoiDung.TabIndex = 2;
            btnChinhSuaNguoiDung.Text = "Chỉnh Sửa Người Dùng";
            btnChinhSuaNguoiDung.UseVisualStyleBackColor = true;
            btnChinhSuaNguoiDung.Click += btnChinhSuaNguoiDung_Click;

            // 
            // btnXoaNguoiDung
            // 
            btnXoaNguoiDung.AutoSize = true;
            btnXoaNguoiDung.Margin = new Padding(0, 0, 10, 0);
            btnXoaNguoiDung.Name = "btnXoaNguoiDung";
            btnXoaNguoiDung.Size = new System.Drawing.Size(120, 30);
            btnXoaNguoiDung.TabIndex = 3;
            btnXoaNguoiDung.Text = "Xóa Người Dùng";
            btnXoaNguoiDung.UseVisualStyleBackColor = true;
            btnXoaNguoiDung.Click += btnXoaNguoiDung_Click;

            // 
            // tabMocThoiGian
            // 
            tabMocThoiGian.Controls.Add(dgvMocThoiGian);
            tabMocThoiGian.Controls.Add(flowLayoutPanelMocThoiGianButtons);
            tabMocThoiGian.Location = new System.Drawing.Point(4, 24);
            tabMocThoiGian.Name = "tabMocThoiGian";
            tabMocThoiGian.Padding = new Padding(3);
            tabMocThoiGian.Size = new System.Drawing.Size(776, 363);
            tabMocThoiGian.TabIndex = 1;
            tabMocThoiGian.Text = "Mốc Thời Gian";
            tabMocThoiGian.UseVisualStyleBackColor = true;

            // 
            // dgvMocThoiGian
            // 
            dgvMocThoiGian.AllowUserToAddRows = false;
            dgvMocThoiGian.AllowUserToDeleteRows = false;
            dgvMocThoiGian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMocThoiGian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMocThoiGian.Dock = DockStyle.Fill;
            dgvMocThoiGian.Location = new System.Drawing.Point(3, 3);
            dgvMocThoiGian.Name = "dgvMocThoiGian";
            dgvMocThoiGian.ReadOnly = true;
            dgvMocThoiGian.RowHeadersVisible = false;
            dgvMocThoiGian.Size = new System.Drawing.Size(770, 316);
            dgvMocThoiGian.TabIndex = 0;

            // 
            // flowLayoutPanelMocThoiGianButtons
            // 
            flowLayoutPanelMocThoiGianButtons.Controls.Add(btnTaoMocThoiGian);
            flowLayoutPanelMocThoiGianButtons.Controls.Add(btnChinhSuaMocThoiGian);
            flowLayoutPanelMocThoiGianButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelMocThoiGianButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelMocThoiGianButtons.WrapContents = false;
            flowLayoutPanelMocThoiGianButtons.AutoSize = true;
            flowLayoutPanelMocThoiGianButtons.Padding = new Padding(10);
            flowLayoutPanelMocThoiGianButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnTaoMocThoiGian
            // 
            btnTaoMocThoiGian.AutoSize = true;
            btnTaoMocThoiGian.Margin = new Padding(0, 0, 10, 0);
            btnTaoMocThoiGian.Name = "btnTaoMocThoiGian";
            btnTaoMocThoiGian.Size = new System.Drawing.Size(150, 30);
            btnTaoMocThoiGian.TabIndex = 1;
            btnTaoMocThoiGian.Text = "Tạo Mốc Thời Gian";
            btnTaoMocThoiGian.UseVisualStyleBackColor = true;
            btnTaoMocThoiGian.Click += btnTaoMocThoiGian_Click;

            // 
            // btnChinhSuaMocThoiGian
            // 
            btnChinhSuaMocThoiGian.AutoSize = true;
            btnChinhSuaMocThoiGian.Margin = new Padding(0, 0, 10, 0);
            btnChinhSuaMocThoiGian.Name = "btnChinhSuaMocThoiGian";
            btnChinhSuaMocThoiGian.Size = new System.Drawing.Size(150, 30);
            btnChinhSuaMocThoiGian.TabIndex = 2;
            btnChinhSuaMocThoiGian.Text = "Chỉnh Sửa Mốc Thời Gian";
            btnChinhSuaMocThoiGian.UseVisualStyleBackColor = true;
            btnChinhSuaMocThoiGian.Click += btnChinhSuaMocThoiGian_Click;

            // 
            // tabHoiDong
            // 
            tabHoiDong.Controls.Add(dgvHoiDong);
            tabHoiDong.Controls.Add(flowLayoutPanelHoiDongButtons);
            tabHoiDong.Location = new System.Drawing.Point(4, 24);
            tabHoiDong.Name = "tabHoiDong";
            tabHoiDong.Padding = new Padding(3);
            tabHoiDong.Size = new System.Drawing.Size(776, 363);
            tabHoiDong.TabIndex = 2;
            tabHoiDong.Text = "Hội Đồng";
            tabHoiDong.UseVisualStyleBackColor = true;

            // 
            // dgvHoiDong
            // 
            dgvHoiDong.AllowUserToAddRows = false;
            dgvHoiDong.AllowUserToDeleteRows = false;
            dgvHoiDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiDong.Dock = DockStyle.Fill;
            dgvHoiDong.Location = new System.Drawing.Point(3, 3);
            dgvHoiDong.Name = "dgvHoiDong";
            dgvHoiDong.ReadOnly = true;
            dgvHoiDong.RowHeadersVisible = false;
            dgvHoiDong.Size = new System.Drawing.Size(770, 316);
            dgvHoiDong.TabIndex = 0;

            // 
            // flowLayoutPanelHoiDongButtons
            // 
            flowLayoutPanelHoiDongButtons.Controls.Add(btnTaoHoiDong);
            flowLayoutPanelHoiDongButtons.Controls.Add(btnChinhSuaHoiDong);
            flowLayoutPanelHoiDongButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelHoiDongButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelHoiDongButtons.WrapContents = false;
            flowLayoutPanelHoiDongButtons.AutoSize = true;
            flowLayoutPanelHoiDongButtons.Padding = new Padding(10);
            flowLayoutPanelHoiDongButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnTaoHoiDong
            // 
            btnTaoHoiDong.AutoSize = true;
            btnTaoHoiDong.Margin = new Padding(0, 0, 10, 0);
            btnTaoHoiDong.Name = "btnTaoHoiDong";
            btnTaoHoiDong.Size = new System.Drawing.Size(150, 30);
            btnTaoHoiDong.TabIndex = 1;
            btnTaoHoiDong.Text = "Tạo Hội Đồng";
            btnTaoHoiDong.UseVisualStyleBackColor = true;
            btnTaoHoiDong.Click += btnTaoHoiDong_Click;

            // 
            // btnChinhSuaHoiDong
            // 
            btnChinhSuaHoiDong.AutoSize = true;
            btnChinhSuaHoiDong.Margin = new Padding(0, 0, 10, 0);
            btnChinhSuaHoiDong.Name = "btnChinhSuaHoiDong";
            btnChinhSuaHoiDong.Size = new System.Drawing.Size(150, 30);
            btnChinhSuaHoiDong.TabIndex = 2;
            btnChinhSuaHoiDong.Text = "Chỉnh Sửa Hội Đồng";
            btnChinhSuaHoiDong.UseVisualStyleBackColor = true;
            btnChinhSuaHoiDong.Click += btnChinhSuaHoiDong_Click;

            // 
            // tabDangKy
            // 
            tabDangKy.Controls.Add(dgvDangKy);
            tabDangKy.Controls.Add(flowLayoutPanelDangKyButtons);
            tabDangKy.Location = new System.Drawing.Point(4, 24);
            tabDangKy.Name = "tabDangKy";
            tabDangKy.Padding = new Padding(3);
            tabDangKy.Size = new System.Drawing.Size(776, 363);
            tabDangKy.TabIndex = 3;
            tabDangKy.Text = "Đăng Ký";
            tabDangKy.UseVisualStyleBackColor = true;

            // 
            // dgvDangKy
            // 
            dgvDangKy.AllowUserToAddRows = false;
            dgvDangKy.AllowUserToDeleteRows = false;
            dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDangKy.Dock = DockStyle.Fill;
            dgvDangKy.Location = new System.Drawing.Point(3, 3);
            dgvDangKy.Name = "dgvDangKy";
            dgvDangKy.ReadOnly = true;
            dgvDangKy.RowHeadersVisible = false;
            dgvDangKy.Size = new System.Drawing.Size(770, 316);
            dgvDangKy.TabIndex = 0;

            // 
            // flowLayoutPanelDangKyButtons
            // 
            flowLayoutPanelDangKyButtons.Controls.Add(btnCapNhatTrangThaiDangKy);
            flowLayoutPanelDangKyButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelDangKyButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelDangKyButtons.WrapContents = false;
            flowLayoutPanelDangKyButtons.AutoSize = true;
            flowLayoutPanelDangKyButtons.Padding = new Padding(10);
            flowLayoutPanelDangKyButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnCapNhatTrangThaiDangKy
            // 
            btnCapNhatTrangThaiDangKy.AutoSize = true;
            btnCapNhatTrangThaiDangKy.Margin = new Padding(0, 0, 10, 0);
            btnCapNhatTrangThaiDangKy.Name = "btnCapNhatTrangThaiDangKy";
            btnCapNhatTrangThaiDangKy.Size = new System.Drawing.Size(200, 30);
            btnCapNhatTrangThaiDangKy.TabIndex = 1;
            btnCapNhatTrangThaiDangKy.Text = "Cập Nhật Trạng Thái Đăng Ký";
            btnCapNhatTrangThaiDangKy.UseVisualStyleBackColor = true;
            btnCapNhatTrangThaiDangKy.Click += btnCapNhatTrangThaiDangKy_Click;

            // 
            // tabNhom
            // 
            tabNhom.Controls.Add(dgvNhom);
            tabNhom.Controls.Add(flowLayoutPanelNhomButtons);
            tabNhom.Location = new System.Drawing.Point(4, 24);
            tabNhom.Name = "tabNhom";
            tabNhom.Padding = new Padding(3);
            tabNhom.Size = new System.Drawing.Size(776, 363);
            tabNhom.TabIndex = 4;
            tabNhom.Text = "Nhóm";
            tabNhom.UseVisualStyleBackColor = true;

            // 
            // dgvNhom
            // 
            dgvNhom.AllowUserToAddRows = false;
            dgvNhom.AllowUserToDeleteRows = false;
            dgvNhom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhom.Dock = DockStyle.Fill;
            dgvNhom.Location = new System.Drawing.Point(3, 3);
            dgvNhom.Name = "dgvNhom";
            dgvNhom.ReadOnly = true;
            dgvNhom.RowHeadersVisible = false;
            dgvNhom.Size = new System.Drawing.Size(770, 316);
            dgvNhom.TabIndex = 0;

            // 
            // flowLayoutPanelNhomButtons
            // 
            flowLayoutPanelNhomButtons.Controls.Add(btnChinhSuaNhom);
            flowLayoutPanelNhomButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNhomButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelNhomButtons.WrapContents = false;
            flowLayoutPanelNhomButtons.AutoSize = true;
            flowLayoutPanelNhomButtons.Padding = new Padding(10);
            flowLayoutPanelNhomButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnChinhSuaNhom
            // 
            btnChinhSuaNhom.AutoSize = true;
            btnChinhSuaNhom.Margin = new Padding(0, 0, 10, 0);
            btnChinhSuaNhom.Name = "btnChinhSuaNhom";
            btnChinhSuaNhom.Size = new System.Drawing.Size(120, 30);
            btnChinhSuaNhom.TabIndex = 2;
            btnChinhSuaNhom.Text = "Chỉnh Sửa Nhóm";
            btnChinhSuaNhom.UseVisualStyleBackColor = true;
            btnChinhSuaNhom.Click += btnChinhSuaNhom_Click;

            // 
            // btnDangXuat
            // 
            btnDangXuat.AutoSize = true;
            btnDangXuat.Dock = DockStyle.Right;
            btnDangXuat.Margin = new Padding(0, 10, 10, 0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new System.Drawing.Size(120, 30);
            btnDangXuat.TabIndex = 4;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;

            // 
            // panelTren
            // 
            panelTren.Controls.Add(btnDangXuat);
            panelTren.Dock = DockStyle.Top;
            panelTren.Height = 50;
            panelTren.Name = "panelTren";
            panelTren.Size = new System.Drawing.Size(784, 50);
            panelTren.TabIndex = 0;

            // 
            // QuanLyAdminForm
            // 
            ClientSize = new System.Drawing.Size(784, 441);
            Controls.Add(tabControl);
            Controls.Add(panelTren);
            Name = "QuanLyAdminForm";
            Text = "Quản Lý Hệ Thống";
            Load += QuanLyAdminForm_Load;
            tabControl.ResumeLayout(false);
            tabNguoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).EndInit();
            flowLayoutPanelNguoiDungButtons.ResumeLayout(false);
            flowLayoutPanelNguoiDungButtons.PerformLayout();
            tabMocThoiGian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMocThoiGian).EndInit();
            flowLayoutPanelMocThoiGianButtons.ResumeLayout(false);
            flowLayoutPanelMocThoiGianButtons.PerformLayout();
            tabHoiDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).EndInit();
            flowLayoutPanelHoiDongButtons.ResumeLayout(false);
            flowLayoutPanelHoiDongButtons.PerformLayout();
            tabDangKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDangKy).EndInit();
            flowLayoutPanelDangKyButtons.ResumeLayout(false);
            flowLayoutPanelDangKyButtons.PerformLayout();
            tabNhom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhom).EndInit();
            flowLayoutPanelNhomButtons.ResumeLayout(false);
            flowLayoutPanelNhomButtons.PerformLayout();
            panelTren.ResumeLayout(false);
            panelTren.PerformLayout();
            ResumeLayout(false);
        }
    }
}
