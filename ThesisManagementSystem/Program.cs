using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.BLL.Services;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.DAL.UnitOfWork;
using ThesisManagement.Entities.Db;
using ThesisManagementSystem.Forms;
using Serilog;
using ThesisManagement.Entities;

namespace ThesisManagementSystem
{
    static class Program
    {
        public static IHost HostInstance { get; private set; }

        [STAThread]
        static void Main()
        {
            // Xây dựng cấu hình
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Cấu hình Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting application");

                // Xây dựng và khởi động Host
                HostInstance = Host.CreateDefaultBuilder()
                    .UseSerilog() // Tích hợp Serilog với Host
                    .ConfigureServices((context, services) =>
                    {
                        // Đăng ký DbContext với chuỗi kết nối từ appsettings.json
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")), 
                            ServiceLifetime.Transient);

                        // Đăng ký UnitOfWork
                        services.AddTransient<IUnitOfWork, UnitOfWork>();

                        // Đăng ký các dịch vụ BLL
                        services.AddTransient<IUserService, UserService>();
                        services.AddTransient<ITopicService, TopicService>();
                        services.AddTransient<IStudentGroupService, StudentGroupService>();
                        services.AddTransient<IStudentService, StudentService>();
                        services.AddTransient<ILecturerService, LecturerService>();
                        services.AddTransient<IAdminService, AdminService>();
                        services.AddTransient<IMilestoneService, MilestoneService>();
                        services.AddTransient<ICommitteeService, CommitteeService>();
                        services.AddTransient<IRegistrationService, RegistrationService>();
                        services.AddTransient<ISubmissionService, SubmissionService>();
                        services.AddTransient<IEvaluateService, EvaluateService>();
                        services.AddTransient<IDefenseScoreService, DefenseScoreService>();

                        // Đăng ký các Form
                        services.AddTransient<DangNhapForm>();
                        services.AddTransient<ChonDetaiForm>();
                        services.AddTransient<SinhVienForm>();
                        services.AddTransient<GiangVienForm>();
                        services.AddTransient<QuanLyAdminForm>();
                        services.AddTransient<TaoHoiDongForm>();
                        services.AddTransient<ChinhSuaGiangVienHoiDongForm>();
                        services.AddTransient<ThemGiangVienVaoHoiDongForm>();
                        services.AddTransient<ChinhSuaHoiDongForm>();
                        services.AddTransient<XoaGiangVienForm>();
                        services.AddTransient<CapNhatTrangThaiForm>();
                        services.AddTransient<TaoNguoiDungForm>();
                        services.AddTransient<TaoCotMocForm>();
                        services.AddTransient<ChinhSuaMocThoiGianForm>();
                        services.AddTransient<ChinhSuaNguoiDungForm>();
                        services.AddTransient<ChinhSuaNhomForm>();
                    })
                    .Build();

                HostInstance.Start();
                using (var serviceScope = HostInstance.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        var userService = services.GetRequiredService<IUserService>();
                        EnsureAdminUser(userService);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "An error occurred while creating the default admin user.");
                        MessageBox.Show($"Đã xảy ra lỗi khi tạo người dùng Admin mặc định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var serviceScope = HostInstance.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;
                    try
                    {
                        var loginForm = services.GetRequiredService<DangNhapForm>();
                        Application.Run(loginForm);
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "Application terminated unexpectedly");
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        private static void EnsureAdminUser(IUserService userService)
        {
            // Kiểm tra xem có user Admin nào không
            var admins = userService.GetAllUsersWithRoles().GetAwaiter().GetResult().Where(u => u.Role == Role.Admin).ToList();
            if (admins.Count == 0)
            {
                // Không có Admin nào, tạo Admin mặc định
                var defaultAdmin = new User
                {
                    UserID = Guid.NewGuid(),
                    Username = "admin",
                    Password = "admin", // Mật khẩu sẽ được mã hóa trong service
                    Role = Role.Admin
                };

                try
                {
                    userService.Register(defaultAdmin,null,null,null,null).GetAwaiter().GetResult();
                    Log.Information("Default admin user created with username 'admin' and password 'admin'.");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating default admin user.");
                    throw new Exception("Không thể tạo người dùng Admin mặc định.", ex);
                }
            }
            else
            {
                Log.Information("Admin user(s) already exist.");
            }
        }
    }
}