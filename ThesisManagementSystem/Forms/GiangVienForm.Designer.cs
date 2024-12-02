// FormGiangVien.Designer.cs

namespace ThesisManagementSystem.Forms
{
    partial class GiangVienForm
    {
        /// <summary>
        /// Biến thiết kế cần thiết.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các control của form
        private System.Windows.Forms.Label lblTenGiangVien;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.GroupBox groupBoxQuanLyDeTai;
        private System.Windows.Forms.DataGridView dgvDeTai;
        private System.Windows.Forms.Button btnThemDeTai;
        private System.Windows.Forms.Button btnSuaDeTai;
        private System.Windows.Forms.Button btnXoaDeTai;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNutDeTai;
        private System.Windows.Forms.GroupBox groupBoxNhomSinhVien;
        private System.Windows.Forms.DataGridView dgvNhomSinhVien;
        private System.Windows.Forms.GroupBox groupBoxNhomHoiDongCham; // GroupBox mới cho Nhóm Hội Đồng Chấm
        private System.Windows.Forms.DataGridView dgvNhomHoiDongCham; // DataGridView mới cho Nhóm Hội Đồng Chấm
        private System.Windows.Forms.GroupBox groupBoxKiHan;
        private System.Windows.Forms.DataGridView dgvKiHan;
        private System.Windows.Forms.GroupBox groupBoxNopVanBan;
        private System.Windows.Forms.DataGridView dgvNopVanBan;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnDanhGia;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNutChinh;
        private System.Windows.Forms.GroupBox groupBoxChiTietNhom;
        private System.Windows.Forms.TextBox txtChiTietNhom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChinh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTopTrai; // Thêm FlowLayoutPanelTopLeft
        private System.Windows.Forms.Button btnDangXuat; // Thêm btnLogout
        private System.Windows.Forms.Button btnDanhGiaNhom; // Nút mới để đánh giá nhóm hội đồng

        /// <summary>
        /// Dọn dẹp bất kỳ tài nguyên nào đang được sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên nên được giải phóng; ngược lại, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Phương thức cần thiết cho hỗ trợ Designer - không sửa đổi 
        /// nội dung của phương thức này với trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenGiangVien = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.groupBoxQuanLyDeTai = new System.Windows.Forms.GroupBox();
            this.dgvDeTai = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanelNutDeTai = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemDeTai = new System.Windows.Forms.Button();
            this.btnSuaDeTai = new System.Windows.Forms.Button();
            this.btnXoaDeTai = new System.Windows.Forms.Button();
            this.groupBoxNhomSinhVien = new System.Windows.Forms.GroupBox();
            this.dgvNhomSinhVien = new System.Windows.Forms.DataGridView();
            this.groupBoxNhomHoiDongCham = new System.Windows.Forms.GroupBox(); // Khởi tạo GroupBoxNhomHoiDongCham
            this.dgvNhomHoiDongCham = new System.Windows.Forms.DataGridView(); // Khởi tạo dgvNhomHoiDongCham
            this.groupBoxKiHan = new System.Windows.Forms.GroupBox();
            this.dgvKiHan = new System.Windows.Forms.DataGridView();
            this.groupBoxNopVanBan = new System.Windows.Forms.GroupBox();
            this.dgvNopVanBan = new System.Windows.Forms.DataGridView();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnDanhGia = new System.Windows.Forms.Button();
            this.flowLayoutPanelNutChinh = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxChiTietNhom = new System.Windows.Forms.GroupBox();
            this.txtChiTietNhom = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelChinh = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelTopTrai = new System.Windows.Forms.FlowLayoutPanel(); // Khởi tạo FlowLayoutPanelTopLeft
            this.btnDangXuat = new System.Windows.Forms.Button(); // Khởi tạo btnDangXuat
            this.btnDanhGiaNhom = new System.Windows.Forms.Button(); // Khởi tạo btnDanhGiaNhom
            this.groupBoxQuanLyDeTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeTai)).BeginInit();
            this.flowLayoutPanelNutDeTai.SuspendLayout();
            this.groupBoxNhomSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomSinhVien)).BeginInit();
            this.groupBoxNhomHoiDongCham.SuspendLayout(); // Tạm dừng Layout cho Nhóm Hội Đồng Chấm
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomHoiDongCham)).BeginInit(); // Bắt đầu Init dgvNhomHoiDongCham
            this.groupBoxKiHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiHan)).BeginInit();
            this.groupBoxNopVanBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNopVanBan)).BeginInit();
            this.flowLayoutPanelNutChinh.SuspendLayout();
            this.groupBoxChiTietNhom.SuspendLayout();
            this.tableLayoutPanelChinh.SuspendLayout();
            this.flowLayoutPanelTopTrai.SuspendLayout(); // Tạm dừng Layout cho FlowLayoutPanelTopLeft
            this.SuspendLayout();
            // 
            // lblTenGiangVien
            // 
            this.lblTenGiangVien.AutoSize = true;
            this.lblTenGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGiangVien.Text = "Tên: ";
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoa.Location = new System.Drawing.Point(403, 0);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(394, 30);
            this.lblKhoa.TabIndex = 1;
            this.lblKhoa.Text = "Khoa: ";
            this.lblKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelTopTrai
            // 
            this.flowLayoutPanelTopTrai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTopTrai.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanelTopTrai.Controls.Add(this.lblTenGiangVien);
            this.flowLayoutPanelTopTrai.Controls.Add(this.btnDangXuat);
            this.flowLayoutPanelTopTrai.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelTopTrai.Name = "flowLayoutPanelTopTrai";
            this.flowLayoutPanelTopTrai.Size = new System.Drawing.Size(394, 24);
            this.flowLayoutPanelTopTrai.TabIndex = 10;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDangXuat.AutoSize = true;
            this.btnDangXuat.Location = new System.Drawing.Point(95, 0); // Điều chỉnh vị trí dựa trên FlowLayoutPanel
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0); // Thêm khoảng cách để căn lề
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(75, 24);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // groupBoxQuanLyDeTai
            // 
            this.groupBoxQuanLyDeTai.Controls.Add(this.dgvDeTai);
            this.groupBoxQuanLyDeTai.Controls.Add(this.flowLayoutPanelNutDeTai);
            this.groupBoxQuanLyDeTai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxQuanLyDeTai.Location = new System.Drawing.Point(3, 33);
            this.groupBoxQuanLyDeTai.Name = "groupBoxQuanLyDeTai";
            this.tableLayoutPanelChinh.SetRowSpan(this.groupBoxQuanLyDeTai, 2);
            this.groupBoxQuanLyDeTai.Size = new System.Drawing.Size(394, 434);
            this.groupBoxQuanLyDeTai.TabIndex = 2;
            this.groupBoxQuanLyDeTai.TabStop = false;
            this.groupBoxQuanLyDeTai.Text = "Quản Lý Đề Tài";
            // 
            // dgvDeTai
            // 
            this.dgvDeTai.AllowUserToAddRows = false;
            this.dgvDeTai.AllowUserToDeleteRows = false;
            this.dgvDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeTai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeTai.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDeTai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeTai.Location = new System.Drawing.Point(6, 21);
            this.dgvDeTai.MultiSelect = false;
            this.dgvDeTai.Name = "dgvDeTai";
            this.dgvDeTai.ReadOnly = true;
            this.dgvDeTai.RowHeadersVisible = false;
            this.dgvDeTai.RowTemplate.Height = 24;
            this.dgvDeTai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeTai.Size = new System.Drawing.Size(382, 311);
            this.dgvDeTai.TabIndex = 0;
            // 
            // flowLayoutPanelNutDeTai
            // 
            this.flowLayoutPanelNutDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelNutDeTai.AutoSize = true;
            this.flowLayoutPanelNutDeTai.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelNutDeTai.Controls.Add(this.btnThemDeTai);
            this.flowLayoutPanelNutDeTai.Controls.Add(this.btnSuaDeTai);
            this.flowLayoutPanelNutDeTai.Controls.Add(this.btnXoaDeTai);
            this.flowLayoutPanelNutDeTai.Location = new System.Drawing.Point(250, 337);
            this.flowLayoutPanelNutDeTai.Name = "flowLayoutPanelNutDeTai";
            this.flowLayoutPanelNutDeTai.Size = new System.Drawing.Size(138, 30);
            this.flowLayoutPanelNutDeTai.TabIndex = 1;
            // 
            // btnThemDeTai
            // 
            this.btnThemDeTai.AutoSize = true;
            this.btnThemDeTai.Location = new System.Drawing.Point(35, 3);
            this.btnThemDeTai.Name = "btnThemDeTai";
            this.btnThemDeTai.Size = new System.Drawing.Size(100, 24);
            this.btnThemDeTai.TabIndex = 0;
            this.btnThemDeTai.Text = "Thêm Đề Tài";
            this.btnThemDeTai.UseVisualStyleBackColor = true;
            this.btnThemDeTai.Click += new System.EventHandler(this.btnTaoDeTai_Click);
            // 
            // btnSuaDeTai
            // 
            this.btnSuaDeTai.AutoSize = true;
            this.btnSuaDeTai.Location = new System.Drawing.Point(35, 3);
            this.btnSuaDeTai.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btnSuaDeTai.Name = "btnSuaDeTai";
            this.btnSuaDeTai.Size = new System.Drawing.Size(100, 24);
            this.btnSuaDeTai.TabIndex = 1;
            this.btnSuaDeTai.Text = "Sửa Đề Tài";
            this.btnSuaDeTai.UseVisualStyleBackColor = true;
            this.btnSuaDeTai.Click += new System.EventHandler(this.btnSuaDeTai_Click);
            // 
            // btnXoaDeTai
            // 
            this.btnXoaDeTai.AutoSize = true;
            this.btnXoaDeTai.Location = new System.Drawing.Point(35, 3);
            this.btnXoaDeTai.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btnXoaDeTai.Name = "btnXoaDeTai";
            this.btnXoaDeTai.Size = new System.Drawing.Size(100, 24);
            this.btnXoaDeTai.TabIndex = 2;
            this.btnXoaDeTai.Text = "Xóa Đề Tài";
            this.btnXoaDeTai.UseVisualStyleBackColor = true;
            this.btnXoaDeTai.Click += new System.EventHandler(this.btnXoaDeTai_Click);
            // 
            // groupBoxNhomSinhVien
            // 
            this.groupBoxNhomSinhVien.Controls.Add(this.dgvNhomSinhVien);
            this.groupBoxNhomSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNhomSinhVien.Location = new System.Drawing.Point(403, 33);
            this.groupBoxNhomSinhVien.Name = "groupBoxNhomSinhVien";
            this.groupBoxNhomSinhVien.Size = new System.Drawing.Size(394, 258);
            this.groupBoxNhomSinhVien.TabIndex = 3;
            this.groupBoxNhomSinhVien.TabStop = false;
            this.groupBoxNhomSinhVien.Text = "Danh Sách Nhóm Sinh Viên (Hướng Dẫn)";
            // 
            // dgvNhomSinhVien
            // 
            this.dgvNhomSinhVien.AllowUserToAddRows = false;
            this.dgvNhomSinhVien.AllowUserToDeleteRows = false;
            this.dgvNhomSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhomSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhomSinhVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNhomSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomSinhVien.Location = new System.Drawing.Point(6, 21);
            this.dgvNhomSinhVien.MultiSelect = false;
            this.dgvNhomSinhVien.Name = "dgvNhomSinhVien";
            this.dgvNhomSinhVien.ReadOnly = true;
            this.dgvNhomSinhVien.RowHeadersVisible = false;
            this.dgvNhomSinhVien.RowTemplate.Height = 24;
            this.dgvNhomSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhomSinhVien.Size = new System.Drawing.Size(382, 231);
            this.dgvNhomSinhVien.TabIndex = 0;
            this.dgvNhomSinhVien.SelectionChanged += new System.EventHandler(this.dgvNhomSinhVien_SelectionChanged);
            // 
            // groupBoxNhomHoiDongCham
            // 
            this.groupBoxNhomHoiDongCham.Controls.Add(this.dgvNhomHoiDongCham);
            this.groupBoxNhomHoiDongCham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNhomHoiDongCham.Location = new System.Drawing.Point(403, 297);
            this.groupBoxNhomHoiDongCham.Name = "groupBoxNhomHoiDongCham";
            this.groupBoxNhomHoiDongCham.Size = new System.Drawing.Size(394, 138);
            this.groupBoxNhomHoiDongCham.TabIndex = 4;
            this.groupBoxNhomHoiDongCham.TabStop = false;
            this.groupBoxNhomHoiDongCham.Text = "Danh Sách Nhóm Sinh Viên (Hội Đồng Chấm)";
            // 
            // dgvNhomHoiDongCham
            // 
            this.dgvNhomHoiDongCham.AllowUserToAddRows = false;
            this.dgvNhomHoiDongCham.AllowUserToDeleteRows = false;
            this.dgvNhomHoiDongCham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhomHoiDongCham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhomHoiDongCham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNhomHoiDongCham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomHoiDongCham.Location = new System.Drawing.Point(6, 21);
            this.dgvNhomHoiDongCham.MultiSelect = false;
            this.dgvNhomHoiDongCham.Name = "dgvNhomHoiDongCham";
            this.dgvNhomHoiDongCham.ReadOnly = true;
            this.dgvNhomHoiDongCham.RowHeadersVisible = false;
            this.dgvNhomHoiDongCham.RowTemplate.Height = 24;
            this.dgvNhomHoiDongCham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhomHoiDongCham.Size = new System.Drawing.Size(382, 111);
            this.dgvNhomHoiDongCham.TabIndex = 0;
            this.dgvNhomHoiDongCham.SelectionChanged += new System.EventHandler(this.dgvNhomHoiDongCham_SelectionChanged);
            // 
            // groupBoxKiHan
            // 
            this.groupBoxKiHan.Controls.Add(this.dgvKiHan);
            this.groupBoxKiHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxKiHan.Location = new System.Drawing.Point(403, 441);
            this.groupBoxKiHan.Name = "groupBoxKiHan";
            this.groupBoxKiHan.Size = new System.Drawing.Size(394, 200);
            this.groupBoxKiHan.TabIndex = 5;
            this.groupBoxKiHan.TabStop = false;
            this.groupBoxKiHan.Text = "Danh Sách Milestones";
            // 
            // dgvKiHan
            // 
            this.dgvKiHan.AllowUserToAddRows = false;
            this.dgvKiHan.AllowUserToDeleteRows = false;
            this.dgvKiHan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKiHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiHan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKiHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiHan.Location = new System.Drawing.Point(6, 21);
            this.dgvKiHan.MultiSelect = false;
            this.dgvKiHan.Name = "dgvKiHan";
            this.dgvKiHan.ReadOnly = true;
            this.dgvKiHan.RowHeadersVisible = false;
            this.dgvKiHan.RowTemplate.Height = 24;
            this.dgvKiHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKiHan.Size = new System.Drawing.Size(382, 173);
            this.dgvKiHan.TabIndex = 0;
            // 
            // groupBoxNopVanBan
            // 
            this.groupBoxNopVanBan.Controls.Add(this.dgvNopVanBan);
            this.groupBoxNopVanBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNopVanBan.Location = new System.Drawing.Point(3, 597);
            this.groupBoxNopVanBan.Name = "groupBoxNopVanBan";
            this.groupBoxNopVanBan.Size = new System.Drawing.Size(394, 44);
            this.groupBoxNopVanBan.TabIndex = 6;
            this.groupBoxNopVanBan.TabStop = false;
            this.groupBoxNopVanBan.Text = "Danh Sách Submissions";
            // 
            // dgvNopVanBan
            // 
            this.dgvNopVanBan.AllowUserToAddRows = false;
            this.dgvNopVanBan.AllowUserToDeleteRows = false;
            this.dgvNopVanBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNopVanBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNopVanBan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNopVanBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNopVanBan.Location = new System.Drawing.Point(6, 21);
            this.dgvNopVanBan.MultiSelect = false;
            this.dgvNopVanBan.Name = "dgvNopVanBan";
            this.dgvNopVanBan.ReadOnly = true;
            this.dgvNopVanBan.RowHeadersVisible = false;
            this.dgvNopVanBan.RowTemplate.Height = 24;
            this.dgvNopVanBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNopVanBan.Size = new System.Drawing.Size(382, 17);
            this.dgvNopVanBan.TabIndex = 0;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.AutoSize = true;
            this.btnTaiLai.Location = new System.Drawing.Point(3, 3);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(100, 30);
            this.btnTaiLai.TabIndex = 6;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnDanhGia
            // 
            this.btnDanhGia.AutoSize = true;
            this.btnDanhGia.Location = new System.Drawing.Point(109, 3);
            this.btnDanhGia.Name = "btnDanhGia";
            this.btnDanhGia.Size = new System.Drawing.Size(100, 30);
            this.btnDanhGia.TabIndex = 7;
            this.btnDanhGia.Text = "Đánh Giá";
            this.btnDanhGia.UseVisualStyleBackColor = true;
            this.btnDanhGia.Click += new System.EventHandler(this.btnDanhGia_Click);
            // 
            // flowLayoutPanelNutChinh
            // 
            this.flowLayoutPanelNutChinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanelNutChinh.AutoSize = true;
            this.flowLayoutPanelNutChinh.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelNutChinh.Controls.Add(this.btnDanhGiaNhom); // Thêm nút Đánh Giá Nhóm
            this.flowLayoutPanelNutChinh.Controls.Add(this.btnDanhGia);
            this.flowLayoutPanelNutChinh.Controls.Add(this.btnTaiLai);
            this.flowLayoutPanelNutChinh.Location = new System.Drawing.Point(525, 653);
            this.flowLayoutPanelNutChinh.Name = "flowLayoutPanelNutChinh";
            this.flowLayoutPanelNutChinh.Size = new System.Drawing.Size(208, 36);
            this.flowLayoutPanelNutChinh.TabIndex = 9;
            // 
            // btnDanhGiaNhom
            // 
            this.btnDanhGiaNhom.AutoSize = true;
            this.btnDanhGiaNhom.Location = new System.Drawing.Point(133, 3);
            this.btnDanhGiaNhom.Name = "btnDanhGiaNhom";
            this.btnDanhGiaNhom.Size = new System.Drawing.Size(75, 30);
            this.btnDanhGiaNhom.TabIndex = 8;
            this.btnDanhGiaNhom.Text = "Đánh Giá Nhóm";
            this.btnDanhGiaNhom.UseVisualStyleBackColor = true;
            this.btnDanhGiaNhom.Click += new System.EventHandler(this.btnDanhGiaNhom_Click);
            // 
            // groupBoxChiTietNhom
            // 
            this.groupBoxChiTietNhom.Controls.Add(this.txtChiTietNhom);
            this.groupBoxChiTietNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChiTietNhom.Location = new System.Drawing.Point(403, 441);
            this.groupBoxChiTietNhom.Name = "groupBoxChiTietNhom";
            this.groupBoxChiTietNhom.Size = new System.Drawing.Size(394, 200);
            this.groupBoxChiTietNhom.TabIndex = 8;
            this.groupBoxChiTietNhom.TabStop = false;
            this.groupBoxChiTietNhom.Text = "Chi Tiết Nhóm";
            // 
            // txtChiTietNhom
            // 
            this.txtChiTietNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChiTietNhom.Location = new System.Drawing.Point(3, 19);
            this.txtChiTietNhom.Multiline = true;
            this.txtChiTietNhom.Name = "txtChiTietNhom";
            this.txtChiTietNhom.ReadOnly = true;
            this.txtChiTietNhom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChiTietNhom.Size = new System.Drawing.Size(388, 178);
            this.txtChiTietNhom.TabIndex = 0;
            // 
            // tableLayoutPanelChinh
            // 
            this.tableLayoutPanelChinh.ColumnCount = 2;
            this.tableLayoutPanelChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelChinh.Controls.Add(this.flowLayoutPanelTopTrai, 0, 0); // Thêm FlowLayoutPanelTopLeft vào (0,0)
            this.tableLayoutPanelChinh.Controls.Add(this.lblKhoa, 1, 0);
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxQuanLyDeTai, 0, 1);
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxNhomSinhVien, 1, 1);
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxNhomHoiDongCham, 1, 2); // Thêm groupBoxNhomHoiDongCham vào (1,2)
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxKiHan, 1, 3);
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxNopVanBan, 0, 4);
            this.tableLayoutPanelChinh.Controls.Add(this.groupBoxChiTietNhom, 1, 4);
            this.tableLayoutPanelChinh.Controls.Add(this.flowLayoutPanelNutChinh, 1, 5);
            this.tableLayoutPanelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelChinh.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelChinh.Name = "tableLayoutPanelChinh";
            this.tableLayoutPanelChinh.RowCount = 6;
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F)); // Row 0: Top labels
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F)); // Row 1: groupBoxQuanLyDeTai
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F)); // Row 2: groupBoxNhomHoiDongCham
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Row 3: groupBoxKiHan
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Row 4: groupBoxNopVanBan & groupBoxChiTietNhom
            this.tableLayoutPanelChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Row 5: flowLayoutPanelNutChinh
            this.tableLayoutPanelChinh.Size = new System.Drawing.Size(800, 689);
            this.tableLayoutPanelChinh.TabIndex = 9;
            // 
            // FormGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.tableLayoutPanelChinh);
            this.Name = "FormGiangVien";
            this.Text = "Bảng Điều Khiển Giảng Viên";
            this.Load += new System.EventHandler(this.FormGiangVien_Load);
            this.groupBoxQuanLyDeTai.ResumeLayout(false);
            this.groupBoxQuanLyDeTai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeTai)).EndInit();
            this.flowLayoutPanelNutDeTai.ResumeLayout(false);
            this.flowLayoutPanelNutDeTai.PerformLayout();
            this.groupBoxNhomSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomSinhVien)).EndInit();
            this.groupBoxNhomHoiDongCham.ResumeLayout(false); // Tiếp tục Layout cho Nhóm Hội Đồng Chấm
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomHoiDongCham)).EndInit(); // Kết thúc Init dgvNhomHoiDongCham
            this.groupBoxKiHan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiHan)).EndInit();
            this.groupBoxNopVanBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNopVanBan)).EndInit();
            this.flowLayoutPanelNutChinh.ResumeLayout(false);
            this.flowLayoutPanelNutChinh.PerformLayout();
            this.groupBoxChiTietNhom.ResumeLayout(false);
            this.groupBoxChiTietNhom.PerformLayout();
            this.tableLayoutPanelChinh.ResumeLayout(false);
            this.tableLayoutPanelChinh.PerformLayout();
            this.flowLayoutPanelTopTrai.ResumeLayout(false);
            this.flowLayoutPanelTopTrai.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
