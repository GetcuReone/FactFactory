﻿using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <inheritdoc />
    public class FactRule : IFactRule
    {
        private readonly Func<IFactContainer, IFact> _func;

        /// <inheritdoc />
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <inheritdoc />
        public IFactType OutputFactType { get; }

        /// <inheritdoc />
        public FactRule(Func<IFactContainer, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            InputFactTypes = inputFactTypes != null 
                ? new ReadOnlyCollection<IFactType>(inputFactTypes)
                : new ReadOnlyCollection<IFactType>(new List<IFactType>());
            OutputFactType = outputFactType;
        }

        /// <inheritdoc />
        public IFact Derive<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            List<IFact> includeFacts = new List<IFact>(
                InputFactTypes
                    .Where(factInfo => factInfo.IsFactType<INotContainedFact>())
                    .Select(factInfo => factInfo.GetNotContainedInstance()));

            includeFacts.AddRange(InputFactTypes
                    .Where(factInfo => factInfo.IsFactType<INoFact>())
                    .Select(factInfo => factInfo.GetNoInstance()));

            foreach (var includeFact in includeFacts)
                container.Add(includeFact);

            IFact fact = _func(container);

            foreach (var includeFact in includeFacts)
                container.Remove(includeFact);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <inheritdoc />
        public bool CanDerive<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            return InputFactTypes.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <inheritdoc />
        public bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule
        {
            if (!OutputFactType.Compare(factRule.OutputFactType))
                return false;
            else if (factRule.InputFactTypes.IsNullOrEmpty() && InputFactTypes.IsNullOrEmpty())
                return true;
            else if (InputFactTypes.IsNullOrEmpty() || factRule.InputFactTypes.IsNullOrEmpty())
                return false;
            else if (factRule.InputFactTypes.Count != InputFactTypes.Count)
                return false;
            else
            {
                foreach (var fact in factRule.InputFactTypes)
                {
                    if (InputFactTypes.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())}) => ({OutputFactType.FactName})";
        }
    }
}
