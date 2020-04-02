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
    public abstract class WantActionBase<TFactBase> : IWantAction<TFactBase>
        where TFactBase : IFact
    {
        private readonly Action<IFactContainer<TFactBase>> _action;

        /// <summary>
        /// Facts required to launch an action.
        /// </summary>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        protected WantActionBase(Action<IFactContainer<TFactBase>> wantAction, IReadOnlyCollection<IFactType> factTypes)
        {
            _action = wantAction ?? throw new ArgumentNullException(nameof(wantAction));

            if (factTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");

            factTypes.CheckArgumentFacts<TFactBase>();

            foreach (IFactType type in factTypes)
                type.CheckSpecialFactType();

            InputFactTypes = factTypes;
        }

        /// <summary>
        /// Run action.
        /// </summary>
        /// <typeparam name="TFactContainer">container with <see cref="InputFactTypes"/>.</typeparam>
        /// <param name="container"></param>
        public virtual void Invoke<TFactContainer>(TFactContainer container) where TFactContainer : IFactContainer<TFactBase>
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
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool IsMorePriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual bool IsLessPriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <summary>
        /// Get the necessary fact types.
        /// </summary>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual List<IFactType> GetNecessaryFactTypes<TFactContainer>(TFactContainer container)
            where TFactContainer : IFactContainer<TFactBase>
        {
            List<IFactType> result = InputFactTypes.ToList();

            foreach (var fact in container)
            {
                IFactType type = fact.GetFactType();
                IFactType notNeedFact = InputFactTypes.FirstOrDefault(t => t.Compare(type));

                if (notNeedFact != null)
                    result.Remove(notNeedFact);
            }

            return result;
        }
    }
}
