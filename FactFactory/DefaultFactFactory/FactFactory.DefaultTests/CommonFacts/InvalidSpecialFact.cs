using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class InvalidSpecialFact : FactBase<int>, ICannotDerivedFact, IContainedFact
    {
        public InvalidSpecialFact() : base(0)
        {
        }

        public IFactType FactType => throw new NotImplementedException();

        public bool CanUse<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer<TFact> container) where TFact : IFact
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            throw new NotImplementedException();
        }
    }
}
