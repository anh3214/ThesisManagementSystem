using ThesisManagement.DAL.Interfaces;
using ThesisManagement.DAL.Repositories;
using ThesisManagement.Entities;
using ThesisManagement.Entities.Db;

namespace ThesisManagement.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IUserRepository Users { get; private set; }
        public IRepository<Student> Students { get; private set; }
        public IRepository<Lecturer> Lecturers { get; private set; }
        public IRepository<StudentGroup> StudentGroups { get; private set; }
        public IRepository<Topic> Topics { get; private set; }
        public IRegistrationRepository Registrations { get; private set; }
        public IRepository<Milestone> Milestones { get; private set; }
        public IRepository<Submission> Submissions { get; private set; }
        public IRepository<Evaluation> Evaluations { get; private set; }
        public ICommitteeRepository Committees { get; private set; }
        public ICommitteeMemberRepository CommitteeMembers { get; private set; }
        public IRepository<Defense> Defenses { get; private set; }
        public IRepository<DefenseScore> DefenseScores { get; private set; }
        public IRepository<ScoreWeight> ScoreWeights { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Students = new Repository<Student>(context);
            Lecturers = new Repository<Lecturer>(context);
            StudentGroups = new Repository<StudentGroup>(context);
            Topics = new Repository<Topic>(context);
            Registrations = new RegistrationRepository(context);
            Milestones = new Repository<Milestone>(context);
            Submissions = new Repository<Submission>(context);
            Evaluations = new Repository<Evaluation>(context);
            Committees = new CommitteeRepository(context);
            CommitteeMembers = new CommitteeMemberRepository(context);
            Defenses = new Repository<Defense>(context);
            DefenseScores = new Repository<DefenseScore>(context);
            ScoreWeights = new Repository<ScoreWeight>(context);
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void DisposeContext()
        {
            context.Dispose();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
