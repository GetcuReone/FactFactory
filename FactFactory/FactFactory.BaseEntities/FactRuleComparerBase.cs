using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Comparer for <see cref="IFactRule{TFactBase}"/>.
    /// </summary>
    public abstract class FactRuleComparerBase<TFactBase, TFactRule, TWantAction, TFactContainer> : IComparer<TFactRule>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        /// <summary>
        /// WantAction.
        /// </summary>
        protected TWantAction WantAction { get; }

        /// <summary>
        /// Container.
        /// </summary>
        protected TFactContainer Container { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        protected FactRuleComparerBase(TWantAction wantAction, TFactContainer container)
        {
            WantAction = wantAction;
            Container = container;
        }

        /// <inheritdoc/>
        public virtual int Compare(TFactRule x, TFactRule y)
        {
            return CompareDefault(x, y);
        }

        /// <summary>
        /// Compare by default algorithm.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual int CompareDefault(TFactRule x, TFactRule y)
        {
            if (x.InputFactTypes.IsNullOrEmpty())
            {
                if (y.InputFactTypes.IsNullOrEmpty())
                    return 0;

                return y.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? -1
                    : 1;
            }

            if (y.InputFactTypes.IsNullOrEmpty())
            {
                return x.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? 1
                    : -1;
            }

            int xCountCondition = x.InputFactTypes.Count(factType => factType.IsFactType<IConditionFact>());
            int yCountCondition = y.InputFactTypes.Count(factType => factType.IsFactType<IConditionFact>());

            if (xCountCondition != yCountCondition)
            {
                return xCountCondition > yCountCondition
                    ? 1
                    : -1;
            }

            int xCountSpecial = x.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());
            int yCountSpecial = y.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());

            if (xCountSpecial != yCountSpecial)
            {
                return xCountSpecial > yCountSpecial
                    ? 1
                    : -1;
            }

            if (x.InputFactTypes.Count > y.InputFactTypes.Count)
                return -1;
            if (x.InputFactTypes.Count < y.InputFactTypes.Count)
                return 1;
            return 0;
        }
    }
}
