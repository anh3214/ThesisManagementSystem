using System;
using System.Windows.Forms;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class ChinhSuaMocThoiGianForm : Form
    {
        public Milestone MocThoiGianDuocChinhSua { get; private set; }

        public ChinhSuaMocThoiGianForm()
        {
            InitializeComponent();
        }

        public void ThietLapMocThoiGian(Milestone mocThoiGian)
        {
            txtTen.Text = mocThoiGian.Name;
            txtMoTa.Text = mocThoiGian.Description;
            dtpHanNop.Value = mocThoiGian.Deadline;
            MocThoiGianDuocChinhSua = mocThoiGian;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra và cập nhật mốc thời gian
            MocThoiGianDuocChinhSua.Name = txtTen.Text.Trim();
            MocThoiGianDuocChinhSua.Description = txtMoTa.Text.Trim();
            MocThoiGianDuocChinhSua.Deadline = dtpHanNop.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
