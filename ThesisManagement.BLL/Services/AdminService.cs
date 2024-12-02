using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class AdminService(IUnitOfWork unitOfWork) : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task ApproveRegistration(Guid registrationId)
        {
            var registration = await _unitOfWork.Registrations.GetById(registrationId);
            if (registration != null)
            {
                registration.Status = RegistrationStatus.Approved;
                _unitOfWork.Registrations.Update(registration);
                await _unitOfWork.Complete();
            }
        }

        public async Task RejectRegistration(Guid registrationId)
        {
            var registration = await _unitOfWork.Registrations.GetById(registrationId);
            if (registration != null)
            {   
                registration.Status = RegistrationStatus.Rejected;
                _unitOfWork.Registrations.Update(registration);
                await _unitOfWork.Complete();
            }
        }

        public async Task CreateMilestone(Milestone milestone)
        {
            _unitOfWork.Milestones.Add(milestone);
            await _unitOfWork.Complete();
        }

        public async Task CreateCommittee(Committee committee)
        {
            _unitOfWork.Committees.Add(committee);
            await _unitOfWork.Complete();
        }
    }
}
