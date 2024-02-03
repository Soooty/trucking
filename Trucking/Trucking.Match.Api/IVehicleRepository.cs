namespace Trucking.Match.Api
{
    public interface IVehicleRepository
    {
        IVehicle Vehicle(int id);
        IVehicle? VehicleForJob(IJob job);
        int NumberOfVehicles();
    }
}