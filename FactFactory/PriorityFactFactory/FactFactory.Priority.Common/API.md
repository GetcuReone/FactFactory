<a name='assembly'></a>
# GetcuReone.FactFactory.Priority.Common

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [ArrayOfFactPriorityExtensions](#T-GetcuReone-FactFactory-Priority-Common-Extensions-ArrayOfFactPriorityExtensions 'GetcuReone.FactFactory.Priority.Common.Extensions.ArrayOfFactPriorityExtensions')
  - [FirstPriorityFactByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-Priority-Common-Extensions-ArrayOfFactPriorityExtensions-FirstPriorityFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Priority.Common.Extensions.ArrayOfFactPriorityExtensions.FirstPriorityFactByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactPriorityExtensions](#T-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions 'GetcuReone.FactFactory.Priority.Common.Extensions.FactPriorityExtensions')
  - [AddPriorityParameter\`\`1(fact,priority,parameterCache)](#M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-AddPriorityParameter``1-``0,GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact,GetcuReone-FactFactory-Interfaces-Operations-IFactParameterCache- 'GetcuReone.FactFactory.Priority.Common.Extensions.FactPriorityExtensions.AddPriorityParameter``1(``0,GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact,GetcuReone.FactFactory.Interfaces.Operations.IFactParameterCache)')
  - [CompareByPriorityParameter(x,y)](#M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-CompareByPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.Common.Extensions.FactPriorityExtensions.CompareByPriorityParameter(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [FindPriorityParameter(fact)](#M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-FindPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.Common.Extensions.FactPriorityExtensions.FindPriorityParameter(GetcuReone.FactFactory.Interfaces.IFact)')
- [FactRulePriorityExtensions](#T-GetcuReone-FactFactory-Priority-Common-Extensions-FactRulePriorityExtensions 'GetcuReone.FactFactory.Priority.Common.Extensions.FactRulePriorityExtensions')
  - [CompareByPriority(firstRule,secondRule,context)](#M-GetcuReone-FactFactory-Priority-Common-Extensions-FactRulePriorityExtensions-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Priority.Common.Extensions.FactRulePriorityExtensions.CompareByPriority(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
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

<a name='T-GetcuReone-FactFactory-Priority-Common-Extensions-ArrayOfFactPriorityExtensions'></a>
## ArrayOfFactPriorityExtensions `type`

##### Namespace

GetcuReone.FactFactory.Priority.Common.Extensions

##### Summary

Extensions methods for array of [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')

<a name='M-GetcuReone-FactFactory-Priority-Common-Extensions-ArrayOfFactPriorityExtensions-FirstPriorityFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstPriorityFactByFactType\`\`1(facts,factType,cache) `method`

##### Summary

Searches for the first occurrence of a priority fact.

##### Returns

[IPriorityFact](#T-GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact 'GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact') fact or null.

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

<a name='T-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions'></a>
## FactPriorityExtensions `type`

##### Namespace

GetcuReone.FactFactory.Priority.Common.Extensions

##### Summary

Extensions methods for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

<a name='M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-AddPriorityParameter``1-``0,GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact,GetcuReone-FactFactory-Interfaces-Operations-IFactParameterCache-'></a>
### AddPriorityParameter\`\`1(fact,priority,parameterCache) `method`

##### Summary

Adds a priority fact to parameters.

##### Returns

`fact`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |
| priority | [GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact](#T-GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact 'GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact') | Priority fact. |
| parameterCache | [GetcuReone.FactFactory.Interfaces.Operations.IFactParameterCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactParameterCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactParameterCache') | Fact parameter cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact |

<a name='M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-CompareByPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
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

<a name='M-GetcuReone-FactFactory-Priority-Common-Extensions-FactPriorityExtensions-FindPriorityParameter-GetcuReone-FactFactory-Interfaces-IFact-'></a>
### FindPriorityParameter(fact) `method`

##### Summary

Find parameter by [Priority](#F-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes-Priority 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes.Priority').

##### Returns

[IPriorityFact](#T-GetcuReone-FactFactory-Priority-Interfaces-IPriorityFact 'GetcuReone.FactFactory.Priority.Interfaces.IPriorityFact') fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Fact. |

<a name='T-GetcuReone-FactFactory-Priority-Common-Extensions-FactRulePriorityExtensions'></a>
## FactRulePriorityExtensions `type`

##### Namespace

GetcuReone.FactFactory.Priority.Common.Extensions

##### Summary

Extensions methods for [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule')

<a name='M-GetcuReone-FactFactory-Priority-Common-Extensions-FactRulePriorityExtensions-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
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
