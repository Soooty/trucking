using Trucking.Job;
using Trucking.Vehicle;

string[] input = File.ReadAllLines(args[0]);

int numberOfVehicles = int.Parse(input[0]);
List<Vehicle> vehicles = new List<Vehicle>();

for (int i = 1; i <= numberOfVehicles; i++)
{
    var x = input[i].Split(' ');
    vehicles.Add(new Vehicle(int.Parse(x[0]), x.Skip(1).ToHashSet()));
}

int numberOfJobs = int.Parse(input[numberOfVehicles + 1]);
List<Job> jobs = new List<Job>();

for (int i = numberOfVehicles + 2; i < numberOfVehicles + 2 + numberOfJobs; i++)
{
    var x = input[i].Split(' ');
    jobs.Add(new Job(int.Parse(x[0]), x[1]));
}

Console.ReadLine();