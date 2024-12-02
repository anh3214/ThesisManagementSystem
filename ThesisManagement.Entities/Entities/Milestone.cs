using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Milestone
    {
        [Key]
        public Guid MilestoneID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
