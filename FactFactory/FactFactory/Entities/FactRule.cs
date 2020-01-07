using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactFactory.Entities
{
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
            InputFactInfos = inputFactInfos;
            OutputFactInfo = outputFactInfo;
        }

        /// <inheritdoc />
        public IFact Derive(IFactContainer container)
        {
            return _func(container);
        }

        /// <inheritdoc />
        public bool IsCanDerive(IFactContainer container)
        {
            return InputFactInfos.All(factInfo => factInfo.ContainsContainer(container));
        }
    }
}
