using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThesisManagement.Entities
{
    public class Topic
    {
        [Key]
        public Guid TopicID { get; set; }

        [Required]
        public Guid LecturerID { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
