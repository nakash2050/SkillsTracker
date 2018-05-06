using System;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
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
