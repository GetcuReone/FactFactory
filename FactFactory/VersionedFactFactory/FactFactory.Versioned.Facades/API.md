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
  - [CalculateFact()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CalculateFactAsync()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CalculateFactAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CanExtractFact()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CanExtractFact(GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareFactRules()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFactRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompareFacts()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompareFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [CompatibleRule()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.CompatibleRule(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetCompatibleRules()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetCompatibleRules(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRequireFacts()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequireFacts(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRequiredTypesOfFacts()](#M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade.GetRequiredTypesOfFacts(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')

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

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFact() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a versioned fact to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFactAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Adds a [IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') to the parameters of the calculated fact.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CanExtractFact-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CanExtractFact() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompareFactRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompareFactRules() `method`

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

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-CompatibleRule-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompatibleRule() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetCompatibleRules-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetCompatibleRules() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequireFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRequireFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.

<a name='M-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade-GetRequiredTypesOfFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRequiredTypesOfFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Remarks

Additionally checks version compatibility.
