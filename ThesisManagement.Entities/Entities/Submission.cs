using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Submission
    {
        [Key]
        public Guid SubmissionID { get; set; }

        [Required]
        public Guid RegistrationID { get; set; }
        public virtual Registration Registration { get; set; }

        [Required]
        public Guid MilestoneID { get; set; }
        public virtual Milestone Milestone { get; set; }

        public DateTime SubmissionDate { get; set; }

        [Required]
        public string DocumentPath { get; set; }
    }
}
