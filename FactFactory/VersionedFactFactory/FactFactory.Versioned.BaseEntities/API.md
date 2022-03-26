<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned.BaseEntities

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [VersionedFactContainerBase](#T-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.#ctor')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Boolean)')
  - [ContainsByVersion\`\`1(version)](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-ContainsByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.ContainsByVersion``1(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [Contains\`\`1()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-Contains``1 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.Contains``1')
  - [GetFactByVersion\`\`1(version)](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-GetFactByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.GetFactByVersion``1(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [GetFact\`\`1()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-GetFact``1 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.GetFact``1')
  - [RemoveByVersion\`\`1(version)](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-RemoveByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.RemoveByVersion``1(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [Remove\`\`1()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-Remove``1 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.Remove``1')
  - [TryGetFactByVersion\`\`1(fact,version)](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-TryGetFactByVersion``1-``0@,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.TryGetFactByVersion``1(``0@,GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [TryGetFact\`\`1()](#M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-TryGetFact``1-``0@- 'GetcuReone.FactFactory.Versioned.BaseEntities.VersionedFactContainerBase.TryGetFact``1(``0@)')

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

<a name='T-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase'></a>
## VersionedFactContainerBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.BaseEntities

##### Summary

Base class for versioned fact container.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-ContainsByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### ContainsByVersion\`\`1(version) `method`

##### Summary

Does an `TFact` type fact with version `version`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-Contains``1'></a>
### Contains\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-GetFactByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### GetFactByVersion\`\`1(version) `method`

##### Summary

Return a fact of `TFact` type with version equal to `version`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Version. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact you need. |

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-GetFact``1'></a>
### GetFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-RemoveByVersion``1-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### RemoveByVersion\`\`1(version) `method`

##### Summary

Remove a fact of `TFact` type with version equal to `version`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Version. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact you need. |

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-Remove``1'></a>
### Remove\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-TryGetFactByVersion``1-``0@,GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### TryGetFactByVersion\`\`1(fact,version) `method`

##### Summary

Try to return a fact of `TFact` type with version equal to `version`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0@](#T-``0@ '``0@') | fact. |
| version | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Version. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact you need. |

<a name='M-GetcuReone-FactFactory-Versioned-BaseEntities-VersionedFactContainerBase-TryGetFact``1-``0@-'></a>
### TryGetFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
