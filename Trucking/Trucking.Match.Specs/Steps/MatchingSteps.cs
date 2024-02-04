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

        [Given(@"vehicles are empty")]
        public void GivenVehiclesAreEmpty()
        {
            mVehicleRepository = new VehicleRepository(Array.Empty<IVehicle>());
        }

        [Given(@"jobs are empty")]
        public void GivenJobsAreEmpty()
        {
            mJobRepository = new JobRepository(Array.Empty<IJob>());
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

        [Then(@"no pairs found")]
        public void ThenNoPairsFound()
        {
            Assert.That(mMatchResult, Is.Empty);
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
