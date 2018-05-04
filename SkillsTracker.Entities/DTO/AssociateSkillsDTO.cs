using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Rating { get; set; }
    }
}
