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
        public IFact Derive(IFactContainer container)
        {
            IFact fact = _func(container);

            if (fact == null)
                throw new InvalidOperationException("Rule cannot return null");

            return fact;
        }

        /// <inheritdoc />
        public bool CanDerive(IFactContainer container)
        {
            return InputFactInfos.All(factInfo => factInfo.ContainsContainer(container));
        }
    }
}
