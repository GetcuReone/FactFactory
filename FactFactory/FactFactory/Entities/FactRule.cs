using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <inheritdoc />
    public sealed class FactRule : IFactRule
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
        public IFact Calculate<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            IFact fact = _func(container);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <inheritdoc />
        public bool CanCalculate<TFactContainer>(TFactContainer container) 
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
