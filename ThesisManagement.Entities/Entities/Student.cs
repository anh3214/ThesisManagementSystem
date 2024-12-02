using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThesisManagement.Entities
{
    public class Student
    {
        [Key, ForeignKey("User")]
        public Guid StudentID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Class { get; set; }

        [Required]
        [MaxLength(50)]
        public string MSSV { get; set; }

        public Guid? GroupID { get; set; }
        public virtual StudentGroup Group { get; set; }

        public virtual User User { get; set; }

        // Navigation properties
        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
