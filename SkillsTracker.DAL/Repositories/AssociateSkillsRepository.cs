using SkillsTracker.Entities;
using SkillsTracker.IRepositories;

namespace SkillsTracker.DAL.Repositories
{
    public class AssociateSkillsRepository : Repository<AssociateSkills>, IAssociateSkillsRepository
    {
        public SkillsTrackerContext SkillsTrackerContext { get { return Context as SkillsTrackerContext; } }

        public AssociateSkillsRepository(SkillsTrackerContext context) :
            base(context)
        {

        }
    }
}
