using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using SkillsTracker.Entities.DTO;
using SkillsTracker.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace SkillsTracker.Tests
{
    [TestClass]
    public class SkillsTests
    {
        private static SkillController _skillController;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _skillController = new SkillController();

            Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void AddNewSkill_ValidSkill_ReturnsAllSkills()
        {
            var skill = new SkillDTO
            {
                SkillName = "Test Skill"
            };

            IHttpActionResult actionResult = _skillController.Post(skill);
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }
    }
}
