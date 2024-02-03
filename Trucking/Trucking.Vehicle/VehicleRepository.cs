using Trucking.Match.Api;

namespace Trucking.Vehicle
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<int, Vehicle> mVehicles = new Dictionary<int, Vehicle>();

        public VehicleRepository(IEnumerable<string> vehicles)
        {
            foreach (string vehicle in vehicles)
            {
                var x = vehicle.Split(' ');
                var vehicleId = int.Parse(x[0]);
                var compatibleJobTypes = x.Skip(1).ToHashSet();
                mVehicles.Add(vehicleId, new Vehicle(
                    vehicleId,
                    compatibleJobTypes
                    )
                );
            }
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