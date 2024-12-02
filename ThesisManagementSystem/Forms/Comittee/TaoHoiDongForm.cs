using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.BLL.Services;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class TaoHoiDongForm : Form
    {
        private readonly ICommitteeService _dichVuHoiDong;
        private readonly ILecturerService _dichVuGiangVien; // Giả sử bạn có ILecturerService để lấy danh sách Giảng Viên
        private List<CommitteeMember> giangVienDaChon;

        public TaoHoiDongForm(ICommitteeService dichVuHoiDong, ILecturerService dichVuGiangVien)
        {
            InitializeComponent();
            _dichVuHoiDong = dichVuHoiDong;
            _dichVuGiangVien = dichVuGiangVien;
            giangVienDaChon = new List<CommitteeMember>();
        }

        private async void TaoHoiDongForm_Load(object sender, EventArgs e)
        {
            KhoiTaoDgvGiangVien();
            await TaiTatCaGiangVien();
        }

        private async Task TaiTatCaGiangVien()
        {
            try
            {
                var giangVien = await _dichVuGiangVien.GetAllLecturers(); // Lấy tất cả Giảng Viên
                dgvGiangVien.Rows.Clear(); // Xóa hàng cũ nếu có
                foreach (var gv in giangVien)
                {
                    dgvGiangVien.Rows.Add(false, gv.LecturerID, gv.Name, gv.Department, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Giảng Viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoDgvGiangVien()
        {
            dgvGiangVien.AutoGenerateColumns = false; // Tắt tự động tạo cột

            // Xóa tất cả các cột hiện có
            dgvGiangVien.Columns.Clear();

            // Thêm cột chọn Giảng Viên
            var selectColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Chọn",
                Name = "Select",
                Width = 50
            };
            dgvGiangVien.Columns.Add(selectColumn);

            // Thêm cột LecturerID (ẩn)
            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "LecturerID",
                Name = "LecturerID",
                Visible = false
            };
            dgvGiangVien.Columns.Add(idColumn);

            // Thêm cột Tên Giảng Viên
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Giảng Viên",
                Name = "Name",
                ReadOnly = true
            };
            dgvGiangVien.Columns.Add(nameColumn);

            // Thêm cột Khoa/Department
            var deptColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Khoa",
                Name = "Department",
                ReadOnly = true
            };
            dgvGiangVien.Columns.Add(deptColumn);

            // Thêm cột Vai trò (ComboBox)
            var roleColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Vai Trò",
                Name = "Role",
                DataSource = Enum.GetValues(typeof(RoleCommitteeMember)),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };
            dgvGiangVien.Columns.Add(roleColumn);
        }

        private void btnThemGiangVien_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGiangVien.Rows)
            {
                var daChon = Convert.ToBoolean(row.Cells["Select"].Value);
                if (daChon)
                {
                    var maGiangVien = (Guid)row.Cells["LecturerID"].Value;
                    var tenGiangVien = row.Cells["Name"].Value.ToString();
                    var vaiTroChuoi = row.Cells["Role"].Value?.ToString();

                    if (string.IsNullOrEmpty(vaiTroChuoi))
                    {
                        MessageBox.Show($"Vui lòng chọn vai trò cho Giảng Viên '{tenGiangVien}'.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Enum.TryParse<RoleCommitteeMember>(vaiTroChuoi, out var vaiTro))
                    {
                        MessageBox.Show($"Vai trò không hợp lệ cho Giảng Viên '{tenGiangVien}'.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra xem Giảng Viên đã được thêm chưa
                    if (giangVienDaChon.Exists(cm => cm.LecturerID == maGiangVien))
                    {
                        MessageBox.Show($"Giảng Viên '{tenGiangVien}' đã được thêm.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue; // Bỏ qua Giảng Viên đã thêm
                    }

                    // Thêm vào danh sách
                    giangVienDaChon.Add(new CommitteeMember
                    {
                        LecturerID = maGiangVien,
                        Role = vaiTro
                    });

                    // Bỏ chọn hàng sau khi thêm
                    row.Cells["Select"].Value = false;
                }
            }

            MessageBox.Show("Giảng Viên đã được thêm thành công. Bạn có thể lưu Hội Đồng.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaGiangVien_Click(object sender, EventArgs e)
        {
            if (giangVienDaChon.Count == 0)
            {
                MessageBox.Show("Không có Giảng Viên nào để xóa.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var xoaGiangVienForm = new XoaGiangVienForm(_dichVuGiangVien);
            xoaGiangVienForm.CaiDatGiangVien(giangVienDaChon);
            if (xoaGiangVienForm.ShowDialog() == DialogResult.OK)
            {
                giangVienDaChon = xoaGiangVienForm.GiangVienDaChon;
                MessageBox.Show("Giảng Viên đã được xóa thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string tenHoiDong = txtTenHoiDong.Text.Trim();
            DateTime ngayBaoVe = dtpNgayBaoVe.Value.Date;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(tenHoiDong))
            {
                MessageBox.Show("Vui lòng nhập tên Hội Đồng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngayBaoVe < DateTime.Today)
            {
                MessageBox.Show("Ngày bảo vệ không thể ở quá khứ.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (giangVienDaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một Giảng Viên vào Hội Đồng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng Chủ Tịch và Thư Ký
            var soLuongChuTich = giangVienDaChon.Count(cm => cm.Role == RoleCommitteeMember.ChuTich);
            var soLuongThuKy = giangVienDaChon.Count(cm => cm.Role == RoleCommitteeMember.ThuKy);

            if (soLuongChuTich != 1)
            {
                MessageBox.Show("Hội Đồng phải có chính xác một Chủ Tịch.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuongThuKy != 1)
            {
                MessageBox.Show("Hội Đồng phải có chính xác một Thư Ký.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo Hội Đồng mới
            var newHoiDong = new Committee
            {
                CommitteeID = Guid.NewGuid(),
                Name = tenHoiDong,
                DefenseDate = ngayBaoVe,
                CommitteeMembers = giangVienDaChon,
            };

            try
            {
                await _dichVuHoiDong.CreateCommittee(newHoiDong);
                MessageBox.Show("Hội Đồng đã được tạo thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo Hội Đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
