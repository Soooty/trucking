namespace Trucking.Match.Api
{
    public interface IVehicle
    {
        int Id { get; }
        HashSet<string> CompatibleJobTypes { get; }
        bool ReservedForJob { get; }
    }
}
