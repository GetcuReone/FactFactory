using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class ResultFact : FactBase<int>
    {
        public ResultFact(int fact) : base(fact)
        {
        }

        public override IFactInfo GetFactInfo()
        {
            return new GetcuReone.FactFactory.Entities.FactInfo<ResultFact>();
        }
    }
}
