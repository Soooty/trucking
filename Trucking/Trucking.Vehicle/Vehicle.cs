using Trucking.Match.Api;

namespace Trucking.Vehicle
{
    public class Vehicle : IVehicle
    {
        public int Id { get; }
        public HashSet<string> CompatibleJobs { get; } = new HashSet<string>();
        public bool ReservedForJob { get; private set; }

        public Vehicle(int id, HashSet<string> compatibleJobs)
        {
            Id = id;
            CompatibleJobs = compatibleJobs;
        }

        public void Reserve()
        {
            ReservedForJob = true;
        }
    }
}
