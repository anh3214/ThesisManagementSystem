using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface ILecturerService
    {
        Task<Lecturer> GetLecturerById(Guid lecturerId);
        Task CreateTopic(Topic topic);
        Task<IEnumerable<Registration>> GetPendingRegistrations();
        Task EvaluateRegistration(Guid registrationId, Evaluation evaluation);
        Task<IEnumerable<Lecturer>> GetAllLecturers();
        Task<(bool, Committee)> GetChairmanCommitteeAsync(Guid userID);
    }
}
