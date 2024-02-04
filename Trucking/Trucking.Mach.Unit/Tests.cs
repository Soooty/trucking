using NUnit.Framework;
using Trucking.Job;
using Trucking.Vehicle;

namespace Trucking.Mach.Unit
{
    public class Tests
    {
        //    [Test]
        //    public void OneOnOne_Can_Match()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A" });
        //        var vehicleRepo = new VehicleRepository(new[] {"1 A"}); 

        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 1);
        //        Assert.True(machedJobs.ContainsKey(1));
        //        Assert.True(machedJobs[1] == 1);
        //    }

        //    [Test]
        //    public void One_Vehicle_Only_One_Job_Can_Match()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A", "2 A" });
        //        var vehicleRepo = new VehicleRepository(new[] { "1 A" });

        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 1);
        //        Assert.True(machedJobs.ContainsKey(1));
        //        Assert.True(machedJobs[1] == 1);
        //    }

        //    [Test]
        //    public void One_Vehicle_Only_One_Job_Can_Match2()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A", "2 B" });
        //        var vehicleRepo = new VehicleRepository(new[] { "1 A B" });
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 1);
        //        Assert.True(machedJobs.ContainsKey(1));
        //        Assert.True(machedJobs[1] == 1);
        //    }

        //    [Test]
        //    public void OneOnOne_Cant_Match()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A" });
        //        var vehicleRepo = new VehicleRepository(new[] { "1 B" });
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 0);
        //    }


        //    [Test]
        //    public void Priority_All_Needs_To_Be_Matched2()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 B" });
        //        var vehicleRepo = new VehicleRepository(new[] { "1 A B", "2 B" });
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.That(machedJobs.Count(), Is.EqualTo(1), "Nincs elég kiosztott munka!");
        //        Assert.That(vehicleRepo.Vehicle(1).ReservedForJob, Is.False);
        //    }


        //    [Test]
        //    public void Priority_All_Needs_To_Be_Matched()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A", "2 B" });
        //        var vehicleRepo = new VehicleRepository(new[] { "1 A B", "2 A" });
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.That(machedJobs.Count(), Is.EqualTo(2), "Nincs elég kiosztott munka!");
        //    }

        //    [Test]
        //    public void No_Vehicle_Cant_Match()
        //    {
        //        var jobRepo = new JobRepository(new[] { "1 A" });
        //        var vehicleRepo = new VehicleRepository(Array.Empty<string>());
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 0);
        //    }

        //    [Test]
        //    public void No_Job_Cant_Match()
        //    {
        //        var jobRepo = new JobRepository(Array.Empty<string>());
        //        var vehicleRepo = new VehicleRepository(new[] { "1 B" });
        //        var jobMatcher = new JobMatcher(vehicleRepo, jobRepo);
        //        var machedJobs = jobMatcher.Match();
        //        Assert.True(machedJobs.Count() == 0);
        //    }
    }
}