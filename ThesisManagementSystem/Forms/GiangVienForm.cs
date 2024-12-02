using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.BLL.Services;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class GiangVienForm : Form
    {
        private readonly Guid _maGiangVien;
        private readonly ILecturerService _giangVienService;
        private readonly ITopicService _deTaiService;
        private readonly IStudentGroupService _nhomSinhVienService;
        private readonly IMilestoneService _kyHanService;
        private readonly ISubmissionService _nopVanBanService;
        private readonly IEvaluateService _danhGiaService;
        private bool isLoading = true;

        public GiangVienForm(
            ILecturerService giangVienService,
            ITopicService deTaiService,
            IStudentGroupService nhomSinhVienService,
            IMilestoneService kyHanService,
            ISubmissionService nopVanBanService,
            IEvaluateService danhGiaService)
        {
            _maGiangVien = UserSession.UserID;
            _giangVienService = giangVienService;
            _deTaiService = deTaiService;
            _danhGiaService = danhGiaService;
            _nhomSinhVienService = nhomSinhVienService;
            _kyHanService = kyHanService;
            _nopVanBanService = nopVanBanService;
            InitializeComponent();
        }

        private async void FormGiangVien_Load(object sender, EventArgs e)
        {
            await LoadDuLieuAsync();
        }

        private async Task LoadDuLieuAsync()
        {
            await TaiThongTinGiangVien();
            await TaiDeTai();
            await TaiNhomHoiDong();
            await TaiNhom();
        }

        private async Task TaiThongTinGiangVien()
        {
            try
            {
                var giangVien = await _giangVienService.GetLecturerById(_maGiangVien);

                if (giangVien != null)
                {
                    lblTenGiangVien.Text = $"Tên Giảng Viên: {giangVien.Name}";
                    lblKhoa.Text = $"Khoa: {giangVien.Department}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải thông tin giảng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiDeTai()
        {
            try
            {
                var deTais = await _deTaiService.GetTopicByWhereClause(x => x.LecturerID.Equals(_maGiangVien));
                var danhSachDeTai = deTais.Select(tItem => new
                {
                    tItem.TopicID,
                    tItem.Title,
                    tItem.Description,
                    NgayTao = tItem.CreatedDate.ToLocalTime().ToString("dd/MM/yyyy")
                }).OrderBy(x => DateTime.Parse(x.NgayTao)).ToList();

                dgvDeTai.DataSource = danhSachDeTai;

                dgvDeTai.Columns["TopicID"].Visible = false;
                dgvDeTai.Columns["Title"].HeaderText = "Tiêu Đề";
                dgvDeTai.Columns["Description"].HeaderText = "Mô Tả";
                dgvDeTai.Columns["NgayTao"].HeaderText = "Ngày Tạo";

                dgvDeTai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDeTai.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiNhom()
        {
            try
            {
                var nhoms = await _nhomSinhVienService
                    .GetGroupsByWhereClause(x => x.AdvisorID.Equals(UserSession.UserID));

                var danhSachNhom = nhoms.Select(sg => new
                {
                    sg.GroupID,
                    sg.GroupName,
                    TruongNhom = sg.GroupLeader.Name,
                    NgayTao = sg.CreatedDate.ToLocalTime().ToString("dd/MM/yyyy")
                }).ToList();

                dgvNhomSinhVien.DataSource = danhSachNhom;

                dgvNhomSinhVien.Columns["GroupID"].Visible = false;
                dgvNhomSinhVien.Columns["GroupName"].HeaderText = "Tên Nhóm";
                dgvNhomSinhVien.Columns["TruongNhom"].HeaderText = "Trưởng Nhóm";
                dgvNhomSinhVien.Columns["NgayTao"].HeaderText = "Ngày Tạo";

                dgvNhomSinhVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvNhomSinhVien.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiKiHan()
        {
            try
            {
                var kyHans = await _kyHanService.GetAllMilestones();
                var danhSachKyHan = kyHans.Select(m => new
                {
                    m.MilestoneID,
                    m.Name,
                    HanNop = m.Deadline.ToLocalTime().ToString("dd/MM/yyyy")
                }).ToList();

                dgvKiHan.DataSource = danhSachKyHan;

                dgvKiHan.Columns["MilestoneID"].Visible = false;
                dgvKiHan.Columns["Name"].HeaderText = "Tên Kỳ Hạn";
                dgvKiHan.Columns["HanNop"].HeaderText = "Hạn Nộp";

                dgvKiHan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvKiHan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách kỳ hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiNhomHoiDong()
        {
            try
            {
                var (isChuNhiem, _) = await _giangVienService.GetChairmanCommitteeAsync(UserSession.UserID);
                var nhomHoiDong = await _nhomSinhVienService.GetGroupsInCommitteeAsync(UserSession.UserID);
                var danhSachNhomHoiDong = nhomHoiDong.Select(g => new
                {
                    g.GroupID,
                    g.GroupName,
                    SoLuongSinhVien = g.Students.Count,
                    TieuDeDeTai = g.Registration.FirstOrDefault(x => x.Status == RegistrationStatus.Approved)?.Topic.Title ?? "Chưa Có Đề Tài Được Duyệt"
                }).ToList();
                dgvNhomHoiDongCham.DataSource = danhSachNhomHoiDong;
                dgvNhomHoiDongCham.Columns["GroupID"].Visible = false;
                dgvNhomHoiDongCham.ClearSelection();
                isLoading = false;
                // Kích hoạt hoặc vô hiệu hóa nút Đánh Giá Nhóm dựa trên vai trò
                btnDanhGiaNhom.Enabled = isChuNhiem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải nhóm hội đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiNopVanBan(Guid nhomId)
        {
            try
            {
                var nopVanBans = await _nopVanBanService
                    .GetSubmissionByWhereClause(s => s.Registration.GroupID == nhomId)
                    .ContinueWith(t => t.Result.Select(s => new
                    {
                        s.SubmissionID,
                        Milestone = s.Milestone.Name,
                        SubmissionDate = s.SubmissionDate.ToLocalTime().ToString("dd/MM/yyyy"),
                        s.DocumentPath
                    }).ToList());
                if (nopVanBans.Count > 0)
                {
                    dgvNopVanBan.DataSource = nopVanBans;

                    dgvNopVanBan.Columns["SubmissionID"].Visible = false;
                    dgvNopVanBan.Columns["Milestone"].HeaderText = "Kỳ Hạn";
                    dgvNopVanBan.Columns["SubmissionDate"].HeaderText = "Ngày Nộp";
                    dgvNopVanBan.Columns["DocumentPath"].HeaderText = "Đường Dẫn Tài Liệu";

                    dgvNopVanBan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvNopVanBan.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách nộp văn bản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiChiTietNhom(Guid nhomId)
        {
            try
            {
                var chiTietNhom = await _nhomSinhVienService.GetGroupById(nhomId);

                if (chiTietNhom != null)
                {
                    var thanhVien = await _nhomSinhVienService.GetGroupMembersAsync(nhomId);
                    var tenThanhVien = string.Join("\r\n- ", thanhVien.Select(m => m.Name));

                    var idDeTai = chiTietNhom.Registration.Count > 0 ? chiTietNhom.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).TopicID : Guid.Empty;
                    var deTai = (await _deTaiService.GetTopicByWhereClause(x => x.TopicID.Equals(idDeTai))).FirstOrDefault();

                    var nopVanBans = await _nopVanBanService.GetSubmissionByWhereClause(x => x.Registration.GroupID.Equals(nhomId));

                    StringBuilder chiTiet = new();
                    chiTiet.AppendLine($"Tên Nhóm: {chiTietNhom.GroupName}");
                    chiTiet.AppendLine($"Trưởng Nhóm: {chiTietNhom.GroupLeader?.Name}");
                    chiTiet.AppendLine($"Ngày Tạo: {chiTietNhom.CreatedDate.ToShortDateString()}");
                    chiTiet.AppendLine();
                    chiTiet.AppendLine("Thành Viên Nhóm:");
                    chiTiet.AppendLine($"- {tenThanhVien}");
                    chiTiet.AppendLine();

                    if (deTai != null)
                    {
                        chiTiet.AppendLine("Đề Tài:");
                        chiTiet.AppendLine($"Tiêu Đề: {deTai.Title}");
                        chiTiet.AppendLine($"Mô Tả: {deTai.Description}");
                        chiTiet.AppendLine($"Giảng Viên Hướng Dẫn: {deTai.Lecturer?.Name}");
                        chiTiet.AppendLine();
                    }
                    else
                    {
                        chiTiet.AppendLine("Đề Tài: Chưa có đề tài được chỉ định.");
                        chiTiet.AppendLine();
                    }

                    chiTiet.AppendLine("Nộp Văn Bản:");
                    if (nopVanBans.Any())
                    {
                        foreach (var nopVanBan in nopVanBans)
                        {
                            chiTiet.AppendLine($"- Kỳ Hạn: {nopVanBan.Milestone}, Ngày Nộp: {nopVanBan.SubmissionDate}, Đường Dẫn Tài Liệu: {nopVanBan.DocumentPath}");
                        }
                    }
                    else
                    {
                        chiTiet.AppendLine("Không tìm thấy nộp văn bản.");
                    }

                    txtChiTietNhom.Text = chiTiet.ToString();
                }
                else
                {
                    txtChiTietNhom.Text = "Không tìm thấy thông tin nhóm.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải chi tiết nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTaoDeTai_Click(object sender, EventArgs e)
        {
            using var createForm = new TaoChinhSuaDeTaiForm(null, _giangVienService, _deTaiService);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                string tieuDe = createForm.TieuDeDeTai;
                string moTa = createForm.MoTaDeTai;
                Guid giangVienId = createForm.MaGiangVien;

                try
                {
                    bool daTonTai = (await _deTaiService
                        .GetTopicByWhereClause(x => x.Title.Equals(tieuDe)))
                        .Any();

                    if (daTonTai)
                    {
                        MessageBox.Show("Đã tồn tại đề tài với tiêu đề này.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var deTaiMoi = new Topic
                    {
                        LecturerID = giangVienId,
                        Title = tieuDe,
                        Description = moTa,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _deTaiService.AddAsync(deTaiMoi);

                    MessageBox.Show("Đề tài đã được tạo thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiDeTai();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi tạo đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý logic đăng xuất ở đây
            UserSession.Logout();
            this.Close();
            var userService = Program.HostInstance.Services.GetRequiredService<IUserService>();
            var formDangNhap = new DangNhapForm(userService);
            formDangNhap.Show();
        }

        private async void btnSuaDeTai_Click(object sender, EventArgs e)
        {
            if (dgvDeTai.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đề tài để sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid deTaiId = (Guid)dgvDeTai.CurrentRow.Cells["DeTaiID"].Value;
            var selectedDeTai = await _deTaiService.GetTopicbyId(deTaiId);
            if (selectedDeTai == null)
            {
                MessageBox.Show("Không thể tìm thấy thông tin đề tài.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var editForm = new TaoChinhSuaDeTaiForm(selectedDeTai, _giangVienService, _deTaiService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedDeTai.Title = editForm.TieuDeDeTai;
                selectedDeTai.Description = editForm.MoTaDeTai;

                try
                {
                    await _deTaiService.UpdateAsync(selectedDeTai);
                    MessageBox.Show("Đề tài đã được cập nhật thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiDeTai();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi cập nhật đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnXoaDeTai_Click(object sender, EventArgs e)
        {
            if (dgvDeTai.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đề tài để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var deTaiId = (Guid)dgvDeTai.CurrentRow.Cells["DeTaiID"].Value;
            var selectedDeTai = await _deTaiService.GetTopicbyId(deTaiId);
            if (selectedDeTai == null)
            {
                MessageBox.Show("Không thể tìm thấy thông tin đề tài.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa đề tài \"{selectedDeTai.Title}\" không?",
                                                 "Xác Nhận Xóa",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _deTaiService.DeleteAsync(selectedDeTai.TopicID);
                    MessageBox.Show("Đề tài đã được xóa thành công.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await TaiDeTai();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnTaiLai_Click(object sender, EventArgs e)
        {
            await TaiDeTai();
            TaiNhom().GetAwaiter();
            TaiNhomHoiDong().GetAwaiter();
        }

        private async void dgvNhomSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhomSinhVien.SelectedRows.Count > 0)
            {
                Guid nhomId = (Guid)dgvNhomSinhVien.SelectedRows[0].Cells["GroupID"].Value;
                await TaiKiHan();
                await TaiNopVanBan(nhomId);
                await TaiChiTietNhom(nhomId);
            }
            else
            {
                dgvKiHan.DataSource = null;
                dgvNopVanBan.DataSource = null;
                txtChiTietNhom.Text = string.Empty;
            }
        }

        private async void btnDanhGia_Click(object sender, EventArgs e)
        {
            if (dgvNhomSinhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhóm để đánh giá.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvKiHan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một kỳ hạn để đánh giá.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guid nhomId = (Guid)dgvNhomSinhVien.SelectedRows[0].Cells["GroupID"].Value;
            Guid kyHanId = (Guid)dgvKiHan.SelectedRows[0].Cells["MilestoneID"].Value;

            var nhom = await _nhomSinhVienService.GetGroupById(nhomId);

            var registrationId = nhom.Registration.First(x => x.Status.Equals(RegistrationStatus.Approved)).RegistrationID;

            var danhGiaDaTonTai = await _danhGiaService.GetEvaluationAsync(nhomId, registrationId, kyHanId, _maGiangVien);
            if (danhGiaDaTonTai.Any())
            {
                MessageBox.Show("Kỳ hạn này đã được đánh giá cho nhóm đã chọn.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using DanhGiaForm evaluateForm = new(nhom, registrationId, kyHanId, _maGiangVien, _kyHanService, _danhGiaService);
            if (evaluateForm.ShowDialog() == DialogResult.OK)
            {
                await TaiKiHan();
                await TaiNopVanBan(nhomId);
            }
        }

        private void btnDanhGiaNhom_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void dgvNhomHoiDongCham_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;
            if (dgvNhomSinhVien.SelectedRows.Count > 0)
            {
                var selectedRow = dgvNhomHoiDongCham.SelectedRows[0];
                var nhomId = (Guid)selectedRow.Cells["GroupID"].Value;


                // Tải chi tiết của nhóm đã chọn
                await TaiKiHan();
                await TaiNopVanBan(nhomId);
                await TaiChiTietNhom(nhomId);
            }
        }

    }
}
