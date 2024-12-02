using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Committee
    {
        [Key]
        public Guid CommitteeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DefenseDate { get; set; }

        // Navigation properties
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; }
        public virtual ICollection<Defense> Defenses { get; set; }

        public Committee()
        {
            CommitteeMembers = new HashSet<CommitteeMember>();
            Defenses = new HashSet<Defense>();
        }
    }
}
