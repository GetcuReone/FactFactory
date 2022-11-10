<a name='assembly'></a>
# GetcuReone.FactFactory.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade')
  - [DeriveWantActionAsync\`\`1()](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantActionAsync``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.DeriveWantActionAsync``1(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0}})')
  - [DeriveWantAction\`\`1()](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantAction``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.DeriveWantAction``1(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0}})')
  - [Validate\`\`1(requests)](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-Validate``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.Validate``1(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0}})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade')
  - [CalculateFact()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CalculateFactAsync()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFactAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CanExtractFact\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanExtractFact``1-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanExtractFact``1(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CanInvokeWork\`\`1(inputFacts,factWork,cache)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanInvokeWork``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},``0,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanInvokeWork``1(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},``0,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [CompareFactRules(firstRule,secondRule,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFactRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareFacts(x,y)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompatibleRule``1-``0,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompatibleRule``1(``0,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CreateWantAction(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CreateWantAction(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [DeriveWantFacts()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFacts(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo)')
  - [DeriveWantFactsAsync()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFactsAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo)')
  - [EqualsFactParameters(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFactParameters-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFactParameters(GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [EqualsFacts(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetCompatibleRules\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``1-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetCompatibleRules``1(``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFactComparer()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFactEqualityComparer()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactEqualityComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactEqualityComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactType``1 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactType``1')
  - [GetRequireFacts\`\`1(factWork,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequireFacts``1-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequireFacts``1(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRequiredTypesOfFacts\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``1-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequiredTypesOfFacts``1(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRuleComparer()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRuleComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRuleComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [NeedCalculateFact()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-NeedCalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.NeedCalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [RuntimeCondition(condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-RuntimeCondition-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.RuntimeCondition(GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [TryCalculateFactByRuntimeCondition(rule,condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeCondition-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.TryCalculateFactByRuntimeCondition(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [TryCalculateFactByRuntimeConditionAsync(rule,condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeConditionAsync-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.TryCalculateFactByRuntimeConditionAsync(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [ValidateAndGetRules\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateAndGetRules``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateAndGetRules``1(``0)')
  - [ValidateContainer()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateContainer-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateContainer(GetcuReone.FactFactory.Interfaces.IFactContainer)')
- [SingleEntityOperationsHelper](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper')
  - [GetWriter(container)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-GetWriter-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.GetWriter(GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [SetCalculateByRule\`\`1(fact)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-SetCalculateByRule``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.SetCalculateByRule``1(``0)')
- [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade')
  - [CalculateTreeAndDeriveWantFacts()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFacts(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule})')
  - [CalculateTreeAndDeriveWantFactsAsync()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFactsAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule})')
  - [CanRemoveFromNeedFactTypes(factType,node,context,copatibleAllFinishedNodes)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CanRemoveFromNeedFactTypes-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CanRemoveFromNeedFactTypes(GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext,System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule})')
  - [GetIndependentNodeGroups()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.GetIndependentNodeGroups(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule)')
  - [GetRelatedRules(rule,rules,context)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetRelatedRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.GetRelatedRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [SyncTreeLevelAndFinishedNodes(treeLevel,finishedNodes,context)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-SyncTreeLevelAndFinishedNodes-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.SyncTreeLevelAndFinishedNodes(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule},System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [TryBuildTreeForFactInfo()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreeForFactInfo-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreeForFactInfo(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest,GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)')
  - [TryBuildTreesForWantAction()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreesForWantAction-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreesForWantAction(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest,GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult@)')
  - [TryRemoveRootNode(node,treeByFactRule,level)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryRemoveRootNode-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule,System-Int32- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryRemoveRootNode(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule,System.Int32)')
  - [TrySyncTreeLevelsAndFinishedNodes(treeByFactRule,level,finishedNodes)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TrySyncTreeLevelsAndFinishedNodes-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule,System-Int32,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule,System.Int32,System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule})')
- [TreeBuildingOperationsHelper](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper')
  - [GetNodesByRules(rules,treeByFactRule,parentNode)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetNodesByRules(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule)')
  - [GetTreesByRequest(request)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetTreesByRequest-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetTreesByRequest(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest)')
  - [GetUniqueRulesFromTree(treeByFactRule)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetUniqueRulesFromTree-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetUniqueRulesFromTree(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule)')
  - [RuleContainBranch(rule,nodeFromBranch)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-RuleContainBranch-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.RuleContainBranch(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule)')

<a name='T--ArrayExtensions'></a>
## ArrayExtensions `type`

##### Namespace



<a name='M-ArrayExtensions-IsNullOrEmpty``1-``0[]-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [\`\`0[]](#T-``0[] '``0[]') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T--EnumerableExtensions'></a>
## EnumerableExtensions `type`

##### Namespace



<a name='M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade'></a>
## FactEngineFacade `type`

##### Namespace

GetcuReone.FactFactory.Facades.FactEngine

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantActionAsync``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}-'></a>
### DeriveWantActionAsync\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantAction``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}-'></a>
### DeriveWantAction\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-Validate``1-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0}}-'></a>
### Validate\`\`1(requests) `method`

##### Summary

Validates `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0}}') | Requests. |

<a name='T--ListExtensions'></a>
## ListExtensions `type`

##### Namespace



<a name='M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty.

##### Returns

`items` is empty or null?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') | Collection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type items. |

<a name='T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade'></a>
## SingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFact() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFactAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanExtractFact``1-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CanExtractFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanInvokeWork``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},``0,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### CanInvokeWork\`\`1(inputFacts,factWork,cache) `method`

##### Summary

Is it possible to start a [IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inputFacts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Input facts. |
| factWork | [\`\`0](#T-``0 '``0') |  |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompareFactRules(firstRule,secondRule,context) `method`

##### Summary

Compare [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |
| secondRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareFacts(x,y) `method`

##### Summary

Comparison of facts.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompatibleRule``1-``0,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompatibleRule\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-'></a>
### DeriveWantFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-'></a>
### DeriveWantFactsAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFactParameters-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### EqualsFactParameters(first,second,context) `method`

##### Summary

Checking the equality of fact parameters.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### EqualsFacts(first,second,context) `method`

##### Summary

Checking the equality of facts.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``1-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetCompatibleRules\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetFactComparer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactEqualityComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetFactEqualityComparer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequireFacts``1-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRequireFacts\`\`1(factWork,context) `method`

##### Summary

Get the facts needed to enter the work.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [\`\`0](#T-``0 '``0') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``1-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRequiredTypesOfFacts\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRuleComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRuleComparer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-NeedCalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### NeedCalculateFact() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-RuntimeCondition-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### RuntimeCondition(condition,context) `method`

##### Summary

Checks for a `condition`

##### Returns

Result [Condition\`\`1](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition``1-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.Condition``1(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeCondition-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### TryCalculateFactByRuntimeCondition(rule,condition,context) `method`

##### Summary

Try to calculate a fact based on a `condition`.

##### Returns

True - The `condition` was not fulfilled and the fact had to be recalculated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Rule for which the condition is checked. |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeConditionAsync-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### TryCalculateFactByRuntimeConditionAsync(rule,condition,context) `method`

##### Summary

Try to calculate a fact based on a `condition`.

##### Returns

True - The `condition` was not fulfilled and the fact had to be recalculated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Rule for which the condition is checked. |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateAndGetRules``1-``0-'></a>
### ValidateAndGetRules\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateContainer-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### ValidateContainer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper'></a>
## SingleEntityOperationsHelper `type`

##### Namespace

GetcuReone.FactFactory.Facades.SingleEntityOperations

##### Summary

Helper.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-GetWriter-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### GetWriter(container) `method`

##### Summary

Get [FactContainerWriter](#T-GetcuReone-FactFactory-BaseEntities-FactContainerWriter 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter') writer.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-SetCalculateByRule``1-``0-'></a>
### SetCalculateByRule\`\`1(fact) `method`

##### Summary

Set a parameter indicating that the fact was calculated using the rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade'></a>
## TreeBuildingOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Facades.TreeBuildingOperations

##### Summary

Tree building operations.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}-'></a>
### CalculateTreeAndDeriveWantFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}-'></a>
### CalculateTreeAndDeriveWantFactsAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CanRemoveFromNeedFactTypes-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}-'></a>
### CanRemoveFromNeedFactTypes(factType,node,context,copatibleAllFinishedNodes) `method`

##### Summary

Determines you can no longer consider the `factType` necessary.

##### Returns

True - may not be considered necessary

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type info. |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext') |  |
| copatibleAllFinishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}') |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-'></a>
### GetIndependentNodeGroups() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetRelatedRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRelatedRules(rule,rules,context) `method`

##### Summary

Return related facts.

##### Returns

Related fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Fact rule. |
| rules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') | Fact rules. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-SyncTreeLevelAndFinishedNodes-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### SyncTreeLevelAndFinishedNodes(treeLevel,finishedNodes,context) `method`

##### Summary

Synchronize the tree level with years ready for calculation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeLevel | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}') | Tree level. |
| finishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}') | Nodes by which the rule can already be calculated. Key - node info, value - node |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreeForFactInfo-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@-'></a>
### TryBuildTreeForFactInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreesForWantAction-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult@-'></a>
### TryBuildTreesForWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryRemoveRootNode-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule,System-Int32-'></a>
### TryRemoveRootNode(node,treeByFactRule,level) `method`

##### Summary

Delete current node.

##### Returns

True - remove root node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node to be removed. |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') | Rule tree. |
| level | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Level in tree. |

##### Remarks

Recursively delete parent nodes
if they do not have other nodes calculating the fact from the child node.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TrySyncTreeLevelsAndFinishedNodes-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule,System-Int32,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}-'></a>
### TrySyncTreeLevelsAndFinishedNodes(treeByFactRule,level,finishedNodes) `method`

##### Summary

Synchronize tree levels with years ready for calculation.

##### Returns

True - managed to sync root level

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') | Tree whose levels you want to synchronize. |
| level | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level at which to start synchronization. |
| finishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule}') |  |

<a name='T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper'></a>
## TreeBuildingOperationsHelper `type`

##### Namespace

GetcuReone.FactFactory.Facades.TreeBuildingOperations

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-'></a>
### GetNodesByRules(rules,treeByFactRule,parentNode) `method`

##### Summary

Returns nodes by rules.

##### Returns

Node list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}') | List of rule. |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Rule tree. |
| parentNode | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') | Parent node. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetTreesByRequest-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest-'></a>
### GetTreesByRequest(request) `method`

##### Summary

Get [TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') by `request`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest') |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetUniqueRulesFromTree-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-'></a>
### GetUniqueRulesFromTree(treeByFactRule) `method`

##### Summary

Get unique rules from tree.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-RuleContainBranch-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-'></a>
### RuleContainBranch(rule,nodeFromBranch) `method`

##### Summary

Whether the `rule` is contained in a branch with `nodeFromBranch`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |
| nodeFromBranch | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') |  |
