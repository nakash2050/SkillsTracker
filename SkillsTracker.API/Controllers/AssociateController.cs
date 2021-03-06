using AssociatesTracker.BAL;
using Newtonsoft.Json;
using SkillsTracker.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
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

        [Route("withSkills/{id}")]
        public IHttpActionResult GetAssociateWithSkills(int id)
        {
            var result = _associateBAL.GetAssociateWithSkills(id);

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

        public IHttpActionResult PostAssociateWithSkills(AssociateWithSkillsDTO associateWithSkillsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _associateBAL.AddAssociateWithSkills(associateWithSkillsDTO);

            return Ok(result);
        }

        [Route("withSkills")]
        public IHttpActionResult Post()
        {
            AssociateWithSkillsDTO associateDTO = null;
            string imageUrl = string.Empty;
            var httpRequest = HttpContext.Current.Request;

            foreach (var key in httpRequest.Form.AllKeys)
            {
                var data = httpRequest.Form[key];
                associateDTO = JsonConvert.DeserializeObject<AssociateWithSkillsDTO>(data);
            }

            if (associateDTO != null)
            {
                var associateInDb = _associateBAL.GetAssociate(associateDTO.Associate.AssociateId);

                if (associateInDb == null)
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        var postedFile = httpRequest.Files[0];
                        var imagePath = HttpContext.Current.Server.MapPath("~/Images/");
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                        }

                        var fileName = String.Format("{0}{1}", associateDTO.Associate.AssociateId, Path.GetExtension(postedFile.FileName));

                        var filePath = Path.Combine(imagePath, fileName);
                        postedFile.SaveAs(filePath);

                        imageUrl = String.Format("{0}/{1}/{2}", ConfigurationManager.AppSettings["ApiBaseURL"], "Images", fileName);
                        associateDTO.Associate.Picture = imageUrl;
                    }

                    var response = _associateBAL.AddAssociateWithSkills(associateDTO);

                    return Ok(new { status = response, ImageUrl = imageUrl });
                }
                else
                {
                    var response = string.Format("Employee with ID: \"{0}\" already exists. Employee Name as per records is : \"{1}\"", associateInDb.AssociateId, associateInDb.Name);
                    return BadRequest(response);
                }
            }

            return BadRequest("Error in data");
        }

        [Route("withSkills")]
        public IHttpActionResult Put()
        {
            AssociateWithSkillsDTO associateDTO = null;
            string imageUrl = string.Empty;
            var httpRequest = HttpContext.Current.Request;

            foreach (var key in httpRequest.Form.AllKeys)
            {
                var data = httpRequest.Form[key];
                associateDTO = JsonConvert.DeserializeObject<AssociateWithSkillsDTO>(data);
            }

            if (associateDTO != null)
            {
                var associateInDb = _associateBAL.GetAssociate(associateDTO.Associate.AssociateId);

                if (associateInDb != null)
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        var postedFile = httpRequest.Files[0];
                        var imagePath = HttpContext.Current.Server.MapPath("~/Images/");
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                        }

                        var fileName = String.Format("{0}_{1}{2}", associateDTO.Associate.AssociateId, DateTime.Now.ToString("MMddyyyHHmmss"), Path.GetExtension(postedFile.FileName));

                        var filePath = Path.Combine(imagePath, fileName);

                        postedFile.SaveAs(filePath);

                        imageUrl = String.Format("{0}/{1}/{2}", ConfigurationManager.AppSettings["ApiBaseURL"], "Images", fileName);
                        associateDTO.Associate.Picture = imageUrl;
                    }

                    var response = _associateBAL.UpdateAssociateWithSkills(associateDTO);

                    return Ok(new { status = response, ImageUrl = imageUrl });
                }
                else
                {
                    var response = string.Format("Employee with ID: \"{0}\" does not exits. ", associateInDb.AssociateId);
                    return BadRequest(response);
                }
            }

            return BadRequest("Error in data");
        }

        public IHttpActionResult Put(int id, AssociateDTO associateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _associateBAL.UpdateAssociate(id, associateDTO);
            return Ok(result);
        }

        public IHttpActionResult UpdateAssociateWithSkills(AssociateWithSkillsDTO associateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _associateBAL.UpdateAssociateWithSkills(associateDTO);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = _associateBAL.DeleteAssociate(id);
            return Ok(result);
        }

        [Route("dashboard")]
        public IHttpActionResult GetDashboardData()
        {
            var dasboard = _associateBAL.GetDashboardData();
            return Ok(dasboard);
        }
    }
}
