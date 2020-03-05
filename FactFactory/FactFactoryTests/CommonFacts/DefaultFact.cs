using GetcuReone.FactFactory.Facts;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class DefaultFact : FactBase<int>
    {
        public DefaultFact(int value) : base(value)
        {
        }
    }
}
