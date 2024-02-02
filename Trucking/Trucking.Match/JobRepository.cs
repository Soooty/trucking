
using Trucking.Job;

internal class JobRepository
{
    List<Job> mJobs = new List<Job>();

    public JobRepository(IEnumerable<string> jobs)
    {
        foreach (string job in jobs)
        {
            var x = job.Split(' ');
            mJobs.Add(new Job(int.Parse(x[0]), x[1]));
        }
    }

    internal List<Job> Jobs()
    {
        return mJobs;
    }
}