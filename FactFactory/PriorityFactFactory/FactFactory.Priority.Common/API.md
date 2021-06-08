<a name='assembly'></a>
# GetcuReone.FactFactory.Priority.Common

## Contents

- [PriorityFactFactoryHelper](#T-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper')
  - [CompareByPriority(x,y)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.CompareByPriority(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompareByPriority\`\`3(x,y,context)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.CompareByPriority``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [FirstPriorityByFactType\`\`1(facts,factType,cache)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FirstPriorityByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.FirstPriorityByFactType``1(System.Collections.Generic.IEnumerable{``0},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [GetPriorityOrNull\`\`1(fact)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-GetPriorityOrNull``1-``0- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.GetPriorityOrNull``1(``0)')
  - [SetPriority\`\`2(fact,priority)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-SetPriority``2-``0,``1- 'GetcuReone.FactFactory.Priority.PriorityFactFactoryHelper.SetPriority``2(``0,``1)')
- [PriorityFactParametersCodes](#T-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes')
  - [Priority](#F-GetcuReone-FactFactory-Priority-Constants-PriorityFactParametersCodes-Priority 'GetcuReone.FactFactory.Priority.Constants.PriorityFactParametersCodes.Priority')

<a name='T-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper'></a>
## PriorityFactFactoryHelper `type`

##### Namespace

GetcuReone.FactFactory.Priority

##### Summary

Helper for PriorityFactFactory.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareByPriority(x,y) `method`

##### Summary

Compare by priority.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| y | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-CompareByPriority``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CompareByPriority\`\`3(x,y,context) `method`

##### Summary

Compare fact rules by 'priority'.

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

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-FirstPriorityByFactType``1-System-Collections-Generic-IEnumerable{``0},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### FirstPriorityByFactType\`\`1(facts,factType,cache) `method`

##### Summary

The first 'priority' fact of the same type.

##### Returns

Priority or null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Fact list. |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Fact type of 'priority'. |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-GetPriorityOrNull``1-``0-'></a>
### GetPriorityOrNull\`\`1(fact) `method`

##### Summary

Get priority fact.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryHelper-SetPriority``2-``0,``1-'></a>
### SetPriority\`\`2(fact,priority) `method`

##### Summary

Set parameter 'priority'.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |
| priority | [\`\`1](#T-``1 '``1') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |
| TPriority |  |

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
