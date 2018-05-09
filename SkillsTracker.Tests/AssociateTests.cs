using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using SkillsTracker.Entities.DTO;
using SkillsTracker.API.Controllers;
using SkillsTracker.API.App_Start;

namespace AssociatesTracker.Tests
{
    [TestClass]
    public class AssociateTests
    {
        private static AssociateController _associateController;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _associateController = new AssociateController();

            Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void AddNewAssociate_ValidAssociate_ReturnsAllAssociates()
        {
            var associate = new AssociateDTO
            {
                AssociateId = new Random().Next(),
                Name = String.Format("Test Associate {0}", new Random().Next()),
                Email = String.Format("associate{0}@skillstracker.com", new Random().Next()),
                Mobile = "9834509344",
                StatusGreen = true,
                StatusBlue = false,
                StatusRed = false,
                Level1 = true,
                Level2 = false,
                Level3 = false,
                Strength = "Strength",
                Weakness = "Weakness",
                Remark = "Remark"
            };

            IHttpActionResult actionResult = _associateController.Post(associate);
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void GetAssociates_All_ReturnsAllCategories()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [TestMethod]
        public void GetAssociate_PassAssociateId_ReturnsValidAssociate()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            var associate = contentResult.Content.FirstOrDefault();

            IHttpActionResult getActionResult = _associateController.Get(associate.AssociateId);
            var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateDTO>;

            Assert.IsNotNull(getContentResult);
            Assert.IsNotNull(getContentResult.Content);
            Assert.AreEqual(associate.AssociateId, getContentResult.Content.AssociateId);
        }

        [TestMethod]
        public void ValidateAssociateModel_ValidAssociate_ReturnsTrue()
        {
            var associateDTO = new AssociateDTO()
            {
                AssociateId = new Random().Next(),
                Name = String.Format("Test Associate {0}", new Random().Next()),
                Email = String.Format("associate{0}@skillstracker.com", new Random().Next()),
                Mobile = "9834509344",
            };

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(associateDTO, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(associateDTO, context, results, true);

            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void UpdateAssociate_ValidAssociate_ReturnsTrue()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            if (contentResult != null)
            {
                var associate = contentResult.Content.FirstOrDefault();
                associate.Name = String.Format("Associate {0}", new Random().Next());

                IHttpActionResult updateActionResult = _associateController.Put(associate.AssociateId, associate);
                var updateContentResult = updateActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(updateContentResult.Content);

                IHttpActionResult getActionResult = _associateController.Get(associate.AssociateId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateDTO>;

                Assert.IsNotNull(getContentResult);
                Assert.AreEqual(associate.Name, getContentResult.Content.Name);
            }
        }

        [TestMethod]
        public void DeleteAssociate_ValidAssociate_ReturnsTrue()
        {
            AddNewAssociate_ValidAssociate_ReturnsAllAssociates();

            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            if (contentResult != null)
            {
                var associate = contentResult.Content.FirstOrDefault();

                IHttpActionResult deleteActionResult = _associateController.Delete(associate.AssociateId);
                var deleteContentResult = deleteActionResult as OkNegotiatedContentResult<bool>;

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(deleteContentResult.Content);

                IHttpActionResult getActionResult = _associateController.Get(associate.AssociateId);
                var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateDTO>;

                Assert.IsNull(getContentResult);
            }
        }

        [TestMethod]
        public void ValidateAssociateModel_InvalidAssociateName_ReturnsFalse()
        {
            var associateDTO = new AssociateDTO()
            {
                Name = string.Empty
            };

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(associateDTO, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(associateDTO, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void GetDashboardData_ReturnsDashboardData()
        {
            IHttpActionResult actionResult = _associateController.GetDashboardData();
            var contentResult = actionResult as OkNegotiatedContentResult<DashboardDTO>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsNotNull(contentResult.Content.Associates);
            Assert.IsNotNull(contentResult.Content.Candidates);
            Assert.IsNotNull(contentResult.Content.Technology);
        }

        public void GetAssociateSkills_PassValidAssociateId_ReturnsValidAssociateWithSkills()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            var associate = contentResult.Content.FirstOrDefault();

            IHttpActionResult getActionResult = _associateController.GetAssociateWithSkills(associate.AssociateId);
            var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateWithSkillsDTO>;

            Assert.IsNotNull(getContentResult);
            Assert.IsNotNull(getContentResult.Content);
            Assert.IsNotNull(getContentResult.Content.Associate);
            Assert.IsNotNull(getContentResult.Content.Skills);
            Assert.AreEqual(associate.AssociateId, getContentResult.Content.Associate.AssociateId);
        }
    }
}
