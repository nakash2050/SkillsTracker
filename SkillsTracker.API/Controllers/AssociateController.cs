using AssociatesTracker.BAL;
using SkillsTracker.Entities.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace SkillsTracker.API.Controllers
{
    [RoutePrefix("api/associate")]
    public class AssociateController : ApiController
    {
        private readonly AssociateBAL _associateBAL;

        public AssociateController()
        {
            _associateBAL = new AssociateBAL();
        }


        public IHttpActionResult Get()
        {
            var associate = _associateBAL.GetAllAssociates();
            return Ok(associate);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _associateBAL.GetAssociate(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        public IHttpActionResult Post(AssociateDTO associateDTO)
        {
            IEnumerable<AssociateDTO> skills = null;

            if (!ModelState.IsValid)
                return BadRequest();

            var result = _associateBAL.AddAssociate(associateDTO);

            if (result)
            {
                skills = _associateBAL.GetAllAssociates();
            }

            return Ok(skills);
        }

        [Route("withskills")]
        public IHttpActionResult Post(AssociateWithSkillsDTO associateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _associateBAL.AddAssociateWithSkills(associateDTO);

            return Ok(result);
        }

        public IHttpActionResult Put(int id, AssociateDTO associateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _associateBAL.UpdateAssociate(id, associateDTO);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = _associateBAL.DeleteAssociate(id);
            return Ok(result);
        }
    }
}
