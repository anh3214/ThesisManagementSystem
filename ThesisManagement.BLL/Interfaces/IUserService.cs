using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(string username, string password);
        Task Register(User user, string? name, string? classValue, string? department, string? msssv);
        Task<User> GetUserById(Guid userId);
        Task<IEnumerable<Lecturer>> GetAllLecturers();
        Task<IEnumerable<User>> GetAllUsersWithRoles();
        Task<IEnumerable<Student>> GetAllStudents();
        Task EditUser(User user, string? name, string? className, string? department);
        Task DeleteUser(Guid selectedUserID);
    }
}
