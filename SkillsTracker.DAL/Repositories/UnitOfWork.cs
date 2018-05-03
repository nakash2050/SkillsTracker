using SkillsTracker.IRepositories;

namespace SkillsTracker.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SkillsTrackerContext _context;

        public UnitOfWork(SkillsTrackerContext context)
        {
            _context = context;
            Skills = new SkillsRepository(context);
            Associates = new AssociatesRepository(context);
            AssociateSkills = new AssociateSkillsRepository(context);
        }

        public ISkillsRepository Skills { get; private set; }

        public IAssociatesRepository Associates { get; private set; }

        public IAssociateSkillsRepository AssociateSkills { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
