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
    public class RegistrationRepository(AppDbContext context) : Repository<Registration>(context), IRegistrationRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Registration>> GetAllWithUsers()
        {
            return await _context.Registrations.Include(r => r.Group).ToListAsync();
        }
        public async Task<IEnumerable<Registration>> GetAllWithGroupAndGroupLeaderAndUser()
        {
            return await _context.Registrations
                .Include(r => r.Group)
                    .ThenInclude(g => g.GroupLeader)
                        .ThenInclude(gl => gl.User).ToListAsync();
        }
    }
}
