namespace Trucking.Job
{
    public class Job
    {
        public int Id { get; }
        public string Type { get; }
        public bool Taken { get; private set; }

        public Job(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public void MatchedWithVehicle()
        {
            Taken = true;
        }
    }
}
