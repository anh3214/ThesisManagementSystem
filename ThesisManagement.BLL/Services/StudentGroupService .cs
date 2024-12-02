using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities.Db;
using ThesisManagement.Entities;
using ThesisManagement.DAL.Interfaces;
using System.Linq.Expressions;

namespace ThesisManagement.BLL.Services
{
    public class StudentGroupService(IUnitOfWork unitOfWork) : IStudentGroupService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<StudentGroup> GetGroupById(Guid groupId)
        {
            return await _unitOfWork.StudentGroups.GetById(groupId, 
                nameof(StudentGroup.Students), 
                nameof(StudentGroup.GroupLeader), 
                nameof(StudentGroup.Registration),
                nameof(StudentGroup.Advisor),
                nameof(StudentGroup.Committee),
                $"{nameof(StudentGroup.Registration)}.{nameof(Registration.Topic)}");
        }

        public async Task AddGroup(StudentGroup group)
        {
            _unitOfWork.StudentGroups.Add(group);
            await _unitOfWork.Complete();
        }

        public async Task UpdateGroup(StudentGroup group)
        {
            _unitOfWork.StudentGroups.Update(group);
            await _unitOfWork.Complete();
        }

        public async Task<List<StudentGroup>> GetAllGroups()
        {
            return (await _unitOfWork.StudentGroups.GetAll(
                nameof(StudentGroup.Students),
                nameof(StudentGroup.Advisor), 
                nameof(StudentGroup.GroupLeader), 
                nameof(StudentGroup.Registration),
                nameof(StudentGroup.GroupLeader),
                $"{nameof(StudentGroup.GroupLeader)}.{nameof(Student.User)}",
                nameof(StudentGroup.Committee))).ToList();
        }

        public async Task<IEnumerable<StudentGroup>> GetGroupsByWhereClause(Expression<Func<StudentGroup, bool>> predicate)
        {
            var result = await _unitOfWork.StudentGroups.Find(predicate, 
                nameof(StudentGroup.Registration),
                nameof(StudentGroup.GroupLeader),
                nameof(StudentGroup.Students),
                $"{nameof(StudentGroup.Registration)}.{nameof(Registration.Topic)}");
            return result;
        }

        public async Task<Guid> GetGroupByLeaderId(Guid studentId)
        {
            var groups = await _unitOfWork.StudentGroups.Find(x => x.GroupLeaderID.Equals(studentId));
            return groups.Any() ? groups.First().GroupID : Guid.Empty;
        }

        public async Task<(bool, Guid)> IsLeaderAsync(Guid studentId)
        {
            var group = await GetGroupByLeaderId(studentId);
            if (group != Guid.Empty)
                return (true,group);

            return (false,Guid.Empty);
        }

        public async Task<IEnumerable<Student>> GetGroupMembersAsync(Guid groupId)
        {
            return await _unitOfWork.Students.Find(x => x.GroupID.Equals(groupId));
        }

        public async Task<IEnumerable<StudentGroup>> GetGroupsInCommitteeAsync(Guid userID)
        {
            var lecturer = await _unitOfWork.Lecturers.GetById(userID, nameof(Lecturer.CommitteeMembers));
            var committeeIds = lecturer?.CommitteeMembers.Select(x => x.CommitteeID).ToList();

            if (committeeIds == null || committeeIds.Count == 0)
                return Enumerable.Empty<StudentGroup>();

            var result = await GetGroupsByWhereClause(
                x => committeeIds.Contains(x.CommiteID ?? Guid.Empty));
            return result;
        }


    }
}
