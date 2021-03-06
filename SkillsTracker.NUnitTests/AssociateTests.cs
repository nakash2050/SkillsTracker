﻿using System.Web.Http;
using AutoMapper;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using SkillsTracker.Entities.DTO;
using SkillsTracker.API.Controllers;
using SkillsTracker.API.App_Start;
using NUnit.Framework;

namespace AssociatesTracker.Tests
{
    public class AssociateTests
    {
        private static AssociateController _associateController;

        [SetUp]
        public void SetUp()
        {
            Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }

        public AssociateTests()
        {
            _associateController = new AssociateController();
        }

        [Test]
        public void AddNewAssociate_ValidAssociate_ReturnsAllAssociates()
        {
            bool isValidAssociate = false;

            while (!isValidAssociate)
            {
                var associateId = new Random().Next();

                var associateInDb = _associateController.Get(associateId);
                var associateResult = associateInDb as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;
                if (associateResult == null)
                {
                    isValidAssociate = true;

                    var associate = new AssociateDTO
                    {
                        AssociateId = associateId,
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
            }
        }

        [Test]
        public void GetAssociates_All_ReturnsAllAssociates()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }

        [Test]
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

        [Test]
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

        [Test]
        public void UpdateAssociate_ValidAssociate_ReturnsTrue()
        {
            AddNewAssociate_ValidAssociate_ReturnsAllAssociates();

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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void GetAssociateWithSkills_PassAssociateId_ReturnsValidAssociate()
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
            Assert.AreEqual(associate.AssociateId, getContentResult.Content.Associate.AssociateId);
        }

        [Test]
        public void AddNewAssociateWithSkills_ValidAssociate_ReturnsAllAssociates()
        {
            bool isValidAssociate = false;
            List<AssociateSkillsDTO> associateSkills = null;

            while (!isValidAssociate)
            {
                var associateId = new Random().Next();

                var associateInDb = _associateController.Get(associateId);
                var associateResult = associateInDb as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;
                if (associateResult == null)
                {
                    isValidAssociate = true;

                    IHttpActionResult skillsActionResult = new AssociateSkillsController().Get();
                    var skillsContentResult = skillsActionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

                    if (skillsContentResult != null)
                    {
                        associateSkills = new List<AssociateSkillsDTO>();
                        associateSkills.Add(skillsContentResult.Content.FirstOrDefault());
                    }

                    var associate = new AssociateWithSkillsDTO()
                    {
                        Associate = new AssociateDTO()
                        {
                            AssociateId = associateId,
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
                        },
                        Skills = associateSkills != null ? associateSkills.ToArray() : null
                    };

                    IHttpActionResult actionResult = _associateController.PostAssociateWithSkills(associate);
                    var contentResult = actionResult as OkNegotiatedContentResult<bool>;

                    Assert.IsNotNull(contentResult);
                    Assert.IsTrue(contentResult.Content);
                }
            }
        }

        [Test]
        public void UpdateAssociateWithSkills_ValidAssociate_ReturnsAllAssociates()
        {
            IHttpActionResult actionResult = _associateController.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AssociateDTO>>;

            if (contentResult != null)
            {
                var associate = contentResult.Content.FirstOrDefault();

                IHttpActionResult aWithSkillsResult = _associateController.GetAssociateWithSkills(associate.AssociateId);
                var aWithSkillsContentResult = aWithSkillsResult as OkNegotiatedContentResult<AssociateWithSkillsDTO>;

                var associateWithSkills = aWithSkillsContentResult.Content;

                if (associateWithSkills != null)
                {
                    associateWithSkills.Associate.Name = String.Format("Associate Updated {0}", new Random().Next());

                    if (associateWithSkills.Skills != null)
                    {
                        IHttpActionResult skillsActionResult = new AssociateSkillsController().Get();
                        var skillsContentResult = skillsActionResult as OkNegotiatedContentResult<IEnumerable<AssociateSkillsDTO>>;

                        if (skillsContentResult != null)
                        {
                            var lstAssociateSkills = new List<AssociateSkillsDTO>();
                            lstAssociateSkills.Add(skillsContentResult.Content.FirstOrDefault());

                            associateWithSkills.Skills = lstAssociateSkills.ToArray();
                        }
                    }

                    IHttpActionResult updateActionResult = _associateController.UpdateAssociateWithSkills(associateWithSkills);
                    var updateContentResult = updateActionResult as OkNegotiatedContentResult<bool>;

                    Assert.IsNotNull(updateActionResult);
                    Assert.IsTrue(updateContentResult.Content);

                    IHttpActionResult getActionResult = _associateController.Get(associate.AssociateId);
                    var getContentResult = getActionResult as OkNegotiatedContentResult<AssociateDTO>;

                    Assert.IsNotNull(getContentResult);
                    Assert.AreEqual(associateWithSkills.Associate.Name, getContentResult.Content.Name);
                }
            }
        }
    }
}
