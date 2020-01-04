using FactFactory.Entities;

namespace FactFactoryTests.FactContainer
{
    internal sealed class IntFact : FactBase<int>
    {
        public IntFact(int fact) : base(fact)
        {
        }
    }
}
