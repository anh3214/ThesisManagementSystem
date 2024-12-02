using System.Security.Cryptography;
using System.Text;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<User> Login(string username, string password)
        {
            var user = (await _unitOfWork.Users.GetAll())
                .FirstOrDefault(u => u.Username == username && VerifyPassword(password, u.Password));

            return user;
        }
        public async Task EditUser(User user, string? name, string? className, string? department)
        {
            var existingUser = await _unitOfWork.Users.GetById(user.UserID) ?? throw new Exception("User not found.");

            // Kiểm tra nếu username được thay đổi và đã tồn tại
            if (!string.Equals(existingUser.Username, user.Username, StringComparison.OrdinalIgnoreCase))
            {
                var userWithSameUsername = _unitOfWork.Users.GetByUsername(user.Username);
                if (userWithSameUsername != null)
                {
                    throw new Exception("Username already exists.");
                }
            }

            existingUser.Username = user.Username;

            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.Password = HashPassword(user.Password);
            }

            // Cập nhật thông tin bổ sung dựa trên vai trò
            switch (existingUser.Role)
            {
                case Role.Student:
                    var student = await _unitOfWork.Students.GetById(existingUser.UserID);
                    if (student != null)
                    {
                        student.Name = name ?? student.Name;
                        student.Class = className ?? student.Class;
                        _unitOfWork.Students.Update(student);
                    }
                    break;
                case Role.Lecturer:
                    var lecturer = await _unitOfWork.Lecturers.GetById(existingUser.UserID);
                    if (lecturer != null)
                    {
                        lecturer.Name = name ?? lecturer.Name;
                        lecturer.Department = department ?? lecturer.Department;
                        _unitOfWork.Lecturers.Update(lecturer);
                    }
                    break;
                case Role.Admin:
                    // Nếu có thêm thông tin cho Admin
                    break;
                default:
                    throw new Exception("Invalid role.");
            }

            _unitOfWork.Users.Update(existingUser);
            await _unitOfWork.Complete();
        }

        public async Task DeleteUser(Guid userID)
        {
            var user = await _unitOfWork.Users.GetById(userID) ?? throw new Exception("User not found.");
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.Complete();
        }

        public async Task Register(User user, string? name, string? classValue, string? department, string? msssv)
        {
            var existingUser = await _unitOfWork.Users.GetByUsername(user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            user.Password = HashPassword(user.Password);
            _unitOfWork.Users.Add(user);

            switch (user.Role)
            {
                case Role.Student:
                    var student = new Student
                    {
                        StudentID = user.UserID,
                        User = user,
                        MSSV = msssv,
                        Name = name!, // Sử dụng Name được truyền vào
                        Class = classValue!
                    };
                    _unitOfWork.Students.Add(student);
                    break;
                case Role.Lecturer:
                    var lecturer = new Lecturer
                    {
                        LecturerID = user.UserID,
                        User = user,
                        Name = name!, // Sử dụng Name được truyền vào
                        Department = department!
                    };
                    _unitOfWork.Lecturers.Add(lecturer);
                    break;
                case Role.Admin:
                    // Nếu có thêm thông tin cho Admin
                    break;
                default:
                    throw new Exception("Invalid role.");
            }

            await _unitOfWork.Complete();
        }
        public async Task<IEnumerable<User>> GetAllUsersWithRoles()
        {
            return await _unitOfWork.Users.GetAll(nameof(User.Student),nameof(User.Lecturer));
        }

        public async Task<IEnumerable<Lecturer>> GetAllLecturers()
        {
            return await _unitOfWork.Lecturers.GetAll(nameof(Lecturer.User));
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _unitOfWork.Users.GetById(userId);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput.Equals(storedHashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _unitOfWork.Students.GetAll();
        }
    }
}
