using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities.Db;
using ThesisManagement.Entities;
using ThesisManagement.DAL.Interfaces;

namespace ThesisManagement.DAL.Repositories
{
    public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
    {
        protected readonly AppDbContext _context = context;

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<IEnumerable<User>> GetAllWithRoles()
        {
            return await _context.Users
                .Include(u => u.Student)
                .Include(u => u.Lecturer).ToListAsync();
        }
    }
}
