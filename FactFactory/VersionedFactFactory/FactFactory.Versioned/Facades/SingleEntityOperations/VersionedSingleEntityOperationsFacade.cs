using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class VersionedSingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactRules(IFactRule first, IFactRule second, IWantActionContext context)
        {
            int resultByVersion = CompareRulesByVersion(first, second, context);
            if (resultByVersion != 0)
                return resultByVersion;

            return base.CompareFactRules(first, second, context);
        }

        /// <summary>
        /// Compare rules by version.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual int CompareRulesByVersion(IFactRule x, IFactRule y, IWantActionContext context)
        {
            var xVersionType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = context.Container.GetVersionFact(xVersionType);
            IVersionFact yVersion = context.Container.GetVersionFact(yVersionType);

            return xVersion.CompareTo(yVersion);
        }
    }
}
