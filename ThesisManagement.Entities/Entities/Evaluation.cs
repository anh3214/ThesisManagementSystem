using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagement.Entities
{
    public class Evaluation
    {
        [Key]
        public Guid EvaluationID { get; set; }

        [Required]
        public Guid RegistrationID { get; set; }
        public virtual Registration Registration { get; set; }

        [Required]
        public Guid MilestoneId { get; set; }
        public virtual Milestone Milestone { get; set; }

        [Required]
        public Guid EvaluatorID { get; set; }
        public virtual Lecturer Evaluator { get; set; }

        [Required]
        public decimal Score { get; set; }

        public string Comments { get; set; }

        [Required]
        public RoleEvaluation Role { get; set; } // 'Advisor', 'Reviewer'

        public DateTime EvaluationDate { get; set; }
    }
    public enum RoleEvaluation
    {
        Advisor,
        Reviewer
    }
}
