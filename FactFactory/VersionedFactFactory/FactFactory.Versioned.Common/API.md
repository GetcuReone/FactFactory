<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned.Common

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [VersionedErrorCode](#T-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode 'GetcuReone.FactFactory.Versioned.Constants.VersionedErrorCode')
  - [VersionNotFound](#F-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode-VersionNotFound 'GetcuReone.FactFactory.Versioned.Constants.VersionedErrorCode.VersionNotFound')
- [VersionedFactFactoryHelper](#T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper')
  - [AddVerionParameter(fact,version)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-AddVerionParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.AddVerionParameter(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [CompareByVersionParameter(x,y)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersionParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.CompareByVersionParameter(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompareByVersion\`\`1(x,y,context)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion``1-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.CompareByVersion``1(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [FindVersionParameter\`\`1(fact)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FindVersionParameter``1-``0- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.FindVersionParameter``1(``0)')
  - [FirstVersionFactByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.FirstVersionFactByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [FirstVersionFactType(factTypes)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.FirstVersionFactType(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType})')
  - [HasVersionParameter\`\`1(fact,version)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-HasVersionParameter``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.HasVersionParameter``1(``0,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [IsRelevantFactByVersioned\`\`1(fact,maxVersion)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-IsRelevantFactByVersioned``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.IsRelevantFactByVersioned``1(``0,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [VersionedFactParametersCodes](#T-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes 'GetcuReone.FactFactory.Versioned.Constants.VersionedFactParametersCodes')
  - [Version](#F-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes-Version 'GetcuReone.FactFactory.Versioned.Constants.VersionedFactParametersCodes.Version')

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

<a name='T-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode'></a>
## VersionedErrorCode `type`

##### Namespace

GetcuReone.FactFactory.Versioned.Constants

##### Summary

Codes for errors in work VersionedFactFactory.

<a name='F-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode-VersionNotFound'></a>
### VersionNotFound `constants`

##### Summary

'VersionNotFound'. No fact was found in the container with information about the required version.

<a name='T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper'></a>
## VersionedFactFactoryHelper `type`

##### Namespace

GetcuReone.FactFactory.Versioned

##### Summary

Helper for VersionedFactFactory.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-AddVerionParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### AddVerionParameter(fact,version) `method`

##### Summary

Adds a version fact to parameters.

##### Returns

`fact`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Fact. |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Verion fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersionParameter-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareByVersionParameter(x,y) `method`

##### Summary

Compares facts by version facts in parameters.

##### Returns

1 - `x` fact is greater than the `y`,
0 - `x` fact is equal than the `y`,
-1 - `x` fact is less than the `y`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Fist fact. |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') | Second fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion``1-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompareByVersion\`\`1(x,y,context) `method`

##### Summary

Compares rules based on version facts.

##### Returns

1 - `x` rule is greater than the `y`,
0 - `x` rule is equal than the `y`,
-1 - `x` rule is less than the `y`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [\`\`0](#T-``0 '``0') | First rule. |
| y | [\`\`0](#T-``0 '``0') | Second rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type rule. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FindVersionParameter``1-``0-'></a>
### FindVersionParameter\`\`1(fact) `method`

##### Summary

Find parameter by [Version](#F-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes-Version 'GetcuReone.FactFactory.Versioned.Constants.VersionedFactParametersCodes.Version').

##### Returns

[IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionFactByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstVersionFactByFactType\`\`1(facts,factType,cache) `method`

##### Summary

Searches for the first occurrence of a version fact.

##### Returns

[IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') fact or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Fact list. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type of [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact'). |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}-'></a>
### FirstVersionFactType(factTypes) `method`

##### Summary

Returns the first type of fact that implements the [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') type.

##### Returns

First found fact type inherited from [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factTypes | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}') | List fact types. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-HasVersionParameter``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### HasVersionParameter\`\`1(fact,version) `method`

##### Summary

Checks the value of the version of the `fact`.

##### Returns

Does the version match the fact of the `version`?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Version fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-IsRelevantFactByVersioned``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### IsRelevantFactByVersioned\`\`1(fact,maxVersion) `method`

##### Summary

Checks if a fact contains a valid version.

##### Returns

Whether the version of the fact is within the valid versions?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |
| maxVersion | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Max version (optional). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='T-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes'></a>
## VersionedFactParametersCodes `type`

##### Namespace

GetcuReone.FactFactory.Versioned.Constants

##### Summary

Versioned codes for fact parameter.

<a name='F-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes-Version'></a>
### Version `constants`

##### Summary

Version of the fact.
