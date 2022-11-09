<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [VersionedSingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade')
  - [CalculateFactAsync\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFactAsync``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')
  - [CalculateFact\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFact``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')
  - [CanExtractFact\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact``2-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CanExtractFact``2(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')
  - [CompareFactRules\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules``2-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFactRules``2(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')
  - [CompareFacts()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule``3-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompatibleRule``3(``0,``1,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2})')
  - [GetCompatibleRules\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules``3-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetCompatibleRules``3(``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2})')
  - [GetRequireFacts\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts``2-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequireFacts``2(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')
  - [GetRequiredTypesOfFacts\`\`2()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts``2-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequiredTypesOfFacts``2(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1})')

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

<a name='T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade'></a>
## VersionedSingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory. Sharpened for work with [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact').

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### CalculateFactAsync\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### CalculateFact\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a versioned fact to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact``2-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### CanExtractFact\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules``2-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### CompareFactRules\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### CompareFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule``3-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2}-'></a>
### CompatibleRule\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules``3-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2}-'></a>
### GetCompatibleRules\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts``2-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### GetRequireFacts\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts``2-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1}-'></a>
### GetRequiredTypesOfFacts\`\`2() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.
