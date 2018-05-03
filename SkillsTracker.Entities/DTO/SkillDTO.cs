using System.ComponentModel.DataAnnotations;

namespace SkillsTracker.Entities.DTO
{
    public class SkillDTO
    {
        public int SkillId { get; set; }

        [Required]
        public string SkillName { get; set; }
    }
}
