// FormSinhVien.Designer.cs

namespace ThesisManagementSystem.Forms
{
    partial class SinhVienForm
    {
        private System.ComponentModel.IContainer components = null;

        // Các control của form
        private Label lblThongTinSinhVien;
        private Label lblTen;
        private Label lblLop;
        private TabControl tabControl;
        private TabPage tabNhom;
        private TabPage tabDeTai;
        private TabPage tabKetQua;
        private TabPage tabNopVanBan;
        private DataGridView dgvThanhVienNhom;
        private Button btnTaoNhom;
        private Button btnThemThanhVien; // Button thêm thành viên
        private Button btnDangXuat; // Button đăng xuất
        private TextBox txtTenNhom;
        private TextBox txtSinhVienThem; // TextBox để nhập thông tin thành viên
        private Label lblThemThanhVien; // Label cho TextBox
        private DataGridView dgvDeTaiTrongHoiDong;
        private Button btnDangKyDeTai;
        private DataGridView dgvKetQua;
        private DataGridView dgvDiemBaoVe; // DataGridView mới cho DefenseScore
        private DataGridView dgvKiHan;
        private Button btnNopVanBan;
        private Button btnSuaVanBan; // Button Edit Document
        private FlowLayoutPanel flowLayoutPanelNhomButtons;
        private FlowLayoutPanel flowLayoutPanelDeTaiButtons;
        private FlowLayoutPanel flowLayoutPanelNopVanBanButtons;

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel thongTinSinhVienLayout;

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
            lblThongTinSinhVien = new Label();
            lblTen = new Label();
            lblLop = new Label();
            tabControl = new TabControl();
            tabNhom = new TabPage();
            dgvThanhVienNhom = new DataGridView();
            flowLayoutPanelNhomButtons = new FlowLayoutPanel();
            txtTenNhom = new TextBox();
            btnTaoNhom = new Button();
            lblThemThanhVien = new Label();
            txtSinhVienThem = new TextBox();
            btnThemThanhVien = new Button();
            btnDangXuat = new Button();
            tabDeTai = new TabPage();
            dgvDeTaiTrongHoiDong = new DataGridView();
            flowLayoutPanelDeTaiButtons = new FlowLayoutPanel();
            btnDangKyDeTai = new Button();
            tabKetQua = new TabPage();
            dgvKetQua = new DataGridView();
            dgvDiemBaoVe = new DataGridView(); // Initialize DefenseScore DataGridView
            tabNopVanBan = new TabPage();
            dgvKiHan = new DataGridView();
            flowLayoutPanelNopVanBanButtons = new FlowLayoutPanel();
            btnNopVanBan = new Button();
            btnSuaVanBan = new Button(); // Initialize Edit Document Button

            mainLayout = new TableLayoutPanel();
            thongTinSinhVienLayout = new TableLayoutPanel();

            // Suspend Layouts
            tabControl.SuspendLayout();
            tabNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThanhVienNhom).BeginInit();
            flowLayoutPanelNhomButtons.SuspendLayout();
            tabDeTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeTaiTrongHoiDong).BeginInit();
            flowLayoutPanelDeTaiButtons.SuspendLayout();
            tabKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiemBaoVe).BeginInit(); // Begin Init DefenseScores
            tabNopVanBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKiHan).BeginInit();
            flowLayoutPanelNopVanBanButtons.SuspendLayout();
            mainLayout.SuspendLayout();
            thongTinSinhVienLayout.SuspendLayout();
            SuspendLayout();

            // 
            // lblThongTinSinhVien
            // 
            lblThongTinSinhVien.AutoSize = true;
            thongTinSinhVienLayout.SetColumnSpan(lblThongTinSinhVien, 2);
            lblThongTinSinhVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblThongTinSinhVien.Location = new Point(3, 0);
            lblThongTinSinhVien.Name = "lblThongTinSinhVien";
            lblThongTinSinhVien.Size = new Size(177, 21);
            lblThongTinSinhVien.TabIndex = 0;
            lblThongTinSinhVien.Text = "Thông Tin Sinh Viên";

            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(3, 21);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(38, 15);
            lblTen.TabIndex = 1;
            lblTen.Text = "Tên: ";

            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(3, 36);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(31, 15);
            lblLop.TabIndex = 2;
            lblLop.Text = "Lớp: ";

            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabNhom);
            tabControl.Controls.Add(tabDeTai);
            tabControl.Controls.Add(tabKetQua);
            tabControl.Controls.Add(tabNopVanBan);
            tabControl.Location = new Point(3, 109);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(881, 388);
            tabControl.TabIndex = 3;

            // 
            // tabNhom
            // 
            tabNhom.Controls.Add(dgvThanhVienNhom);
            tabNhom.Controls.Add(flowLayoutPanelNhomButtons);
            tabNhom.Location = new Point(4, 24);
            tabNhom.Name = "tabNhom";
            tabNhom.Padding = new Padding(3);
            tabNhom.Size = new Size(873, 360);
            tabNhom.TabIndex = 0;
            tabNhom.Text = "Nhóm";
            tabNhom.UseVisualStyleBackColor = true;

            // 
            // dgvThanhVienNhom
            // 
            dgvThanhVienNhom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThanhVienNhom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThanhVienNhom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThanhVienNhom.Location = new Point(0, 0);
            dgvThanhVienNhom.Name = "dgvThanhVienNhom";
            dgvThanhVienNhom.ReadOnly = true;
            dgvThanhVienNhom.RowHeadersVisible = false;
            dgvThanhVienNhom.Size = new Size(873, 295);
            dgvThanhVienNhom.TabIndex = 0;

            // 
            // flowLayoutPanelNhomButtons
            // 
            flowLayoutPanelNhomButtons.AutoScroll = true;
            flowLayoutPanelNhomButtons.AutoSize = true;
            flowLayoutPanelNhomButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelNhomButtons.Controls.Add(txtTenNhom);
            flowLayoutPanelNhomButtons.Controls.Add(btnTaoNhom);
            flowLayoutPanelNhomButtons.Controls.Add(lblThemThanhVien);
            flowLayoutPanelNhomButtons.Controls.Add(txtSinhVienThem);
            flowLayoutPanelNhomButtons.Controls.Add(btnThemThanhVien);
            flowLayoutPanelNhomButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNhomButtons.Location = new Point(3, 301);
            flowLayoutPanelNhomButtons.Name = "flowLayoutPanelNhomButtons";
            flowLayoutPanelNhomButtons.Padding = new Padding(10);
            flowLayoutPanelNhomButtons.Size = new Size(867, 56);
            flowLayoutPanelNhomButtons.TabIndex = 1;

            // 
            // txtTenNhom
            // 
            txtTenNhom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTenNhom.Location = new Point(13, 20);
            txtTenNhom.Name = "txtTenNhom";
            txtTenNhom.PlaceholderText = "Tên Nhóm";
            txtTenNhom.Size = new Size(200, 23);
            txtTenNhom.TabIndex = 0;

            // 
            // btnTaoNhom
            // 
            btnTaoNhom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTaoNhom.Location = new Point(219, 13);
            btnTaoNhom.Name = "btnTaoNhom";
            btnTaoNhom.Size = new Size(100, 30);
            btnTaoNhom.TabIndex = 1;
            btnTaoNhom.Text = "Tạo Nhóm";
            btnTaoNhom.UseVisualStyleBackColor = true;
            btnTaoNhom.Click += btnTaoNhom_Click;

            // 
            // lblThemThanhVien
            // 
            lblThemThanhVien.AutoSize = true;
            lblThemThanhVien.Location = new Point(342, 10);
            lblThemThanhVien.Margin = new Padding(20, 0, 3, 0);
            lblThemThanhVien.Name = "lblThemThanhVien";
            lblThemThanhVien.Size = new Size(169, 15);
            lblThemThanhVien.TabIndex = 2;
            lblThemThanhVien.Text = "Mã Sinh Viên hoặc Tên để Thêm:";

            // 
            // txtSinhVienThem
            // 
            txtSinhVienThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtSinhVienThem.Location = new Point(535, 20);
            txtSinhVienThem.Name = "txtSinhVienThem";
            txtSinhVienThem.PlaceholderText = "Nhập ID hoặc Tên";
            txtSinhVienThem.Size = new Size(150, 23);
            txtSinhVienThem.TabIndex = 3;

            // 
            // btnThemThanhVien
            // 
            btnThemThanhVien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnThemThanhVien.Location = new Point(691, 13);
            btnThemThanhVien.Name = "btnThemThanhVien";
            btnThemThanhVien.Size = new Size(120, 30);
            btnThemThanhVien.TabIndex = 4;
            btnThemThanhVien.Text = "Thêm Thành Viên";
            btnThemThanhVien.UseVisualStyleBackColor = true;
            btnThemThanhVien.Click += btnThemThanhVien_Click;

            // 
            // btnDangXuat
            // 
            btnDangXuat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDangXuat.Location = new Point(200, 39);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(100, 30);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;

            // 
            // tabDeTai
            // 
            tabDeTai.Controls.Add(dgvDeTaiTrongHoiDong);
            tabDeTai.Controls.Add(flowLayoutPanelDeTaiButtons);
            tabDeTai.Location = new Point(4, 24);
            tabDeTai.Name = "tabDeTai";
            tabDeTai.Padding = new Padding(3);
            tabDeTai.Size = new Size(873, 360);
            tabDeTai.TabIndex = 1;
            tabDeTai.Text = "Đề Tài";
            tabDeTai.UseVisualStyleBackColor = true;

            // 
            // dgvDeTaiTrongHoiDong
            // 
            dgvDeTaiTrongHoiDong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDeTaiTrongHoiDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeTaiTrongHoiDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeTaiTrongHoiDong.Location = new Point(0, 0);
            dgvDeTaiTrongHoiDong.Name = "dgvDeTaiTrongHoiDong";
            dgvDeTaiTrongHoiDong.Size = new Size(873, 295);
            dgvDeTaiTrongHoiDong.TabIndex = 0;

            // 
            // flowLayoutPanelDeTaiButtons
            // 
            flowLayoutPanelDeTaiButtons.AutoScroll = true;
            flowLayoutPanelDeTaiButtons.AutoSize = true;
            flowLayoutPanelDeTaiButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelDeTaiButtons.Controls.Add(btnDangKyDeTai);
            flowLayoutPanelDeTaiButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelDeTaiButtons.Location = new Point(3, 301);
            flowLayoutPanelDeTaiButtons.Name = "flowLayoutPanelDeTaiButtons";
            flowLayoutPanelDeTaiButtons.Padding = new Padding(10);
            flowLayoutPanelDeTaiButtons.Size = new Size(867, 56);
            flowLayoutPanelDeTaiButtons.TabIndex = 1;

            // 
            // btnDangKyDeTai
            // 
            btnDangKyDeTai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDangKyDeTai.Location = new Point(13, 13);
            btnDangKyDeTai.Name = "btnDangKyDeTai";
            btnDangKyDeTai.Size = new Size(150, 30);
            btnDangKyDeTai.TabIndex = 0;
            btnDangKyDeTai.Text = "Đăng Ký Đề Tài";
            btnDangKyDeTai.UseVisualStyleBackColor = true;
            btnDangKyDeTai.Click += btnDangKyDeTai_Click;

            // 
            // tabKetQua
            // 
            tabKetQua.Controls.Add(dgvKetQua);
            tabKetQua.Controls.Add(dgvDiemBaoVe); // Add DefenseScore DataGridView
            tabKetQua.Location = new Point(4, 24);
            tabKetQua.Name = "tabKetQua";
            tabKetQua.Padding = new Padding(3);
            tabKetQua.Size = new Size(873, 360);
            tabKetQua.TabIndex = 2;
            tabKetQua.Text = "Kết Quả";
            tabKetQua.UseVisualStyleBackColor = true;

            // 
            // dgvKetQua
            // 
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Location = new Point(0, 0);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.ReadOnly = true;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.Size = new Size(873, 180); // Shrink height
            dgvKetQua.TabIndex = 0;

            // Define columns for dgvKetQua
            dgvKetQua.Columns.Clear();
            dgvKetQua.Columns.Add("Loai", "Loại");
            dgvKetQua.Columns.Add("Diem", "Điểm");
            dgvKetQua.Columns.Add("NhanXet", "Nhận Xét");
            dgvKetQua.Columns.Add("NgayDanhGia", "Ngày Đánh Giá");
            dgvKetQua.Columns.Add("TenNguoiDanhGia", "Người Đánh Giá");
            dgvKetQua.Columns.Add("VaiTro", "Vai Trò");


            dgvKetQua.Columns["Diem"].DefaultCellStyle.Format = "N2";
            dgvKetQua.Columns["NgayDanhGia"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 
            // dgvDiemBaoVe
            // 
            dgvDiemBaoVe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDiemBaoVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiemBaoVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiemBaoVe.Location = new Point(0, 190); // Position below dgvKetQua
            dgvDiemBaoVe.Name = "dgvDiemBaoVe";
            dgvDiemBaoVe.ReadOnly = true;
            dgvDiemBaoVe.RowHeadersVisible = false;
            dgvDiemBaoVe.Size = new Size(873, 170); // Adjust size
            dgvDiemBaoVe.TabIndex = 1;

            // Define columns for dgvDiemBaoVe
            dgvDiemBaoVe.Columns.Clear();
            dgvDiemBaoVe.Columns.Add("LoaiBaoVe", "Loại Bảo Vệ");
            dgvDiemBaoVe.Columns.Add("DiemBaoVe", "Điểm Bảo Vệ");
            dgvDiemBaoVe.Columns.Add("NhanXetBaoVe", "Nhận Xét Bảo Vệ");
            dgvDiemBaoVe.Columns.Add("NgayBaoVe", "Ngày Bảo Vệ");
            dgvDiemBaoVe.Columns.Add("TenNguoiBaoVe", "Người Bảo Vệ");
            dgvDiemBaoVe.Columns.Add("VaiTroBaoVe", "Vai Trò");


            dgvDiemBaoVe.Columns["DiemBaoVe"].DefaultCellStyle.Format = "N2";
            dgvDiemBaoVe.Columns["NgayBaoVe"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 
            // tabNopVanBan
            // 
            tabNopVanBan.Controls.Add(dgvKiHan);
            tabNopVanBan.Controls.Add(flowLayoutPanelNopVanBanButtons);
            tabNopVanBan.Location = new Point(4, 24);
            tabNopVanBan.Name = "tabNopVanBan";
            tabNopVanBan.Padding = new Padding(3);
            tabNopVanBan.Size = new Size(873, 360);
            tabNopVanBan.TabIndex = 3;
            tabNopVanBan.Text = "Nộp Văn Bản";
            tabNopVanBan.UseVisualStyleBackColor = true;

            // 
            // dgvKiHan
            // 
            dgvKiHan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKiHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKiHan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKiHan.Location = new Point(0, 0);
            dgvKiHan.Name = "dgvKiHan";
            dgvKiHan.ReadOnly = true;
            dgvKiHan.RowHeadersVisible = false;
            dgvKiHan.Size = new Size(873, 295);
            dgvKiHan.TabIndex = 0;

            // 
            // flowLayoutPanelNopVanBanButtons
            // 
            flowLayoutPanelNopVanBanButtons.AutoScroll = true;
            flowLayoutPanelNopVanBanButtons.AutoSize = true;
            flowLayoutPanelNopVanBanButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelNopVanBanButtons.Controls.Add(btnNopVanBan);
            flowLayoutPanelNopVanBanButtons.Controls.Add(btnSuaVanBan); // Add Edit Document Button
            flowLayoutPanelNopVanBanButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelNopVanBanButtons.Location = new Point(3, 301);
            flowLayoutPanelNopVanBanButtons.Name = "flowLayoutPanelNopVanBanButtons";
            flowLayoutPanelNopVanBanButtons.Padding = new Padding(10);
            flowLayoutPanelNopVanBanButtons.Size = new Size(867, 56);
            flowLayoutPanelNopVanBanButtons.TabIndex = 1;

            // 
            // btnNopVanBan
            // 
            btnNopVanBan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNopVanBan.Location = new Point(13, 13);
            btnNopVanBan.Name = "btnNopVanBan";
            btnNopVanBan.Size = new Size(150, 30);
            btnNopVanBan.TabIndex = 0;
            btnNopVanBan.Text = "Nộp Văn Bản";
            btnNopVanBan.UseVisualStyleBackColor = true;
            btnNopVanBan.Click += btnNopVanBan_Click;

            // 
            // btnSuaVanBan
            // 
            btnSuaVanBan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSuaVanBan.Location = new Point(173, 13);
            btnSuaVanBan.Name = "btnSuaVanBan";
            btnSuaVanBan.Size = new Size(150, 30);
            btnSuaVanBan.TabIndex = 1;
            btnSuaVanBan.Text = "Sửa Văn Bản";
            btnSuaVanBan.UseVisualStyleBackColor = true;
            btnSuaVanBan.Click += btnSuaVanBan_Click;

            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(thongTinSinhVienLayout, 0, 0);
            mainLayout.Controls.Add(tabControl, 0, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(887, 500);
            mainLayout.TabIndex = 0;

            // 
            // thongTinSinhVienLayout
            // 
            thongTinSinhVienLayout.ColumnCount = 2;
            thongTinSinhVienLayout.ColumnStyles.Add(new ColumnStyle());
            thongTinSinhVienLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            thongTinSinhVienLayout.Controls.Add(lblThongTinSinhVien, 0, 0);
            thongTinSinhVienLayout.Controls.Add(lblTen, 0, 1);
            thongTinSinhVienLayout.Controls.Add(lblLop, 0, 2);
            thongTinSinhVienLayout.Controls.Add(btnDangXuat, 1, 2);
            thongTinSinhVienLayout.Dock = DockStyle.Top;
            thongTinSinhVienLayout.Location = new Point(3, 3);
            thongTinSinhVienLayout.Name = "thongTinSinhVienLayout";
            thongTinSinhVienLayout.RowCount = 3;
            thongTinSinhVienLayout.RowStyles.Add(new RowStyle());
            thongTinSinhVienLayout.RowStyles.Add(new RowStyle());
            thongTinSinhVienLayout.RowStyles.Add(new RowStyle());
            thongTinSinhVienLayout.Size = new Size(881, 100);
            thongTinSinhVienLayout.TabIndex = 0;

            // 
            // FormSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 500);
            Controls.Add(mainLayout);
            Name = "FormSinhVien";
            Text = "Cổng Sinh Viên";
            Load += FormSinhVien_Load;
            tabControl.ResumeLayout(false);
            tabNhom.ResumeLayout(false);
            tabNhom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThanhVienNhom).EndInit();
            flowLayoutPanelNhomButtons.ResumeLayout(false);
            flowLayoutPanelNhomButtons.PerformLayout();
            tabDeTai.ResumeLayout(false);
            tabDeTai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeTaiTrongHoiDong).EndInit();
            flowLayoutPanelDeTaiButtons.ResumeLayout(false);
            tabKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiemBaoVe).EndInit();
            tabNopVanBan.ResumeLayout(false);
            tabNopVanBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKiHan).EndInit();
            flowLayoutPanelNopVanBanButtons.ResumeLayout(false);
            flowLayoutPanelNopVanBanButtons.PerformLayout();
            mainLayout.ResumeLayout(false);
            thongTinSinhVienLayout.ResumeLayout(false);
            thongTinSinhVienLayout.PerformLayout();
            ResumeLayout(false);
        }
    }
}
