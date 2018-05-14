using NBench.Util;
using NBench;
using SkillsTracker.NUnitTests;
using AssociatesTracker.Tests;

namespace SkillsTracker.NBench
{
    public class SkillsTrackerPerfSpecs
    {
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of GetAllSkills API",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void BenchmarkGetAllSkills()
        {
            var skillsTest = new SkillsTests();
            skillsTest.SetUp();
            skillsTest.GetSkills_All_ReturnsAllSkills();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of AddNewSkill API.",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void BenchmarkAddNewSkill()
        {
            var skillsTest = new SkillsTests();
            skillsTest.SetUp();
            skillsTest.AddNewSkill_ValidSkill_ReturnsAllSkills();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of GetAllAssociates API.",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void BenchmarkGetAllAssociates()
        {
            var associateTests = new AssociateTests();
            associateTests.SetUp();
            associateTests.GetAssociates_All_ReturnsAllAssociates();

            _counter.Increment();
        }

        [PerfBenchmark(Description = "Test to ensure the performance parameters of AddNewAssociate API.",
            NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.GreaterThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.GreaterThanOrEqualTo, 0.0d)]
        public void BenchmarkAddAssociate()
        {
            var associateTests = new AssociateTests();
            associateTests.SetUp();
            associateTests.AddNewAssociate_ValidAssociate_ReturnsAllAssociates();

            _counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            
        }
    }
}
