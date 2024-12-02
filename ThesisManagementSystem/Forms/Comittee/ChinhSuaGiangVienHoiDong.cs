using System;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class ChinhSuaGiangVienHoiDongForm : Form
    {
        private readonly ICommitteeService _dichVuHoiDong;
        private readonly ILecturerService _dichVuGiangVien;
        private Guid _hoiDongID;
        private Committee _hoiDong;

        public ChinhSuaGiangVienHoiDongForm(ICommitteeService dichVuHoiDong, ILecturerService dichVuGiangVien)
        {
            InitializeComponent();
            _dichVuHoiDong = dichVuHoiDong;
            _dichVuGiangVien = dichVuGiangVien;
        }

        /// <summary>
        /// Thiết lập ID của Hội Đồng cho form này.
        /// </summary>
        /// <param name="hoiDongID">ID của Hội Đồng muốn chỉnh sửa.</param>
        public void SetHoiDongID(Guid hoiDongID)
        {
            _hoiDongID = hoiDongID;
        }

        private async void ChinhSuaGiangVienHoiDongForm_Load(object sender, EventArgs e)
        {
            KhoiTaoDgvGiangVienTrongHoiDong();
            await TaiDuLieuHoiDong();
        }

        /// <summary>
        /// Khởi tạo các cột cho DataGridView.
        /// </summary>
        private void KhoiTaoDgvGiangVienTrongHoiDong()
        {
            dgvGiangVienTrongHoiDong.AutoGenerateColumns = false;
            dgvGiangVienTrongHoiDong.Columns.Clear();

            // Cột LecturerID (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvGiangVienTrongHoiDong.Columns.Add(idColumn);

            // Cột Tên Giảng Viên
            var tenGiangVienColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Giảng Viên",
                Name = "TenGiangVien",
                ReadOnly = true
            };
            dgvGiangVienTrongHoiDong.Columns.Add(tenGiangVienColumn);

            // Cột Khoa
            var khoaColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa",
                Name = "Khoa",
                ReadOnly = true
            };
            dgvGiangVienTrongHoiDong.Columns.Add(khoaColumn);

            // Cột Vai Trò (ComboBox)
            var vaiTroColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Vai Trò",
                Name = "VaiTro",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvGiangVienTrongHoiDong.Columns.Add(vaiTroColumn);

            // Cột Remove (Checkbox)
            var removeColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Xóa",
                Name = "Remove",
                Width = 50
            };
            dgvGiangVienTrongHoiDong.Columns.Add(removeColumn);
        }

        /// <summary>
        /// Tải dữ liệu của Hội Đồng hiện tại.
        /// </summary>
        private async Task TaiDuLieuHoiDong()
        {
            try
            {
                _hoiDong = await _dichVuHoiDong.GetCommitteeByID(_hoiDongID);
                if (_hoiDong == null)
                {
                    MessageBox.Show("Không tìm thấy Hội Đồng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin Hội Đồng
                txtTenHoiDong.Text = _hoiDong.Name;
                dtpNgayBaoVe.Value = _hoiDong.DefenseDate;

                // Tải danh sách Giảng Viên vào DataGridView
                await NapDanhSachGiangVienTrongHoiDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tải danh sách Giảng Viên vào DataGridView.
        /// </summary>
        private async Task NapDanhSachGiangVienTrongHoiDong()
        {
            dgvGiangVienTrongHoiDong.Rows.Clear();

            foreach (var member in _hoiDong.CommitteeMembers)
            {
                var giangVien = await _dichVuGiangVien.GetLecturerById(member.LecturerID);
                if (giangVien != null)
                {
                    dgvGiangVienTrongHoiDong.Rows.Add(
                        member.LecturerID,
                        giangVien.Name,
                        giangVien.Department,
                        member.Role,
                        false
                    );
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu Thay Đổi.
        /// </summary>
        private async void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGiangVienTrongHoiDong.Rows)
            {
                var lecturerID = (Guid)row.Cells["LecturerID"].Value;
                var role = (RoleCommitteeMember)row.Cells["VaiTro"].Value;
                var remove = Convert.ToBoolean(row.Cells["Remove"].Value);

                if (remove)
                {
                    await _dichVuHoiDong.RemoveLecturerFromCommittee(_hoiDongID, lecturerID);
                }
                else
                {
                    var member = _hoiDong.CommitteeMembers.FirstOrDefault(cm => cm.LecturerID == lecturerID);
                    if (member != null && member.Role != role)
                    {
                        member.Role = role;
                        await _dichVuHoiDong.UpdateCommitteeMember(member);
                    }
                }
            }

            MessageBox.Show("Các thay đổi đã được lưu thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Hủy.
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
