using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class SinhVienForm : Form
    {
        private readonly Guid _maSinhVien;
        private readonly IStudentService _dichVuSinhVien;
        private readonly IStudentGroupService _dichVuNhomSinhVien;
        private readonly IRegistrationService _dichVuDangKy;
        private readonly ITopicService _dichVuDeTai;
        private readonly IMilestoneService _dichVuKiHan;
        private readonly IEvaluateService _dichVuDanhGia;
        private readonly ISubmissionService _dichVuNopVanBan;
        private readonly IDefenseScoreService _dichVuDiemBaoVe;

        public SinhVienForm(
            IStudentService dichVuSinhVien,
            IStudentGroupService dichVuNhomSinhVien,
            IRegistrationService dichVuDangKy,
            ITopicService dichVuDeTai,
            IMilestoneService dichVuKiHan,
            ISubmissionService dichVuNopVanBan,
            IEvaluateService dichVuDanhGia,
            IDefenseScoreService dichVuDiemBaoVe)
        {
            InitializeComponent();
            _maSinhVien = UserSession.UserID;
            _dichVuSinhVien = dichVuSinhVien;
            _dichVuNhomSinhVien = dichVuNhomSinhVien;
            _dichVuDangKy = dichVuDangKy;
            _dichVuDeTai = dichVuDeTai;
            _dichVuKiHan = dichVuKiHan;
            _dichVuDanhGia = dichVuDanhGia;
            _dichVuNopVanBan = dichVuNopVanBan;
            _dichVuDiemBaoVe = dichVuDiemBaoVe;
        }

        private async void FormSinhVien_Load(object sender, EventArgs e)
        {
            LoadDuLieuAsync().GetAwaiter();
            SetVisibilityNutAsync().GetAwaiter();
        }

        private async Task LoadDuLieuAsync()
        {
            try
            {
                TaiThongTinSinhVien().GetAwaiter();
                await TaiThongTinNhom();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiKetQua(Guid idDangKy)
        {
            var ketQua = await _dichVuDanhGia.FindAsync(x => x.RegistrationID.Equals(idDangKy));
            // Chuyển đổi dữ liệu Evaluation vào dgvKetQua
            dgvKetQua.Rows.Clear();

            foreach (var eval in ketQua)
            {
                dgvKetQua.Rows.Add(
                    "Đánh Giá",
                    eval.Score,
                    0m, // Điểm dự án không áp dụng cho Đánh Giá
                    eval.Comments,
                    eval.EvaluationDate.ToString("dd/MM/yyyy"),
                    eval.Evaluator.Name,
                    eval.Role
                );
            }

            // Chuyển đổi dữ liệu DefenseScore vào dgvDiemBaoVe
            var diemBaoVe = await _dichVuDiemBaoVe.GetScore(idDangKy);
            dgvDiemBaoVe.Rows.Clear();
            if (diemBaoVe != null)
            {
                foreach (var dbv in diemBaoVe.DefenseScores)
                {
                    dgvDiemBaoVe.Rows.Add(
                        "Bảo Vệ Dự Án",
                        dbv.Score,
                        dbv.Comments
                    );
                }
            }
        }

        private async Task TaiThongTinSinhVien()
        {
            // Tải thông tin sinh viên từ cơ sở dữ liệu
            var sinhVien = await _dichVuSinhVien.GetStudentById(_maSinhVien);
            lblTen.Text = $"Tên: {sinhVien.Name}";
            lblLop.Text = $"Lớp: {sinhVien.Class}";
        }

        private async Task TaiThongTinNhom()
        {
            var sinhVien = await _dichVuSinhVien.GetStudentById(_maSinhVien);
            if (sinhVien.GroupID != null)
            {
                // Nếu đã có nhóm
                var nhom = await _dichVuNhomSinhVien.GetGroupById(sinhVien.GroupID.Value);
                if (nhom != null)
                {
                    txtTenNhom.Text = nhom.GroupName;
                    txtTenNhom.ReadOnly = true;
                    btnTaoNhom.Enabled = false;
                    if (nhom.Registration.Count != 0)
                    {
                        dgvDeTaiTrongHoiDong.DataSource = nhom.Registration.Select(s => new
                        {
                            s.TopicID,
                            s.Topic.Title,
                            s.Status,
                            s.Topic.Description,
                            s.RegistrationDate
                        }).ToList();

                        dgvDeTaiTrongHoiDong.Columns["TopicID"].Visible = false;
                        var idDangKy = nhom.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).RegistrationID;
                        await TaiKetQua(idDangKy);
                        var nopVanBan = await _dichVuNopVanBan.GetSubmissionByWhereClause(x => x.RegistrationID.Equals(idDangKy));
                        dgvKiHan.DataSource = nopVanBan.Select(s => new
                        {
                            s.SubmissionID,
                            s.RegistrationID,
                            TenKiHan = s.Milestone.Name,
                            s.SubmissionDate,
                            s.DocumentPath
                        }).ToList();

                        dgvKiHan.Columns["SubmissionID"].Visible = false;
                        dgvKiHan.Columns["RegistrationID"].Visible = false;
                    }
                    else
                        dgvDeTaiTrongHoiDong.DataSource = null;
                    // Hiển thị thành viên nhóm
                    dgvThanhVienNhom.DataSource = nhom.Students.Select(s => new
                    {
                        TenSinhVien = s.Name,
                        Lop = s.Class,
                    }).ToList();
                }
            }
            else
            {
                // Nếu chưa có nhóm
                txtTenNhom.ReadOnly = false;
                btnTaoNhom.Enabled = true;
                dgvThanhVienNhom.DataSource = null;
            }
        }

        private async void btnTaoNhom_Click(object sender, EventArgs e)
        {
            var tenNhom = txtTenNhom.Text;
            if (!string.IsNullOrEmpty(tenNhom))
            {
                var nhomMoi = new StudentGroup
                {
                    GroupID = Guid.NewGuid(),
                    GroupName = tenNhom,
                    CreatedDate = DateTime.Now,
                    GroupLeaderID = _maSinhVien
                };

                await _dichVuNhomSinhVien.AddGroup(nhomMoi);

                var sinhVien = await _dichVuSinhVien.GetStudentById(_maSinhVien);
                if (sinhVien != null)
                {
                    sinhVien.GroupID = nhomMoi.GroupID;
                    await _dichVuSinhVien.Update(sinhVien);
                }

                TaiThongTinNhom().GetAwaiter();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhóm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnThemThanhVien_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            var maSinhVienThem = txtSinhVienThem.Text;

            if (!string.IsNullOrEmpty(maSinhVienThem))
            {
                // Tìm sinh viên theo ID hoặc tên
                var sinhVien = await _dichVuSinhVien.GetByStudentIdOrName(maSinhVienThem);

                if (sinhVien != null)
                {
                    // Kiểm tra xem sinh viên đã có nhóm chưa
                    if (sinhVien.GroupID == null || sinhVien.GroupID.Equals(Guid.Empty))
                    {
                        // Cập nhật GroupID của sinh viên để thêm vào nhóm hiện tại
                        sinhVien.GroupID = await _dichVuNhomSinhVien.GetGroupByLeaderId(_maSinhVien);

                        if (sinhVien.GroupID.HasValue)
                        {
                            await _dichVuSinhVien.Update(sinhVien);
                            MessageBox.Show("Thành viên đã được thêm vào nhóm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await TaiThongTinNhom(); // Tải lại thông tin nhóm
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhóm để thêm thành viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sinh viên này đã thuộc một nhóm khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với thông tin đã nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên sinh viên.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDangKyDeTai_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy nhóm của sinh viên
                var (isLeader, maNhom) = await _dichVuNhomSinhVien.IsLeaderAsync(_maSinhVien);

                if (!isLeader)
                {
                    MessageBox.Show("Bạn không phải là trưởng nhóm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var nhom = await _dichVuNhomSinhVien.GetGroupById(maNhom);
                // Kiểm tra xem nhóm đã đăng ký đề tài chưa
                var dangKyDaTonTai = nhom.Registration;
                if (dangKyDaTonTai != null && dangKyDaTonTai.Any(x => x.Status.Equals(RegistrationStatus.Approved)))
                {
                    MessageBox.Show("Nhóm của bạn đã đăng ký đề tài.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Lấy danh sách đề tài có sẵn
                var maDeTaiDangKy = dangKyDaTonTai?.Select(r => r.TopicID).ToList() ?? new List<Guid>();
                var deTaiCoSan = await _dichVuDeTai.GetTopicByWhereClause(
                    x => !maDeTaiDangKy.Contains(x.TopicID) && x.LecturerID.Equals(nhom.AdvisorID),
                    nameof(Topic.Lecturer)
                );
                if (!deTaiCoSan.Any())
                {
                    MessageBox.Show("Hiện không có đề tài nào để đăng ký.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị danh sách đề tài trong một Form mới để chọn
                var formChonDeTai = new ChonDetaiForm(deTaiCoSan);
                if (formChonDeTai.ShowDialog() == DialogResult.OK)
                {
                    var deTaiChon = formChonDeTai.SelectedThesis;
                    if (deTaiChon != null)
                    {
                        // Đăng ký đề tài cho nhóm
                        await _dichVuDangKy.RegisterThesisForGroupAsync(nhom.GroupID, deTaiChon.TopicID);
                        MessageBox.Show("Đăng ký đề tài thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật thông tin nhóm để hiển thị đề tài đã đăng ký
                        await LoadDuLieuAsync();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNopVanBan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy nhóm của sinh viên
                var (isLeader, maNhom) = await _dichVuNhomSinhVien.IsLeaderAsync(_maSinhVien);

                if (!isLeader)
                {
                    MessageBox.Show("Bạn không phải là trưởng nhóm.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var nhom = await _dichVuNhomSinhVien.GetGroupById(maNhom);
                var dangKy = nhom.Registration.FirstOrDefault(r => r.Status == RegistrationStatus.Approved);

                if (dangKy == null)
                {
                    MessageBox.Show("Nhóm của bạn chưa đăng ký đề tài.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở FormNopVanBan
                var formNopVanBan = new NopTaiLieuForm(dangKy.RegistrationID, _dichVuKiHan, _dichVuNopVanBan);
                formNopVanBan.ShowDialog();
                await LoadDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nộp văn bản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaVanBan_Click(object sender, EventArgs e)
        {
            if (dgvKiHan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nộp văn bản để chỉnh sửa.", "Không Có Lựa Chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng được chọn
            var selectedRow = dgvKiHan.SelectedRows[0];
            string duongDanVanBanHienTai = selectedRow.Cells["DocumentPath"].Value.ToString();

            using (ChinhSuaTaiLieuForm formSuaVanBan = new ChinhSuaTaiLieuForm(duongDanVanBanHienTai))
            {
                if (formSuaVanBan.ShowDialog() == DialogResult.OK)
                {
                    string duongDanVanBanMoi = formSuaVanBan.DuongDanTaiLieuMoi;

                    // Cập nhật đường dẫn văn bản trong DataGridView
                    selectedRow.Cells["DocumentPath"].Value = duongDanVanBanMoi;

                    CapNhatVanBanNop((Guid)selectedRow.Cells["SubmissionID"].Value, duongDanVanBanMoi);

                    MessageBox.Show("Văn bản đã được cập nhật thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void CapNhatVanBanNop(Guid maNopVanBan, string duongDanVanBanMoi)
        {
            try
            {
                // Lấy nộp văn bản theo ID
                var nopVanBan = (await _dichVuNopVanBan.GetSubmissionByWhereClause(s => s.SubmissionID == maNopVanBan)).FirstOrDefault();

                if (nopVanBan == null)
                {
                    MessageBox.Show("Không tìm thấy nộp văn bản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật đường dẫn văn bản
                nopVanBan.DocumentPath = duongDanVanBanMoi;

                // Lưu thay đổi
                await _dichVuNopVanBan.UpdateSubmissionAsync(nopVanBan);

                MessageBox.Show("Văn bản đã được cập nhật thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật văn bản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SetVisibilityNutAsync()
        {
            var (isLeader, _) = await _dichVuNhomSinhVien.IsLeaderAsync(_maSinhVien);
            btnSuaVanBan.Visible = isLeader;
            btnThemThanhVien.Visible = isLeader;
            btnDangKyDeTai.Visible = isLeader;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý logic đăng xuất ở đây
            UserSession.Logout();
            this.Close();
            var dichVuNguoiDung = Program.HostInstance.Services.GetRequiredService<IUserService>();
            var formDangNhap = new DangNhapForm(dichVuNguoiDung);
            formDangNhap.Show();
        }
    }
}
