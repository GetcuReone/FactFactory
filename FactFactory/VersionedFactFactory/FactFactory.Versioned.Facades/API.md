<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned.Facades

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
  - [ToReadOnlyCollection\`\`1(items)](#M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}- 'ListExtensions.ToReadOnlyCollection``1(System.Collections.Generic.IList{``0})')
- [VersionedSingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade')
  - [CalculateFact\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CalculateFactAsync\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFactAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanExtractFact\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CanExtractFact``3(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFactRules\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFactRules``3(``0,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompareFacts()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule\`\`4()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompatibleRule``4(``0,``1,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [GetCompatibleRules\`\`4()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules``4-``0,System-Collections-Generic-IEnumerable{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetCompatibleRules``4(``0,System.Collections.Generic.IEnumerable{``1},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [GetRequiredTypesOfFacts\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequiredTypesOfFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRequireFacts\`\`3()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequireFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')

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

<a name='T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade'></a>
## VersionedSingleEntityOperationsFacade `type`

##### Namespace

GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations

##### Summary

Single operations on entities of the FactFactory. Sharpened for work with [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact').

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFact\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a versioned fact to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFactAsync\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CanExtractFact\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules``3-``0,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CompareFactRules\`\`3() `method`

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

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### CompatibleRule\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules``4-``0,System-Collections-Generic-IEnumerable{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### GetCompatibleRules\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequiredTypesOfFacts\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequireFacts\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.
