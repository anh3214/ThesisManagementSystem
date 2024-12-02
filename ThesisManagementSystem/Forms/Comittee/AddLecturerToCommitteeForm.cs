// AddLecturerToCommitteeForm.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class AddLecturerToCommitteeForm : Form
    {
        private readonly ICommitteeService _committeeService;
        private readonly ILecturerService _lecturerService;
        private Guid _committeeID;
        private Committee _committee;

        public AddLecturerToCommitteeForm(ICommitteeService committeeService, ILecturerService lecturerService)
        {
            InitializeComponent();
            _committeeService = committeeService;
            _lecturerService = lecturerService;
        }

        /// <summary>
        /// Thiết lập CommitteeID cho form này.
        /// </summary>
        /// <param name="committeeID">ID của Committee muốn thêm Lecturers.</param>
        public void SetCommitteeID(Guid committeeID)
        {
            _committeeID = committeeID;
        }

        /// <summary>
        /// Sự kiện Load của form.
        /// </summary>
        private async void AddLecturerToCommitteeForm_Load(object sender, EventArgs e)
        {
            InitializeAvailableLecturersDataGridView();
            await LoadCommitteeData();
            await LoadAvailableLecturers();
        }

        /// <summary>
        /// Khởi tạo các cột cho DataGridView.
        /// </summary>
        private void InitializeAvailableLecturersDataGridView()
        {
            dgvAvailableLecturers.AutoGenerateColumns = false;

            dgvAvailableLecturers.Columns.Clear();

            // Checkbox column để chọn Lecturer
            var selectColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "Select",
                Width = 50
            };
            dgvAvailableLecturers.Columns.Add(selectColumn);

            // LecturerID column (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvAvailableLecturers.Columns.Add(idColumn);

            // Name column
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Name",
                ReadOnly = true
            };
            dgvAvailableLecturers.Columns.Add(nameColumn);

            // Department column
            var deptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Department",
                Name = "Department",
                ReadOnly = true
            };
            dgvAvailableLecturers.Columns.Add(deptColumn);

            // Role column (ComboBox)
            var roleColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Role",
                Name = "Role",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvAvailableLecturers.Columns.Add(roleColumn);
        }

        /// <summary>
        /// Tải dữ liệu Committee hiện tại.
        /// </summary>
        private async Task LoadCommitteeData()
        {
            try
            {
                _committee = await _committeeService.GetCommitteeByID(_committeeID);
                if (_committee == null)
                {
                    MessageBox.Show("Committee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Committee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tải danh sách Lecturers có thể thêm vào Committee (không bao gồm các Lecturers đã trong Committee).
        /// </summary>
        private async Task LoadAvailableLecturers()
        {
            try
            {
                // Lấy tất cả Lecturers
                var allLecturers = await _lecturerService.GetAllLecturers();

                // Lấy LecturerIDs hiện tại trong Committee
                var currentLecturerIDs = _committee.CommitteeMembers.Select(cm => cm.LecturerID).ToList();

                // Lấy Lecturers không có trong Committee
                var availableLecturers = allLecturers.Where(l => !currentLecturerIDs.Contains(l.LecturerID)).ToList();

                // Thêm vào DataGridView
                dgvAvailableLecturers.Rows.Clear();
                foreach (var lecturer in availableLecturers)
                {
                    dgvAvailableLecturers.Rows.Add(false, lecturer.LecturerID, lecturer.Name, lecturer.Department, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available Lecturers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Add Lecturers.
        /// </summary>
        private void btnAddLecturers_Click(object sender, EventArgs e)
        {
            // Lấy danh sách Lecturers đã chọn
            var selectedLecturers = new List<CommitteeMember>();
            foreach (DataGridViewRow row in dgvAvailableLecturers.Rows)
            {
                var isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    var lecturerID = (Guid)row.Cells["LecturerID"].Value;
                    var name = row.Cells["Name"].Value.ToString();
                    var roleValue = row.Cells["Role"].Value?.ToString();

                    // Kiểm tra xem đã chọn vai trò chưa
                    if (string.IsNullOrEmpty(roleValue))
                    {
                        MessageBox.Show($"Please assign a role for Lecturer '{name}'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra xem vai trò có hợp lệ không
                    if (!Enum.TryParse<RoleCommitteeMember>(roleValue, out var role))
                    {
                        MessageBox.Show($"Invalid role selected for Lecturer '{name}'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra rằng không có nhiều hơn một Chairman hoặc Secretary
                    if (role == RoleCommitteeMember.Chairman && _committee.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.Chairman) + selectedLecturers.Count(cm => cm.Role == RoleCommitteeMember.Chairman) >= 1)
                    {
                        MessageBox.Show("Committee already has a Chairman.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (role == RoleCommitteeMember.Secretary && _committee.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.Secretary) + selectedLecturers.Count(cm => cm.Role == RoleCommitteeMember.Secretary) >= 1)
                    {
                        MessageBox.Show("Committee already has a Secretary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo CommitteeMember
                    var committeeMember = new CommitteeMember
                    {
                        CommitteeID = _committeeID,
                        LecturerID = lecturerID,
                        Role = role
                    };

                    selectedLecturers.Add(committeeMember);
                }
            }

            if (selectedLecturers.Count == 0)
            {
                MessageBox.Show("No Lecturers selected to add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Thêm từng CommitteeMember vào Committee
                foreach (var cm in selectedLecturers)
                {
                    _committeeService.AddLecturerToCommittee(_committeeID, cm.LecturerID, cm.Role);
                }

                MessageBox.Show("Lecturers added successfully to the Committee.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Lecturers to Committee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Cancel.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
