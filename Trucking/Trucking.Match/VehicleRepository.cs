using Trucking.Job;
using Trucking.Vehicle;

internal class VehicleRepository
{
    List<Vehicle> mVehicles = new List<Vehicle>();
    public VehicleRepository(Span<string> vehicles)
    {
        foreach (string vehicle in vehicles)
        {
            var x = vehicle.Split(' ');
            mVehicles.Add(new Vehicle(int.Parse(x[0]), x.Skip(1).ToHashSet()));
        }
    }

    internal Vehicle VehicleForJob(Job job)
    {
        throw new NotImplementedException();
    }
}
