using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class ResultFact : FactBase<int>
    {
        public ResultFact(int fact) : base(fact)
        {
        }

        public override IFactType GetFactType()
        {
            return new GetcuReone.FactFactory.Entities.FactType<ResultFact>();
        }
    }
}
