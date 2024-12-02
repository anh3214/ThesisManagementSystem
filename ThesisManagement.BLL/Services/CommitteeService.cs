using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.DAL.Repositories;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class CommitteeService(IUnitOfWork unitOfWork) : ICommitteeService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Committee>> GetAllCommitteesWithLecturers()
        {
            return await _unitOfWork.Committees.GetAllWithLecturers();
        }

        public async Task CreateCommittee(Committee committee)
        {
            // Kiểm tra CommitteeName trùng
            var existingCommittee = await _unitOfWork.Committees.GetByName(committee.Name);
            if (existingCommittee != null)
            {
                throw new Exception("Committee name already exists.");
            }

            _unitOfWork.Committees.Add(committee);
            await _unitOfWork.Complete();
        }

        public async Task AddLecturerToCommittee(Guid committeeID, Guid lecturerID, RoleCommitteeMember role)
        {
            // Kiểm tra xem Committee tồn tại
            _ = await _unitOfWork.Committees.GetById(committeeID) ?? throw new Exception("Committee not found.");

            // Kiểm tra Lecturer tồn tại
            _ = await _unitOfWork.Lecturers.GetById(lecturerID) ?? throw new Exception("Lecturer not found.");

            // Kiểm tra xem Lecturer đã là thành viên của Committee chưa
            var existingMember = _unitOfWork.CommitteeMembers.GetByCommitteeAndLecturer(committeeID, lecturerID);
            if (existingMember != null)
            {
                throw new Exception("Lecturer is already a member of the committee.");
            }

            // Kiểm tra số lượng Chairman và Secretary
            if (role == RoleCommitteeMember.Chairman)
            {
                var chairmanCount = await _unitOfWork.CommitteeMembers.CountByCommitteeAndRole(committeeID, RoleCommitteeMember.Chairman);
                if (chairmanCount >= 1)
                {
                    throw new Exception("Committee already has a Chairman.");
                }
            }
            else if (role == RoleCommitteeMember.Secretary)
            {
                var secretaryCount = await _unitOfWork.CommitteeMembers.CountByCommitteeAndRole(committeeID, RoleCommitteeMember.Secretary);
                if (secretaryCount >= 1)
                {
                    throw new Exception("Committee already has a Secretary.");
                }
            }

            // Tạo CommitteeMember mới
            var committeeMember = new CommitteeMember
            {
                CommitteeID = committeeID,
                LecturerID = lecturerID,
                Role = role
            };

            _unitOfWork.CommitteeMembers.Add(committeeMember);
            await _unitOfWork.Complete();
        }

        public async Task EditCommittee(Committee committee)
        {
            var existingCommittee = await _unitOfWork.Committees.GetById(committee.CommitteeID);
            if (existingCommittee == null)
            {
                throw new Exception("Committee not found.");
            }

            // Kiểm tra nếu tên Committee được thay đổi và trùng với tên Committee khác
            if (!string.Equals(existingCommittee.Name, committee.Name, StringComparison.OrdinalIgnoreCase))
            {
                var committeeWithSameName = _unitOfWork.Committees.GetByName(committee.Name);
                if (committeeWithSameName != null)
                {
                    throw new Exception("Another Committee with the same name already exists.");
                }
            }

            existingCommittee.Name = committee.Name;
            existingCommittee.DefenseDate = committee.DefenseDate;

            _unitOfWork.Committees.Update(existingCommittee);
            await _unitOfWork.Complete();
        }

        public async Task<Committee> GetCommitteeByID(Guid committeeID)
        {
            var committee = await _unitOfWork.Committees.GetById(committeeID) ?? throw new Exception("Committee not found.");
            // Bao gồm các thành viên nếu cần
            committee.CommitteeMembers = (await _unitOfWork.CommitteeMembers.GetByCommitteeID(committeeID)).ToList();
            return committee;
        }
        public async Task EditCommitteeMemberRole(Guid committeeMemberID, RoleCommitteeMember newRole)
        {
            var committeeMember = await _unitOfWork.CommitteeMembers.GetById(committeeMemberID) ?? throw new Exception("Committee Member not found.");

            // Kiểm tra số lượng Chairman và Secretary nếu vai trò thay đổi
            if (committeeMember.Role != newRole)
            {
                if (newRole == RoleCommitteeMember.Chairman)
                {
                    var chairmanCount = await _unitOfWork.CommitteeMembers.CountByCommitteeAndRole(committeeMember.CommitteeID, RoleCommitteeMember.Chairman);
                    if (chairmanCount >= 1)
                    {
                        throw new Exception("Committee already has a Chairman.");
                    }
                }
                else if (newRole == RoleCommitteeMember.Secretary)
                {
                    var secretaryCount = await _unitOfWork.CommitteeMembers.CountByCommitteeAndRole(committeeMember.CommitteeID, RoleCommitteeMember.Secretary);
                    if (secretaryCount >= 1)
                    {
                        throw new Exception("Committee already has a Secretary.");
                    }
                }

                committeeMember.Role = newRole;
                _unitOfWork.CommitteeMembers.Update(committeeMember);
                await _unitOfWork.Complete();
            }
            // Nếu vai trò không thay đổi, không làm gì cả
        }

        public async Task RemoveLecturerFromCommittee(Guid committeID, Guid lecturerID)
        {
            var committeeMember = await _unitOfWork.CommitteeMembers.GetByCommitteeAndLecturer(committeID, lecturerID) ?? throw new Exception("Không tìm thấy Lecturer trong Committee.");
            _unitOfWork.CommitteeMembers.Delete(committeeMember);
            await _unitOfWork.Complete();
        }

        public async Task UpdateCommitteeMember(CommitteeMember committeeMember)
        {
            try
            {
                await _unitOfWork.CommitteeMembers.UpdateCommitteeMember(committeeMember);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật CommitteeMember: {ex.Message}");
            }
        }
    }
}