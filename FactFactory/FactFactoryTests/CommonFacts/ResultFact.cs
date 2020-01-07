using FactFactory.Facts;
using FactFactory.Interfaces;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class ResultFact : FactBase<int>
    {
        public ResultFact(int fact) : base(fact)
        {
        }

        public override IFactInfo GetFactInfo()
        {
            return new FactFactory.Entities.FactInfo<ResultFact>();
        }
    }
}
