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
        public IEnumerable<IFactType> InputFactTypes { get; }

        /// <inheritdoc />
        public DateTime DateOfDerive { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public WantAction(Action<IFactContainer> action, IList<IFactType> factTypes)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            InputFactTypes = new ReadOnlyCollection<IFactType>(factTypes);
        }

        /// <inheritdoc />
        public void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer
        {
            _action(container);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())})";
        }
    }
}
