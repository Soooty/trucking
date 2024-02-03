namespace Trucking.Match.Api
{
    public interface IVehicleRepository
    {
        IVehicle Vehicle(int id);
        int NumberOfVehicles();
    }
}