using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Lecturer
    {
        [Key, ForeignKey("User")]
        public Guid LecturerID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; }
        public virtual ICollection<DefenseScore> DefenseScores { get; set; }
    }
}
