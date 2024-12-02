using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class EditCommitteeForm : Form
    {
        private readonly ICommitteeService _committeeService;
        private readonly ILecturerService _lecturerService;
        private Guid _committeeID;
        private Committee _committee;
        private readonly IServiceProvider _serviceProvider;

        public EditCommitteeForm(ICommitteeService committeeService, ILecturerService lecturerService, IServiceProvider services)
        {
            InitializeComponent();
            _committeeService = committeeService;
            _lecturerService = lecturerService;
            _serviceProvider = services;
        }

        // Phương thức để thiết lập CommitteeID và tải dữ liệu Committee
        public void SetCommitteeID(Guid committeeID)
        {
            _committeeID = committeeID;
        }

        private async void EditCommitteeForm_Load(object sender, EventArgs e)
        {
            InitializeLecturersDataGridView();
            await LoadCommitteeData();
        }

        private async Task LoadCommitteeData()
        {
            try
            {
                _committee = await _committeeService.GetCommitteeByID(_committeeID);
                if (_committee == null)
                {
                    MessageBox.Show("Không tìm thấy Committee.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtCommitteeName.Text = _committee.Name;
                dtpDefenseDate.Value = _committee.DefenseDate;

                // Tải danh sách Lecturers vào DataGridView
                await PopulateLecturersDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Committee: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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


        private async Task PopulateLecturersDataGridView()
        {
            dgvLecturers.Rows.Clear();

            foreach (var cm in _committee.CommitteeMembers)
            {
                var lecturer = await _lecturerService.GetLecturerById(cm.LecturerID);
                if (lecturer != null)
                {
                    dgvLecturers.Rows.Add(false, cm.LecturerID, lecturer.Name, lecturer.Department, cm.Role);
                }
            }
        }

        private async void btnAddLecturer_Click(object sender, EventArgs e)
        {
            // Mở form chọn Lecturer để thêm
            var addLecturerForm = _serviceProvider.GetRequiredService<AddLecturerToCommitteeForm>();
            addLecturerForm.SetCommitteeID(_committeeID);
            if (addLecturerForm.ShowDialog() == DialogResult.OK)
            {
                // Tải lại dữ liệu Committee
                await LoadCommitteeData();
            }
        }

        private async void btnRemoveLecturer_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các Lecturer được chọn để xóa
            var selectedLecturers = dgvLecturers.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Select"].Value))
                .Select(r => new
                {
                    LecturerID = (Guid)r.Cells["LecturerID"].Value,
                    Name = r.Cells["Name"].Value.ToString()
                })
                .ToList();

            if (selectedLecturers.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một Lecturer để xóa.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa {selectedLecturers.Count} Lecturer(s) khỏi Committee này?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                foreach (var lecturer in selectedLecturers)
                {
                    try
                    {
                        await _committeeService.RemoveLecturerFromCommittee(_committee.CommitteeID, lecturer.LecturerID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa Lecturer '{lecturer.Name}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Lecturers đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadCommitteeData();
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

            // Kiểm tra số lượng Chairman và Secretary
            var chairmanCount = _committee.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.Chairman);
            var secretaryCount = _committee.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.Secretary);

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

            // Cập nhật Committee
            _committee.Name = committeeName;
            _committee.DefenseDate = defenseDate;

            try
            {
                await _committeeService.EditCommittee(_committee);
                MessageBox.Show("Committee đã được cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật Committee: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
