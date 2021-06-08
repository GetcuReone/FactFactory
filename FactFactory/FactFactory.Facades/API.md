<a name='assembly'></a>
# GetcuReone.FactFactory.Facades

## Contents

- [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade')
  - [CalculateFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CalculateFactAsync\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CalculateFactAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanExtractFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanExtractFact``3(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanInvokeWork\`\`1(inputFacts,factWork,cache)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CanInvokeWork``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},``0,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CanInvokeWork``1(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},``0,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [CompareFactRules\`\`3(x,y,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFactRules``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFacts(x,y)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule\`\`4()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompatibleRule``4(``0,``1,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [DeriveWantFacts\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFacts``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [DeriveWantFactsAsync\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFactsAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.DeriveWantFactsAsync``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [EqualsFactParameters\`\`2(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFactParameters``2-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFactParameters``2(GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [EqualsFacts\`\`2(first,second,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-EqualsFacts``2-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.EqualsFacts``2(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetCompatibleRules\`\`4()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``4-``0,System-Collections-Generic-IEnumerable{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetCompatibleRules``4(``0,System.Collections.Generic.IEnumerable{``1},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [GetFactComparer\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetFactEqualityComparer\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetFactEqualityComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetFactEqualityComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetRequiredTypesOfFacts\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequiredTypesOfFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRequireFacts\`\`3(factWork,context)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequireFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRequireFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRuleComparer\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRuleComparer``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.GetRuleComparer``3(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [NeedCalculateFact\`\`3()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-NeedCalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.NeedCalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [ValidateAndGetRules\`\`2()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateAndGetRules``2-``1- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateAndGetRules``2(``1)')
  - [ValidateContainer\`\`1()](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-ValidateContainer``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.ValidateContainer``1(``0)')
- [SingleEntityOperationsHelper](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper')
  - [GetWriter\`\`1(container)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-GetWriter``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.GetWriter``1(``0)')
  - [SetCalculateByRule\`\`1(fact)](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsHelper-SetCalculateByRule``1-``0- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsHelper.SetCalculateByRule``1(``0)')
- [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade')
  - [CalculateTreeAndDeriveWantFacts\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFacts``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [CalculateTreeAndDeriveWantFactsAsync\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.CalculateTreeAndDeriveWantFactsAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [GetIndependentNodeGroups\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.GetIndependentNodeGroups``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [SyncTreeLevelAndFinishedNodes\`\`3(treeLevel,finishedNodes,context)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-SyncTreeLevelAndFinishedNodes``3-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.SyncTreeLevelAndFinishedNodes``3(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}},System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [TryBuildTreeForFactInfo\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreeForFactInfo``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)')
  - [TryBuildTrees\`\`4()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTrees``4-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult{``0,``2,``3}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTrees``4(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult{``0,``2,``3}@)')
  - [TryBuildTreesForWantAction\`\`3()](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTreesForWantAction``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryBuildTreesForWantAction``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult{``0,``1,``2}@)')
  - [TryRemoveRootNode\`\`3(node,treeByFactRule,level)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryRemoveRootNode``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TryRemoveRootNode``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2},System.Int32)')
  - [TrySyncTreeLevelsAndFinishedNodes\`\`3(treeByFactRule,level,finishedNodes)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TrySyncTreeLevelsAndFinishedNodes``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2},System-Int32,System-Collections-Generic-Dictionary{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade.TrySyncTreeLevelsAndFinishedNodes``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2},System.Int32,System.Collections.Generic.Dictionary{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}})')
- [TreeBuildingOperationsHelper](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper')
  - [GetNodesByRules\`\`3(rules,treeByFactRule,parentNode)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules``3-System-Collections-Generic-List{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetNodesByRules``3(System.Collections.Generic.List{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [GetTreesByRequest\`\`3(request)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetTreesByRequest``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetTreesByRequest``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2})')
  - [GetUniqueRulesFromTree\`\`3(treeByFactRule)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetUniqueRulesFromTree``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.GetUniqueRulesFromTree``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [RuleContainBranch\`\`1(rule,nodeFromBranch)](#M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-RuleContainBranch``1-``0,GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0}- 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsHelper.RuleContainBranch``1(``0,GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0})')

<a name='T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade'></a>
## SingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFact\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFactAsync\`\`3() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}-'></a>
### DeriveWantFacts\`\`2() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetCompatibleRules``4-``0,System-Collections-Generic-IEnumerable{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
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

<a name='M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequiredTypesOfFacts\`\`3() `method`

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

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFacts\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFactsAsync\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetIndependentNodeGroups\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

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

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade-TryBuildTrees``4-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult{``0,``2,``3}@-'></a>
### TryBuildTrees\`\`4() `method`

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

Delete current node. Recursively delete parent nodes if they do not have other nodes calculating the fact from the child node.

##### Returns

True - remove root node.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') |  |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') |  |
| level | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

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
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

<a name='T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper'></a>
## TreeBuildingOperationsHelper `type`

##### Namespace

GetcuReone.FactFactory.Facades.TreeBuildingOperations

<a name='M-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsHelper-GetNodesByRules``3-System-Collections-Generic-List{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetNodesByRules\`\`3(rules,treeByFactRule,parentNode) `method`

##### Summary

Returns nodes by rules.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') |  |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') |  |
| parentNode | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

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
