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
    public class AssociateSkillsController : ApiController
    {
        private readonly AssociateSkillsBAL _askillsBAL;

        public AssociateSkillsController()
        {
            _askillsBAL = new AssociateSkillsBAL();
        }

        public IHttpActionResult Get()
        {
            var skills = _askillsBAL.GetAllAssociateSkills();
            return Ok(skills);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _askillsBAL.GetAssociateSkill(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        public IHttpActionResult Post(AssociateSkillsDTO associateSkillDTO)
        {
            IEnumerable<AssociateSkillsDTO> skills = null;

            if (!ModelState.IsValid)
                return BadRequest();

            var result = _askillsBAL.AddAssociateSkill(associateSkillDTO);

            if (result)
            {
                skills = _askillsBAL.GetAllAssociateSkills();
            }

            return Ok(skills);
        }

        public IHttpActionResult Put(int id, AssociateSkillsDTO associateSkillDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _askillsBAL.UpdateAssociateSkill(id, associateSkillDTO);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = _askillsBAL.DeleteAssociateSkill(id);
            return Ok(result);
        }
    }
}
