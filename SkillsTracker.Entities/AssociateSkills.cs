using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsTracker.Entities
{
    public class AssociateSkills
    {
        [Key]
        [Column("Associate_Skills_ID")]
        public int AssociateSkillsId { get; set; }

        [Column("Associate_ID")]
        [ForeignKey("Associate")]
        public int AssociateId { get; set; }

        [Column("Skill_ID")]
        [ForeignKey("Skills")]
        public int SkillId { get; set; }

        public int Rating { get; set; }

        public Associate Associate { get; set; }

        public Skills Skills { get; set; }
    }
}
