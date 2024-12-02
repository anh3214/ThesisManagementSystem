using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface ITopicService
    {
        Task AddAsync(Topic newTopic);
        Task DeleteAsync(Guid topicID);
        Task<IEnumerable<Topic>> GetAllTopic();
        Task<Topic> GetTopicbyId(Guid id);
        Task<IEnumerable<Topic>> GetTopicByWhereClause(Expression<Func<Topic, bool>> predicate, params string[] includes);
        Task UpdateAsync(Topic selectedTopic);
    }
}
