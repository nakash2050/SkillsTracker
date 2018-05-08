using System.Linq;
using SkillsTracker.Entities;
using SkillsTracker.IRepositories;
using System.Collections.Generic;

namespace SkillsTracker.DAL.Repositories
{
    public class AssociateSkillsRepository : Repository<AssociateSkills>, IAssociateSkillsRepository
    {
        public SkillsTrackerContext SkillsTrackerContext { get { return Context as SkillsTrackerContext; } }

        public AssociateSkillsRepository(SkillsTrackerContext context) :
            base(context)
        {

        }

        public IEnumerable<AssociateSkills> GetAssociateSkillByAssociateId(int associateId)
        {
            var result = SkillsTrackerContext.AssociateSkills.Where(associate => associate.AssociateId == associateId).ToList();
            return result;
        }
    }
}
