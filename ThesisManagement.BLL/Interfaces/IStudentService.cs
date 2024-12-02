using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentById(Guid studentId, params string[] includes);
        Task<IEnumerable<Topic>> GetAvailableTopics();
        Task RegisterGroup(StudentGroup group);
        Task Update(Student student);
        Task<Student> GetByStudentIdOrName(string studentIdInput);
    }
}
