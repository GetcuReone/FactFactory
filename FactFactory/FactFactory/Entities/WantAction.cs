using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Desired action information
    /// </summary>
    public sealed class WantAction : IWantAction
    {
        private readonly Action<IFactContainer> _action;

        /// <inheritdoc />
        public IEnumerable<IFactInfo> InputFacts { get; }

        /// <inheritdoc />
        public DateTime DateOfDerive { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public WantAction(Action<IFactContainer> action, IList<IFactInfo> factInfos)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            InputFacts = new ReadOnlyCollection<IFactInfo>(factInfos);
        }

        /// <inheritdoc />
        public void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer
        {
            _action(container);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFacts.Select(f => f.FactName).ToList())})";
        }
    }
}
