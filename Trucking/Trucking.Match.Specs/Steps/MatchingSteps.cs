using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using Trucking.Job;
using Trucking.Match.Api;
using Trucking.Match.Specs.Support;
using Trucking.Vehicle;

namespace Trucking.Match.Specs.StepDefinitions
{
    [Binding]
    public sealed class MatchingSteps
    {
        private VehicleRepository mVehicleRepository;
        private JobRepository mJobRepository;
        private Dictionary<int, int> mMatchResult;

        [Given(@"the vehicles")]
        public void GivenTheVehicles(IEnumerable<IVehicle> vehicles)
        {
            mVehicleRepository = new VehicleRepository(vehicles);
        }

        [Given(@"the jobs")]
        public void GivenTheJobs(IEnumerable<IJob> jobs)
        {
            mJobRepository = new JobRepository(jobs);
        }

        [When(@"we match the jobs with the vehicles")]
        public void WhenWeMatchTheJobsWithTheVehicles()
        {
            mMatchResult = new JobMatcher.JobMatcher(mVehicleRepository, mJobRepository).Match();
        }

        [Then(@"following pairs will be found")]
        public void ThenFollowingPairsWillBeFound(Table table)
        {
            var expected = table.Rows.ToDictionary(
                r => int.Parse(r["Job id"]), 
                r => int.Parse(r["Vehicle id"]));
            Assert.That(mMatchResult, Is.EquivalentTo(expected));
        }

        [StepArgumentTransformation]
        public IEnumerable<IVehicle> Vehicles(Table table)
        {
            return table.Rows.Select(r=> r.CreateInstance<TestVehicle>()).Cast<IVehicle>();
        }

        [StepArgumentTransformation]
        public IEnumerable<IJob> Jobs(Table table)
        {
            return table.Rows.Select(r => r.CreateInstance<Job.Job>()).Cast<IJob>();
        }
    }
}
