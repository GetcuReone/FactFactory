using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace FactFactoryTests.FactType.Env
{
    internal class NotContainedWithoutConstructor : IFact, INotContainedFact
    {
        private NotContainedWithoutConstructor()
        {

        }

        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFactType FactType => throw new NotImplementedException();

        public bool CanUse<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            throw new NotImplementedException();
        }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }

        public bool IsFactContained<TFact>(IFactContainer<TFact> container)
            where TFact : IFact
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
