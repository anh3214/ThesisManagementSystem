using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.DAL.UnitOfWork;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class LecturerService(IUnitOfWork unitOfWork) : ILecturerService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Lecturer> GetLecturerById(Guid lecturerId)
        {
            var lecturer = await _unitOfWork.Lecturers.GetById(lecturerId);
            return lecturer ?? throw new Exception("Lecturer not found.");
        }

        public async Task CreateTopic(Topic topic)
        {
            _unitOfWork.Topics.Add(topic);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Registration>> GetPendingRegistrations()
        {
            var registrations = (await _unitOfWork.Registrations.GetAll())
                .Where(r => r.Status is RegistrationStatus.Pending)
                .ToList();

            return registrations;
        }

        public async Task EvaluateRegistration(Guid registrationId, Evaluation evaluation)
        {
            _unitOfWork.Evaluations.Add(evaluation);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<Lecturer>> GetAllLecturers()
        {
            return await _unitOfWork.Lecturers.GetAll();
        }

        public async Task<(bool,Committee)> GetChairmanCommitteeAsync(Guid userID)
        {
            var lecturer = (await _unitOfWork.Lecturers.Find(x => x.User.UserID.Equals(userID), nameof(Lecturer.User), nameof(Lecturer.CommitteeMembers)))
                .FirstOrDefault() ?? throw new Exception("Lecturer not found.");
            var chairmanCommittee = lecturer.CommitteeMembers
                .FirstOrDefault(cm => cm.Role == RoleCommitteeMember.ChuTich)?.Committee;

            return chairmanCommittee == null ? (false, chairmanCommittee) : (true,chairmanCommittee);
        }

    }
}
