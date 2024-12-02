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
    public class MilestoneService(IUnitOfWork unitOfWork) : IMilestoneService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task CreateMilestone(Milestone newMilestone)
        {
            _unitOfWork.Milestones.Add(newMilestone);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Milestone>> GetAllMilestones()
        {
            return await _unitOfWork.Milestones.GetAll();
        }

        public async Task<Milestone> GetByIdAsync(Guid milestoneId)
        {
            return await _unitOfWork.Milestones.GetById(milestoneId);
        }

        public async Task<IEnumerable<Milestone>> GetMilestoneByWhereClause(Expression<Func<Milestone, bool>> predicate)
        {
            return await _unitOfWork.Milestones.Find(predicate);
        }

        public async Task UpdateMilestone(Milestone editedMilestone)
        {
            _unitOfWork.Milestones.Update(editedMilestone);
            await _unitOfWork.Complete();
        }
        // Các phương thức khác nếu cần...
    }
}
