<a name='assembly'></a>
# GetcuReone.FactFactory.Priority.Common

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [PriorityFactFactoryHelper](#T-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper')
  - [AddPriorityParameter\`\`2(fact,priority)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-AddPriorityParameter``2-``0,``1- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.AddPriorityParameter``2(``0,``1)')
  - [CompareByPriority(firstRule,secondRule,context)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.CompareByPriority(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareByPriorityParameter(x,y)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.CompareByPriorityParameter(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [FindPriorityParameter\`\`1(fact)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FindPriorityParameter``1-``0- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.FindPriorityParameter``1(``0)')
  - [FirstPriorityFactByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FirstPriorityFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.FirstPriorityFactByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
- [PriorityFactParametersCodes](#T-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes')
  - [Priority](#F-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes-Priority 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes.Priority')

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

<a name='T-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper'></a>
## PriorityFactFactoryHelper `type`

##### Namespace

GetcuReone.FactFactory.Priority

##### Summary

Helper for PriorityFactFactory.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-AddPriorityParameter``2-``0,``1-'></a>
### AddPriorityParameter\`\`2(fact,priority) `method`

##### Summary

Adds a priority fact to parameters.

##### Returns

`fact`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |
| priority | [\`\`1](#T-``1 '``1') | Priority fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact |
| TPriority | Type priority fact. |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompareByPriority(firstRule,secondRule,context) `method`

##### Summary

Compares rules based on priority facts.

##### Returns

1 - `firstRule` rule is greater than the `secondRule`,
0 - `firstRule` rule is equal than the `secondRule`,
-1 - `firstRule` rule is less than the `secondRule`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | First rule. |
| secondRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Second rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareByPriorityParameter(x,y) `method`

##### Summary

Compares facts by priority facts in parameters.

##### Returns

1 - `x` fact is greater than the `y`,
0 - `x` fact is equal than the `y`,
-1 - `x` fact is less than the `y`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Fist fact. |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Second fact. |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FindPriorityParameter``1-``0-'></a>
### FindPriorityParameter\`\`1(fact) `method`

##### Summary

Find parameter by [Priority](#F-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes-Priority 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes.Priority').

##### Returns

[IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact') fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FirstPriorityFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstPriorityFactByFactType\`\`1(facts,factType,cache) `method`

##### Summary

Searches for the first occurrence of a priority fact.

##### Returns

[IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact') fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Fact list. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type of 'priority'. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='T-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes'></a>
## PriorityFactParametersCodes `type`

##### Namespace

GetcuReone.FactFactory.Priority.Constants

##### Summary

'Priority' codes for fact parameter.

<a name='F-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes-Priority'></a>
### Priority `constants`

##### Summary

Priority parameter code.
