using Trucking.Match.Api;

namespace Trucking.Vehicle
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<int, Vehicle> mVehicles = new Dictionary<int, Vehicle>();
        private List<Vehicle> mVehiclePriorityList;
        private IDictionary<string, int> mJobPriority;

        public VehicleRepository(IEnumerable<string> vehicles, IDictionary<string, int> jobPriority)
        {
            mJobPriority = jobPriority;
            foreach (string vehicle in vehicles)
            {
                var x = vehicle.Split(' ');
                var vehicleId = int.Parse(x[0]);
                var compatibleJobTypes = x.Skip(1).ToHashSet();
                mVehicles.Add(vehicleId, new Vehicle(
                    vehicleId,
                    compatibleJobTypes,
                    CalculateVehicleRate(compatibleJobTypes)
                    )
                );
            }
            mVehiclePriorityList = mVehicles.Values.OrderBy(v => v.Rate).ToList();
        }

        public IVehicle Vehicle(int id)
        {
            return mVehicles[id];
        }

        public IVehicle? VehicleForJob(IJob job)
        {
            var vehicle = mVehiclePriorityList
                .FirstOrDefault(v => v.CompatibleJobs.Contains(job.Type));
            if (vehicle != null)
            {
                vehicle.Reserve();
                mVehiclePriorityList.Remove(vehicle);
            }

            return vehicle;
        }

        public int NumberOfVehicles()
        {
            return mVehicles.Count;
        }

        private int CalculateVehicleRate(HashSet<string> compatibleJobTypes)
        {
            return compatibleJobTypes.Sum(t => mJobPriority.ContainsKey(t)
            ? mJobPriority[t]
            : 1);
        }
    }
}