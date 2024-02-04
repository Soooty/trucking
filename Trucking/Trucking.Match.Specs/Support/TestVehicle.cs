using Trucking.Match.Api;

namespace Trucking.Match.Specs.Support
{
    internal class TestVehicle : IVehicle
    {
        public int Id { get; set; }

        public HashSet<string> CompatibleJobTypes { get; set; }

        public bool ReservedForJob { get; set; }
    }
}