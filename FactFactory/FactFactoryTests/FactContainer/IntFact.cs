using FactFactory.Facts;

namespace FactFactoryTests.FactContainer
{
    internal sealed class IntFact : FactBase<int>
    {
        public IntFact(int fact) : base(fact)
        {
        }
    }
}
