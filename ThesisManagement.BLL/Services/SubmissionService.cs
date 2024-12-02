using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class SubmissionService(IUnitOfWork unitOfWork) : ISubmissionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddSubmissionAsync(Submission newSubmission)
        {
            _unitOfWork.Submissions.Add(newSubmission);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Submission>> GetSubmissionByWhereClause(Expression<Func<Submission, bool>> predicate)
        {
            return await _unitOfWork.Submissions.Find(predicate,nameof(Submission.Milestone));
        }

        public async Task UpdateSubmissionAsync(Submission submission)
        {
            _unitOfWork.Submissions.Update(submission);
            await _unitOfWork.Complete();
        }
    }
}
