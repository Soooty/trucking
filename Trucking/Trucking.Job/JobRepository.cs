using System.Collections.Immutable;
using Trucking.Match.Api;

namespace Trucking.Job
{
    public class JobRepository : IJobRepository
    {
        readonly Dictionary<int, Job> mJobs = new();

        public JobRepository(IEnumerable<string> jobs)
        {
            foreach (string jobAsString in jobs)
            {
                var x = jobAsString.Split(' ');
                var job = new Job(int.Parse(x[0]), x[1]);
                mJobs.Add(job.Id, job);
            }
        }

        public IJob Job(int id)
        {
            return mJobs[id];
        }
        public IDictionary<int, IJob> Jobs()
        {
            return mJobs.Values.Select(i=>i).Cast<IJob>().ToImmutableDictionary(i=>i.Id, i=>i);
        }

        public int NumberOfJobs()
        {
            return mJobs.Count();
        }
    }
}