using System;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class EditLecturerInCommitteeForm : Form
    {
        private readonly ICommitteeService _committeeService;
        private readonly ILecturerService _lecturerService;
        private Guid _committeeID;
        private Committee _committee;

        public EditLecturerInCommitteeForm(ICommitteeService committeeService, ILecturerService lecturerService)
        {
            InitializeComponent();
            _committeeService = committeeService;
            _lecturerService = lecturerService;
        }

        public void SetCommitteeID(Guid committeeID)
        {
            _committeeID = committeeID;
        }

        private async void EditLecturerInCommitteeForm_Load(object sender, EventArgs e)
        {
            InitializeLecturersDataGridView();
            await LoadCommitteeData();
        }

        private void InitializeLecturersDataGridView()
        {
            dgvLecturersInCommittee.AutoGenerateColumns = false;
            dgvLecturersInCommittee.Columns.Clear();

            // LecturerID column (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvLecturersInCommittee.Columns.Add(idColumn);

            // Name column
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Name",
                ReadOnly = true
            };
            dgvLecturersInCommittee.Columns.Add(nameColumn);

            // Department column
            var deptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Department",
                Name = "Department",
                ReadOnly = true
            };
            dgvLecturersInCommittee.Columns.Add(deptColumn);

            // Role column (ComboBox)
            var roleColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Role",
                Name = "Role",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvLecturersInCommittee.Columns.Add(roleColumn);

            // Remove column (Checkbox)
            var removeColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Remove",
                Name = "Remove",
                Width = 50
            };
            dgvLecturersInCommittee.Columns.Add(removeColumn);
        }

        private async Task LoadCommitteeData()
        {
            _committee = await _committeeService.GetCommitteeByID(_committeeID);
            if (_committee == null)
            {
                MessageBox.Show("Committee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            dgvLecturersInCommittee.Rows.Clear();
            foreach (var member in _committee.CommitteeMembers)
            {
                var lecturer = await _lecturerService.GetLecturerById(member.LecturerID);
                if (lecturer != null)
                {
                    dgvLecturersInCommittee.Rows.Add(
                        member.LecturerID,
                        lecturer.Name,
                        lecturer.Department,
                        member.Role,
                        false
                    );
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLecturersInCommittee.Rows)
            {
                var lecturerID = (Guid)row.Cells["LecturerID"].Value;
                var role = (RoleCommitteeMember)row.Cells["Role"].Value;
                var remove = Convert.ToBoolean(row.Cells["Remove"].Value);

                if (remove)
                {
                    _committeeService.RemoveLecturerFromCommittee(_committeeID, lecturerID);
                }
                else
                {
                    var member = _committee.CommitteeMembers.FirstOrDefault(cm => cm.LecturerID == lecturerID);
                    if (member != null && member.Role != role)
                    {
                        member.Role = role;
                        _committeeService.UpdateCommitteeMember(member);
                    }
                }
            }

            MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
