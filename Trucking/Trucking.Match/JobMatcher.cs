
using Trucking.Match.Api;

internal class JobMatcher : IJobMatcher
{
    private IVehicleRepository mVehicleRepository;
    private IJobRepository mJobRepository;

    public JobMatcher(IVehicleRepository vehicleRepository, IJobRepository jobRepository)
    {
        mVehicleRepository = vehicleRepository;
        mJobRepository = jobRepository;
    }

    public Dictionary<int, int> Match()
    {
        var matchedJobs = new Dictionary<int, int>();
        foreach (var job in mJobRepository.Jobs().Values)
        {
            var vehicleForJob = mVehicleRepository.VehicleForJob(job);
            if (vehicleForJob != null)
            {
                matchedJobs.Add(job.Id, vehicleForJob.Id);
                job.MatchedWithVehicle();
            }
        }

        return matchedJobs;
    }
}
