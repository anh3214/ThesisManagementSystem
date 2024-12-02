using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities.Db;
using ThesisManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ThesisManagement.DAL.Repositories
{
    public class CommitteeRepository(AppDbContext context) : Repository<Committee>(context), ICommitteeRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Committee> GetByName(string name)
        {
            return await _context.Committees
                .Include(c => c.CommitteeMembers)
                    .ThenInclude(cm => cm.Lecturer)
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Committee>> GetAllWithLecturers()
        {
            return await _context.Committees
                .Include(c => c.CommitteeMembers)
                    .ThenInclude(cm => cm.Lecturer).ToListAsync();
        }

        public async Task AddLecturerToCommittee(CommitteeMember committeeMember)
        {
            _context.CommitteeMembers.Add(committeeMember);
            await _context.SaveChangesAsync();
        }
    }
}
