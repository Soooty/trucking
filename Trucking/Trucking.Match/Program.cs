using Trucking.Job;
using Trucking.Vehicle;

string[] input = File.ReadAllLines(args[0]);

int numberOfVehicles = int.Parse(input[0]);
int numberOfJobs = int.Parse(input[numberOfVehicles + 1]);
var jobRepository = new JobRepository(input.Take(new Range(numberOfVehicles + 2, numberOfVehicles + 2 + numberOfJobs)));

VehicleRepository vehicleRepository = new VehicleRepository(
    input.Take(new Range(1, numberOfVehicles+1)));

var jobMatcher = new JobMatcher(vehicleRepository, jobRepository);

Dictionary<int, int> output = jobMatcher.Match();
File.WriteAllLines("output.txt", output.Select(o => $"{o.Key} {o.Value}"));
Console.WriteLine($"Done! Matched jobs: {output.Count}");