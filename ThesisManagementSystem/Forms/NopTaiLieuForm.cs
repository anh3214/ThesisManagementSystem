using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class NopTaiLieuForm : Form
    {
        private readonly Guid _maDangKy;
        private readonly IMilestoneService _cotMocService;
        private readonly ISubmissionService _nopBaiService;

        public NopTaiLieuForm(Guid maDangKy, IMilestoneService cotMocService, ISubmissionService nopBaiService)
        {
            InitializeComponent();
            _maDangKy = maDangKy;
            _cotMocService = cotMocService;
            _nopBaiService = nopBaiService;
        }

        private async void NopTaiLieuForm_Load(object sender, EventArgs e)
        {
            // Tải danh sách cột mốc
            var cotMoc = await _cotMocService.GetAllMilestones();
            cmbCotMoc.DataSource = cotMoc;
            cmbCotMoc.DisplayMember = "Name";
            cmbCotMoc.ValueMember = "MilestoneID";
        }

        private async void btnNop_Click(object sender, EventArgs e)
        {
            if (cmbCotMoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một cột mốc.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDuongDanTaiLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn tài liệu.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maCotMocDuocChon = (Guid)cmbCotMoc.SelectedValue;

            // Kiểm tra xem đã có nộp bài cho cột mốc và đăng ký này chưa
            var nopBaiTonTai = await _nopBaiService.GetSubmissionByWhereClause(
                s => s.RegistrationID == _maDangKy && s.MilestoneID == maCotMocDuocChon);

            if (nopBaiTonTai.Any())
            {
                MessageBox.Show("Đã tồn tại bài nộp cho cột mốc này.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Uri.IsWellFormedUriString(txtDuongDanTaiLieu.Text, UriKind.Absolute))
            {
                MessageBox.Show("Đường dẫn đã nhập không hợp lệ.", "Lỗi URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nopBaiMoi = new Submission
            {
                SubmissionID = Guid.NewGuid(),
                RegistrationID = _maDangKy,
                MilestoneID = maCotMocDuocChon,
                SubmissionDate = DateTime.Now,
                DocumentPath = txtDuongDanTaiLieu.Text
            };

            await _nopBaiService.AddSubmissionAsync(nopBaiMoi);

            MessageBox.Show("Nộp tài liệu thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}