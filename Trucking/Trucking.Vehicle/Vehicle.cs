
namespace Trucking.Vehicle
{
    public class Vehicle
    {
        public int Id { get; }
        public HashSet<string> CompatibleJobs { get; } = new HashSet<string>();
        public int Rate { get; }
        public bool ReservedForJob { get; private set; }

        public Vehicle(int id, HashSet<string> compatibleJobs, int rate)
        {
            Id = id;
            CompatibleJobs = compatibleJobs;
            Rate = rate;
        }

        public void Reserve()
        {
            ReservedForJob = true;
        }
    }
}
