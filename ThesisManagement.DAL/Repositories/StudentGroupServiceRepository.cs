using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;
using ThesisManagement.Entities.Db;

namespace ThesisManagement.DAL.Repositories
{
    public class StudentGroupServiceRepository(AppDbContext context) : Repository<StudentGroup>(context), IStudentGroupServiceRepository
    {
        private readonly AppDbContext _context = context;
    }
}
