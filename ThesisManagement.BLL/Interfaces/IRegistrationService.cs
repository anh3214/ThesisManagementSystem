using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsWithGroupAndGroupLeaderAndUser();
        Task UpdateRegistrationStatus(Guid registrationID, RegistrationStatus newStatus);
        Task RegisterThesisForGroupAsync(Guid groupId, Guid thesisId);

        // Các phương thức khác...
    }
}
