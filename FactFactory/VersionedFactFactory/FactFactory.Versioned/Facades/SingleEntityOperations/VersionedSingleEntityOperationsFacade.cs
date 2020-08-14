using GetcuReone.FactFactory.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations
{
    /// <inheritdoc/>
    public class VersionedSingleEntityOperationsFacade : SingleEntityOperationsFacade
    {
        /// <inheritdoc/>
        public override int CompareFactWorks<TFactWork, TWantAction, TFactContainer>(TFactWork first, TFactWork second, TWantAction wantAction, TFactContainer container)
        {
            if ((first is IFactRule firstRule) && (second is IFactRule secondRule))
            {
                int resultByVersion = CompareRulesByVersion<IFactRule, TWantAction, TFactContainer>(firstRule, secondRule, wantAction, container);
                if (resultByVersion != 0)
                    return resultByVersion;
            }

            return base.CompareFactWorks<TFactWork, TWantAction, TFactContainer>(first, second, wantAction, container);
        }

        /// <summary>
        /// Compare rules by version.
        /// </summary>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public virtual int CompareRulesByVersion<TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, TWantAction wantAction, TFactContainer container)
            where TFactRule : IFactRule
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            var xVersionType = x.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());
            var yVersionType = y.InputFactTypes?.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            if (xVersionType == null)
                return yVersionType == null ? 0 : 1;
            if (yVersionType == null)
                return -1;

            IVersionFact xVersion = container.GetVersionFact(xVersionType);
            IVersionFact yVersion = container.GetVersionFact(yVersionType);

            return xVersion.CompareTo(yVersion);
        }
    }
}
