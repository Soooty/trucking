namespace Trucking.Match.Api
{
    public interface IJobRepository
    {
        IDictionary<string, int> JobPriority();
        IDictionary<int, IJob> Jobs();
    }
}