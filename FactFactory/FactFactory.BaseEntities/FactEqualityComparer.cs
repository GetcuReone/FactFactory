using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Class for comparing facts.
    /// </summary>
    public class FactEqualityComparer : EqualityComparer<IFact>
    {
        private readonly IFactTypeCache _cache;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cache">Fact type cache.</param>
        public FactEqualityComparer(IFactTypeCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public override bool Equals(IFact x, IFact y)
        {
            if (x == null & y == null)
                return true;

            if (x is ISpecialFact xSpecialFact && y is ISpecialFact ySpecialFact)
                return xSpecialFact.EqualsInfo(ySpecialFact);

            if (!_cache.GetFactType(x).EqualsFactType(_cache.GetFactType(y)))
                return false;

            IReadOnlyCollection<IFactParameter> xParameters = x.GetParameters();
            IReadOnlyCollection<IFactParameter> yParameters = y.GetParameters();

            if (xParameters.IsNullOrEmpty() && yParameters.IsNullOrEmpty())
                return true;
            if (xParameters.IsNullOrEmpty() || yParameters.IsNullOrEmpty())
                return false;
            if (xParameters.Count != yParameters.Count)
                return false;

            foreach (IFactParameter xParameter in xParameters)
            {
                bool found = false;

                foreach(IFactParameter yParameter in yParameters)
                {
                    if (EqualsFactParameter(xParameter, yParameter))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Fact parameter comparison method.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool EqualsFactParameter(IFactParameter x, IFactParameter y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;

            if (x.Code == null)
                return y.Code == null;
            else if (y.Code == null)
                return false;
            else if (!x.Code.Equals(y.Code, StringComparison.OrdinalIgnoreCase))
                return false;

            if (x.Value == null)
                return y.Value == null;
            else if (y.Value == null)
                return false;

            if (x.Value is ISpecialFact xSpecialFact)
                return y.Value is ISpecialFact ySpecialFact && xSpecialFact.EqualsInfo(ySpecialFact);
            else if (y.Value is ISpecialFact)
                return false;

            return x.Value.Equals(y.Value);
        }

        /// <inheritdoc/>
        public override int GetHashCode(IFact obj)
        {
            switch (obj)
            {
                case null: return 0;
                case IConditionFact _: return 3;
                case ISpecialFact _: return 2;
                case IFact _: return 1;
            }
        }
    }
}