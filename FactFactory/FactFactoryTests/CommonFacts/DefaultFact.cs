using GetcuReone.FactFactory;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class DefaultFact : BaseFact<int>
    {
        public DefaultFact(int value) : base(value) { }
    }
}
