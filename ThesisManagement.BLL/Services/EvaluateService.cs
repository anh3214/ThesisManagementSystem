using System.Linq.Expressions;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class EvaluateService(IUnitOfWork unitOfWork) : IEvaluateService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(Evaluation evaluation)
        {
            _unitOfWork.Evaluations.Add(evaluation);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Evaluation>> FindAsync(Expression<Func<Evaluation, bool>> predicate)
        {
            return await _unitOfWork.Evaluations.Find(predicate,
                nameof(Evaluation.Registration),
                nameof(Evaluation.Evaluator),
                $"{nameof(Evaluation.Registration)}.{nameof(Evaluation.Registration.Submissions)}",
                $"{nameof(Evaluation.Registration)}.{nameof(Evaluation.Registration.Topic)}");
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationAsync(Guid groupId,Guid registationId ,Guid milestoneId, Guid lecturerId)
        {
            return await FindAsync(x => 
                x.Registration.GroupID.Equals(groupId)
                && x.MilestoneId.Equals(milestoneId)
                && x.Registration.RegistrationID.Equals(registationId)
                && x.EvaluatorID.Equals(lecturerId));
        }
    }
}
