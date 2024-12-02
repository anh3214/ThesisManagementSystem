using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class XoaGiangVienForm : Form
    {
        private List<CommitteeMember> _giangVien;
        private readonly ILecturerService _dichVuGiangVien;

        public List<CommitteeMember> GiangVienDaChon { get; private set; }

        public XoaGiangVienForm(ILecturerService dichVuGiangVien)
        {
            InitializeComponent();
            _dichVuGiangVien = dichVuGiangVien;
            GiangVienDaChon = new List<CommitteeMember>();
        }

        public void CaiDatGiangVien(List<CommitteeMember> giangVien)
        {
            _giangVien = giangVien;
        }

        private async void XoaGiangVienForm_Load(object sender, EventArgs e)
        {
            await TaiTatCaGiangVien();
        }

        private async Task TaiTatCaGiangVien()
        {
            try
            {
                var giangVien = await _dichVuGiangVien.GetAllLecturers(); // Lấy tất cả Giảng Viên
                lstGiangVien.Items.Clear(); // Xóa các mục cũ nếu có
                foreach (var gv in giangVien)
                {
                    var cm = _giangVien.FirstOrDefault(g => g.LecturerID == gv.LecturerID);
                    if (cm != null)
                    {
                        lstGiangVien.Items.Add(new DanhSachGiangVienItem
                        {
                            LecturerID = cm.LecturerID,
                            Name = gv.Name,
                            Role = cm.Role
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách Giảng Viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaGiangVien_Click(object sender, EventArgs e)
        {
            var selectedItems = lstGiangVien.SelectedItems.Cast<DanhSachGiangVienItem>().ToList();
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một Giảng Viên để xóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var item in selectedItems)
            {
                var cm = _giangVien.Find(l => l.LecturerID == item.LecturerID);
                if (cm != null)
                {
                    GiangVienDaChon.Add(cm);
                    _giangVien.Remove(cm);
                }
            }

            // Cập nhật ListBox
            foreach (var item in selectedItems)
            {
                lstGiangVien.Items.Remove(item);
            }

            MessageBox.Show("Giảng Viên đã được xóa.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Lớp trợ giúp để hiển thị các mục trong ListBox
        private class DanhSachGiangVienItem
        {
            public Guid LecturerID { get; set; }
            public string Name { get; set; }
            public RoleCommitteeMember Role { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Role})";
            }
        }
    }
}
