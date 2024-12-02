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
    public class CommitteeMemberRepository(AppDbContext context) : Repository<CommitteeMember>(context), ICommitteeMemberRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<CommitteeMember> GetByCommitteeAndLecturer(Guid committeeID, Guid lecturerID)
        {
            return await _context.CommitteeMembers
                .FirstOrDefaultAsync(cm => cm.CommitteeID == committeeID && cm.LecturerID == lecturerID);
        }

        public async Task<int> CountByCommitteeAndRole(Guid committeeID, RoleCommitteeMember role)
        {
            return await _context.CommitteeMembers
                .CountAsync(cm => cm.CommitteeID == committeeID && cm.Role == role);
        }
        public async Task<IEnumerable<CommitteeMember>> GetByCommitteeID(Guid committeeID)
        {
            return await _context.CommitteeMembers
                .Where(cm => cm.CommitteeID == committeeID)
                .Include(cm => cm.Lecturer).ToListAsync();
        }

        public async Task UpdateCommitteeMember(CommitteeMember committeeMember)
        {
            // Tìm CommitteeMember hiện tại trong cơ sở dữ liệu
            var existingMember = await _context.CommitteeMembers
                .FirstOrDefaultAsync(cm => cm.CommitteeID == committeeMember.CommitteeID) ?? throw new Exception("CommitteeMember không tồn tại.");
            existingMember.Role = committeeMember.Role;

            _context.CommitteeMembers.Update(existingMember);
        }
    }
}
