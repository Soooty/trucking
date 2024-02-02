namespace Trucking.Vehicle
{
    public class Vechicle
    {
        public int Id { get; }
        public HashSet<string> CompatibleJobs { get; } = new HashSet<string>();
    }
}
