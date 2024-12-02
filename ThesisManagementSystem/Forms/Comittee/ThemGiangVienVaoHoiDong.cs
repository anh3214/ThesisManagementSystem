using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class ThemGiangVienVaoHoiDongForm : Form
    {
        private readonly ICommitteeService _dichVuHoiDong;
        private readonly ILecturerService _dichVuGiangVien;
        private Guid _hoiDongID;
        private Committee _hoiDong;

        public ThemGiangVienVaoHoiDongForm(ICommitteeService dichVuHoiDong, ILecturerService dichVuGiangVien)
        {
            InitializeComponent();
            _dichVuHoiDong = dichVuHoiDong;
            _dichVuGiangVien = dichVuGiangVien;
        }

        /// <summary>
        /// Thiết lập ID của Hội Đồng cho form này.
        /// </summary>
        /// <param name="hoiDongID">ID của Hội Đồng muốn thêm Giảng Viên.</param>
        public void SetHoiDongID(Guid hoiDongID)
        {
            _hoiDongID = hoiDongID;
        }

        /// <summary>
        /// Sự kiện Load của form.
        /// </summary>
        private async void ThemGiangVienVaoHoiDongForm_Load(object sender, EventArgs e)
        {
            KhoiTaoDgvGiangVienCoSan();
            await TaiDuLieuHoiDong();
            await TaiGiangVienCoSan();
        }

        /// <summary>
        /// Khởi tạo các cột cho DataGridView.
        /// </summary>
        private void KhoiTaoDgvGiangVienCoSan()
        {
            dgvGiangVienKhongCo.AutoGenerateColumns = false;

            dgvGiangVienKhongCo.Columns.Clear();

            // Cột chọn Giảng Viên
            var selectColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Chọn",
                Name = "Chon",
                Width = 50
            };
            dgvGiangVienKhongCo.Columns.Add(selectColumn);

            // Cột LecturerID (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvGiangVienKhongCo.Columns.Add(idColumn);

            // Cột Tên Giảng Viên
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Giảng Viên",
                Name = "TenGiangVien",
                ReadOnly = true
            };
            dgvGiangVienKhongCo.Columns.Add(nameColumn);

            // Cột Khoa
            var deptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa",
                Name = "Khoa",
                ReadOnly = true
            };
            dgvGiangVienKhongCo.Columns.Add(deptColumn);

            // Cột Vai Trò (ComboBox)
            var roleColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Vai Trò",
                Name = "VaiTro",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvGiangVienKhongCo.Columns.Add(roleColumn);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tải danh sách Giảng Viên có sẵn (không bao gồm các Giảng Viên đã trong Hội Đồng).
        /// </summary>
        private async Task TaiGiangVienCoSan()
        {
            try
            {
                // Lấy tất cả Giảng Viên
                var tatCaGiangVien = await _dichVuGiangVien.GetAllLecturers();

                // Lấy LecturerIDs hiện tại trong Hội Đồng
                var maGiangVienHienTai = _hoiDong.CommitteeMembers.Select(cm => cm.LecturerID).ToList();

                // Lấy Giảng Viên không có trong Hội Đồng
                var giangVienCoSan = tatCaGiangVien.Where(g => !maGiangVienHienTai.Contains(g.LecturerID)).ToList();

                // Thêm vào DataGridView
                dgvGiangVienKhongCo.Rows.Clear();
                foreach (var giangVien in giangVienCoSan)
                {
                    dgvGiangVienKhongCo.Rows.Add(false, giangVien.LecturerID, giangVien.Name, giangVien.Department, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Giảng Viên có sẵn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Thêm Giảng Viên.
        /// </summary>
        private async void btnThemGiangVien_Click(object sender, EventArgs e)
        {
            // Lấy danh sách Giảng Viên đã chọn
            var giangVienDuocChon = new List<CommitteeMember>();
            foreach (DataGridViewRow row in dgvGiangVienKhongCo.Rows)
            {
                var daChon = Convert.ToBoolean(row.Cells["Chon"].Value);
                if (daChon)
                {
                    var maGiangVien = (Guid)row.Cells["LecturerID"].Value;
                    var tenGiangVien = row.Cells["TenGiangVien"].Value.ToString();
                    var vaiTroChuoi = row.Cells["VaiTro"].Value?.ToString();

                    // Kiểm tra xem đã chọn vai trò chưa
                    if (string.IsNullOrEmpty(vaiTroChuoi))
                    {
                        MessageBox.Show($"Vui lòng chọn vai trò cho Giảng Viên '{tenGiangVien}'.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra vai trò có hợp lệ không
                    if (!Enum.TryParse<RoleCommitteeMember>(vaiTroChuoi, out var vaiTro))
                    {
                        MessageBox.Show($"Vai trò không hợp lệ cho Giảng Viên '{tenGiangVien}'.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra rằng không có nhiều hơn một Chủ Tịch hoặc Thư Ký
                    if (vaiTro == RoleCommitteeMember.ChuTich && _hoiDong.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.ChuTich) + giangVienDuocChon.Count(cm => cm.Role == RoleCommitteeMember.ChuTich) >= 1)
                    {
                        MessageBox.Show("Hội Đồng đã có một Chủ Tịch.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (vaiTro == RoleCommitteeMember.ThuKy && _hoiDong.CommitteeMembers.Count(cm => cm.Role == RoleCommitteeMember.ThuKy) + giangVienDuocChon.Count(cm => cm.Role == RoleCommitteeMember.ThuKy) >= 1)
                    {
                        MessageBox.Show("Hội Đồng đã có một Thư Ký.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tạo CommitteeMember
                    var committeeMember = new CommitteeMember
                    {
                        CommitteeID = _hoiDongID,
                        LecturerID = maGiangVien,
                        Role = vaiTro
                    };

                    giangVienDuocChon.Add(committeeMember);
                }
            }

            if (giangVienDuocChon.Count == 0)
            {
                MessageBox.Show("Không có Giảng Viên nào được chọn để thêm.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Thêm từng CommitteeMember vào Hội Đồng
                foreach (var cm in giangVienDuocChon)
                {
                    await _dichVuHoiDong.AddLecturerToCommittee(_hoiDongID, cm.LecturerID, cm.Role);
                }

                MessageBox.Show("Giảng Viên đã được thêm thành công vào Hội Đồng.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

                // Cập nhật lại DataGridView nếu cần
                await TaiGiangVienCoSan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm Giảng Viên vào Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
