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
    public class RegistrationService(IUnitOfWork unitOfWork) : IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Registration>> GetAllRegistrationsWithGroupAndGroupLeaderAndUser()
        {
            return await _unitOfWork.Registrations.GetAllWithGroupAndGroupLeaderAndUser();
        }

        public async Task RegisterThesisForGroupAsync(Guid groupId, Guid thesisId)
        {
            // Kiểm tra xem nhóm đã đăng ký đề tài chưa
            var existingRegistration = await _unitOfWork.Registrations.Find(r => r.GroupID == groupId && r.Status.Equals(RegistrationStatus.Approved));
            if (existingRegistration.Any())
            {
                throw new InvalidOperationException("Nhóm đã đăng ký đề tài trước đó.");
            }

            // Kiểm tra xem đề tài đã được đăng ký bởi nhóm khác chưa
            var thesisRegistration = await _unitOfWork.Registrations.Find(r => r.TopicID == thesisId);
            if (thesisRegistration.Any())
            {
                throw new InvalidOperationException("Đề tài đã được đăng ký bởi một nhóm khác.");
            }

            // Lấy thông tin đề tài
            _ = await _unitOfWork.Topics.GetById(thesisId) ?? throw new ArgumentException("Đề tài không tồn tại.");

            // Tạo đăng ký đề tài mới
            var registration = new Registration
            {
                RegistrationID = Guid.NewGuid(),
                GroupID = groupId,
                TopicID = thesisId,
                RegistrationDate = DateTime.Now,
                Status = RegistrationStatus.Pending,
            };

            _unitOfWork.Registrations.Add(registration);
            await _unitOfWork.Complete();
        }

        public async Task UpdateRegistrationStatus(Guid registrationID, RegistrationStatus newStatus)
        {
            var registration = await _unitOfWork.Registrations.GetById(registrationID) ?? throw new Exception("Registration not found.");
            registration.Status = newStatus;
            _unitOfWork.Registrations.Update(registration);
            await _unitOfWork.Complete();
        }

    }
}
