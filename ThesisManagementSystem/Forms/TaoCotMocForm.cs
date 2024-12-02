using System;
using System.Windows.Forms;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class TaoCotMocForm : Form
    {
        public Milestone CotMocMoi { get; private set; }

        public TaoCotMocForm()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Kiểm tra và tạo cột mốc mới
            CotMocMoi = new Milestone
            {
                MilestoneID = Guid.NewGuid(),
                Name = txtTen.Text,
                Description = txtMoTa.Text,
                Deadline = dtpHanChot.Value
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
