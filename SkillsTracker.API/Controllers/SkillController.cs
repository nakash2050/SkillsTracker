using SkillsTracker.BAL;
using SkillsTracker.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillsTracker.API.Controllers
{
    public class SkillController : ApiController
    {
        private readonly SkillsBAL _skillsBAL;

        public SkillController()
        {
            _skillsBAL = new SkillsBAL();
        }


        public IHttpActionResult Get()
        {
            var skills = _skillsBAL.GetAllSkills();
            return Ok(skills);
        }

        public IHttpActionResult Post(SkillDTO skillDTO)
        {
            IEnumerable<SkillDTO> skills = null;

            if (!ModelState.IsValid)
                return BadRequest();

            var result = _skillsBAL.AddSkill(skillDTO);

            if (result)
            {
                skills = _skillsBAL.GetAllSkills();
            }

            return Ok(skills);
        }
    }
}
