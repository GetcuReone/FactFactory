using GetcuReone.FactFactory;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;

namespace FactFactoryTests.CommonFacts
{
    internal sealed class InvalidSpecialFact : FactBase<int>
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

        public bool Condition<TFactWork, TFactRule, TWantAction, TFactContainer>(TFactWork factWork, IEnumerable<TFactRule> compatibleRules, IWantActionContext<TWantAction, TFactContainer> context)
            where TFactWork : IFactWork
            where TFactRule : IFactRule
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
