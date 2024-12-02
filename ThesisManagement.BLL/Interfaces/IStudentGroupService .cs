using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IStudentGroupService
    {
        Task<StudentGroup> GetGroupById(Guid groupId);
        Task AddGroup(StudentGroup group);
        Task UpdateGroup(StudentGroup group);
        Task<List<StudentGroup>> GetAllGroups();
        Task<Guid> GetGroupByLeaderId(Guid studentId);
        Task<(bool,Guid)> IsLeaderAsync(Guid studentId);
        Task<IEnumerable<Student>> GetGroupMembersAsync(Guid groupId);
        Task<IEnumerable<StudentGroup>> GetGroupsByWhereClause(Expression<Func<StudentGroup, bool>> predicate);
        Task<IEnumerable<StudentGroup>> GetGroupsInCommitteeAsync(Guid userID);
    }
}
