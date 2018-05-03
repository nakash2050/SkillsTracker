using SkillsTracker.Entities;
using System.Data.Entity;

namespace SkillsTracker.DAL
{
    public class SkillsTrackerContext : DbContext
    {
        public SkillsTrackerContext()
            : base("name=SkillsTrackerContext")
        {

        }

        public virtual DbSet<Skills> Skills { get; set; }

        public virtual DbSet<Associate> Associate { get; set; }

        public virtual DbSet<AssociateSkills> AssociateSkills { get; set; }
    }
}
