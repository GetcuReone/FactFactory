<a name='assembly'></a>
# GetcuReone.FactFactory.Versioned

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [DateTimeVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.DateTimeVersionBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase-#ctor-System-DateTime- 'GetcuReone.FactFactory.Versioned.SpecialFacts.DateTimeVersionBase.#ctor(System.DateTime)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.DateTimeVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [IntVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.IntVersionBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase-#ctor-System-Int32- 'GetcuReone.FactFactory.Versioned.SpecialFacts.IntVersionBase.#ctor(System.Int32)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.IntVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
  - [ToReadOnlyCollection\`\`1(items)](#M-ListExtensions-ToReadOnlyCollection``1-System-Collections-Generic-IList{``0}- 'ListExtensions.ToReadOnlyCollection``1(System.Collections.Generic.IList{``0})')
- [LongVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.LongVersionBase')
  - [#ctor(version)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase-#ctor-System-Int64- 'GetcuReone.FactFactory.Versioned.SpecialFacts.LongVersionBase.#ctor(System.Int64)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.LongVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [MajorMinorPatchVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.MajorMinorPatchVersionBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase-#ctor-System-String- 'GetcuReone.FactFactory.Versioned.SpecialFacts.MajorMinorPatchVersionBase.#ctor(System.String)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.MajorMinorPatchVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [UintVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.UintVersionBase')
  - [#ctor(version)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase-#ctor-System-UInt32- 'GetcuReone.FactFactory.Versioned.SpecialFacts.UintVersionBase.#ctor(System.UInt32)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.UintVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [UlongVersionBase](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase 'GetcuReone.FactFactory.Versioned.SpecialFacts.UlongVersionBase')
  - [#ctor(version)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase-#ctor-System-UInt64- 'GetcuReone.FactFactory.Versioned.SpecialFacts.UlongVersionBase.#ctor(System.UInt64)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.UlongVersionBase.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
- [VersionBase\`1](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1')
  - [#ctor(version)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-#ctor-`0- 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.#ctor(`0)')
  - [VersionValue](#P-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-VersionValue 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.VersionValue')
  - [CompareTo(other)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.CompareTo(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [CreateIncompatibilityVersionException(versionedFact)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-CreateIncompatibilityVersionException-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.CreateIncompatibilityVersionException(GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact)')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
  - [op_Implicit(fact)](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-op_Implicit-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase{`0}-~`0 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.op_Implicit(GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase{`0})~`0')
  - [ToString()](#M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-ToString 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.ToString')
- [VersionedFactFactory](#T-GetcuReone-FactFactory-Versioned-VersionedFactFactory 'GetcuReone.FactFactory.Versioned.VersionedFactFactory')
  - [#ctor()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-#ctor 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.#ctor')
  - [#ctor(getDefaultFactsFunc)](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}- 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.#ctor(System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}})')
  - [Rules](#P-GetcuReone-FactFactory-Versioned-VersionedFactFactory-Rules 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.Rules')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.CreateWantAction(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.CreateWantAction(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-GetDefaultContainer 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.GetDefaultContainer')
  - [GetDefaultFacts()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}- 'GetcuReone.FactFactory.Versioned.VersionedFactFactory.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer})')
- [VersionedFactFactoryBase\`4](#T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryBase`4')
  - [DeriveFact\`\`2()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-DeriveFact``2-`3- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryBase`4.DeriveFact``2(`3)')
  - [DeriveFactAsync\`\`2()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-DeriveFactAsync``2-`3- 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryBase`4.DeriveFactAsync``2(`3)')
  - [GetSingleEntityOperations()](#M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-GetSingleEntityOperations 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryBase`4.GetSingleEntityOperations')

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

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase'></a>
## DateTimeVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for [DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') based version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase-#ctor-System-DateTime-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-DateTimeVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

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

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase'></a>
## IntVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for [Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') based version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase-#ctor-System-Int32-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-IntVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

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

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase'></a>
## LongVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for [Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') based version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase-#ctor-System-Int64-'></a>
### #ctor(version) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | version |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-LongVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase'></a>
## MajorMinorPatchVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for {major.minor.patch} versions.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase-#ctor-System-String-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-MajorMinorPatchVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase'></a>
## UintVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for [UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') based version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase-#ctor-System-UInt32-'></a>
### #ctor(version) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32') | version |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-UintVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase'></a>
## UlongVersionBase `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for [UInt64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt64 'System.UInt64') based version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase-#ctor-System-UInt64-'></a>
### #ctor(version) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [System.UInt64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt64 'System.UInt64') | version |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-UlongVersionBase-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1'></a>
## VersionBase\`1 `type`

##### Namespace

GetcuReone.FactFactory.Versioned.SpecialFacts

##### Summary

Base class for version facts.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-#ctor-`0-'></a>
### #ctor(version) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| version | [\`0](#T-`0 '`0') | Value version. |

<a name='P-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-VersionValue'></a>
### VersionValue `property`

##### Summary

Value version.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-CompareTo-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CompareTo(other) `method`

##### Summary

Compares the version fact to the `other`.

##### Returns

1 - more, 0 - equal, -1 less.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') | Version fact for comparison |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-CreateIncompatibilityVersionException-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact-'></a>
### CreateIncompatibilityVersionException(versionedFact) `method`

##### Summary

Error creating version incompatibility.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| versionedFact | [GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact](#T-GetcuReone-FactFactory-Versioned-Interfaces-IVersionFact 'GetcuReone.FactFactory.Versioned.Interfaces.IVersionFact') |  |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-op_Implicit-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase{`0}-~`0'></a>
### op_Implicit(fact) `method`

##### Summary

Extracts [VersionValue](#P-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-VersionValue 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase`1.VersionValue').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase{\`0})~\`0](#T-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase{`0}-~`0 'GetcuReone.FactFactory.Versioned.SpecialFacts.VersionBase{`0})~`0') | Version value. |

<a name='M-GetcuReone-FactFactory-Versioned-SpecialFacts-VersionBase`1-ToString'></a>
### ToString() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-VersionedFactFactory'></a>
## VersionedFactFactory `type`

##### Namespace

GetcuReone.FactFactory.Versioned

##### Summary

Default implementation of versioned fact factory [VersionedFactFactoryBase\`4](#T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4 'GetcuReone.FactFactory.Versioned.VersionedFactFactoryBase`4').

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}-'></a>
### #ctor(getDefaultFactsFunc) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| getDefaultFactsFunc | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Function that returns default facts. |

<a name='P-GetcuReone-FactFactory-Versioned-VersionedFactFactory-Rules'></a>
### Rules `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-GetDefaultContainer'></a>
### GetDefaultContainer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}-'></a>
### GetDefaultFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4'></a>
## VersionedFactFactoryBase\`4 `type`

##### Namespace

GetcuReone.FactFactory.Versioned

##### Summary

Base class for versioned fact factory.

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-DeriveFact``2-`3-'></a>
### DeriveFact\`\`2() `method`

##### Summary

Derive `TFactResult` with version.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |
| TVersion | Type of version fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-DeriveFactAsync``2-`3-'></a>
### DeriveFactAsync\`\`2() `method`

##### Summary

Derive `TFactResult` with version.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |
| TVersion | Type of version fact. |

<a name='M-GetcuReone-FactFactory-Versioned-VersionedFactFactoryBase`4-GetSingleEntityOperations'></a>
### GetSingleEntityOperations() `method`

##### Summary

Returns the [VersionedSingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade').

##### Returns

Instance [VersionedSingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Versioned-Facades-SingleEntityOperations-VersionedSingleEntityOperationsFacade 'GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations.VersionedSingleEntityOperationsFacade').

##### Parameters

This method has no parameters.
