using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IDefenseScoreService
    {
        Task AddSync(Defense defense);
        Task<(bool, Guid)> CheckHaveDefense(Guid idRegitation);
        Task<Defense> GetScore(Guid registationId);
        Task Update(Defense defense);
    }
}
