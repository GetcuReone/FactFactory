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
        public virtual IComparer<TFactWork> GetComparer<TFactWork, TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            return Comparer<TFactWork>.Create(
                (x, y) => CompareFactWorks(x, y, wantAction, container));
        }

        /// <summary>
        /// Compare <typeparamref name="TFactWork"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="container">Container within which the sorting will take place.</param>
        /// <param name="wantAction">Action within which the sorting will take place.</param>
        /// <returns></returns>
        public virtual int CompareFactWorks<TFactWork, TWantAction, TFactContainer>(TFactWork first, TFactWork second, TWantAction wantAction, TFactContainer container)
            where TFactWork : IFactWork
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
        {
            if ((first is IWantAction) || (second is IWantAction))
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
        public virtual TFactContainer ValidateAndGetContainer<TFactContainer>(TFactContainer container) 
            where TFactContainer : IFactContainer
        {
            if (container == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Container cannot be null.");

            IFactContainer containerCopy = container.Copy();
            if (containerCopy == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method return null.");
            if (container.Equals(containerCopy))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method return original container.");
            if (!(containerCopy is TFactContainer container1))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactContainer.Copy method returned a different type of container.");
            if (container1.Any(fact => fact is IConditionFact))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, $"Container contains {nameof(IConditionFact)} facts.");

            container1.IsReadOnly = true;
            return container1;
        }

        /// <inheritdoc/>
        public TFactRuleCollection ValidateAndGetRules<TFactRule, TFactRuleCollection>(TFactRuleCollection ruleCollection)
            where TFactRule : IFactRule
            where TFactRuleCollection : IFactRuleCollection<TFactRule>
        {
            // Get a copy of the rules
            if (ruleCollection == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "Rules cannot be null.");

            IFactRuleCollection<TFactRule> rulesCopy = ruleCollection.Copy();
            if (rulesCopy == null)
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return null.");
            if (rulesCopy.Equals(ruleCollection))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method return original rule collection.");
            if (!(rulesCopy is TFactRuleCollection rules))
                throw CommonHelper.CreateDeriveException(ErrorCode.InvalidData, "IFactRuleCollection.Copy method returned a different type of rules.");

            rules.IsReadOnly = true;
            return rules;
        }
    }
}
