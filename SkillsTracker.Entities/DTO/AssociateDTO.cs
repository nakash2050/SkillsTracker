using System.ComponentModel.DataAnnotations;

namespace SkillsTracker.Entities.DTO
{
    public class AssociateDTO
    {
        [Required]
        public int AssociateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public string Picture { get; set; }

        public bool StatusGreen { get; set; }

        public bool StatusBlue { get; set; }

        public bool StatusRed { get; set; }

        public bool Level1 { get; set; }

        public bool Level2 { get; set; }

        public bool Level3 { get; set; }

        public string Remark { get; set; }

        public string Strength { get; set; }

        public string Weakness { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }
    }
}
