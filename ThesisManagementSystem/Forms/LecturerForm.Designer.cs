// LecturerForm.Designer.cs

namespace ThesisManagementSystem.Forms
{
    partial class LecturerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declare UI components
        private System.Windows.Forms.Label lblLecturerName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.GroupBox groupBoxCreateTopic;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.Button btnCreateTopic;
        private System.Windows.Forms.Button btnEditTopic;
        private System.Windows.Forms.Button btnDeleteTopic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTopicButtons;
        private System.Windows.Forms.GroupBox groupBoxGroups;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.GroupBox groupBoxCommitteeGroups; // New GroupBox for Committee Groups
        private System.Windows.Forms.DataGridView dgvCommitteeGroups; // New DataGridView for Committee Groups
        private System.Windows.Forms.GroupBox groupBoxMilestones;
        private System.Windows.Forms.DataGridView dgvMilestones;
        private System.Windows.Forms.GroupBox groupBoxSubmissions;
        private System.Windows.Forms.DataGridView dgvSubmissions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMainButtons;
        private System.Windows.Forms.GroupBox groupBoxGroupDetails;
        private System.Windows.Forms.TextBox txtGroupDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTopLeft; // Added FlowLayoutPanelTopLeft
        private System.Windows.Forms.Button btnLogout; // Added btnLogout
        private System.Windows.Forms.Button btnEvaluateGroup; // New button for evaluating committee groups

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên nên được dispose; ngược lại, false.</param>
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
        /// Required method for Designer support - không sửa đổi 
        /// nội dung của phương thức này với trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLecturerName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.groupBoxCreateTopic = new System.Windows.Forms.GroupBox();
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanelTopicButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateTopic = new System.Windows.Forms.Button();
            this.btnEditTopic = new System.Windows.Forms.Button();
            this.btnDeleteTopic = new System.Windows.Forms.Button();
            this.groupBoxGroups = new System.Windows.Forms.GroupBox();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.groupBoxCommitteeGroups = new System.Windows.Forms.GroupBox(); // Initialize GroupBoxCommitteeGroups
            this.dgvCommitteeGroups = new System.Windows.Forms.DataGridView(); // Initialize dgvCommitteeGroups
            this.groupBoxMilestones = new System.Windows.Forms.GroupBox();
            this.dgvMilestones = new System.Windows.Forms.DataGridView();
            this.groupBoxSubmissions = new System.Windows.Forms.GroupBox();
            this.dgvSubmissions = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.flowLayoutPanelMainButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxGroupDetails = new System.Windows.Forms.GroupBox();
            this.txtGroupDetails = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelTopLeft = new System.Windows.Forms.FlowLayoutPanel(); // Initialize FlowLayoutPanelTopLeft
            this.btnLogout = new System.Windows.Forms.Button(); // Initialize btnLogout
            this.btnEvaluateGroup = new System.Windows.Forms.Button(); // Initialize btnEvaluateGroup
            this.groupBoxCreateTopic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            this.flowLayoutPanelTopicButtons.SuspendLayout();
            this.groupBoxGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.groupBoxCommitteeGroups.SuspendLayout(); // Suspend Layout for Committee Groups
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommitteeGroups)).BeginInit(); // Begin Init dgvCommitteeGroups
            this.groupBoxMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestones)).BeginInit();
            this.groupBoxSubmissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).BeginInit();
            this.flowLayoutPanelMainButtons.SuspendLayout();
            this.groupBoxGroupDetails.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.flowLayoutPanelTopLeft.SuspendLayout(); // Suspend Layout for FlowLayoutPanelTopLeft
            this.SuspendLayout();
            // 
            // lblLecturerName
            // 
            this.lblLecturerName.AutoSize = true;
            this.lblLecturerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecturerName.Text = "Tên: ";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(403, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(394, 30);
            this.lblDepartment.TabIndex = 1;
            this.lblDepartment.Text = "Khoa: ";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelTopLeft
            // 
            this.flowLayoutPanelTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTopLeft.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanelTopLeft.Controls.Add(this.lblLecturerName);
            this.flowLayoutPanelTopLeft.Controls.Add(this.btnLogout);
            this.flowLayoutPanelTopLeft.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelTopLeft.Name = "flowLayoutPanelTopLeft";
            this.flowLayoutPanelTopLeft.Size = new System.Drawing.Size(394, 24);
            this.flowLayoutPanelTopLeft.TabIndex = 10;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogout.AutoSize = true;
            this.btnLogout.Location = new System.Drawing.Point(95, 0); // Adjust position based on FlowLayoutPanel
            this.btnLogout.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0); // Add margin for spacing
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 24);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBoxCreateTopic
            // 
            this.groupBoxCreateTopic.Controls.Add(this.dgvTopics);
            this.groupBoxCreateTopic.Controls.Add(this.flowLayoutPanelTopicButtons);
            this.groupBoxCreateTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCreateTopic.Location = new System.Drawing.Point(3, 33);
            this.groupBoxCreateTopic.Name = "groupBoxCreateTopic";
            this.tableLayoutPanelMain.SetRowSpan(this.groupBoxCreateTopic, 2);
            this.groupBoxCreateTopic.Size = new System.Drawing.Size(394, 434);
            this.groupBoxCreateTopic.TabIndex = 2;
            this.groupBoxCreateTopic.TabStop = false;
            this.groupBoxCreateTopic.Text = "Quản Lý Đề Tài";
            // 
            // dgvTopics
            // 
            this.dgvTopics.AllowUserToAddRows = false;
            this.dgvTopics.AllowUserToDeleteRows = false;
            this.dgvTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTopics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopics.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Location = new System.Drawing.Point(6, 21);
            this.dgvTopics.MultiSelect = false;
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.ReadOnly = true;
            this.dgvTopics.RowHeadersVisible = false;
            this.dgvTopics.RowTemplate.Height = 24;
            this.dgvTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopics.Size = new System.Drawing.Size(382, 311);
            this.dgvTopics.TabIndex = 0;
            // 
            // flowLayoutPanelTopicButtons
            // 
            this.flowLayoutPanelTopicButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelTopicButtons.AutoSize = true;
            this.flowLayoutPanelTopicButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelTopicButtons.Controls.Add(this.btnCreateTopic);
            this.flowLayoutPanelTopicButtons.Controls.Add(this.btnEditTopic);
            this.flowLayoutPanelTopicButtons.Controls.Add(this.btnDeleteTopic);
            this.flowLayoutPanelTopicButtons.Location = new System.Drawing.Point(250, 337);
            this.flowLayoutPanelTopicButtons.Name = "flowLayoutPanelTopicButtons";
            this.flowLayoutPanelTopicButtons.Size = new System.Drawing.Size(138, 30);
            this.flowLayoutPanelTopicButtons.TabIndex = 1;
            // 
            // btnCreateTopic
            // 
            this.btnCreateTopic.AutoSize = true;
            this.btnCreateTopic.Location = new System.Drawing.Point(35, 3);
            this.btnCreateTopic.Name = "btnCreateTopic";
            this.btnCreateTopic.Size = new System.Drawing.Size(100, 24);
            this.btnCreateTopic.TabIndex = 0;
            this.btnCreateTopic.Text = "Thêm Đề Tài";
            this.btnCreateTopic.UseVisualStyleBackColor = true;
            this.btnCreateTopic.Click += new System.EventHandler(this.btnCreateTopic_Click);
            // 
            // btnEditTopic
            // 
            this.btnEditTopic.AutoSize = true;
            this.btnEditTopic.Location = new System.Drawing.Point(35, 3);
            this.btnEditTopic.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btnEditTopic.Name = "btnEditTopic";
            this.btnEditTopic.Size = new System.Drawing.Size(100, 24);
            this.btnEditTopic.TabIndex = 1;
            this.btnEditTopic.Text = "Sửa Đề Tài";
            this.btnEditTopic.UseVisualStyleBackColor = true;
            this.btnEditTopic.Click += new System.EventHandler(this.btnEditTopic_Click);
            // 
            // btnDeleteTopic
            // 
            this.btnDeleteTopic.AutoSize = true;
            this.btnDeleteTopic.Location = new System.Drawing.Point(35, 3);
            this.btnDeleteTopic.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.btnDeleteTopic.Name = "btnDeleteTopic";
            this.btnDeleteTopic.Size = new System.Drawing.Size(100, 24);
            this.btnDeleteTopic.TabIndex = 2;
            this.btnDeleteTopic.Text = "Xóa Đề Tài";
            this.btnDeleteTopic.UseVisualStyleBackColor = true;
            this.btnDeleteTopic.Click += new System.EventHandler(this.btnDeleteTopic_Click);
            // 
            // groupBoxGroups
            // 
            this.groupBoxGroups.Controls.Add(this.dgvGroups);
            this.groupBoxGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGroups.Location = new System.Drawing.Point(403, 33);
            this.groupBoxGroups.Name = "groupBoxGroups";
            this.groupBoxGroups.Size = new System.Drawing.Size(394, 258);
            this.groupBoxGroups.TabIndex = 3;
            this.groupBoxGroups.TabStop = false;
            this.groupBoxGroups.Text = "Danh Sách Nhóm Sinh Viên (Hướng Dẫn)";
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(6, 21);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.RowTemplate.Height = 24;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(382, 231);
            this.dgvGroups.TabIndex = 0;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.dgvGroups_SelectionChanged);
            // 
            // groupBoxCommitteeGroups
            // 
            this.groupBoxCommitteeGroups.Controls.Add(this.dgvCommitteeGroups);
            this.groupBoxCommitteeGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCommitteeGroups.Location = new System.Drawing.Point(403, 297);
            this.groupBoxCommitteeGroups.Name = "groupBoxCommitteeGroups";
            this.groupBoxCommitteeGroups.Size = new System.Drawing.Size(394, 138);
            this.groupBoxCommitteeGroups.TabIndex = 4;
            this.groupBoxCommitteeGroups.TabStop = false;
            this.groupBoxCommitteeGroups.Text = "Danh Sách Nhóm Sinh Viên (Hội Đồng Chấm)";
            // 
            // dgvCommitteeGroups
            // 
            this.dgvCommitteeGroups.AllowUserToAddRows = false;
            this.dgvCommitteeGroups.AllowUserToDeleteRows = false;
            this.dgvCommitteeGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommitteeGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommitteeGroups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommitteeGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommitteeGroups.Location = new System.Drawing.Point(6, 21);
            this.dgvCommitteeGroups.MultiSelect = false;
            this.dgvCommitteeGroups.Name = "dgvCommitteeGroups";
            this.dgvCommitteeGroups.ReadOnly = true;
            this.dgvCommitteeGroups.RowHeadersVisible = false;
            this.dgvCommitteeGroups.RowTemplate.Height = 24;
            this.dgvCommitteeGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommitteeGroups.Size = new System.Drawing.Size(382, 111);
            this.dgvCommitteeGroups.TabIndex = 0;
            this.dgvCommitteeGroups.SelectionChanged += new System.EventHandler(this.dgvCommitteeGroups_SelectionChanged);
            // 
            // groupBoxMilestones
            // 
            this.groupBoxMilestones.Controls.Add(this.dgvMilestones);
            this.groupBoxMilestones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMilestones.Location = new System.Drawing.Point(403, 441);
            this.groupBoxMilestones.Name = "groupBoxMilestones";
            this.groupBoxMilestones.Size = new System.Drawing.Size(394, 200);
            this.groupBoxMilestones.TabIndex = 5;
            this.groupBoxMilestones.TabStop = false;
            this.groupBoxMilestones.Text = "Danh Sách Milestones";
            // 
            // dgvMilestones
            // 
            this.dgvMilestones.AllowUserToAddRows = false;
            this.dgvMilestones.AllowUserToDeleteRows = false;
            this.dgvMilestones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMilestones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMilestones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMilestones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilestones.Location = new System.Drawing.Point(6, 21);
            this.dgvMilestones.MultiSelect = false;
            this.dgvMilestones.Name = "dgvMilestones";
            this.dgvMilestones.ReadOnly = true;
            this.dgvMilestones.RowHeadersVisible = false;
            this.dgvMilestones.RowTemplate.Height = 24;
            this.dgvMilestones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMilestones.Size = new System.Drawing.Size(382, 173);
            this.dgvMilestones.TabIndex = 0;
            // 
            // groupBoxSubmissions
            // 
            this.groupBoxSubmissions.Controls.Add(this.dgvSubmissions);
            this.groupBoxSubmissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSubmissions.Location = new System.Drawing.Point(3, 597);
            this.groupBoxSubmissions.Name = "groupBoxSubmissions";
            this.groupBoxSubmissions.Size = new System.Drawing.Size(394, 44);
            this.groupBoxSubmissions.TabIndex = 6;
            this.groupBoxSubmissions.TabStop = false;
            this.groupBoxSubmissions.Text = "Danh Sách Submissions";
            // 
            // dgvSubmissions
            // 
            this.dgvSubmissions.AllowUserToAddRows = false;
            this.dgvSubmissions.AllowUserToDeleteRows = false;
            this.dgvSubmissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubmissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubmissions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubmissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubmissions.Location = new System.Drawing.Point(6, 21);
            this.dgvSubmissions.MultiSelect = false;
            this.dgvSubmissions.Name = "dgvSubmissions";
            this.dgvSubmissions.ReadOnly = true;
            this.dgvSubmissions.RowHeadersVisible = false;
            this.dgvSubmissions.RowTemplate.Height = 24;
            this.dgvSubmissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubmissions.Size = new System.Drawing.Size(382, 17);
            this.dgvSubmissions.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Tải Lại";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.AutoSize = true;
            this.btnEvaluate.Location = new System.Drawing.Point(109, 3);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(100, 30);
            this.btnEvaluate.TabIndex = 7;
            this.btnEvaluate.Text = "Đánh Giá";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // flowLayoutPanelMainButtons
            // 
            this.flowLayoutPanelMainButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanelMainButtons.AutoSize = true;
            this.flowLayoutPanelMainButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelMainButtons.Controls.Add(this.btnEvaluateGroup); // Add EvaluateGroup button
            this.flowLayoutPanelMainButtons.Controls.Add(this.btnEvaluate);
            this.flowLayoutPanelMainButtons.Controls.Add(this.btnRefresh);
            this.flowLayoutPanelMainButtons.Location = new System.Drawing.Point(525, 653);
            this.flowLayoutPanelMainButtons.Name = "flowLayoutPanelMainButtons";
            this.flowLayoutPanelMainButtons.Size = new System.Drawing.Size(208, 36);
            this.flowLayoutPanelMainButtons.TabIndex = 9;
            // 
            // btnEvaluateGroup
            // 
            this.btnEvaluateGroup.AutoSize = true;
            this.btnEvaluateGroup.Location = new System.Drawing.Point(133, 3);
            this.btnEvaluateGroup.Name = "btnEvaluateGroup";
            this.btnEvaluateGroup.Size = new System.Drawing.Size(75, 30);
            this.btnEvaluateGroup.TabIndex = 8;
            this.btnEvaluateGroup.Text = "Đánh Giá Nhóm";
            this.btnEvaluateGroup.UseVisualStyleBackColor = true;
            this.btnEvaluateGroup.Click += new System.EventHandler(this.btnEvaluateGroup_Click);
            // 
            // groupBoxGroupDetails
            // 
            this.groupBoxGroupDetails.Controls.Add(this.txtGroupDetails);
            this.groupBoxGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGroupDetails.Location = new System.Drawing.Point(403, 441);
            this.groupBoxGroupDetails.Name = "groupBoxGroupDetails";
            this.groupBoxGroupDetails.Size = new System.Drawing.Size(394, 200);
            this.groupBoxGroupDetails.TabIndex = 8;
            this.groupBoxGroupDetails.TabStop = false;
            this.groupBoxGroupDetails.Text = "Chi Tiết Nhóm";
            // 
            // txtGroupDetails
            // 
            this.txtGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGroupDetails.Location = new System.Drawing.Point(3, 19);
            this.txtGroupDetails.Multiline = true;
            this.txtGroupDetails.Name = "txtGroupDetails";
            this.txtGroupDetails.ReadOnly = true;
            this.txtGroupDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupDetails.Size = new System.Drawing.Size(388, 178);
            this.txtGroupDetails.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelTopLeft, 0, 0); // Add FlowLayoutPanelTopLeft to (0,0)
            this.tableLayoutPanelMain.Controls.Add(this.lblDepartment, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxCreateTopic, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxGroups, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxCommitteeGroups, 1, 2); // Add groupBoxCommitteeGroups to (1,2)
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxMilestones, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxSubmissions, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxGroupDetails, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelMainButtons, 1, 5);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 6;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F)); // Row 0: Top labels
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F)); // Row 1: groupBoxCreateTopic
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F)); // Row 2: groupBoxCommitteeGroups
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Row 3: groupBoxMilestones
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Row 4: groupBoxSubmissions & groupBoxGroupDetails
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Row 5: flowLayoutPanelMainButtons
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 689);
            this.tableLayoutPanelMain.TabIndex = 9;
            // 
            // btnEvaluateGroup
            // 
            // Already initialized above
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "LecturerForm";
            this.Text = "Lecturer Dashboard";
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            this.groupBoxCreateTopic.ResumeLayout(false);
            this.groupBoxCreateTopic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            this.flowLayoutPanelTopicButtons.ResumeLayout(false);
            this.flowLayoutPanelTopicButtons.PerformLayout();
            this.groupBoxGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.groupBoxCommitteeGroups.ResumeLayout(false); // Resume Layout for Committee Groups
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommitteeGroups)).EndInit(); // End Init dgvCommitteeGroups
            this.groupBoxMilestones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestones)).EndInit();
            this.groupBoxSubmissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).EndInit();
            this.flowLayoutPanelMainButtons.ResumeLayout(false);
            this.flowLayoutPanelMainButtons.PerformLayout();
            this.groupBoxGroupDetails.ResumeLayout(false);
            this.groupBoxGroupDetails.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.flowLayoutPanelTopLeft.ResumeLayout(false);
            this.flowLayoutPanelTopLeft.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
