namespace Trucking.Match.Api
{
    public interface IJobRepository
    {
        IDictionary<int, IJob> Jobs();
        IJob Job(int jobId);
        int NumberOfJobs();
    }
}