using GetcuReone.FactFactory;

namespace FactFactory.VersionedTests.CommonFacts
{
    public sealed class Fact1 : FactBase<int>
    {
        public Fact1(int fact) : base(fact)
        {
        }
    }
}
