using Trucking.Match.Api;

namespace Trucking.Job
{
    public class Job : IJob
    {
        public int Id { get; }
        public string Type { get; }

        public Job(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
