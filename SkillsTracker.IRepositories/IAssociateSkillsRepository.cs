using SkillsTracker.Entities;
using System.Collections.Generic;

namespace SkillsTracker.IRepositories
{
    public interface IAssociateSkillsRepository : IRepository<AssociateSkills>
    {
        IEnumerable<AssociateSkills> GetAssociateSkillByAssociateId(int associateId);
    }
}
