using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface ICommitteeService
    {
        Task<IEnumerable<Committee>> GetAllCommitteesWithLecturers();
        Task CreateCommittee(Committee committee);
        Task AddLecturerToCommittee(Guid committeeID, Guid lecturerID, RoleCommitteeMember role);
        Task EditCommittee(Committee committee);
        Task<Committee> GetCommitteeByID(Guid committeeID);
        Task EditCommitteeMemberRole(Guid lecturerID, RoleCommitteeMember newRole);
        Task RemoveLecturerFromCommittee(Guid committeID, Guid lecturerID);
        Task UpdateCommitteeMember(CommitteeMember member);
        // Các phương thức khác...
    }
}
