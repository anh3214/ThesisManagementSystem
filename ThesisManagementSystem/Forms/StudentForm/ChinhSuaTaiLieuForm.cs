using System;
using System.Windows.Forms;

namespace ThesisManagementSystem.Forms
{
    public partial class ChinhSuaTaiLieuForm : Form
    {
        public string DuongDanTaiLieuMoi { get; private set; }

        public ChinhSuaTaiLieuForm(string duongDanTaiLieuHienTai)
        {
            InitializeComponent();
            txtTaiLieuHienTai.Text = duongDanTaiLieuHienTai;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiLieuMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn tài liệu mới.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.IsWellFormedUriString(txtTaiLieuMoi.Text, UriKind.Absolute))
            {
                MessageBox.Show("Đường dẫn URL không hợp lệ.", "Lỗi URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DuongDanTaiLieuMoi = txtTaiLieuMoi.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
