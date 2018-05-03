using SkillsTracker.Entities;
using SkillsTracker.IRepositories;

namespace SkillsTracker.DAL.Repositories
{
    public class AssociatesRepository : Repository<Associate>, IAssociatesRepository
    {

        public SkillsTrackerContext SkillsTrackerContext { get { return Context as SkillsTrackerContext; } }

        public AssociatesRepository(SkillsTrackerContext context) :
            base(context)
        {

        }
    }
}
