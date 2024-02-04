using Trucking.Match.Api;

namespace Trucking.Vehicle
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<int, IVehicle> mVehicles = new Dictionary<int, IVehicle>();

        public VehicleRepository(IEnumerable<IVehicle> vehicles)
        {
            mVehicles = vehicles.ToDictionary(v => v.Id, v => v);
        }

        public IVehicle Vehicle(int id)
        {
            return mVehicles[id];
        }

        public int NumberOfVehicles()
        {
            return mVehicles.Count;
        }
    }
}