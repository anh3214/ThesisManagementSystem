using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class StudentGroup
    {
        [Key]
        public Guid GroupID { get; set; }

        [Required]
        [MaxLength(100)]
        public string GroupName { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid GroupLeaderID { get; set; }
        [ForeignKey("GroupLeaderID")]
        public virtual Student GroupLeader { get; set; }

        public Guid? AdvisorID { get; set; }
        [ForeignKey("AdvisorID")]
        public virtual Lecturer Advisor { get; set; }

        public Guid? CommiteID { get; set; }
        [ForeignKey("CommiteeId")]
        public virtual Committee Committee { get; set; }

        // Navigation properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
