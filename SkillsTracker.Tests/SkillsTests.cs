using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using SkillsTracker.Entities.DTO;
using SkillsTracker.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;

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

        [TestMethod]
        public void GetSkills_All_ReturnsAllSkills()
        {
            IHttpActionResult actionResult = _skillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void GetSkill_PassSkillId_ReturnsValidSkill()
        {
            IHttpActionResult actionResult = _skillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            var skill = contentResult.Content.FirstOrDefault();

            IHttpActionResult getActionResult = _skillController.Get(skill.SkillId);
            var getContentResult = getActionResult as OkNegotiatedContentResult<SkillDTO>;

            Assert.IsNotNull(getContentResult);
            Assert.IsNotNull(getContentResult.Content);
            Assert.AreEqual(skill.SkillId, getContentResult.Content.SkillId);
        }

        [TestMethod]
        public void ValidateSkillModel_ValidSkill_ReturnsTrue()
        {
            var skillDTO = new SkillDTO()
            {
                SkillName = "Skill"
            };

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(skillDTO, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(skillDTO, context, results, true);

            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void UpdateSkill_ValidSkill_ReturnsTrue()
        {
            IHttpActionResult actionResult = _skillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            if (contentResult != null)
            {
                var skill = contentResult.Content.FirstOrDefault();
                skill.SkillName = String.Format("Skill {0}", new Random().Next());

                IHttpActionResult updateActionResult = _skillController.Put(skill.SkillId, skill);
                var updateContentResult = updateActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(updateContentResult.Content);

                IHttpActionResult getActionResult = _skillController.Get(skill.SkillId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<SkillDTO>;

                Assert.IsNotNull(getContentResult);
                Assert.AreEqual(skill.SkillName, getContentResult.Content.SkillName);
            }
        }

        [TestMethod]
        public void DeleteSkill_ValidSkill_ReturnsTrue()
        {
            AddNewSkill_ValidSkill_ReturnsAllSkills();

            IHttpActionResult actionResult = _skillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            if (contentResult != null)
            {
                var skill = contentResult.Content.FirstOrDefault();

                IHttpActionResult deleteActionResult = _skillController.Delete(skill.SkillId);
                var deleteContentResult = deleteActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(deleteContentResult.Content);

                IHttpActionResult getActionResult = _skillController.Get(skill.SkillId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<SkillDTO>;

                Assert.IsNull(getContentResult);
            }
        }

        [TestMethod]
        public void ValidateSkillModel_InvalidSkillName_ReturnsFalse()
        {
            var skillDTO = new SkillDTO()
            {
                SkillName = string.Empty
            };

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(skillDTO, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(skillDTO, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }
    }
}
