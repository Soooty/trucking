namespace Trucking.Job
{
    public class Job
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
