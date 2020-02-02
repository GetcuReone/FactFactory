using GetcuReone.FactFactory.Helpers;
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
        public IReadOnlyCollection<IFactType> InpuTFactTypes { get; }

        /// <inheritdoc />
        public IFactType OutpuTFactType { get; }

        /// <inheritdoc />
        public FactRule(Func<IFactContainer, IFact> func, List<IFactType> inpuTFactTypes, IFactType outpuTFactType)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            InpuTFactTypes = inpuTFactTypes != null 
                ? new ReadOnlyCollection<IFactType>(inpuTFactTypes)
                : new ReadOnlyCollection<IFactType>(new List<IFactType>());
            OutpuTFactType = outpuTFactType;
        }

        /// <inheritdoc />
        public IFact Derive<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            List<IFact> includeFacts = new List<IFact>(
                InpuTFactTypes
                    .Where(factInfo => factInfo.IsFactType<INotContainedFact>())
                    .Select(factInfo => factInfo.GetNotContainedInstance()));

            includeFacts.AddRange(InpuTFactTypes
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
            return InpuTFactTypes.All(factInfo => factInfo.ContainsContainer(container));
        }

        /// <inheritdoc />
        public bool Compare<TFactRule>(TFactRule factRule) where TFactRule : IFactRule
        {
            if (!OutpuTFactType.Compare(factRule.OutpuTFactType))
                return false;
            else if (factRule.InpuTFactTypes.IsNullOrEmpty() && InpuTFactTypes.IsNullOrEmpty())
                return true;
            else if (InpuTFactTypes.IsNullOrEmpty() || factRule.InpuTFactTypes.IsNullOrEmpty())
                return false;
            else if (factRule.InpuTFactTypes.Count != InpuTFactTypes.Count)
                return false;
            else
            {
                foreach (var fact in factRule.InpuTFactTypes)
                {
                    if (InpuTFactTypes.All(f => !f.Compare(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InpuTFactTypes.Select(f => f.FactName).ToList())}) => ({OutpuTFactType.FactName})";
        }
    }
}
