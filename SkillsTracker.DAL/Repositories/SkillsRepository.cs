using SkillsTracker.Entities;
using SkillsTracker.IRepositories;

namespace SkillsTracker.DAL.Repositories
{
    public class SkillsRepository :  Repository<Skills>, ISkillsRepository
    {
        public SkillsTrackerContext SkillsTrackerContext { get { return Context as SkillsTrackerContext; } }

        public SkillsRepository(SkillsTrackerContext context) :
            base(context)
        {

        }
    }
}
