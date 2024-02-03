namespace Trucking.Match.Api
{
    public interface IJob
    {
        int Id { get; }
        string Type { get; }
        bool Taken { get; }
        void MatchedWithVehicle();
    }
}
