using GetcuReone.FactFactory.Helpers;
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
    public class WantAction : IWantAction
    {
        private readonly Action<IFactContainer> _action;

        /// <summary>
        /// Facts required to launch an action
        /// </summary>
        public IEnumerable<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Start date for fact deriving for action
        /// </summary>
        public DateTime DateOfDerive { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wantAction">action taken after deriving a fact</param>
        /// <param name="factTypes">facts required to launch an action</param>
        public WantAction(Action<IFactContainer> wantAction, IList<IFactType> factTypes)
        {
            _action = wantAction ?? throw new ArgumentNullException(nameof(wantAction));

            if (factTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");

            InputFactTypes = new ReadOnlyCollection<IFactType>(factTypes);
        }

        /// <summary>
        /// Run action
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/></typeparam>
        /// <param name="container"></param>
        public void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer
        {
            _action(container);
        }

        /// <summary>
        /// String representation of an object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())})";
        }
    }
}
