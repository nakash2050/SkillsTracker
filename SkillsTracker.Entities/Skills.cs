using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsTracker.Entities
{
    public class Skills
    {
        [Key]
        [Column("Skill_ID")]
        public int SkillId { get; set; }

        [Column("Skill_Name")]
        [Required]
        public string SkillName { get; set; }
    }
}
