using ThesisManagement.DAL.Repositories;
using ThesisManagement.Entities;

namespace ThesisManagement.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRepository<Student> Students { get; }
        IRepository<Lecturer> Lecturers { get; }
        IRepository<StudentGroup> StudentGroups { get; }
        IRepository<Topic> Topics { get; }
        IRegistrationRepository Registrations { get; }
        IRepository<Milestone> Milestones { get; }
        IRepository<Submission> Submissions { get; }
        IRepository<Evaluation> Evaluations { get; }
        ICommitteeRepository Committees { get; }
        ICommitteeMemberRepository CommitteeMembers { get; }
        IRepository<Defense> Defenses { get; }
        IRepository<DefenseScore> DefenseScores { get; }
        IRepository<ScoreWeight> ScoreWeights { get; }

        Task<int> Complete();
    }
}
