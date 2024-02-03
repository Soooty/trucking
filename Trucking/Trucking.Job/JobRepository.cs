using System.Collections.Immutable;
using Trucking.Match.Api;

namespace Trucking.Job
{
    public class JobRepository : IJobRepository
    {
        readonly Dictionary<int, Job> mJobs = new();
        private readonly Dictionary<string, int> mJobPriority = new();

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

        public IDictionary<string, int> JobPriority()
        {
            return mJobPriority.ToImmutableDictionary();
        }

        public IDictionary<int, IJob> Jobs()
        {
            return mJobs.Values.Select(i=>i).Cast<IJob>().ToImmutableDictionary(i=>i.Id, i=>i);
        }
    }
}