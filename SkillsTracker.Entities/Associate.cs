using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsTracker.Entities
{
    public class Associate
    {        
        [Key]
        [Column("Associate_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssociateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public string Picture { get; set; }

        [Column("Status_Green")]
        public bool StatusGreen { get; set; }

        [Column("Status_Blue")]
        public bool StatusBlue { get; set; }

        [Column("Status_Red")]
        public bool StatusRed { get; set; }

        [Column("Level_1")]
        public bool Level1 { get; set; }

        [Column("Level_2")]
        public bool Level2 { get; set; }

        [Column("Level_3")]
        public bool Level3 { get; set; }

        public string Remark { get; set; }

        public string Strength { get; set; }

        public string Weakness { get; set; }
    }
}
