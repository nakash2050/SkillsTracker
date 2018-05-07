using System.Collections.Generic;

namespace SkillsTracker.Entities.DTO
{
    public class DashboardDTO
    {
        public CandidatesDTO Candidates { get; set; }

        public TechDashboardDTO Technology { get; set; }

        public List<AssociatesDashboardDTO> Associates { get; set; }
    }
}
