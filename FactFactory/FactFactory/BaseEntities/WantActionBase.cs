using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for <see cref="IWantAction{TFact}"/>.
    /// </summary>
    public abstract class WantActionBase<TFact> : IWantAction<TFact>
        where TFact : IFact
    {
        private readonly Action<IFactContainer<TFact>> _action;

        /// <summary>
        /// Facts required to launch an action.
        /// </summary>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected WantActionBase(Action<IFactContainer<TFact>> wantAction, IList<IFactType> factTypes)
        {
            _action = wantAction ?? throw new ArgumentNullException(nameof(wantAction));

            if (factTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");

            factTypes.CheckArgumentFacts<TFact>();

            foreach (IFactType type in factTypes)
                type.CheckSpecialFactType();

            InputFactTypes = new ReadOnlyCollection<IFactType>(factTypes);
        }

        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        public void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer<TFact>
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
