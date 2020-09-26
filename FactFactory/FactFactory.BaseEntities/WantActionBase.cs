using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for <see cref="IWantAction"/>.
    /// </summary>
    public abstract class WantActionBase : FactWorkBase, IWantAction
    {
        private readonly Action<IEnumerable<IFact>> _action2;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected WantActionBase(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes)
            : base(factTypes, FactWorkOption.CanExecuteSync)
        {
            _action2 = wantAction ?? throw new ArgumentNullException(nameof(wantAction));

            if (InputFactTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");
        }

        /// <summary>
        /// String representation of an object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())})";
        }

        /// <inheritdoc/>
        public virtual void Invoke(IEnumerable<IFact> requireFacts)
        {
            _action2(requireFacts);
        }
    }
}
