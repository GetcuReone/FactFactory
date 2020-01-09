﻿using FactFactory.Helpers;
using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FactFactory.Entities
{
    /// <inheritdoc />
    public class FactRule : IFactRule
    {
        private readonly Func<IFactContainer, IFact> _func;

        /// <inheritdoc />
        public IReadOnlyCollection<IFactInfo> InputFactInfos { get; }

        /// <inheritdoc />
        public IFactInfo OutputFactInfo { get; }

        /// <inheritdoc />
        public FactRule(Func<IFactContainer, IFact> func, List<IFactInfo> inputFactInfos, IFactInfo outputFactInfo)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            InputFactInfos = inputFactInfos != null 
                ? new ReadOnlyCollection<IFactInfo>(inputFactInfos)
                : new ReadOnlyCollection<IFactInfo>(new List<IFactInfo>());
            OutputFactInfo = outputFactInfo;
        }

        /// <inheritdoc />
        public IFact Derive<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            IFact fact = _func(container);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <inheritdoc />
        public bool CanDerive<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            return InputFactInfos.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <inheritdoc />
        public bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule
        {
            if (!OutputFactInfo.Compare(factRule.OutputFactInfo))
                return false;
            else if (factRule.InputFactInfos.IsNullOrEmpty() && InputFactInfos.IsNullOrEmpty())
                return true;
            else if (InputFactInfos.IsNullOrEmpty() || factRule.InputFactInfos.IsNullOrEmpty())
                return false;
            else if (factRule.InputFactInfos.Count != InputFactInfos.Count)
                return false;
            else
            {
                foreach (var fact in factRule.InputFactInfos)
                {
                    if (!InputFactInfos.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }
    }
}
