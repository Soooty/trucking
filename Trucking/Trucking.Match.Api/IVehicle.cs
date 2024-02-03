namespace Trucking.Match.Api
{
    public interface IVehicle
    {
        int Id { get; }
        HashSet<string> CompatibleJobs { get; }
        bool ReservedForJob { get; }
    }
}
