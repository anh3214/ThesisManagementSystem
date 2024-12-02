using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.DAL.Interfaces
{
    public interface ICommitteeMemberRepository : IRepository<CommitteeMember>
    {
        Task<CommitteeMember> GetByCommitteeAndLecturer(Guid committeeID, Guid lecturerID);
        Task<int> CountByCommitteeAndRole(Guid committeeID, RoleCommitteeMember role);
        Task<IEnumerable<CommitteeMember>> GetByCommitteeID(Guid committeeID);
        Task UpdateCommitteeMember(CommitteeMember committeeMember);
    }
}
