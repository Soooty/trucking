using System.Collections.Immutable;
using Trucking.Match.Api;

namespace Trucking.Job
{
    public class JobRepository : IJobRepository
    {
        readonly Dictionary<int, IJob> mJobs = new();

        public JobRepository(IEnumerable<IJob> jobs)
        {
            mJobs = jobs.ToDictionary(j => j.Id, j => j);
            
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