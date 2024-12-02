using Microsoft.EntityFrameworkCore;

namespace ThesisManagement.Entities.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // DbSet properties
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<Defense> Defenses { get; set; }
        public DbSet<DefenseScore> DefenseScores { get; set; }
        public DbSet<ScoreWeight> ScoreWeights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary keys
            modelBuilder.Entity<CommitteeMember>()
                .HasKey(cm => new { cm.CommitteeID, cm.LecturerID });

            modelBuilder.Entity<DefenseScore>()
                .HasKey(ds => new { ds.DefenseID, ds.LecturerID });

            // One-to-one relationships between User and Student/Lecturer
            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.StudentID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            modelBuilder.Entity<User>()
                .HasOne(u => u.Lecturer)
                .WithOne(l => l.User)
                .HasForeignKey<Lecturer>(l => l.LecturerID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between StudentGroup and Student
            modelBuilder.Entity<StudentGroup>()
                .HasMany(sg => sg.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-one relationship between StudentGroup and Registration
            modelBuilder.Entity<StudentGroup>()
                .HasMany(sg => sg.Registration)
                .WithOne(r => r.Group)
                .HasForeignKey(r => r.GroupID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Lecturer and Topic
            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Topics)
                .WithOne(t => t.Lecturer)
                .HasForeignKey(t => t.LecturerID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Topic and Registration
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Registrations)
                .WithOne(r => r.Topic)
                .HasForeignKey(r => r.TopicID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Registration and Evaluation
            modelBuilder.Entity<Registration>()
                .HasMany(r => r.Evaluations)
                .WithOne(e => e.Registration)
                .HasForeignKey(e => e.RegistrationID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            modelBuilder.Entity<Milestone>()
                .HasMany(r => r.Evaluations)
                .WithOne(e => e.Milestone)
                .HasForeignKey(e => e.MilestoneId)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Milestone and Submission
            modelBuilder.Entity<Milestone>()
                .HasMany(m => m.Submissions)
                .WithOne(s => s.Milestone)
                .HasForeignKey(s => s.MilestoneID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Registration and Submission
            modelBuilder.Entity<Registration>()
                .HasMany(r => r.Submissions)
                .WithOne(s => s.Registration)
                .HasForeignKey(s => s.RegistrationID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Committee and CommitteeMember
            modelBuilder.Entity<Committee>()
                .HasMany(c => c.CommitteeMembers)
                .WithOne(cm => cm.Committee)
                .HasForeignKey(cm => cm.CommitteeID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Lecturer and CommitteeMember
            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.CommitteeMembers)
                .WithOne(cm => cm.Lecturer)
                .HasForeignKey(cm => cm.LecturerID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Committee and Defense
            modelBuilder.Entity<Committee>()
                .HasMany(c => c.Defenses)
                .WithOne(d => d.Committee)
                .HasForeignKey(d => d.CommitteeID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-one relationship between Registration and Defense
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Defense)
                .WithOne(d => d.Registration)
                .HasForeignKey<Defense>(d => d.RegistrationID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Defense and DefenseScore
            modelBuilder.Entity<Defense>()
                .HasMany(d => d.DefenseScores)
                .WithOne(ds => ds.Defense)
                .HasForeignKey(ds => ds.DefenseID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // One-to-many relationship between Lecturer and DefenseScore
            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.DefenseScores)
                .WithOne(ds => ds.Lecturer)
                .HasForeignKey(ds => ds.LecturerID)
                .OnDelete(DeleteBehavior.Restrict); // Thêm DeleteBehavior

            // Configuring GroupLeader in StudentGroup to avoid circular dependency
            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.GroupLeader)
                .WithMany()
                .HasForeignKey(sg => sg.GroupLeaderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Advisor)
                .WithMany()
                .HasForeignKey(sg => sg.AdvisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Committee)
                .WithMany()
                .HasForeignKey(sg => sg.CommiteID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
