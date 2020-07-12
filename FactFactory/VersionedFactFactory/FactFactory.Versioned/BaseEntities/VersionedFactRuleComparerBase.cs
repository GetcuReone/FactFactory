using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <inheritdoc/>
    public abstract class VersionedFactRuleComparerBase<TFactBase, TFactRule, TWantAction, TFactContainer> : FactRuleComparerBase<TFactBase, TFactRule, TWantAction, TFactContainer>
        where TFactBase : IVersionedFact
        where TFactRule : IFactRule<TFactBase>
        where TWantAction : IWantAction<TFactBase>
        where TFactContainer : IFactContainer<TFactBase>
    {
        /// <inheritdoc/>
        protected VersionedFactRuleComparerBase(TWantAction wantAction, TFactContainer container) : base(wantAction, container)
        {
        }

        /// <summary>
        /// Equal rules with different versions.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual bool EqualRulesWithDifferentVersions(TFactRule x, TFactRule y)
        {
            if (!x.OutputFactType.EqualsFactType(y.OutputFactType))
                return false;

            var xInput = x.InputFactTypes
                ?.Where(factType => !factType.IsFactType<IVersionFact>()).ToList()
                ?? new List<IFactType>(0);
            var yInput = y.InputFactTypes
                ?.Where(factType => !factType.IsFactType<IVersionFact>()).ToList()
                ?? new List<IFactType>(0);

            if (xInput.Count != yInput.Count)
                return false;

            foreach(IFactType factType in xInput)
            {
                var foundFactType = yInput.FirstOrDefault(yType => factType.EqualsFactType(yType));

                if (foundFactType == null)
                    return false;

                yInput.Remove(foundFactType);
            }

            if (yInput.Count != 0)
                return false;

            return true;
        }

        /// <summary>
        /// Compare by version.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual int CompareByVersion(TFactRule x, TFactRule y)
        {

            var xVersionType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = Container.GetVersionFact(xVersionType);
            IVersionFact yVersion = Container.GetVersionFact(yVersionType);

            return xVersion.CompareTo(yVersion);
        }

        /// <inheritdoc/>
        public override int Compare(TFactRule x, TFactRule y)
        {
            int resultByVersion = CompareByVersion(x, y);

            return resultByVersion == 0 
                ? base.Compare(x, y) 
                : resultByVersion;
        }
    }
}
