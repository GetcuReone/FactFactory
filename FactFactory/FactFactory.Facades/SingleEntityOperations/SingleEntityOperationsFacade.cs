using GetcuReone.ComboPatterns.Facade;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System.Collections.ObjectModel;
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
        public virtual TFactContainer ValidateAndGetCopyContainer<TFactBase, TFactContainer>(TFactContainer container)
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
