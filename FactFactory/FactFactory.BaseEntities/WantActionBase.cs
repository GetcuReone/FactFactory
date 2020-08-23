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
        private readonly Action<IFactContainer> _action;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected WantActionBase(Action<IFactContainer> wantAction, List<IFactType> factTypes)
            : base(factTypes)
        {
            _action = wantAction ?? throw new ArgumentNullException(nameof(wantAction));

            if (InputFactTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");
        }

        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="IFactWork.InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        public virtual void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer
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

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer
        {
            List<IFactType> result = InputFactTypes.ToList();

            foreach (var fact in container)
            {
                IFactType type = fact.GetFactType();
                IFactType notNeedFact = InputFactTypes.FirstOrDefault(t => t.EqualsFactType(type));

                if (notNeedFact != null)
                    result.Remove(notNeedFact);
            }

            return result;
        }
    }
}
