using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class InvalidSpecialFact : FactBase<int>, ICannotDerivedFact, ICanDerivedFact
    {
        public InvalidSpecialFact() : base(0)
        {
        }

        public IFactType FactType => throw new NotImplementedException();

        public bool Condition<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer container) where TFact : IFact
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            throw new NotImplementedException();
        }
    }
}
