using System;
using System.Windows.Forms;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class CapNhatTrangThaiForm : Form
    {
        public RegistrationStatus TrangThaiDaChon { get; private set; }

        public CapNhatTrangThaiForm()
        {
            InitializeComponent();
            cmbTrangThai.Items.AddRange(new object[] { "Approved", "Rejected" });
        }

        public void CaiDatTrangThaiHienTai(string trangThaiHienTai)
        {
            cmbTrangThai.SelectedItem = trangThaiHienTai;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cmbTrangThai.SelectedItem != null)
            {
                try
                {
                    TrangThaiDaChon = (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), cmbTrangThai.SelectedItem.ToString());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Trạng thái đã chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng chọn trạng thái.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
