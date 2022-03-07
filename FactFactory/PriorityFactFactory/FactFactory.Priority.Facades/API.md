<a name='assembly'></a>
# GetcuReone.FactFactory.Priority.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
  - [ToReadOnlyCollection\`\`1(items)](#M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}- 'ListExtensions.ToReadOnlyCollection``1(System.Collections.Generic.IList{``0})')
- [PrioritySingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade')
  - [CalculateFact\`\`3(node,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CalculateFactAsync\`\`3(node,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CalculateFactAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFactRules\`\`3(x,y,context)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CompareFactRules``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFacts(x,y)](#M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')

<a name='T--ArrayExtensions'></a>
## ArrayExtensions `type`

##### Namespace



<a name='M-ArrayExtensions-IsNullOrEmpty``1-``0[]-'></a>
### IsNullOrEmpty\`\`1(items) `method`

##### Summary

True - `items` is null or empty

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

True - `items` is null or empty

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

True - `items` is null or empty

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

<a name='M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}-'></a>
### ToReadOnlyCollection\`\`1(items) `method`

##### Summary

Convert list to [ReadOnlyCollection\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.ObjectModel.ReadOnlyCollection`1 'System.Collections.ObjectModel.ReadOnlyCollection`1')

##### Returns

Read-only collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| items | [System.Collections.Generic.IList{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{``0}') | Coollection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TItem | Type item. |

<a name='T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade'></a>
## PrioritySingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory. Sharpened for work with [IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact').

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFact\`\`3(node,context) `method`

##### Summary

Calculates the fact and adds the priority fact to the parameters.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node containing information about the calculation rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFactAsync\`\`3(node,context) `method`

##### Summary

Calculates the fact asynchronously and adds the priority fact to the parameters.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node containing information about the calculation rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CompareFactRules\`\`3(x,y,context) `method`

##### Summary

Compares rules by priority and base attribute ([CompareFactRules\`\`3](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFactRules``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')).

##### Returns

1 - `x` rule is greater than the `y`, 0 - `x` rule is equal than the `y`, -1 - `x` rule is less than the `y`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [\`\`0](#T-``0 '``0') | First rule. |
| y | [\`\`0](#T-``0 '``0') | Secon role. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

<a name='M-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareFacts(x,y) `method`

##### Summary

Compares fact by priority and base attribute ([CompareFacts](#M-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')).

##### Returns

1 - `x` fact is greater than the `y`, 0 - `x` fact is equal than the `y`, -1 - `x` fact is less than the `y`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | First fact. |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Second fact. |
