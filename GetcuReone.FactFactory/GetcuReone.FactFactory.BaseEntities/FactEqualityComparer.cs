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
        private readonly Func<IFact, IFact, bool> _equalsFunc;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="equalsFunc"></param>
        public FactEqualityComparer(Func<IFact, IFact, bool> equalsFunc)
        {
           _equalsFunc = equalsFunc ?? throw new ArgumentNullException(nameof(equalsFunc));
        }

        /// <inheritdoc/>
        public override bool Equals(IFact x, IFact y)
        {
            return _equalsFunc(x, y);
        }

        /// <summary>
        /// Checking the equality of fact parameters.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool EqualsFactParameters(IFactParameter first, IFactParameter second)
        {
            if (first == null)
                return second == null;
            else if (second == null)
                return false;
            else if (first == second)
                return true;

            if (first.Code == null)
                return second.Code == null;
            else if (second.Code == null)
                return false;
            else if (!first.Code.Equals(second.Code, StringComparison.OrdinalIgnoreCase))
                return false;

            if (first.Value == null)
                return second.Value == null;
            else if (second.Value == null)
                return false;

            if (first.Value is ISpecialFact xSpecialFact)
                return second.Value is ISpecialFact ySpecialFact && xSpecialFact.EqualsInfo(ySpecialFact);
            else if (second.Value is ISpecialFact)
                return false;

            return first.Value.Equals(second.Value);
        }

        /// <summary>
        /// Checking the equality of facts.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="cache"></param>
        /// <param name="includeFactParams">
        /// True - parameters of facts will be compared using the <see cref="EqualsFactParameters(IFactParameter, IFactParameter)"/> method.
        /// False - Parameters of facts will be compared using the method.
        /// </param>
        /// <returns></returns>
        public static bool EqualsFacts(IFact first, IFact second, IFactTypeCache cache = null, bool includeFactParams = true)
        {
            if (first == null)
                return second == null;

            if (second == null)
                return false;

            if (first == second)
                return true;

            if (first is ISpecialFact xSpecialFact && second is ISpecialFact ySpecialFact)
                return xSpecialFact.EqualsInfo(ySpecialFact);

            IFactType firstFactType;
            IFactType secondFactType;

            if (cache != null)
            {
                firstFactType = cache.GetFactType(first);
                secondFactType = cache.GetFactType(second);
            }
            else
            {
                firstFactType = first.GetFactType();
                secondFactType = second.GetFactType();
            }

            if (!firstFactType.EqualsFactType(secondFactType))
                return false;

            if (!includeFactParams)
                return true;

            IReadOnlyCollection<IFactParameter> firstParameters = first.GetParameters();
            IReadOnlyCollection<IFactParameter> secondParameters = second.GetParameters();

            if (firstParameters.IsNullOrEmpty() && secondParameters.IsNullOrEmpty())
                return true;

            if (firstParameters.IsNullOrEmpty() || secondParameters.IsNullOrEmpty())
                return false;

            if (firstParameters.Count != secondParameters.Count)
                return false;

            foreach (IFactParameter xParameter in firstParameters)
            {
                bool found = false;

                foreach (IFactParameter yParameter in secondParameters)
                {
                    if (EqualsFactParameters(xParameter, yParameter))
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

        /// <inheritdoc/>
        public override int GetHashCode(IFact obj)
        {
            switch (obj)
            {
                case null: return 0;
                case IBuildConditionFact _: return 3;
                case ISpecialFact _: return 2;
                case IFact _: return 1;
            }
        }

        /// <summary>
        /// Returns default.
        /// </summary>
        /// <returns></returns>
        public static FactEqualityComparer GetDefault()
        {
            return new FactEqualityComparer((first, second) => EqualsFacts(first, second));
        }
    }
}