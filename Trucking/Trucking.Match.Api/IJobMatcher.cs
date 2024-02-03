namespace Trucking.Match.Api
{
    public interface IJobMatcher
    {
        Dictionary<int, int> Match();
    }
}