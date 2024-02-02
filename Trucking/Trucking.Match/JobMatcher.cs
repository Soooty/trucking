
internal class JobMatcher
{
    private VehicleRepository mVehicleRepository;
    private JobRepository mJobRepository;

    public JobMatcher(VehicleRepository vehicleRepository, JobRepository jobRepository)
    {
        mVehicleRepository = vehicleRepository;
        mJobRepository = jobRepository;
    }

    internal Dictionary<int, int> Match()
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