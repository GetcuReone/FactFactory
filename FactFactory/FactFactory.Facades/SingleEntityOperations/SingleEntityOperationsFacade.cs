using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.Generic;
using System.Linq;
using CommonHelper = GetcuReone.FactFactory.FactFactoryCommonHelper;

namespace GetcuReone.FactFactory.Facades.SingleEntityOperations
{
    /// <summary>
    /// Single operations on entities of the FactFactory.
    /// </summary>
    public class SingleEntityOperationsFacade : FacadeBase, ISingleEntityOperations
    {
        /// <inheritdoc/>
        public virtual IComparer<TFactWork> GetComparer<TFactBase, TFactWork, TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return Comparer<TFactWork>.Create(
                (x, y) => CompareFactWorks<TFactBase, TFactWork, TWantAction, TFactContainer>(x, y, wantAction, container));
        }

        /// <summary>
        /// Compare <typeparamref name="TFactWork"/>.
        /// </summary>
        /// <typeparam name="TFactBase"></typeparam>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="container">Container within which the sorting will take place.</param>
        /// <param name="wantAction">Action within which the sorting will take place.</param>
        /// <returns></returns>
        public virtual int CompareFactWorks<TFactBase, TFactWork, TWantAction, TFactContainer>(TFactWork first, TFactWork second, TWantAction wantAction, TFactContainer container)
            where TFactBase : IFact
            where TFactWork : IFactWork<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            if ((first is IWantAction<TFactBase>) || (second is IWantAction<TFactBase>))
                return 0;

            if (first.InputFactTypes.IsNullOrEmpty())
            {
                if (second.InputFactTypes.IsNullOrEmpty())
                    return 0;

                return second.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? -1
                    : 1;
            }

            if (second.InputFactTypes.IsNullOrEmpty())
            {
                return first.InputFactTypes.Any(factType => factType.IsFactType<ISpecialFact>())
                    ? 1
                    : -1;
            }

            int xCountCondition = first.InputFactTypes.Count(factType => factType.IsFactType<IConditionFact>());
            int yCountCondition = second.InputFactTypes.Count(factType => factType.IsFactType<IConditionFact>());

            if (xCountCondition != yCountCondition)
            {
                return xCountCondition > yCountCondition
                    ? 1
                    : -1;
            }

            int xCountSpecial = first.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());
            int yCountSpecial = second.InputFactTypes.Count(factType => factType.IsFactType<ISpecialFact>());

            if (xCountSpecial != yCountSpecial)
            {
                return xCountSpecial > yCountSpecial
                    ? 1
                    : -1;
            }

            if (first.InputFactTypes.Count > second.InputFactTypes.Count)
                return -1;
            if (first.InputFactTypes.Count < second.InputFactTypes.Count)
                return 1;
            return 0;
        }

        /// <inheritdoc/>
        public virtual TFactContainer ValidateAndGetContainer<TFactBase, TFactContainer>(TFactContainer container)
            where TFactBase : IFact
            where TFactContainer : IFactContainer<TFactBase>
        {
            if (container == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "Container cannot be null.");

            IFactContainer<TFactBase> containerCopy = container.Copy();
            if (containerCopy == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (container.Equals(containerCopy))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer container1))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");
            if (container1.Any(fact => fact is IConditionFact))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, $"Container contains {nameof(IConditionFact)} facts.");

            container1.IsReadOnly = true;
            return container1;
        }

        /// <inheritdoc/>
        public TFactRuleCollection ValidateAndGetRules<TFactBase, TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactBase : IFact
            where TFactRule : IFactRule<TFactBase>
            where TFactRuleCollection : IFactRuleCollection<TFactBase, TFactRule>
        {
            // Get a copy of the rules
            if (ruleCollection == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "Rules cannot be null.");

            IFactRuleCollection<TFactBase, TFactRule> rulesCopy = ruleCollection.Copy();
            if (rulesCopy == null)
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return null.");
            if (rulesCopy.Equals(ruleCollection))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return original rule collection.");
            if (!(rulesCopy is TFactRuleCollection rules))
                throw CommonHelper.CreateDeriveException<TFactBase>(ErrorCode.InvalidData, "IFactRuleCollection.Copy method returned a different type of rules.");

            rules.IsReadOnly = true;
            return rules;
        }
    }
}
