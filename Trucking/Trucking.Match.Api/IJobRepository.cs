namespace Trucking.Match.Api
{
    public interface IJobRepository
    {
        IDictionary<string, int> JobPriority();
        IDictionary<int, IJob> Jobs();
        IJob Job(int jobId);
        int NumberOfJobs();
    }
}