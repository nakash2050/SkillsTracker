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

        public IHttpActionResult Get(int id)
        {
            var result = _skillsBAL.GetSkill(id);

            if (result == null)
                return NotFound();

            return Ok(result);
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

        public IHttpActionResult Put(int id, SkillDTO skillDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _skillsBAL.UpdateSkill(id, skillDTO);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = _skillsBAL.DeleteSkill(id);
            return Ok(result);
        }
    }
}
