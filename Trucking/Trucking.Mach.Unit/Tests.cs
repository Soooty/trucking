using NUnit.Framework;
using Trucking.Job;
using Trucking.Match.Api;
using Trucking.Vehicle;

namespace Trucking.Mach.Unit
{
    public class Tests
    {
        [Test]
        public void BigDataSet()
        {
            string[] input = File.ReadAllLines("TesztFeladatImput.txt");

            int numberOfVehicles = int.Parse(input[0]);
            int numberOfJobs = int.Parse(input[numberOfVehicles + 1]);

            var vehicles = input.Take(new Range(1, numberOfVehicles + 1))
                .Select(v => VehicleFromString(v));
            var vehicleRepository = new VehicleRepository(vehicles);

            var jobs = input.Take(new Range(numberOfVehicles + 2, numberOfVehicles + 2 + numberOfJobs))
                .Select(j => JobFromString(j));
            var jobRepository = new JobRepository(jobs);


            var jobMatcher = new JobMatcher.JobMatcher(vehicleRepository, jobRepository);

            Dictionary<int, int> output = jobMatcher.Match();
            
            Assert.That(output.Count(), Is.EqualTo(numberOfJobs));
            Assert.That(output.Count(), Is.EqualTo(output.Values.Distinct().Count()));
        }

        private static IJob JobFromString(string job)
        {
            var x = job.Split(' ');

            return new Job.Job(int.Parse(x[0]), x[1]);
        }

        private static IVehicle VehicleFromString(string vehicle)
        {

            var x = vehicle.Split(' ');
            var vehicleId = int.Parse(x[0]);
            var compatibleJobTypes = x.Skip(1).ToHashSet();

            return new Vehicle.Vehicle(vehicleId, compatibleJobTypes);
        }
    }
}