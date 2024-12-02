using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.DAL.Interfaces
{
    public interface ICommitteeRepository : IRepository<Committee>
    {
        Task<Committee> GetByName(string name);
        Task<IEnumerable<Committee>> GetAllWithLecturers();
        Task AddLecturerToCommittee(CommitteeMember committeeMember);
    }
}
