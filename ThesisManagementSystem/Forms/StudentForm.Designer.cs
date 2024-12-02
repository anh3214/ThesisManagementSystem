// StudentForm.Designer.cs

namespace ThesisManagementSystem.Forms
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        // Các control của form
        private Label lblStudentInfo;
        private Label lblName;
        private Label lblClass;
        private TabControl tabControl;
        private TabPage tabGroup;
        private TabPage tabTopics;
        private TabPage tabResults;
        private TabPage tabSubmissions;
        private DataGridView dgvGroupMembers;
        private Button btnCreateGroup;
        private Button btnAddMember; // Button thêm thành viên
        private Button btnLogout; // Button logout
        private TextBox txtGroupName;
        private TextBox txtStudentToAdd; // TextBox để nhập thông tin thành viên
        private Label lblAddMember; // Label cho TextBox
        private DataGridView dgvAvailableTopics;
        private Button btnRegisterTopic;
        private DataGridView dgvResults;
        private DataGridView dgvDefenseScores; // DataGridView mới cho DefenseScore
        private DataGridView dgvMilestones;
        private Button btnSubmitDocument;
        private Button btnEditDocument; // Button Edit Document
        private FlowLayoutPanel flowLayoutPanelGroupButtons;
        private FlowLayoutPanel flowLayoutPanelTopicsButtons;
        private FlowLayoutPanel flowLayoutPanelSubmissionsButtons;

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel studentInfoLayout;

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
            lblStudentInfo = new Label();
            lblName = new Label();
            lblClass = new Label();
            tabControl = new TabControl();
            tabGroup = new TabPage();
            dgvGroupMembers = new DataGridView();
            flowLayoutPanelGroupButtons = new FlowLayoutPanel();
            txtGroupName = new TextBox();
            btnCreateGroup = new Button();
            lblAddMember = new Label();
            txtStudentToAdd = new TextBox();
            btnAddMember = new Button();
            btnLogout = new Button();
            tabTopics = new TabPage();
            dgvAvailableTopics = new DataGridView();
            flowLayoutPanelTopicsButtons = new FlowLayoutPanel();
            btnRegisterTopic = new Button();
            tabResults = new TabPage();
            dgvResults = new DataGridView();
            dgvDefenseScores = new DataGridView(); // Initialize DefenseScore DataGridView
            tabSubmissions = new TabPage();
            dgvMilestones = new DataGridView();
            flowLayoutPanelSubmissionsButtons = new FlowLayoutPanel();
            btnSubmitDocument = new Button();
            btnEditDocument = new Button(); // Initialize Edit Document Button

            mainLayout = new TableLayoutPanel();
            studentInfoLayout = new TableLayoutPanel();

            // Suspend Layouts
            tabControl.SuspendLayout();
            tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGroupMembers).BeginInit();
            flowLayoutPanelGroupButtons.SuspendLayout();
            tabTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableTopics).BeginInit();
            flowLayoutPanelTopicsButtons.SuspendLayout();
            tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDefenseScores).BeginInit(); // Begin Init DefenseScores
            tabSubmissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMilestones).BeginInit();
            flowLayoutPanelSubmissionsButtons.SuspendLayout();
            mainLayout.SuspendLayout();
            studentInfoLayout.SuspendLayout();
            SuspendLayout();

            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            studentInfoLayout.SetColumnSpan(lblStudentInfo, 2);
            lblStudentInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblStudentInfo.Location = new Point(3, 0);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(164, 21);
            lblStudentInfo.TabIndex = 0;
            lblStudentInfo.Text = "Student Information";

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(3, 21);
            lblName.Name = "lblName";
            lblName.Size = new Size(40, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name: ";

            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(3, 36);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(35, 15);
            lblClass.TabIndex = 2;
            lblClass.Text = "Class: ";

            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabGroup);
            tabControl.Controls.Add(tabTopics);
            tabControl.Controls.Add(tabResults);
            tabControl.Controls.Add(tabSubmissions);
            tabControl.Location = new Point(3, 109);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(881, 388);
            tabControl.TabIndex = 3;

            // 
            // tabGroup
            // 
            tabGroup.Controls.Add(dgvGroupMembers);
            tabGroup.Controls.Add(flowLayoutPanelGroupButtons);
            tabGroup.Location = new Point(4, 24);
            tabGroup.Name = "tabGroup";
            tabGroup.Padding = new Padding(3);
            tabGroup.Size = new Size(873, 360);
            tabGroup.TabIndex = 0;
            tabGroup.Text = "Group";
            tabGroup.UseVisualStyleBackColor = true;

            // 
            // dgvGroupMembers
            // 
            dgvGroupMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGroupMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGroupMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroupMembers.Location = new Point(0, 0);
            dgvGroupMembers.Name = "dgvGroupMembers";
            dgvGroupMembers.ReadOnly = true;
            dgvGroupMembers.RowHeadersVisible = false;
            dgvGroupMembers.Size = new Size(873, 295);
            dgvGroupMembers.TabIndex = 0;

            // 
            // flowLayoutPanelGroupButtons
            // 
            flowLayoutPanelGroupButtons.AutoScroll = true;
            flowLayoutPanelGroupButtons.AutoSize = true;
            flowLayoutPanelGroupButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelGroupButtons.Controls.Add(txtGroupName);
            flowLayoutPanelGroupButtons.Controls.Add(btnCreateGroup);
            flowLayoutPanelGroupButtons.Controls.Add(lblAddMember);
            flowLayoutPanelGroupButtons.Controls.Add(txtStudentToAdd);
            flowLayoutPanelGroupButtons.Controls.Add(btnAddMember);
            flowLayoutPanelGroupButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelGroupButtons.Location = new Point(3, 301);
            flowLayoutPanelGroupButtons.Name = "flowLayoutPanelGroupButtons";
            flowLayoutPanelGroupButtons.Padding = new Padding(10);
            flowLayoutPanelGroupButtons.Size = new Size(867, 56);
            flowLayoutPanelGroupButtons.TabIndex = 1;

            // 
            // txtGroupName
            // 
            txtGroupName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtGroupName.Location = new Point(13, 20);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Group Name";
            txtGroupName.Size = new Size(200, 23);
            txtGroupName.TabIndex = 0;

            // 
            // btnCreateGroup
            // 
            btnCreateGroup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateGroup.Location = new Point(219, 13);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(100, 30);
            btnCreateGroup.TabIndex = 1;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = true;
            btnCreateGroup.Click += btnCreateGroup_Click;

            // 
            // lblAddMember
            // 
            lblAddMember.AutoSize = true;
            lblAddMember.Location = new Point(342, 10);
            lblAddMember.Margin = new Padding(20, 0, 3, 0);
            lblAddMember.Name = "lblAddMember";
            lblAddMember.Size = new Size(160, 15);
            lblAddMember.TabIndex = 2;
            lblAddMember.Text = "Student ID or Name to Add:";

            // 
            // txtStudentToAdd
            // 
            txtStudentToAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtStudentToAdd.Location = new Point(508, 20);
            txtStudentToAdd.Name = "txtStudentToAdd";
            txtStudentToAdd.PlaceholderText = "Enter ID or Name";
            txtStudentToAdd.Size = new Size(150, 23);
            txtStudentToAdd.TabIndex = 3;

            // 
            // btnAddMember
            // 
            btnAddMember.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddMember.Location = new Point(668, 13);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(120, 30);
            btnAddMember.TabIndex = 4;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;

            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.Location = new Point(42, 67);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // 
            // tabTopics
            // 
            tabTopics.Controls.Add(dgvAvailableTopics);
            tabTopics.Controls.Add(flowLayoutPanelTopicsButtons);
            tabTopics.Location = new Point(4, 24);
            tabTopics.Name = "tabTopics";
            tabTopics.Padding = new Padding(3);
            tabTopics.Size = new Size(873, 360);
            tabTopics.TabIndex = 1;
            tabTopics.Text = "Topics";
            tabTopics.UseVisualStyleBackColor = true;

            // 
            // dgvAvailableTopics
            // 
            dgvAvailableTopics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAvailableTopics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableTopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableTopics.Location = new Point(0, 0);
            dgvAvailableTopics.Name = "dgvAvailableTopics";
            dgvAvailableTopics.Size = new Size(873, 295);
            dgvAvailableTopics.TabIndex = 0;

            // 
            // flowLayoutPanelTopicsButtons
            // 
            flowLayoutPanelTopicsButtons.AutoScroll = true;
            flowLayoutPanelTopicsButtons.AutoSize = true;
            flowLayoutPanelTopicsButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelTopicsButtons.Controls.Add(btnRegisterTopic);
            flowLayoutPanelTopicsButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelTopicsButtons.Location = new Point(3, 301);
            flowLayoutPanelTopicsButtons.Name = "flowLayoutPanelTopicsButtons";
            flowLayoutPanelTopicsButtons.Padding = new Padding(10);
            flowLayoutPanelTopicsButtons.Size = new Size(867, 56);
            flowLayoutPanelTopicsButtons.TabIndex = 1;

            // 
            // btnRegisterTopic
            // 
            btnRegisterTopic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRegisterTopic.Location = new Point(13, 13);
            btnRegisterTopic.Name = "btnRegisterTopic";
            btnRegisterTopic.Size = new Size(150, 30);
            btnRegisterTopic.TabIndex = 0;
            btnRegisterTopic.Text = "Register Topic";
            btnRegisterTopic.UseVisualStyleBackColor = true;
            btnRegisterTopic.Click += btnRegisterTopic_Click;

            // 
            // tabResults
            // 
            tabResults.Controls.Add(dgvResults);
            tabResults.Controls.Add(dgvDefenseScores);
            tabResults.Location = new Point(4, 24);
            tabResults.Name = "tabResults";
            tabResults.Padding = new Padding(3);
            tabResults.Size = new Size(873, 360);
            tabResults.TabIndex = 2;
            tabResults.Text = "Results";
            tabResults.UseVisualStyleBackColor = true;

            // 
            // dgvResults
            // 
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(0, 0);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.Size = new Size(873, 180); // Shrink height
            dgvResults.TabIndex = 0;

            // Define columns for dgvResults
            dgvResults.Columns.Clear();
            dgvResults.Columns.Add("Type", "Type");
            dgvResults.Columns.Add("Score", "Score");
            dgvResults.Columns.Add("ProjectScore", "Project Score");
            dgvResults.Columns.Add("Comments", "Comments");
            dgvResults.Columns.Add("EvaluationDate", "Date");
            dgvResults.Columns.Add("EvaluatorName", "Evaluator");
            dgvResults.Columns.Add("Role", "Role");

            foreach (DataGridViewColumn column in dgvResults.Columns)
            {
                column.ReadOnly = true;
            }

            dgvResults.Columns["Score"].DefaultCellStyle.Format = "N2";
            dgvResults.Columns["ProjectScore"].DefaultCellStyle.Format = "N2";
            dgvResults.Columns["EvaluationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 
            // dgvDefenseScores
            // 
            dgvDefenseScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDefenseScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDefenseScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDefenseScores.Location = new Point(0, 190); // Position below dgvResults
            dgvDefenseScores.Name = "dgvDefenseScores";
            dgvDefenseScores.ReadOnly = true;
            dgvDefenseScores.RowHeadersVisible = false;
            dgvDefenseScores.Size = new Size(873, 170); // Adjust size
            dgvDefenseScores.TabIndex = 1;

            // Define columns for dgvDefenseScores
            dgvDefenseScores.Columns.Clear();
            dgvDefenseScores.Columns.Add("DefenseType", "Defense Type");
            dgvDefenseScores.Columns.Add("DefenseScore", "Score");
            dgvDefenseScores.Columns.Add("DefenseComments", "Comments");
            dgvDefenseScores.Columns.Add("DefenseDate", "Date");
            dgvDefenseScores.Columns.Add("DefenseEvaluator", "Evaluator");
            dgvDefenseScores.Columns.Add("DefenseRole", "Role");

            foreach (DataGridViewColumn column in dgvDefenseScores.Columns)
            {
                column.ReadOnly = true;
            }

            dgvDefenseScores.Columns["DefenseScore"].DefaultCellStyle.Format = "N2";
            dgvDefenseScores.Columns["DefenseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 
            // tabSubmissions
            // 
            tabSubmissions.Controls.Add(dgvMilestones);
            tabSubmissions.Controls.Add(flowLayoutPanelSubmissionsButtons);
            tabSubmissions.Location = new Point(4, 24);
            tabSubmissions.Name = "tabSubmissions";
            tabSubmissions.Padding = new Padding(3);
            tabSubmissions.Size = new Size(873, 360);
            tabSubmissions.TabIndex = 3;
            tabSubmissions.Text = "Submissions";
            tabSubmissions.UseVisualStyleBackColor = true;

            // 
            // dgvMilestones
            // 
            dgvMilestones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMilestones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMilestones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMilestones.Location = new Point(0, 0);
            dgvMilestones.Name = "dgvMilestones";
            dgvMilestones.Size = new Size(873, 295);
            dgvMilestones.TabIndex = 0;

            // 
            // flowLayoutPanelSubmissionsButtons
            // 
            flowLayoutPanelSubmissionsButtons.AutoScroll = true;
            flowLayoutPanelSubmissionsButtons.AutoSize = true;
            flowLayoutPanelSubmissionsButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelSubmissionsButtons.Controls.Add(btnSubmitDocument);
            flowLayoutPanelSubmissionsButtons.Controls.Add(btnEditDocument); // Add Edit Document Button
            flowLayoutPanelSubmissionsButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelSubmissionsButtons.Location = new Point(3, 301);
            flowLayoutPanelSubmissionsButtons.Name = "flowLayoutPanelSubmissionsButtons";
            flowLayoutPanelSubmissionsButtons.Padding = new Padding(10);
            flowLayoutPanelSubmissionsButtons.Size = new Size(867, 56);
            flowLayoutPanelSubmissionsButtons.TabIndex = 1;

            // 
            // btnSubmitDocument
            // 
            btnSubmitDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSubmitDocument.Location = new Point(13, 13);
            btnSubmitDocument.Name = "btnSubmitDocument";
            btnSubmitDocument.Size = new Size(150, 30);
            btnSubmitDocument.TabIndex = 0;
            btnSubmitDocument.Text = "Submit Document";
            btnSubmitDocument.UseVisualStyleBackColor = true;
            btnSubmitDocument.Click += btnSubmitDocument_Click;

            // 
            // btnEditDocument
            // 
            btnEditDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditDocument.Location = new Point(173, 13);
            btnEditDocument.Name = "btnEditDocument";
            btnEditDocument.Size = new Size(150, 30);
            btnEditDocument.TabIndex = 1;
            btnEditDocument.Text = "Edit Document";
            btnEditDocument.UseVisualStyleBackColor = true;
            btnEditDocument.Click += btnEditDocument_Click;

            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(studentInfoLayout, 0, 0);
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
            // studentInfoLayout
            // 
            studentInfoLayout.ColumnCount = 2;
            studentInfoLayout.ColumnStyles.Add(new ColumnStyle());
            studentInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            studentInfoLayout.Controls.Add(lblStudentInfo, 0, 0);
            studentInfoLayout.Controls.Add(lblName, 0, 1);
            studentInfoLayout.Controls.Add(lblClass, 0, 2);
            studentInfoLayout.Controls.Add(btnLogout, 1, 2);
            studentInfoLayout.Dock = DockStyle.Top;
            studentInfoLayout.Location = new Point(3, 3);
            studentInfoLayout.Name = "studentInfoLayout";
            studentInfoLayout.RowCount = 3;
            studentInfoLayout.RowStyles.Add(new RowStyle());
            studentInfoLayout.RowStyles.Add(new RowStyle());
            studentInfoLayout.RowStyles.Add(new RowStyle());
            studentInfoLayout.Size = new Size(881, 100);
            studentInfoLayout.TabIndex = 0;

            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 500);
            Controls.Add(mainLayout);
            Name = "StudentForm";
            Text = "Student Portal";
            Load += StudentForm_Load;
            tabControl.ResumeLayout(false);
            tabGroup.ResumeLayout(false);
            tabGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGroupMembers).EndInit();
            flowLayoutPanelGroupButtons.ResumeLayout(false);
            flowLayoutPanelGroupButtons.PerformLayout();
            tabTopics.ResumeLayout(false);
            tabTopics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableTopics).EndInit();
            flowLayoutPanelTopicsButtons.ResumeLayout(false);
            tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDefenseScores).EndInit();
            tabSubmissions.ResumeLayout(false);
            tabSubmissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMilestones).EndInit();
            flowLayoutPanelSubmissionsButtons.ResumeLayout(false);
            flowLayoutPanelSubmissionsButtons.PerformLayout();
            mainLayout.ResumeLayout(false);
            studentInfoLayout.ResumeLayout(false);
            studentInfoLayout.PerformLayout();
            ResumeLayout(false);
        }
    }
}
