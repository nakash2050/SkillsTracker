using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using SkillsTracker.Entities.DTO;
using SkillsTracker.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SkillsTracker.Tests
{
    [TestClass]
    public class AssociateSkillsTests
    {
        private static SkillController _skillController;
        private static AssociateController _associateController;
        private static AssociateSkillsController _associateSkillController;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _skillController = new SkillController();
            _associateController = new AssociateController();
            _associateSkillController = new AssociateSkillsController();

            Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void AddNewAssociateSkill_ValidAssociateSkill_ReturnsAllAssociateSkills()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            var associate = contentResult.Content.FirstOrDefault();

            IHttpActionResult skillActionResult = _skillController.Get();
            var associateContentResult = skillActionResult as OkNegotiatedContentResult<IEnumerable<SkillDTO>>;

            Assert.IsNotNull(associateContentResult);
            Assert.IsNotNull(associateContentResult.Content);

            var skill = associateContentResult.Content.FirstOrDefault();

            var associateSkill = new AssociateSkillsDTO
            {
                AssociateId = associate.AssociateId,
                SkillId = skill.SkillId,
                SkillRating = new Random().Next(20)
            };

            IHttpActionResult aSkillsactionResult = _associateSkillController.Post(associateSkill);
            var aSkillcontentResult = aSkillsactionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

            Assert.IsNotNull(aSkillcontentResult);
            Assert.IsNotNull(aSkillcontentResult.Content);
        }

        [TestMethod]
        public void GetAssociateSkills_All_ReturnsAllAssociateSkills()
        {
            IHttpActionResult actionResult = _associateSkillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void GetAssociateSkill_PassAssociateSkillId_ReturnsValidAssociateSkill()
        {
            IHttpActionResult actionResult = _associateSkillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            var skill = contentResult.Content.FirstOrDefault();

            IHttpActionResult getActionResult = _associateSkillController.Get(skill.AssociateSkillsId);
            var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateSkillsDTO>;

            Assert.IsNotNull(getContentResult);
            Assert.IsNotNull(getContentResult.Content);
            Assert.AreEqual(skill.AssociateSkillsId, getContentResult.Content.AssociateSkillsId);
        }


        [TestMethod]
        public void UpdateAssociateSkill_ValidAssociateSkill_ReturnsTrue()
        {
            IHttpActionResult actionResult = _associateSkillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

            if (contentResult != null)
            {
                var skill = contentResult.Content.FirstOrDefault();
                skill.SkillRating = new Random().Next(20);

                IHttpActionResult updateActionResult = _associateSkillController.Put(skill.AssociateSkillsId, skill);
                var updateContentResult = updateActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(updateContentResult.Content);

                IHttpActionResult getActionResult = _associateSkillController.Get(skill.AssociateSkillsId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateSkillsDTO>;

                Assert.IsNotNull(getContentResult);
                Assert.AreEqual(skill.SkillRating, getContentResult.Content.SkillRating);
            }
        }

        [TestMethod]
        public void DeleteAssociateSkill_ValidAssociateSkillId_ReturnsTrue()
        {
            IHttpActionResult actionResult = _associateSkillController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

            if (contentResult != null)
            {
                var skill = contentResult.Content.FirstOrDefault();

                IHttpActionResult deleteActionResult = _associateSkillController.Delete(skill.AssociateSkillsId);
                var deleteContentResult = deleteActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(deleteContentResult.Content);

                IHttpActionResult getActionResult = _associateSkillController.Get(skill.AssociateSkillsId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateSkillsDTO>;

                Assert.IsNull(getContentResult);
            }
        }
    }
}
