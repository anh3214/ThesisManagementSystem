using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IEvaluateService
    {
        Task AddAsync(Evaluation evaluation);
        Task<IEnumerable<Evaluation>> FindAsync(Expression<Func<Evaluation, bool>> predicate);
        Task<IEnumerable<Evaluation>> GetEvaluationAsync(Guid groupId, Guid registationId ,Guid milestoneId, Guid lecturerId);
    }
}
