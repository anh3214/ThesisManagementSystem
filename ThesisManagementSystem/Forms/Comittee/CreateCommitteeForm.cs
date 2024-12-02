using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class CreateCommitteeForm : Form
    {
        private readonly ICommitteeService _committeeService;
        private readonly ILecturerService _lecturerService; // Giả sử bạn có ILecturerService để lấy danh sách Lecturers
        private List<CommitteeMember> selectedLecturers;

        public CreateCommitteeForm(ICommitteeService committeeService, ILecturerService lecturerService)
        {
            InitializeComponent();
            _committeeService = committeeService;
            _lecturerService = lecturerService;
            selectedLecturers = new List<CommitteeMember>();
        }

        private async void CreateCommitteeForm_Load(object sender, EventArgs e)
        {
            InitializeLecturersDataGridView();
            await LoadAllLecturers();
        }

        private async Task LoadAllLecturers()
        {
            try
            {
                var lecturers = await _lecturerService.GetAllLecturers(); // Lấy tất cả Lecturers
                dgvLecturers.Rows.Clear(); // Xóa hàng cũ nếu có
                foreach (var lecturer in lecturers)
                {
                    dgvLecturers.Rows.Add(false, lecturer.LecturerID, lecturer.Name, lecturer.Department, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Lecturers: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeLecturersDataGridView()
        {
            dgvLecturers.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa tất cả các cột hiện có
            dgvLecturers.Columns.Clear();

            // Thêm cột chọn Lecturer
            var selectColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Chọn",
                Name = "Select",
                Width = 50
            };
            dgvLecturers.Columns.Add(selectColumn);

            // Thêm cột LecturerID (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvLecturers.Columns.Add(idColumn);

            // Thêm cột Tên Lecturer
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Lecturer",
                Name = "Name",
                ReadOnly = true
            };
            dgvLecturers.Columns.Add(nameColumn);

            // Thêm cột Khoa/Department
            var deptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa",
                Name = "Department",
                ReadOnly = true
            };
            dgvLecturers.Columns.Add(deptColumn);

            // Thêm cột Vai trò (ComboBox)
            var roleColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Vai trò",
                Name = "Role",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvLecturers.Columns.Add(roleColumn);
        }

        private void btnAddLecturer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLecturers.Rows)
            {
                var isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    var lecturerID = (Guid)row.Cells["LecturerID"].Value;
                    var name = row.Cells["Name"].Value.ToString();
                    var roleValue = row.Cells["Role"].Value?.ToString();

                    if (string.IsNullOrEmpty(roleValue))
                    {
                        MessageBox.Show($"Vui lòng chọn vai trò cho Lecturer '{name}'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Enum.TryParse<RoleCommitteeMember>(roleValue, out var role))
                    {
                        MessageBox.Show($"Vai trò không hợp lệ cho Lecturer '{name}'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra xem Lecturer đã được thêm chưa
                    if (selectedLecturers.Exists(cm => cm.LecturerID == lecturerID))
                    {
                        MessageBox.Show($"Lecturer '{name}' đã được thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue; // Bỏ qua Lecturer đã thêm
                    }

                    // Thêm vào danh sách
                    selectedLecturers.Add(new CommitteeMember
                    {
                        LecturerID = lecturerID,
                        Role = role
                    });

                    // Bỏ chọn hàng sau khi thêm
                    row.Cells["Select"].Value = false;
                }
            }

            MessageBox.Show("Lecturers đã được thêm thành công. Bạn có thể lưu Committee.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnRemoveLecturer_Click(object sender, EventArgs e)
        {
            if (selectedLecturers.Count == 0)
            {
                MessageBox.Show("Không có Lecturer nào để xóa.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var removeForm = new RemoveLecturerForm(_lecturerService);
            removeForm.SetUpLecture(selectedLecturers);
            if (removeForm.ShowDialog() == DialogResult.OK)
            {
                selectedLecturers = removeForm.SelectedLecturers;
                MessageBox.Show("Lecturers đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            string committeeName = txtCommitteeName.Text.Trim();
            DateTime defenseDate = dtpDefenseDate.Value.Date;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(committeeName))
            {
                MessageBox.Show("Vui lòng nhập tên Committee.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (defenseDate < DateTime.Today)
            {
                MessageBox.Show("Ngày bảo vệ không thể ở quá khứ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedLecturers.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một Lecturer vào Committee.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng Chairman và Secretary
            var chairmanCount = selectedLecturers.Count(cm => cm.Role == RoleCommitteeMember.Chairman);
            var secretaryCount = selectedLecturers.Count(cm => cm.Role == RoleCommitteeMember.Secretary);

            if (chairmanCount != 1)
            {
                MessageBox.Show("Committee phải có chính xác một Chairman.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (secretaryCount != 1)
            {
                MessageBox.Show("Committee phải có chính xác một Secretary.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo Committee mới
            var newCommittee = new Committee
            {
                CommitteeID = Guid.NewGuid(),
                Name = committeeName,
                DefenseDate = defenseDate,
                CommitteeMembers = selectedLecturers,
            };

            try
            {
                await _committeeService.CreateCommittee(newCommittee);
                MessageBox.Show("Committee đã được tạo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo Committee: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
