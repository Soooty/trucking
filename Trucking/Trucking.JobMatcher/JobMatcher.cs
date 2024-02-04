using Accord.Math.Optimization;
using Trucking.Match.Api;

namespace Trucking.JobMatcher
{
    public class JobMatcher : IJobMatcher
    {
        private IVehicleRepository mVehicleRepository;
        private IJobRepository mJobRepository;

        public JobMatcher(IVehicleRepository vehicleRepository, IJobRepository jobRepository)
        {
            mVehicleRepository = vehicleRepository;
            mJobRepository = jobRepository;
        }

        public Dictionary<int, int> Match()
        {
            var numberOfJobs = mJobRepository.NumberOfJobs();
            var numberOfVehicles = mVehicleRepository.NumberOfVehicles();


            if (numberOfJobs == 0 || numberOfVehicles == 0)
                return new Dictionary<int, int>();

            var munkres = new Munkres(CostMatrix(numberOfJobs, numberOfVehicles));
            munkres.Minimize();

            return munkres.Solution
                .Select((v, i) => new { Job = i + 1, Vehicle = (int)v + 1 })
                .Where(pair => pair.Vehicle > 0
                && CompatibleJob(mVehicleRepository.Vehicle(pair.Vehicle), mJobRepository.Job(pair.Job)))
                .ToDictionary(pair => pair.Job, pair => pair.Vehicle);
        }

        private double[][] CostMatrix(int numberOfJobs, int numberOfVehicles)
        {
            var costMatrix = new double[numberOfJobs][];
            for (int i = 0; i < numberOfJobs; i++)
            {
                costMatrix[i] = new double[numberOfVehicles];
                for (int j = 0; j < numberOfVehicles; j++)
                {
                    var job = mJobRepository.Job(i + 1);
                    var vehicle = mVehicleRepository.Vehicle(j + 1);
                    if (CompatibleJob(vehicle, job))
                    {
                        costMatrix[i][j] = 0;
                    }
                    else
                    {
                        costMatrix[i][j] = numberOfVehicles * 1000;
                    }
                }
            }

            return costMatrix;
        }

        private bool CompatibleJob(IVehicle vehicle, IJob job)
        {
            return vehicle.CompatibleJobTypes.Contains(job.Type);
        }
    }
}
