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
    public class TopicService(IUnitOfWork unitOfWork) : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(Topic newTopic)
        {
            _unitOfWork.Topics.Add(newTopic);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(Guid topicID)
        {
            var entity = await _unitOfWork.Topics.GetById(topicID);
            _unitOfWork.Topics.Delete(entity);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Topic>> GetAllTopic()
        {
            return await _unitOfWork.Topics.GetAll(nameof(Topic.Lecturer));
        }

        public async Task<Topic> GetTopicbyId(Guid id)
        {
            return await _unitOfWork.Topics.GetById(id);
        }

        public async Task<IEnumerable<Topic>> GetTopicByWhereClause(Expression<Func<Topic, bool>> predicate, params string[] includes)
        {
            return await _unitOfWork.Topics.Find(predicate, includes);
        }

        public async Task UpdateAsync(Topic selectedTopic)
        {
            _unitOfWork.Topics.Update(selectedTopic);
            await _unitOfWork.Complete();
        }
    }
}
