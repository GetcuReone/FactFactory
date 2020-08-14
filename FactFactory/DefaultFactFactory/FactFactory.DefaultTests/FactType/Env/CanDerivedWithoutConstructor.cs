using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactFactory.DefaultTests.FactType.Env
{
    internal class CanDerivedWithoutConstructor : IFact, ICanDerivedFact
    {
        private CanDerivedWithoutConstructor()
        {

        }

        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFactType FactType => throw new NotImplementedException();

        public IEnumerable<IFactParameter> Parameters => throw new NotImplementedException();

        public void AddParameter(IFactParameter parameter)
        {
            throw new NotImplementedException();
        }

        public bool Condition<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork factWork, TWantAction wantAction, TFactContainer container)
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
