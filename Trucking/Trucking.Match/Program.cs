string[] input = File.ReadAllLines(args[0]);

int numberOfVehicles = int.Parse(input[0]);
VehicleRepository vehicleRepository = new VehicleRepository(input.AsSpan(1,numberOfVehicles));

int numberOfJobs = int.Parse(input[numberOfVehicles + 1]);
JobRepository jobRepository = new JobRepository(input.AsSpan(numberOfVehicles+2, numberOfJobs));

Console.ReadLine();