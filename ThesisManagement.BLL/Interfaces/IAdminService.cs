using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IAdminService
    {
        Task ApproveRegistration(Guid registrationId);
        Task RejectRegistration(Guid registrationId);
        Task CreateMilestone(Milestone milestone);
        Task CreateCommittee(Committee committee);
    }
}
