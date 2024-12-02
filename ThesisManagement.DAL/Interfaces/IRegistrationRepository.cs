using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.DAL.Interfaces
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Task<IEnumerable<Registration>> GetAllWithUsers();
        Task<IEnumerable<Registration>> GetAllWithGroupAndGroupLeaderAndUser();
    }
}
