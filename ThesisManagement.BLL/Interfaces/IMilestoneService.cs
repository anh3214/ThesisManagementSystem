using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IMilestoneService
    {
        Task CreateMilestone(Milestone newMilestone);
        Task<IEnumerable<Milestone>> GetAllMilestones();
        Task<Milestone> GetByIdAsync(Guid milestoneId);
        Task<IEnumerable<Milestone>> GetMilestoneByWhereClause(Expression<Func<Milestone, bool>> predicate);
        Task UpdateMilestone(Milestone editedMilestone);
        // Các phương thức khác...
    }
}
