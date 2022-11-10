<a name='assembly'></a>
# GetcuReone.FactFactory.Common

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ErrorCode](#T-GetcuReone-FactFactory-Constants-ErrorCode 'GetcuReone.FactFactory.Constants.ErrorCode')
  - [EmptyRuleCollection](#F-GetcuReone-FactFactory-Constants-ErrorCode-EmptyRuleCollection 'GetcuReone.FactFactory.Constants.ErrorCode.EmptyRuleCollection')
  - [FactCannotDerived](#F-GetcuReone-FactFactory-Constants-ErrorCode-FactCannotDerived 'GetcuReone.FactFactory.Constants.ErrorCode.FactCannotDerived')
  - [InvalidData](#F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidData 'GetcuReone.FactFactory.Constants.ErrorCode.InvalidData')
  - [InvalidFactType](#F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidFactType 'GetcuReone.FactFactory.Constants.ErrorCode.InvalidFactType')
  - [InvalidOperation](#F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidOperation 'GetcuReone.FactFactory.Constants.ErrorCode.InvalidOperation')
  - [RuleNotFound](#F-GetcuReone-FactFactory-Constants-ErrorCode-RuleNotFound 'GetcuReone.FactFactory.Constants.ErrorCode.RuleNotFound')
  - [RuntimeCondition](#F-GetcuReone-FactFactory-Constants-ErrorCode-RuntimeCondition 'GetcuReone.FactFactory.Constants.ErrorCode.RuntimeCondition')
- [ErrorResources](#T-GetcuReone-FactFactory-Resources-ErrorResources 'GetcuReone.FactFactory.Resources.ErrorResources')
  - [OnWantActionCannotBePerformedSynchronously(wantAction)](#M-GetcuReone-FactFactory-Resources-ErrorResources-OnWantActionCannotBePerformedSynchronously-GetcuReone-FactFactory-Interfaces-IWantAction- 'GetcuReone.FactFactory.Resources.ErrorResources.OnWantActionCannotBePerformedSynchronously(GetcuReone.FactFactory.Interfaces.IWantAction)')
- [FactFactoryHelper](#T-GetcuReone-FactFactory-FactFactoryHelper 'GetcuReone.FactFactory.FactFactoryHelper')
  - [CannotIsType\`\`1(type,paramName)](#M-GetcuReone-FactFactory-FactFactoryHelper-CannotIsType``1-GetcuReone-FactFactory-Interfaces-IFactType,System-String- 'GetcuReone.FactFactory.FactFactoryHelper.CannotIsType``1(GetcuReone.FactFactory.Interfaces.IFactType,System.String)')
  - [CompareTo(firstRule,secondRule)](#M-GetcuReone-FactFactory-FactFactoryHelper-CompareTo-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.FactFactoryHelper.CompareTo(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [CompareTo(x,y)](#M-GetcuReone-FactFactory-FactFactoryHelper-CompareTo-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.FactFactoryHelper.CompareTo(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CreateDeriveException(details)](#M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail}- 'GetcuReone.FactFactory.FactFactoryHelper.CreateDeriveException(System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail})')
  - [CreateDeriveException(code,reason)](#M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String- 'GetcuReone.FactFactory.FactFactoryHelper.CreateDeriveException(System.String,System.String)')
  - [CreateDeriveException(code,reason,requiredAction,container)](#M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.FactFactoryHelper.CreateDeriveException(System.String,System.String,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [CreateDeriveException(code,reason,requiredAction,container,requiredFacts)](#M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}- 'GetcuReone.FactFactory.FactFactoryHelper.CreateDeriveException(System.String,System.String,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer,System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail})')
  - [CreateException(code,reason)](#M-GetcuReone-FactFactory-FactFactoryHelper-CreateException-System-String,System-String- 'GetcuReone.FactFactory.FactFactoryHelper.CreateException(System.String,System.String)')
  - [FirstFactByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-FactFactoryHelper-FirstFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.FactFactoryHelper.FirstFactByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [GetFact\`\`1(facts)](#M-GetcuReone-FactFactory-FactFactoryHelper-GetFact``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.FactFactoryHelper.GetFact``1(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [IsCalculatedByRule\`\`1(fact)](#M-GetcuReone-FactFactory-FactFactoryHelper-IsCalculatedByRule``1-``0- 'GetcuReone.FactFactory.FactFactoryHelper.IsCalculatedByRule``1(``0)')
  - [WhereFactsByFactType(facts,factType,cache)](#M-GetcuReone-FactFactory-FactFactoryHelper-WhereFactsByFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.FactFactoryHelper.WhereFactsByFactType(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [WhereFactsByFactTypes(facts,factTypes,cache)](#M-GetcuReone-FactFactory-FactFactoryHelper-WhereFactsByFactTypes-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.FactFactoryHelper.WhereFactsByFactTypes(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
- [FactParametersCodes](#T-GetcuReone-FactFactory-Constants-FactParametersCodes 'GetcuReone.FactFactory.Constants.FactParametersCodes')
  - [CalculateByRule](#F-GetcuReone-FactFactory-Constants-FactParametersCodes-CalculateByRule 'GetcuReone.FactFactory.Constants.FactParametersCodes.CalculateByRule')
- [FactTypeExtensions](#T-GetcuReone-FactFactory-Extensions-FactTypeExtensions 'GetcuReone.FactFactory.Extensions.FactTypeExtensions')
  - [IsBuildOrRuntimeFact(type)](#M-GetcuReone-FactFactory-Extensions-FactTypeExtensions-IsBuildOrRuntimeFact-GetcuReone-FactFactory-Interfaces-IFactType- 'GetcuReone.FactFactory.Extensions.FactTypeExtensions.IsBuildOrRuntimeFact(GetcuReone.FactFactory.Interfaces.IFactType)')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')

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

<a name='T-GetcuReone-FactFactory-Constants-ErrorCode'></a>
## ErrorCode `type`

##### Namespace

GetcuReone.FactFactory.Constants

##### Summary

Error codes.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-EmptyRuleCollection'></a>
### EmptyRuleCollection `constants`

##### Summary

Collection of rules for calculating the fact is empty.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-FactCannotDerived'></a>
### FactCannotDerived `constants`

##### Summary

Fact cannot be derived.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidData'></a>
### InvalidData `constants`

##### Summary

Invalid data.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidFactType'></a>
### InvalidFactType `constants`

##### Summary

The fact is of the invalid type.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-InvalidOperation'></a>
### InvalidOperation `constants`

##### Summary

Invalid operation.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-RuleNotFound'></a>
### RuleNotFound `constants`

##### Summary

Rule not found.

<a name='F-GetcuReone-FactFactory-Constants-ErrorCode-RuntimeCondition'></a>
### RuntimeCondition `constants`

##### Summary

Failed to meet [Condition\`\`1](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition``1-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.Condition``1(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
and find another solution

<a name='T-GetcuReone-FactFactory-Resources-ErrorResources'></a>
## ErrorResources `type`

##### Namespace

GetcuReone.FactFactory.Resources

##### Summary

Error resources.

<a name='M-GetcuReone-FactFactory-Resources-ErrorResources-OnWantActionCannotBePerformedSynchronously-GetcuReone-FactFactory-Interfaces-IWantAction-'></a>
### OnWantActionCannotBePerformedSynchronously(wantAction) `method`

##### Summary

Action cannot be performed synchronously.

##### Returns

Error text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | WantAction. |

<a name='T-GetcuReone-FactFactory-FactFactoryHelper'></a>
## FactFactoryHelper `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Common helper for FactFactory.

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CannotIsType``1-GetcuReone-FactFactory-Interfaces-IFactType,System-String-'></a>
### CannotIsType\`\`1(type,paramName) `method`

##### Summary

Cannot is `TFact`.

##### Returns

`type`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Type fact info. |
| paramName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Parameter name. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CompareTo-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### CompareTo(firstRule,secondRule) `method`

##### Summary

Compare fact rules.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |
| secondRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CompareTo-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareTo(x,y) `method`

##### Summary

Compare facts by [CalculateByRule](#F-GetcuReone-FactFactory-Constants-FactParametersCodes-CalculateByRule 'GetcuReone.FactFactory.Constants.FactParametersCodes.CalculateByRule').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail}-'></a>
### CreateDeriveException(details) `method`

##### Summary

Create [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Returns

Exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| details | [System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail}') | Error deteils. |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String-'></a>
### CreateDeriveException(code,reason) `method`

##### Summary

Creates [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Returns

Exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code. |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error reason. |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### CreateDeriveException(code,reason,requiredAction,container) `method`

##### Summary

Creates [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Returns

Exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code. |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error reason. |
| requiredAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | Action for which it was not possible to derive the facts. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CreateDeriveException-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}-'></a>
### CreateDeriveException(code,reason,requiredAction,container,requiredFacts) `method`

##### Summary

Creates [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Returns

Exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code. |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error reason. |
| requiredAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | Action for which it was not possible to derive the facts. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| requiredFacts | [System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}') | The facts that tried to derive. |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-CreateException-System-String,System-String-'></a>
### CreateException(code,reason) `method`

##### Summary

Create [FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException')

##### Returns

Exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | error code |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | error reason |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-FirstFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstFactByFactType\`\`1(facts,factType,cache) `method`

##### Summary

The first fact of the same type.

##### Returns

Fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Fact list. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-GetFact``1-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### GetFact\`\`1(facts) `method`

##### Summary

Returns first fact by type `TFact`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-IsCalculatedByRule``1-``0-'></a>
### IsCalculatedByRule\`\`1(fact) `method`

##### Summary

Was the fact calculated using the rule.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-WhereFactsByFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### WhereFactsByFactType(facts,factType,cache) `method`

##### Summary

Get an array of facts of a specific type.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Facts. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Required type. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache (optional). |

<a name='M-GetcuReone-FactFactory-FactFactoryHelper-WhereFactsByFactTypes-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### WhereFactsByFactTypes(facts,factTypes,cache) `method`

##### Summary

Get an array of facts of a specific types.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Facts. |
| factTypes | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}') | Required types. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache (optional). |

<a name='T-GetcuReone-FactFactory-Constants-FactParametersCodes'></a>
## FactParametersCodes `type`

##### Namespace

GetcuReone.FactFactory.Constants

##### Summary

Default codes for fact parameter.

<a name='F-GetcuReone-FactFactory-Constants-FactParametersCodes-CalculateByRule'></a>
### CalculateByRule `constants`

##### Summary

Was the fact calculated using the rule.

<a name='T-GetcuReone-FactFactory-Extensions-FactTypeExtensions'></a>
## FactTypeExtensions `type`

##### Namespace

GetcuReone.FactFactory.Extensions

##### Summary

Extensions for [IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType')

<a name='M-GetcuReone-FactFactory-Extensions-FactTypeExtensions-IsBuildOrRuntimeFact-GetcuReone-FactFactory-Interfaces-IFactType-'></a>
### IsBuildOrRuntimeFact(type) `method`

##### Summary

Checks if a `type` is fact [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact') or [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

##### Returns

True - `type` is [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact') or [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type. |

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
