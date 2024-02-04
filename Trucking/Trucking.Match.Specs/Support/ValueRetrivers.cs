using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace Trucking.JobMatcher
{
    [Binding]
    public static class ValueRetrivers
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new StringHashSetRetriever());
        }

        internal class StringHashSetRetriever : ClassRetriever<HashSet<string>>
        {
            protected override HashSet<string> GetNonEmptyValue(string value)
            {
                return value.Split(' ').ToHashSet();
            }
        }
    }
}

