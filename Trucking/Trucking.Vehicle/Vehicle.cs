using Trucking.Match.Api;

namespace Trucking.Vehicle
{
    public class Vehicle : IVehicle
    {
        public int Id { get; }
        public HashSet<string> CompatibleJobTypes { get; } = new HashSet<string>();
        public bool ReservedForJob { get; private set; }

        public Vehicle(int id, HashSet<string> compatibleJobs)
        {
            Id = id;
            CompatibleJobTypes = compatibleJobs;
        }

        public void Reserve()
        {
            ReservedForJob = true;
        }
    }
}
