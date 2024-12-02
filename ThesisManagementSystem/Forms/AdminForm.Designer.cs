// AdminForm.Designer.cs
namespace ThesisManagementSystem.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabUsers;
        private TabPage tabMilestones;
        private TabPage tabCommittees;
        private TabPage tabRegistrations;
        private TabPage tabGroups; // Thêm tab Groups
        private DataGridView dgvUsers;
        private DataGridView dgvMilestones;
        private DataGridView dgvCommittees;
        private DataGridView dgvRegistrations;
        private DataGridView dgvGroups; // DataGridView cho Groups
        private Button btnCreateCommittee;
        private Button btnEditCommittee;
        private Button btnUpdateRegistrationStatus;
        private Button btnCreateUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnCreateMilestone;
        private Button btnEditMilestone;
        private Button btnLogout;
        private Button btnEditGroup; // Nút chỉnh sửa nhóm
        private FlowLayoutPanel flowLayoutPanelUsersButtons;
        private FlowLayoutPanel flowLayoutPanelMilestonesButtons;
        private FlowLayoutPanel flowLayoutPanelCommitteesButtons;
        private FlowLayoutPanel flowLayoutPanelRegistrationsButtons;
        private FlowLayoutPanel flowLayoutPanelGroupsButtons; // FlowLayoutPanel cho Groups
        private Panel panelTop;

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
            // Initialize Components
            tabControl = new TabControl();
            tabUsers = new TabPage();
            dgvUsers = new DataGridView();
            flowLayoutPanelUsersButtons = new FlowLayoutPanel();
            btnCreateUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            tabMilestones = new TabPage();
            dgvMilestones = new DataGridView();
            flowLayoutPanelMilestonesButtons = new FlowLayoutPanel();
            btnCreateMilestone = new Button();
            btnEditMilestone = new Button();
            tabCommittees = new TabPage();
            dgvCommittees = new DataGridView();
            flowLayoutPanelCommitteesButtons = new FlowLayoutPanel();
            btnCreateCommittee = new Button();
            btnEditCommittee = new Button();
            tabRegistrations = new TabPage();
            dgvRegistrations = new DataGridView();
            flowLayoutPanelRegistrationsButtons = new FlowLayoutPanel();
            btnUpdateRegistrationStatus = new Button();
            tabGroups = new TabPage(); // Initialize tabGroups
            dgvGroups = new DataGridView(); // Initialize dgvGroups
            flowLayoutPanelGroupsButtons = new FlowLayoutPanel(); // Initialize flowLayoutPanelGroupsButtons
            btnEditGroup = new Button(); // Initialize btnEditGroup
            btnLogout = new Button();
            panelTop = new Panel();

            // Suspend Layouts
            tabControl.SuspendLayout();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            flowLayoutPanelUsersButtons.SuspendLayout();
            tabMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMilestones).BeginInit();
            tabCommittees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCommittees).BeginInit();
            flowLayoutPanelCommitteesButtons.SuspendLayout();
            tabRegistrations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
            tabGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGroups).BeginInit();
            flowLayoutPanelGroupsButtons.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();

            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabUsers);
            tabControl.Controls.Add(tabMilestones);
            tabControl.Controls.Add(tabCommittees);
            tabControl.Controls.Add(tabRegistrations);
            tabControl.Controls.Add(tabGroups); // Thêm tabGroups vào tabControl
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(784, 391);
            tabControl.TabIndex = 1;

            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(dgvUsers);
            tabUsers.Controls.Add(flowLayoutPanelUsersButtons);
            tabUsers.Location = new System.Drawing.Point(4, 24);
            tabUsers.Name = "tabUsers";
            tabUsers.Padding = new Padding(3);
            tabUsers.Size = new System.Drawing.Size(776, 363);
            tabUsers.TabIndex = 0;
            tabUsers.Text = "Users";
            tabUsers.UseVisualStyleBackColor = true;

            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new System.Drawing.Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.Size = new System.Drawing.Size(770, 313);
            dgvUsers.TabIndex = 0;

            // 
            // flowLayoutPanelUsersButtons
            // 
            flowLayoutPanelUsersButtons.Controls.Add(btnCreateUser);
            flowLayoutPanelUsersButtons.Controls.Add(btnEditUser);
            flowLayoutPanelUsersButtons.Controls.Add(btnDeleteUser);
            flowLayoutPanelUsersButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelUsersButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelUsersButtons.WrapContents = false;
            flowLayoutPanelUsersButtons.AutoSize = true;
            flowLayoutPanelUsersButtons.Padding = new Padding(10);
            flowLayoutPanelUsersButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnCreateUser
            // 
            btnCreateUser.AutoSize = true;
            btnCreateUser.Margin = new Padding(0, 0, 10, 0);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new System.Drawing.Size(120, 30);
            btnCreateUser.TabIndex = 1;
            btnCreateUser.Text = "Create User";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;

            // 
            // btnEditUser
            // 
            btnEditUser.AutoSize = true;
            btnEditUser.Margin = new Padding(0, 0, 10, 0);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new System.Drawing.Size(120, 30);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;

            // 
            // btnDeleteUser
            // 
            btnDeleteUser.AutoSize = true;
            btnDeleteUser.Margin = new Padding(0, 0, 10, 0);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new System.Drawing.Size(120, 30);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;

            // 
            // tabMilestones
            // 
            tabMilestones.Controls.Add(dgvMilestones);
            tabMilestones.Controls.Add(flowLayoutPanelMilestonesButtons);
            tabMilestones.Location = new System.Drawing.Point(4, 24);
            tabMilestones.Name = "tabMilestones";
            tabMilestones.Padding = new Padding(3);
            tabMilestones.Size = new System.Drawing.Size(776, 363);
            tabMilestones.TabIndex = 1;
            tabMilestones.Text = "Milestones";
            tabMilestones.UseVisualStyleBackColor = true;

            // 
            // dgvMilestones
            // 
            dgvMilestones.AllowUserToAddRows = false;
            dgvMilestones.AllowUserToDeleteRows = false;
            dgvMilestones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMilestones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMilestones.Dock = DockStyle.Fill;
            dgvMilestones.Location = new System.Drawing.Point(3, 3);
            dgvMilestones.Name = "dgvMilestones";
            dgvMilestones.ReadOnly = true;
            dgvMilestones.RowHeadersVisible = false;
            dgvMilestones.Size = new System.Drawing.Size(770, 316);
            dgvMilestones.TabIndex = 0;

            // 
            // flowLayoutPanelMilestonesButtons
            // 
            flowLayoutPanelMilestonesButtons.Controls.Add(btnCreateMilestone);
            flowLayoutPanelMilestonesButtons.Controls.Add(btnEditMilestone);
            flowLayoutPanelMilestonesButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelMilestonesButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelMilestonesButtons.WrapContents = false;
            flowLayoutPanelMilestonesButtons.AutoSize = true;
            flowLayoutPanelMilestonesButtons.Padding = new Padding(10);
            flowLayoutPanelMilestonesButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnCreateMilestone
            // 
            btnCreateMilestone.AutoSize = true;
            btnCreateMilestone.Margin = new Padding(0, 0, 10, 0);
            btnCreateMilestone.Name = "btnCreateMilestone";
            btnCreateMilestone.Size = new System.Drawing.Size(150, 30);
            btnCreateMilestone.TabIndex = 1;
            btnCreateMilestone.Text = "Create Milestone";
            btnCreateMilestone.UseVisualStyleBackColor = true;
            btnCreateMilestone.Click += btnCreateMilestone_Click;

            // 
            // btnEditMilestone
            // 
            btnEditMilestone.AutoSize = true;
            btnEditMilestone.Margin = new Padding(0, 0, 10, 0);
            btnEditMilestone.Name = "btnEditMilestone";
            btnEditMilestone.Size = new System.Drawing.Size(150, 30);
            btnEditMilestone.TabIndex = 2;
            btnEditMilestone.Text = "Edit Milestone";
            btnEditMilestone.UseVisualStyleBackColor = true;
            btnEditMilestone.Click += btnEditMilestone_Click;

            // 
            // tabCommittees
            // 
            tabCommittees.Controls.Add(dgvCommittees);
            tabCommittees.Controls.Add(flowLayoutPanelCommitteesButtons);
            tabCommittees.Location = new System.Drawing.Point(4, 24);
            tabCommittees.Name = "tabCommittees";
            tabCommittees.Padding = new Padding(3);
            tabCommittees.Size = new System.Drawing.Size(776, 363);
            tabCommittees.TabIndex = 2;
            tabCommittees.Text = "Committees";
            tabCommittees.UseVisualStyleBackColor = true;

            // 
            // dgvCommittees
            // 
            dgvCommittees.AllowUserToAddRows = false;
            dgvCommittees.AllowUserToDeleteRows = false;
            dgvCommittees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCommittees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommittees.Dock = DockStyle.Fill;
            dgvCommittees.Location = new System.Drawing.Point(3, 3);
            dgvCommittees.Name = "dgvCommittees";
            dgvCommittees.ReadOnly = true;
            dgvCommittees.RowHeadersVisible = false;
            dgvCommittees.Size = new System.Drawing.Size(770, 316);
            dgvCommittees.TabIndex = 0;

            // 
            // flowLayoutPanelCommitteesButtons
            // 
            flowLayoutPanelCommitteesButtons.Controls.Add(btnCreateCommittee);
            flowLayoutPanelCommitteesButtons.Controls.Add(btnEditCommittee);
            flowLayoutPanelCommitteesButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelCommitteesButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelCommitteesButtons.WrapContents = false;
            flowLayoutPanelCommitteesButtons.AutoSize = true;
            flowLayoutPanelCommitteesButtons.Padding = new Padding(10);
            flowLayoutPanelCommitteesButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnCreateCommittee
            // 
            btnCreateCommittee.AutoSize = true;
            btnCreateCommittee.Margin = new Padding(0, 0, 10, 0);
            btnCreateCommittee.Name = "btnCreateCommittee";
            btnCreateCommittee.Size = new System.Drawing.Size(150, 30);
            btnCreateCommittee.TabIndex = 1;
            btnCreateCommittee.Text = "Create Committee";
            btnCreateCommittee.UseVisualStyleBackColor = true;
            btnCreateCommittee.Click += btnCreateCommittee_Click;

            // 
            // btnEditCommittee
            // 
            btnEditCommittee.AutoSize = true;
            btnEditCommittee.Margin = new Padding(0, 0, 10, 0);
            btnEditCommittee.Name = "btnEditCommittee";
            btnEditCommittee.Size = new System.Drawing.Size(150, 30);
            btnEditCommittee.TabIndex = 2;
            btnEditCommittee.Text = "Edit Committee";
            btnEditCommittee.UseVisualStyleBackColor = true;
            btnEditCommittee.Click += btnEditCommittee_Click;

            // 
            // tabRegistrations
            // 
            tabRegistrations.Controls.Add(dgvRegistrations);
            tabRegistrations.Controls.Add(flowLayoutPanelRegistrationsButtons);
            tabRegistrations.Location = new System.Drawing.Point(4, 24);
            tabRegistrations.Name = "tabRegistrations";
            tabRegistrations.Padding = new Padding(3);
            tabRegistrations.Size = new System.Drawing.Size(776, 363);
            tabRegistrations.TabIndex = 3;
            tabRegistrations.Text = "Registrations";
            tabRegistrations.UseVisualStyleBackColor = true;

            // 
            // dgvRegistrations
            // 
            dgvRegistrations.AllowUserToAddRows = false;
            dgvRegistrations.AllowUserToDeleteRows = false;
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrations.Dock = DockStyle.Fill;
            dgvRegistrations.Location = new System.Drawing.Point(3, 3);
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.RowHeadersVisible = false;
            dgvRegistrations.Size = new System.Drawing.Size(770, 316);
            dgvRegistrations.TabIndex = 0;

            // 
            // flowLayoutPanelRegistrationsButtons
            // 
            flowLayoutPanelRegistrationsButtons.Controls.Add(btnUpdateRegistrationStatus);
            flowLayoutPanelRegistrationsButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelRegistrationsButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelRegistrationsButtons.WrapContents = false;
            flowLayoutPanelRegistrationsButtons.AutoSize = true;
            flowLayoutPanelRegistrationsButtons.Padding = new Padding(10);
            flowLayoutPanelRegistrationsButtons.Size = new System.Drawing.Size(770, 47);

            // 
            // btnUpdateRegistrationStatus
            // 
            btnUpdateRegistrationStatus.AutoSize = true;
            btnUpdateRegistrationStatus.Margin = new Padding(0, 0, 10, 0);
            btnUpdateRegistrationStatus.Name = "btnUpdateRegistrationStatus";
            btnUpdateRegistrationStatus.Size = new System.Drawing.Size(200, 30);
            btnUpdateRegistrationStatus.TabIndex = 1;
            btnUpdateRegistrationStatus.Text = "Update Registration Status";
            btnUpdateRegistrationStatus.UseVisualStyleBackColor = true;
            btnUpdateRegistrationStatus.Click += btnUpdateRegistrationStatus_Click;

            // 
            // tabGroups
            // 
            tabGroups.Controls.Add(dgvGroups);
            tabGroups.Controls.Add(flowLayoutPanelGroupsButtons);
            tabGroups.Location = new System.Drawing.Point(4, 24);
            tabGroups.Name = "tabGroups";
            tabGroups.Padding = new Padding(3);
            tabGroups.Size = new System.Drawing.Size(776, 363);
            tabGroups.TabIndex = 4;
            tabGroups.Text = "Groups";
            tabGroups.UseVisualStyleBackColor = true;

            // 
            // dgvGroups
            // 
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.AllowUserToDeleteRows = false;
            dgvGroups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGroups.Dock = DockStyle.Fill;
            dgvGroups.Location = new System.Drawing.Point(3, 3);
            dgvGroups.Name = "dgvGroups";
            dgvGroups.ReadOnly = true;
            dgvGroups.RowHeadersVisible = false;
            dgvGroups.Size = new System.Drawing.Size(770, 316);
            dgvGroups.TabIndex = 0;

            // 
            // flowLayoutPanelGroupsButtons
            // 
            flowLayoutPanelGroupsButtons.Controls.Add(btnEditGroup);
            flowLayoutPanelGroupsButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelGroupsButtons.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelGroupsButtons.WrapContents = false;
            flowLayoutPanelGroupsButtons.AutoSize = true;
            flowLayoutPanelGroupsButtons.Padding = new Padding(10);
            flowLayoutPanelGroupsButtons.Size = new System.Drawing.Size(770, 47);


            // 
            // btnEditGroup
            // 
            btnEditGroup.AutoSize = true;
            btnEditGroup.Margin = new Padding(0, 0, 10, 0);
            btnEditGroup.Name = "btnEditGroup";
            btnEditGroup.Size = new System.Drawing.Size(120, 30);
            btnEditGroup.TabIndex = 2;
            btnEditGroup.Text = "Edit Group";
            btnEditGroup.UseVisualStyleBackColor = true;
            btnEditGroup.Click += btnEditGroup_Click;

            // 
            // btnLogout
            // 
            btnLogout.AutoSize = true;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.Margin = new Padding(0, 10, 10, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(120, 30);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;

            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 50;
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(784, 50);
            panelTop.TabIndex = 0;

            // 
            // AdminForm
            // 
            ClientSize = new System.Drawing.Size(784, 441);
            Controls.Add(tabControl);
            Controls.Add(panelTop);
            Name = "AdminForm";
            Text = "Admin Panel";
            Load += AdminForm_Load;
            tabControl.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            flowLayoutPanelUsersButtons.ResumeLayout(false);
            flowLayoutPanelUsersButtons.PerformLayout();
            tabMilestones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMilestones).EndInit();
            flowLayoutPanelMilestonesButtons.ResumeLayout(false);
            flowLayoutPanelMilestonesButtons.PerformLayout();
            tabCommittees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCommittees).EndInit();
            flowLayoutPanelCommitteesButtons.ResumeLayout(false);
            flowLayoutPanelCommitteesButtons.PerformLayout();
            tabRegistrations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            flowLayoutPanelRegistrationsButtons.ResumeLayout(false);
            flowLayoutPanelRegistrationsButtons.PerformLayout();
            tabGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGroups).EndInit();
            flowLayoutPanelGroupsButtons.ResumeLayout(false);
            flowLayoutPanelGroupsButtons.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }
    }
}
