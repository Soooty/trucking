using Trucking.Job;
using Trucking.JobMatcher;
using Trucking.Vehicle;

string[] input = File.ReadAllLines(args[0]);

int numberOfVehicles = int.Parse(input[0]);
int numberOfJobs = int.Parse(input[numberOfVehicles + 1]);

var vehicles = input.Take(new Range(1, numberOfVehicles + 1))
    .Select(v => VehicleFromString(v));
var vehicleRepository = new VehicleRepository(vehicles);

var jobs = input.Take(new Range(numberOfVehicles + 2, numberOfVehicles + 2 + numberOfJobs))
    .Select(j => JobFromString(j));
var jobRepository = new JobRepository(jobs);


var jobMatcher = new JobMatcher(vehicleRepository, jobRepository);

Dictionary<int, int> output = jobMatcher.Match();
File.WriteAllLines("output.txt", output.Select(o => $"{o.Key} {o.Value}"));
Console.WriteLine($"Done! Matched jobs: {output.Count}");

Vehicle VehicleFromString(string vehicle)
{

    var x = vehicle.Split(' ');
    var vehicleId = int.Parse(x[0]);
    var compatibleJobTypes = x.Skip(1).ToHashSet();

    return new Vehicle(vehicleId, compatibleJobTypes);
}

Job JobFromString(string job)
{ 
    var x = job.Split(' ');

    return new Job(int.Parse(x[0]), x[1]);
}
