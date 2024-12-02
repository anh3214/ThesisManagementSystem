using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class CommitteeMember
    {
        [Key]
        public Guid CommitteeID { get; set; }
        public virtual Committee Committee { get; set; }

        public Guid LecturerID { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public RoleCommitteeMember Role { get; set; } // 'Chairman', 'Secretary', 'Member'
    }
    public enum RoleCommitteeMember
    {
        ChuTich,
        ThuKy,
        ThanhVien
    }
}
