using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace SkillsTracker.Tests
{
    [TestClass]
    public class SkillsTests
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
