using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;

namespace FactFactoryTests.FactType.Env
{
    internal class ConditionWithoutConstructor : IFact, IBuildConditionFact
    {
        private ConditionWithoutConstructor()
        {

        }

        public bool CalculatedByRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IFactType FactType => throw new NotImplementedException();

        public void AddParameter(IFactParameter parameter)
        {
            throw new NotImplementedException();
        }

        public bool Condition<TFactWork, TWantAction>(TFactWork factWork, TWantAction wantAction, IFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
        {
            throw new NotImplementedException();
        }

        public bool Condition<TFactWork, TFactRule, TWantAction>(TFactWork factWork, IWantActionContext<TWantAction> context, Func<IWantActionContext<TWantAction>, IFactRuleCollection<TFactRule>> getCompatibleRules)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
            where TWantAction : IWantAction
        {
            throw new NotImplementedException();
        }

        public bool EqualsInfo(ISpecialFact specialFact)
        {
            throw new NotImplementedException();
        }

        public IFactType GetFactType()
        {
            throw new NotImplementedException();
        }

        public IFactParameter GetParameter(string parameterCode)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IFactParameter> GetParameters()
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
