<a name='assembly'></a>
# GetcuReone.FactFactory.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade')
  - [DeriveWantActionAsync\`\`4()](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantActionAsync``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.DeriveWantActionAsync``4(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}})')
  - [DeriveWantAction\`\`4()](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantAction``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.DeriveWantAction``4(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}})')
  - [Validate\`\`4(requests)](#M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-Validate``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}- 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade.Validate``4(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade')
  - [CalculateFactAsync\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFactAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CalculateFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanExtractFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanExtractFact``3(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanInvokeWork\`\`1(inputFacts,factWork,cache)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanInvokeWork``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},``0,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanInvokeWork``1(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},``0,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [CompareFactRules\`\`3(x,y,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFactRules``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFacts(x,y)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule\`\`4()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompatibleRule``4(``0,``1,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [CreateWantAction\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction``1-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CreateWantAction``1(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction``1-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CreateWantAction``1(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [DeriveWantFactsAsync\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFactsAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFactsAsync``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [DeriveWantFacts\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFacts``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [EqualsFactParameters\`\`2(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFactParameters``2-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFactParameters``2(GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [EqualsFacts\`\`2(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFacts``2-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFacts``2(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetCompatibleRules\`\`4()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``4-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetCompatibleRules``4(``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [GetFactComparer\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetFactEqualityComparer\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactEqualityComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactEqualityComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactType``1 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactType``1')
  - [GetRequireFacts\`\`3(factWork,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequireFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequireFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRequiredTypesOfFacts\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequiredTypesOfFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRuleComparer\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRuleComparer``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRuleComparer``3(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [NeedCalculateFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-NeedCalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.NeedCalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [RuntimeCondition\`\`2(condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-RuntimeCondition``2-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.RuntimeCondition``2(GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [TryCalculateFactByRuntimeConditionAsync\`\`3(rule,condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeConditionAsync``3-``0,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.TryCalculateFactByRuntimeConditionAsync``3(``0,GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [TryCalculateFactByRuntimeCondition\`\`3(rule,condition,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeCondition``3-``0,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.TryCalculateFactByRuntimeCondition``3(``0,GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [ValidateAndGetRules\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateAndGetRules``2-``1- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateAndGetRules``2(``1)')
  - [ValidateContainer\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateContainer``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateContainer``1(``0)')
- [SingleEntityOperationsHelper](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper')
  - [GetWriter\`\`1(container)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-GetWriter``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.GetWriter``1(``0)')
  - [SetCalculateByRule\`\`1(fact)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-SetCalculateByRule``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.SetCalculateByRule``1(``0)')
- [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade')
  - [CalculateTreeAndDeriveWantFactsAsync\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFactsAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [CalculateTreeAndDeriveWantFacts\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFacts``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [CanRemoveFromNeedFactTypes\`\`3(factType,node,context,copatibleAllFinishedNodes)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CanRemoveFromNeedFactTypes``3-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``0,``1,``2},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CanRemoveFromNeedFactTypes``3(GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``0,``1,``2},System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}})')
  - [GetIndependentNodeGroups\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.GetIndependentNodeGroups``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [GetRelatedRules\`\`3(rule,rules,context)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetRelatedRules``3-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.GetRelatedRules``3(``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [SyncTreeLevelAndFinishedNodes\`\`3(treeLevel,finishedNodes,context)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-SyncTreeLevelAndFinishedNodes``3-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.SyncTreeLevelAndFinishedNodes``3(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}},System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [TryBuildTreeForFactInfo\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreeForFactInfo``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)')
  - [TryBuildTreesForWantAction\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreesForWantAction``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreesForWantAction``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult{``0,``1,``2}@)')
  - [TryRemoveRootNode\`\`3(node,treeByFactRule,level)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryRemoveRootNode``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryRemoveRootNode``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2},System.Int32)')
  - [TrySyncTreeLevelsAndFinishedNodes\`\`3(treeByFactRule,level,finishedNodes)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TrySyncTreeLevelsAndFinishedNodes``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2},System.Int32,System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}})')
- [TreeBuildingOperationsHelper](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper')
  - [GetNodesByRules\`\`3(rules,treeByFactRule,parentNode)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules``3-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetNodesByRules``3(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [GetTreesByRequest\`\`3(request)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetTreesByRequest``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetTreesByRequest``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2})')
  - [GetUniqueRulesFromTree\`\`3(treeByFactRule)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetUniqueRulesFromTree``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetUniqueRulesFromTree``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [RuleContainBranch\`\`1(rule,nodeFromBranch)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-RuleContainBranch``1-``0,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.RuleContainBranch``1(``0,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0})')

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

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantActionAsync``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}-'></a>
### DeriveWantActionAsync\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-DeriveWantAction``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}-'></a>
### DeriveWantAction\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade-Validate``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}-'></a>
### Validate\`\`4(requests) `method`

##### Summary

Validates `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{\`\`0,\`\`1,\`\`2,\`\`3}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}}') | Requests. |

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFactAsync\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFact\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CanExtractFact\`\`3() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CompareFactRules\`\`3(x,y,context) `method`

##### Summary

Compare [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [\`\`0](#T-``0 '``0') |  |
| y | [\`\`0](#T-``0 '``0') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') |  |

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### CompatibleRule\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction``1-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CreateWantAction``1-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFactsAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}-'></a>
### DeriveWantFactsAsync\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}-'></a>
### DeriveWantFacts\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFactParameters``2-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### EqualsFactParameters\`\`2(first,second,context) `method`

##### Summary

Checking the equality of fact parameters.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`0,\`\`1}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFacts``2-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### EqualsFacts\`\`2(first,second,context) `method`

##### Summary

Checking the equality of facts.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`0,\`\`1}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``4-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### GetCompatibleRules\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### GetFactComparer\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactEqualityComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### GetFactEqualityComparer\`\`2() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequireFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequireFacts\`\`3(factWork,context) `method`

##### Summary

Get the facts needed to enter the work.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [\`\`0](#T-``0 '``0') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork |  |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequiredTypesOfFacts\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRuleComparer``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRuleComparer\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-NeedCalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### NeedCalculateFact\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-RuntimeCondition``2-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### RuntimeCondition\`\`2(condition,context) `method`

##### Summary

Checks for a `condition`

##### Returns

Result [Condition\`\`4](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`0,\`\`1}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeConditionAsync``3-``0,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### TryCalculateFactByRuntimeConditionAsync\`\`3(rule,condition,context) `method`

##### Summary

Try to calculate a fact based on a `condition`.

##### Returns

True - The `condition` was not fulfilled and the fact had to be recalculated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [\`\`0](#T-``0 '``0') | Rule for which the condition is checked. |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-TryCalculateFactByRuntimeCondition``3-``0,GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### TryCalculateFactByRuntimeCondition\`\`3(rule,condition,context) `method`

##### Summary

Try to calculate a fact based on a `condition`.

##### Returns

True - The `condition` was not fulfilled and the fact had to be recalculated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [\`\`0](#T-``0 '``0') | Rule for which the condition is checked. |
| condition | [GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact') | Condition. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateAndGetRules``2-``1-'></a>
### ValidateAndGetRules\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateContainer``1-``0-'></a>
### ValidateContainer\`\`1() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-GetWriter``1-``0-'></a>
### GetWriter\`\`1(container) `method`

##### Summary

Get [FactContainerWriter\`1](#T-GetcuReone-FactFactory-BaseEntities-FactContainerWriter`1 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter`1') writer.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactContainer |  |

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

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFactsAsync\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFacts\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CanRemoveFromNeedFactTypes``3-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``0,``1,``2},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}}-'></a>
### CanRemoveFromNeedFactTypes\`\`3(factType,node,context,copatibleAllFinishedNodes) `method`

##### Summary

Determines you can no longer consider the `factType` necessary.

##### Returns

True - may not be considered necessary

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type info. |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``0,``1,``2}') |  |
| copatibleAllFinishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{\`\`0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FactRole type. |
| TWantAction | WantAction type. |
| TFactContainer | FactContainer type. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetIndependentNodeGroups\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetRelatedRules``3-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRelatedRules\`\`3(rule,rules,context) `method`

##### Summary

Return related facts.

##### Returns

Related fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [\`\`0](#T-``0 '``0') | Fact rule. |
| rules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0} 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}') | Fact rules. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-SyncTreeLevelAndFinishedNodes``3-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### SyncTreeLevelAndFinishedNodes\`\`3(treeLevel,finishedNodes,context) `method`

##### Summary

Synchronize the tree level with years ready for calculation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeLevel | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}}') | Tree level. |
| finishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{\`\`0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}}') | Nodes by which the rule can already be calculated. Key - node info, value - node |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@-'></a>
### TryBuildTreeForFactInfo\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreesForWantAction``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@-'></a>
### TryBuildTreesForWantAction\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryRemoveRootNode``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32-'></a>
### TryRemoveRootNode\`\`3(node,treeByFactRule,level) `method`

##### Summary

Delete current node.

##### Returns

True - remove root node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node to be removed. |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') | Rule tree. |
| level | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Level in tree. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FatcRule type. |
| TWantAction | WantAction type. |
| TFactContainer | FactContainer type. |

##### Remarks

Recursively delete parent nodes
if they do not have other nodes calculating the fact from the child node.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TrySyncTreeLevelsAndFinishedNodes``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}}-'></a>
### TrySyncTreeLevelsAndFinishedNodes\`\`3(treeByFactRule,level,finishedNodes) `method`

##### Summary

Synchronize tree levels with years ready for calculation.

##### Returns

True - managed to sync root level

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') | Tree whose levels you want to synchronize. |
| level | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level at which to start synchronization. |
| finishedNodes | [System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{\`\`0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FatcRule type. |
| TWantAction | WantAction type. |
| TFactContainer | FactContainer type. |

<a name='T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper'></a>
## TreeBuildingOperationsHelper `type`

##### Namespace

GetcuReone.FactFactory.Facades.TreeBuildingOperations

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules``3-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetNodesByRules\`\`3(rules,treeByFactRule,parentNode) `method`

##### Summary

Returns nodes by rules.

##### Returns

Node list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | List of rule. |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Rule tree. |
| parentNode | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') | Parent node. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FatcRule type. |
| TWantAction | WantAction type. |
| TFactContainer | FactContainer type. |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetTreesByRequest``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2}-'></a>
### GetTreesByRequest\`\`3(request) `method`

##### Summary

Get [TreeByFactRule\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3') by `request`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetUniqueRulesFromTree``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetUniqueRulesFromTree\`\`3(treeByFactRule) `method`

##### Summary

Get unique rules from tree.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-RuleContainBranch``1-``0,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}-'></a>
### RuleContainBranch\`\`1(rule,nodeFromBranch) `method`

##### Summary

Whether the `rule` is contained in a branch with `nodeFromBranch`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [\`\`0](#T-``0 '``0') |  |
| nodeFromBranch | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
