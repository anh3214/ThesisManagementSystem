using System.ComponentModel.DataAnnotations;

namespace ThesisManagement.Entities
{
    public class Registration
    {
        [Key]
        public Guid RegistrationID { get; set; }

        [Required]
        public Guid GroupID { get; set; }
        public virtual StudentGroup Group { get; set; }

        [Required]
        public Guid TopicID { get; set; }
        public virtual Topic Topic { get; set; }

        [Required]
        public RegistrationStatus Status { get; set; } // 'Pending', 'Approved', 'Rejected'

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual Defense Defense { get; set; }
    }
    public enum RegistrationStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
