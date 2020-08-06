using GetcuReone.FactFactory.BaseEntities.SpecialFacts;
using System;

namespace FactFactory.DefaultTests.CommonFacts
{
    internal sealed class SpecialFact : SpecialFactBase
    {
        public override bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
