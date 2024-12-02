using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface ISubmissionService
    {
        Task AddSubmissionAsync(Submission newSubmission);
        Task<IEnumerable<Submission>> GetSubmissionByWhereClause(Expression<Func<Submission, bool>> predicate);
        Task UpdateSubmissionAsync(Submission submission);
    }
}
