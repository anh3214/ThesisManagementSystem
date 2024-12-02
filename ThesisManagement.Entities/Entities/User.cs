using System.ComponentModel.DataAnnotations;

namespace ThesisManagement.Entities
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; } // 'Student', 'Lecturer', 'Admin'

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
    public enum Role
    {
        Student,
        Lecturer,
        Admin
    }
}
