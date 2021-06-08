<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned.Common

## Contents

- [VersionedErrorCode](#T-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode 'GetcuReone.FactFactory.Versioned.Constants.VersionedErrorCode')
  - [VersionNotFound](#F-GetcuReone-FactFactory-Versioned-Constants-VersionedErrorCode-VersionNotFound 'GetcuReone.FactFactory.Versioned.Constants.VersionedErrorCode.VersionNotFound')
- [VersionedFactFactoryHelper](#T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper')
  - [CompareByVersion(x,y)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.CompareByVersion(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompareByVersion\`\`3(x,y,context)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.CompareByVersion``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [FirstVersionByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.FirstVersionByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [GetVersionFactType(factTypes)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-GetVersionFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.GetVersionFactType(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType})')
  - [GetVersionOrNull\`\`1(fact)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-GetVersionOrNull``1-``0- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.GetVersionOrNull``1(``0)')
  - [HasVersion\`\`1(fact,version)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-HasVersion``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.HasVersion``1(``0,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [IsRelevantFactByVersioned\`\`1(fact,maxVersion)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-IsRelevantFactByVersioned``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.IsRelevantFactByVersioned``1(``0,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [SetVersion(fact,version)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-SetVersion-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryHelper.SetVersion(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [VersionedFactParametersCodes](#T-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes 'GetcuReone.FactFactory.Versioned.Constants.VersionedFactParametersCodes')
  - [Version](#F-GetcuReone-FactFactory-Versioned-Constants-VersionedFactParametersCodes-Version 'GetcuReone.FactFactory.Versioned.Constants.VersionedFactParametersCodes.Version')

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

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareByVersion(x,y) `method`

##### Summary

Compare facts by version.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-CompareByVersion``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CompareByVersion\`\`3(x,y,context) `method`

##### Summary

Compare fact rules by version.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [\`\`0](#T-``0 '``0') |  |
| y | [\`\`0](#T-``0 '``0') |  |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule |  |
| TWantAction |  |
| TFactContainer |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-FirstVersionByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstVersionByFactType\`\`1(facts,factType,cache) `method`

##### Summary

The first version fact of the same type.

##### Returns

Version or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Fact list. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type of version. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-GetVersionFactType-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}-'></a>
### GetVersionFactType(factTypes) `method`

##### Summary

Return the fact type of a version.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factTypes | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}') |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-GetVersionOrNull``1-``0-'></a>
### GetVersionOrNull\`\`1(fact) `method`

##### Summary

Get version fact.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-HasVersion``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### HasVersion\`\`1(fact,version) `method`

##### Summary

The fact has a version.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-IsRelevantFactByVersioned``1-``0,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### IsRelevantFactByVersioned\`\`1(fact,maxVersion) `method`

##### Summary

Is relevant fact by versioned.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |
| maxVersion | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Max version (optional). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryHelper-SetVersion-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### SetVersion(fact,version) `method`

##### Summary

Set version.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') |  |

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
