using System.ComponentModel.DataAnnotations;

namespace SkillsTracker.Entities.DTO
{
    public class AssociateSkillsDTO
    {
        public int AssociateSkillsId { get; set; }

        [Required]
        public int AssociateId { get; set; }

        [Required]
        public int SkillId { get; set; }

        [Required]
        public int SkillRating { get; set; }

        public string SkillName { get; set; }
    }
}
