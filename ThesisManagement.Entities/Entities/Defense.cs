using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Defense
    {
        [Key]
        public Guid DefenseID { get; set; }

        [Required]
        public Guid RegistrationID { get; set; }
        public virtual Registration Registration { get; set; }

        [Required]
        public Guid CommitteeID { get; set; }
        public virtual Committee Committee { get; set; }

        public DateTime DefenseDate { get; set; }

        // Navigation properties
        public virtual ICollection<DefenseScore> DefenseScores { get; set; }
    }
}
