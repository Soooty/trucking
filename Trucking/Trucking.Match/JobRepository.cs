
using System.Collections.Immutable;
using Trucking.Job;

internal class JobRepository
{
    Dictionary<int, Job> mJobs = new Dictionary<int, Job>();
    private Dictionary<string, int> mJobPriority = new Dictionary<string, int>();

    public JobRepository(IEnumerable<string> jobs)
    {
        foreach (string jobAsString in jobs)
        {
            var x = jobAsString.Split(' ');
            var job = new Job(int.Parse(x[0]), x[1]);
            mJobs.Add(job.Id, job);
            if (!mJobPriority.ContainsKey(job.Type))
                mJobPriority.Add(job.Type, 0);
            mJobPriority[job.Type] = mJobPriority[job.Type] + 2;
        }
    }

    internal IDictionary<string, int> JobPriority()
    {
        return mJobPriority.ToImmutableDictionary();
    }

    internal IDictionary<int, Job> Jobs()
    {
        return mJobs.ToImmutableDictionary();
    }
}