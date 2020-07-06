using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public abstract class FactWorkBase<TFactBase> : IFactWork<TFactBase>
        where TFactBase : IFact
    {
        /// <inheritdoc/>
        public IReadOnlyCollection<IFactType> InputFactTypes { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factTypes">Fact types.</param>
        protected FactWorkBase(List<IFactType> factTypes)
        {
            if (!factTypes.IsNullOrEmpty())
            {
                factTypes.CheckArgumentFacts<TFactBase>();

                factTypes.ForEach(factType =>
                {
                    factType.CheckSpecialFactType();
                });

                InputFactTypes = factTypes;
            }
            else
                InputFactTypes = new ReadOnlyCollection<IFactType>(new List<IFactType>(0));
        }

        /// <summary>
        /// Determining the equality of a set of fact types.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        protected virtual bool EqualsFactTypes(IEnumerable<IFactType> first, IEnumerable<IFactType> second)
        {
            if (first.IsNullOrEmpty() && second.IsNullOrEmpty())
                return true;
            else if (first.IsNullOrEmpty() || second.IsNullOrEmpty())
                return false;
            else if (first.Count() != second.Count())
                return false;
            else
            {
                foreach (var fact in second)
                {
                    if (first.All(f => !f.EqualsFactType(fact)))
                        return false;
                }

                return true;
            }
        }

        /// <inheritdoc/>
        public virtual bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return EqualsFactTypes(InputFactTypes, workFact?.InputFactTypes);
        }

        /// <inheritdoc/>
        public virtual bool IsMorePriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual bool IsLessPriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
            where TFactWork : IFactWork<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return false;
        }

        /// <inheritdoc/>
        public virtual bool СompatibilityWithRule<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
            where TFactRule : IFactRule<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return true;
        }
    }
}
