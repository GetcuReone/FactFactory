<a name='assembly'></a>
# GetcuReone.FactFactory.TestsCommon

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [CommonTestBase](#T-FactFactory-TestsCommon-CommonTestBase 'FactFactory.TestsCommon.CommonTestBase')
  - [ExpectedDeriveException(action)](#M-FactFactory-TestsCommon-CommonTestBase-ExpectedDeriveException-System-Action- 'FactFactory.TestsCommon.CommonTestBase.ExpectedDeriveException(System.Action)')
  - [ExpectedFactFactoryException(action)](#M-FactFactory-TestsCommon-CommonTestBase-ExpectedFactFactoryException-System-Action- 'FactFactory.TestsCommon.CommonTestBase.ExpectedFactFactoryException(System.Action)')
  - [GetFactRule\`\`1()](#M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``1-System-Func{``0},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'FactFactory.TestsCommon.CommonTestBase.GetFactRule``1(System.Func{``0},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetFactRule\`\`2()](#M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``2-System-Func{``0,``1},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'FactFactory.TestsCommon.CommonTestBase.GetFactRule``2(System.Func{``0,``1},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetFactRule\`\`3()](#M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``3-System-Func{``0,``1,``2},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'FactFactory.TestsCommon.CommonTestBase.GetFactRule``3(System.Func{``0,``1,``2},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetFactRule\`\`4(func,option)](#M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``4-System-Func{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'FactFactory.TestsCommon.CommonTestBase.GetFactRule``4(System.Func{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetFactTypeCache()](#M-FactFactory-TestsCommon-CommonTestBase-GetFactTypeCache 'FactFactory.TestsCommon.CommonTestBase.GetFactTypeCache')
  - [GetFactType\`\`1()](#M-FactFactory-TestsCommon-CommonTestBase-GetFactType``1 'FactFactory.TestsCommon.CommonTestBase.GetFactType``1')
  - [GetWantActionContext\`\`1(wantAction,container,singleEntity,cache)](#M-FactFactory-TestsCommon-CommonTestBase-GetWantActionContext``1-``0,GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache- 'FactFactory.TestsCommon.CommonTestBase.GetWantActionContext``1(``0,GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache)')
  - [GetWantAction\`\`1()](#M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``1-System-Action{``0}- 'FactFactory.TestsCommon.CommonTestBase.GetWantAction``1(System.Action{``0})')
  - [GetWantAction\`\`2()](#M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``2-System-Action{``0,``1}- 'FactFactory.TestsCommon.CommonTestBase.GetWantAction``2(System.Action{``0,``1})')
  - [GetWantAction\`\`3(action)](#M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``3-System-Action{``0,``1,``2}- 'FactFactory.TestsCommon.CommonTestBase.GetWantAction``3(System.Action{``0,``1,``2})')
- [CommonTestHelper](#T-FactFactory-TestsCommon-Helpers-CommonTestHelper 'FactFactory.TestsCommon.Helpers.CommonTestHelper')
  - [AndAddRules\`\`2(givenBlock,factRules)](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-AndAddRules``2-GetcuReone-GwtTestFramework-Entities-GivenBlock{``0,``1},GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection{GetcuReone-FactFactory-Entities-FactRule}- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.AndAddRules``2(GetcuReone.GwtTestFramework.Entities.GivenBlock{``0,``1},GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection{GetcuReone.FactFactory.Entities.FactRule})')
  - [AndAssertErrorDetail\`\`1(thenBlock,errorCode,errorMessage)](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-AndAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-ThenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException},System-String,System-String- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.AndAssertErrorDetail``1(GetcuReone.GwtTestFramework.Entities.ThenBlock{``0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException},System.String,System.String)')
  - [SetCalculateByRuleParam\`\`1(fact)](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-SetCalculateByRuleParam``1-``0- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.SetCalculateByRuleParam``1(``0)')
  - [ThenAssertErrorDetail\`\`1(whenBlock,errorCode,errorMessage)](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException},System-String,System-String- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.ThenAssertErrorDetail``1(GetcuReone.GwtTestFramework.Entities.WhenBlock{``0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException},System.String,System.String)')
  - [ThenAssertErrorDetail\`\`1()](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,GetcuReone-FactFactory-Exceptions-FactFactoryException},System-String,System-String- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.ThenAssertErrorDetail``1(GetcuReone.GwtTestFramework.Entities.WhenBlock{``0,GetcuReone.FactFactory.Exceptions.FactFactoryException},System.String,System.String)')
  - [ThenFactValueEquals\`\`3(whenBlock,expectedValue)](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenFactValueEquals``3-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,``1},``2- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.ThenFactValueEquals``3(GetcuReone.GwtTestFramework.Entities.WhenBlock{``0,``1},``2)')
  - [ThenFactValueEquals\`\`3()](#M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenFactValueEquals``3-GetcuReone-GwtTestFramework-Entities-WhenAsyncBlock{``0,``1},``2- 'FactFactory.TestsCommon.Helpers.CommonTestHelper.ThenFactValueEquals``3(GetcuReone.GwtTestFramework.Entities.WhenAsyncBlock{``0,``1},``2)')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [Objects](#T-FactFactory-TestsCommon-TC-Objects 'FactFactory.TestsCommon.TC.Objects')
  - [BuildCanDerived](#F-FactFactory-TestsCommon-TC-Objects-BuildCanDerived 'FactFactory.TestsCommon.TC.Objects.BuildCanDerived')
  - [BuildCannotDerived](#F-FactFactory-TestsCommon-TC-Objects-BuildCannotDerived 'FactFactory.TestsCommon.TC.Objects.BuildCannotDerived')
  - [BuildContained](#F-FactFactory-TestsCommon-TC-Objects-BuildContained 'FactFactory.TestsCommon.TC.Objects.BuildContained')
  - [BuildNotContained](#F-FactFactory-TestsCommon-TC-Objects-BuildNotContained 'FactFactory.TestsCommon.TC.Objects.BuildNotContained')
  - [Container](#F-FactFactory-TestsCommon-TC-Objects-Container 'FactFactory.TestsCommon.TC.Objects.Container')
  - [Fact](#F-FactFactory-TestsCommon-TC-Objects-Fact 'FactFactory.TestsCommon.TC.Objects.Fact')
  - [FactType](#F-FactFactory-TestsCommon-TC-Objects-FactType 'FactFactory.TestsCommon.TC.Objects.FactType')
  - [Factory](#F-FactFactory-TestsCommon-TC-Objects-Factory 'FactFactory.TestsCommon.TC.Objects.Factory')
  - [Rule](#F-FactFactory-TestsCommon-TC-Objects-Rule 'FactFactory.TestsCommon.TC.Objects.Rule')
  - [RuleCollection](#F-FactFactory-TestsCommon-TC-Objects-RuleCollection 'FactFactory.TestsCommon.TC.Objects.RuleCollection')
  - [WantAction](#F-FactFactory-TestsCommon-TC-Objects-WantAction 'FactFactory.TestsCommon.TC.Objects.WantAction')
- [Projects](#T-FactFactory-TestsCommon-TC-Projects 'FactFactory.TestsCommon.TC.Projects')
  - [Priority](#F-FactFactory-TestsCommon-TC-Projects-Priority 'FactFactory.TestsCommon.TC.Projects.Priority')
  - [Versioned](#F-FactFactory-TestsCommon-TC-Projects-Versioned 'FactFactory.TestsCommon.TC.Projects.Versioned')
- [TC](#T-FactFactory-TestsCommon-TC 'FactFactory.TestsCommon.TC')

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

<a name='T-FactFactory-TestsCommon-CommonTestBase'></a>
## CommonTestBase `type`

##### Namespace

FactFactory.TestsCommon

##### Summary

Base test class.

<a name='M-FactFactory-TestsCommon-CommonTestBase-ExpectedDeriveException-System-Action-'></a>
### ExpectedDeriveException(action) `method`

##### Summary

Expect error [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Returns

Error [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | Action |

<a name='M-FactFactory-TestsCommon-CommonTestBase-ExpectedFactFactoryException-System-Action-'></a>
### ExpectedFactFactoryException(action) `method`

##### Summary

Expect error [FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException').

##### Returns

Error [FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | Action |

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``1-System-Func{``0},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### GetFactRule\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``2-System-Func{``0,``1},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### GetFactRule\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``3-System-Func{``0,``1,``2},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### GetFactRule\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactRule``4-System-Func{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### GetFactRule\`\`4(func,option) `method`

##### Summary

Get fact rule.

##### Returns

Fact rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3}') | Func for `TFactResult` |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for fact rule |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Fact rule parametr 1 |
| TFact2 | Fact rule parametr 2 |
| TFact3 | Fact rule parametr 3 |
| TFactResult | Type result for fact rule |

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactTypeCache'></a>
### GetFactTypeCache() `method`

##### Summary

Get fact type cache.

##### Returns

Fact type cahce.

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetWantActionContext``1-``0,GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-'></a>
### GetWantActionContext\`\`1(wantAction,container,singleEntity,cache) `method`

##### Summary

Get context for [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction').

##### Returns

Context for [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [\`\`0](#T-``0 '``0') | Desired action information |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container |
| singleEntity | [GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations](#T-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations') | Single operations on entities of the FactFactory |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') | Cache for fact type |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | Type `wantAction` |

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``1-System-Action{``0}-'></a>
### GetWantAction\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``2-System-Action{``0,``1}-'></a>
### GetWantAction\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-CommonTestBase-GetWantAction``3-System-Action{``0,``1,``2}-'></a>
### GetWantAction\`\`3(action) `method`

##### Summary

Get wantAction.

##### Returns

WantAction.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{\`\`0,\`\`1,\`\`2}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2}') | Action |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Parameter 1 |
| TFact2 | Parameter 2 |
| TFact3 | Parameter 3 |

<a name='T-FactFactory-TestsCommon-Helpers-CommonTestHelper'></a>
## CommonTestHelper `type`

##### Namespace

FactFactory.TestsCommon.Helpers

##### Summary

Helper for test.

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-AndAddRules``2-GetcuReone-GwtTestFramework-Entities-GivenBlock{``0,``1},GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection{GetcuReone-FactFactory-Entities-FactRule}-'></a>
### AndAddRules\`\`2(givenBlock,factRules) `method`

##### Summary

Given block for add rules.

##### Returns

Given block.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| givenBlock | [GetcuReone.GwtTestFramework.Entities.GivenBlock{\`\`0,\`\`1}](#T-GetcuReone-GwtTestFramework-Entities-GivenBlock{``0,``1} 'GetcuReone.GwtTestFramework.Entities.GivenBlock{``0,``1}') | Previous given block |
| factRules | [GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection{GetcuReone.FactFactory.Entities.FactRule}](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection{GetcuReone-FactFactory-Entities-FactRule} 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection{GetcuReone.FactFactory.Entities.FactRule}') | Fact rules |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TInput | Input type |
| TFactory | Fact factory type. |

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-AndAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-ThenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException},System-String,System-String-'></a>
### AndAssertErrorDetail\`\`1(thenBlock,errorCode,errorMessage) `method`

##### Summary

Check for errors.

##### Returns

Result of checking.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| thenBlock | [GetcuReone.GwtTestFramework.Entities.ThenBlock{\`\`0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException}](#T-GetcuReone-GwtTestFramework-Entities-ThenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException} 'GetcuReone.GwtTestFramework.Entities.ThenBlock{``0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException}') | Then block |
| errorCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code |
| errorMessage | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error message |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TInput | Input type |

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-SetCalculateByRuleParam``1-``0-'></a>
### SetCalculateByRuleParam\`\`1(fact) `method`

##### Summary

Set param [CalculateByRule](#F-GetcuReone-FactFactory-Constants-FactParametersCodes-CalculateByRule 'GetcuReone.FactFactory.Constants.FactParametersCodes.CalculateByRule').

##### Returns

`fact`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Fact type |

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException},System-String,System-String-'></a>
### ThenAssertErrorDetail\`\`1(whenBlock,errorCode,errorMessage) `method`

##### Summary

Check for errors.

##### Returns

Result of checking.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| whenBlock | [GetcuReone.GwtTestFramework.Entities.WhenBlock{\`\`0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException}](#T-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException} 'GetcuReone.GwtTestFramework.Entities.WhenBlock{``0,GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException}') | When block |
| errorCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code |
| errorMessage | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error message |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TInput | Input type |

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenAssertErrorDetail``1-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,GetcuReone-FactFactory-Exceptions-FactFactoryException},System-String,System-String-'></a>
### ThenAssertErrorDetail\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenFactValueEquals``3-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,``1},``2-'></a>
### ThenFactValueEquals\`\`3(whenBlock,expectedValue) `method`

##### Summary

Then block for check [Value](#P-GetcuReone-FactFactory-BaseFact`1-Value 'GetcuReone.FactFactory.BaseFact`1.Value').

##### Returns

Then block

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| whenBlock | [GetcuReone.GwtTestFramework.Entities.WhenBlock{\`\`0,\`\`1}](#T-GetcuReone-GwtTestFramework-Entities-WhenBlock{``0,``1} 'GetcuReone.GwtTestFramework.Entities.WhenBlock{``0,``1}') | Previous when block |
| expectedValue | [\`\`2](#T-``2 '``2') | Expected value |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TInput | Input type |
| TFact | Fact type |
| TFactValue | Fact value type. |

<a name='M-FactFactory-TestsCommon-Helpers-CommonTestHelper-ThenFactValueEquals``3-GetcuReone-GwtTestFramework-Entities-WhenAsyncBlock{``0,``1},``2-'></a>
### ThenFactValueEquals\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

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

<a name='T-FactFactory-TestsCommon-TC-Objects'></a>
## Objects `type`

##### Namespace

FactFactory.TestsCommon.TC

##### Summary

Categories of objects for testing.

<a name='F-FactFactory-TestsCommon-TC-Objects-BuildCanDerived'></a>
### BuildCanDerived `constants`

##### Summary

[BuildCanDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCanDerived`1').

<a name='F-FactFactory-TestsCommon-TC-Objects-BuildCannotDerived'></a>
### BuildCannotDerived `constants`

##### Summary

[BuildCannotDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCannotDerived`1').

<a name='F-FactFactory-TestsCommon-TC-Objects-BuildContained'></a>
### BuildContained `constants`

##### Summary

[BuildContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildContained`1').

<a name='F-FactFactory-TestsCommon-TC-Objects-BuildNotContained'></a>
### BuildNotContained `constants`

##### Summary

[BuildNotContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildNotContained`1').

<a name='F-FactFactory-TestsCommon-TC-Objects-Container'></a>
### Container `constants`

##### Summary

Fact container [IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer').

<a name='F-FactFactory-TestsCommon-TC-Objects-Fact'></a>
### Fact `constants`

##### Summary

[IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

<a name='F-FactFactory-TestsCommon-TC-Objects-FactType'></a>
### FactType `constants`

##### Summary

[IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType').

<a name='F-FactFactory-TestsCommon-TC-Objects-Factory'></a>
### Factory `constants`

##### Summary

Fact factory [IFactFactory\`3](#T-GetcuReone-FactFactory-Interfaces-IFactFactory`3 'GetcuReone.FactFactory.Interfaces.IFactFactory`3').

<a name='F-FactFactory-TestsCommon-TC-Objects-Rule'></a>
### Rule `constants`

##### Summary

Fact rule [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

<a name='F-FactFactory-TestsCommon-TC-Objects-RuleCollection'></a>
### RuleCollection `constants`

##### Summary

Fact rule collection

<a name='F-FactFactory-TestsCommon-TC-Objects-WantAction'></a>
### WantAction `constants`

##### Summary

Desired action [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction').

<a name='T-FactFactory-TestsCommon-TC-Projects'></a>
## Projects `type`

##### Namespace

FactFactory.TestsCommon.TC

##### Summary

Test categories for projects.

<a name='F-FactFactory-TestsCommon-TC-Projects-Priority'></a>
### Priority `constants`

##### Summary

Refers to the FactFactory.Priority project.

<a name='F-FactFactory-TestsCommon-TC-Projects-Versioned'></a>
### Versioned `constants`

##### Summary

Refers to the FactFactory.Versioned project.

<a name='T-FactFactory-TestsCommon-TC'></a>
## TC `type`

##### Namespace

FactFactory.TestsCommon

##### Summary

Test categories.
