<a name='assembly'></a>
# GetcuReone.FactFactory.Priority.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [PrioritySingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade')
  - [CalculateFact(node,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CalculateFactAsync(node,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CalculateFactAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareFactRules(firstRule,secondRule,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CompareFactRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareFacts(firstFact,secondFact)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')

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

<a name='T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade'></a>
## PrioritySingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory. Sharpened for work with [IPriorityFact](#T-GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact 'GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact').

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFact(node,context) `method`

##### Summary

Calculates the fact and adds the priority fact to the parameters.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node containing information about the calculation rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFactAsync(node,context) `method`

##### Summary

Calculates the fact asynchronously and adds the priority fact to the parameters.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node containing information about the calculation rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompareFactRules(firstRule,secondRule,context) `method`

##### Summary

Compares rules by priority and base attribute
([CompareFactRules](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFactRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')).

##### Returns

1 - `firstRule` rule is greater than the `secondRule`,
0 - `firstRule` rule is equal than the `secondRule`,
-1 - `firstRule` rule is less than the `secondRule`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | First rule. |
| secondRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Secon role. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareFacts(firstFact,secondFact) `method`

##### Summary

Compares fact by priority and base attribute ([CompareFacts](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')).

##### Returns

1 - `firstFact` fact is greater than the `secondFact`,
0 - `firstFact` fact is equal than the `secondFact`,
-1 - `firstFact` fact is less than the `secondFact`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstFact | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | First fact. |
| secondFact | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Second fact. |
