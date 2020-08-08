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
        public override int CompareFactWorks<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork first, TFactWork second, TWantAction wantAction, TFactContainer container)
        {
            if ((first is IFactRule<TFactBase> firstRule) && (second is IFactRule<TFactBase> secondRule))
            {
                int resultByVersion = CompareRulesByVersion<TFactBase, IFactRule<TFactBase>, TWantAction, TFactContainer>(firstRule, secondRule, wantAction, container);
                if (resultByVersion != 0)
                    return resultByVersion;
            }

            return base.CompareFactWorks<TFactBase, TFactWork, TWantAction, TFactContainer>(first, second, wantAction, container);
        }

        /// <summary>
        /// Compare rules by version.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactRule"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="wantAction"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        protected virtual int CompareRulesByVersion<TFactBase, TFactRule, TWantAction, TFactContainer>(TFactRule x, TFactRule y, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactRule : IFactRule<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
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
