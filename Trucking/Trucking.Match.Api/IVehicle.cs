namespace Trucking.Match.Api
{
    public interface IVehicle
    {
        int Id { get; }
        HashSet<string> CompatibleJobs { get; }
        int Rate { get; }
        bool ReservedForJob { get; }
    }
}
