<a name='assembly'></a>
# GetcuReone.FactFactory.Priority

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [PriorityBase\`1](#T-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1')
  - [#ctor()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-#ctor-`0- 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.#ctor(`0)')
  - [PriorityValue](#P-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-PriorityValue 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.PriorityValue')
  - [CompareTo(other)](#M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact- 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.CompareTo(FactFactory.Priority.Interfaces.IPriorityFact)')
  - [CreateIncompatibilityVersionException(priorityFact)](#M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-CreateIncompatibilityVersionException-FactFactory-Priority-Interfaces-IPriorityFact- 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.CreateIncompatibilityVersionException(FactFactory.Priority.Interfaces.IPriorityFact)')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
  - [op_Implicit(fact)](#M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-op_Implicit-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase{`0}-~`0 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.op_Implicit(GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase{`0})~`0')
- [PriorityFactFactory](#T-GetcuReone-FactFactory-Priority-PriorityFactFactory 'GetcuReone.FactFactory.Priority.PriorityFactFactory')
  - [#ctor()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-#ctor 'GetcuReone.FactFactory.Priority.PriorityFactFactory.#ctor')
  - [#ctor(getDefaultFactsFunc)](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}- 'GetcuReone.FactFactory.Priority.PriorityFactFactory.#ctor(System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}})')
  - [Rules](#P-GetcuReone-FactFactory-Priority-PriorityFactFactory-Rules 'GetcuReone.FactFactory.Priority.PriorityFactFactory.Rules')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Priority.PriorityFactFactory.CreateWantAction(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Priority.PriorityFactFactory.CreateWantAction(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-GetDefaultContainer 'GetcuReone.FactFactory.Priority.PriorityFactFactory.GetDefaultContainer')
  - [GetDefaultFacts()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}- 'GetcuReone.FactFactory.Priority.PriorityFactFactory.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer})')
- [PriorityFactFactoryBase\`4](#T-GetcuReone-FactFactory-Priority-PriorityFactFactoryBase`4 'GetcuReone.FactFactory.Priority.PriorityFactFactoryBase`4')
  - [GetSingleEntityOperations()](#M-GetcuReone-FactFactory-Priority-PriorityFactFactoryBase`4-GetSingleEntityOperations 'GetcuReone.FactFactory.Priority.PriorityFactFactoryBase`4.GetSingleEntityOperations')
- [UintPriorityBase](#T-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase 'GetcuReone.FactFactory.Priority.SpecialFacts.UintPriorityBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase-#ctor-System-UInt32- 'GetcuReone.FactFactory.Priority.SpecialFacts.UintPriorityBase.#ctor(System.UInt32)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact- 'GetcuReone.FactFactory.Priority.SpecialFacts.UintPriorityBase.CompareTo(FactFactory.Priority.Interfaces.IPriorityFact)')
- [ULongPriorityBase](#T-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase 'GetcuReone.FactFactory.Priority.SpecialFacts.ULongPriorityBase')
  - [#ctor()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase-#ctor-System-UInt64- 'GetcuReone.FactFactory.Priority.SpecialFacts.ULongPriorityBase.#ctor(System.UInt64)')
  - [CompareTo()](#M-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact- 'GetcuReone.FactFactory.Priority.SpecialFacts.ULongPriorityBase.CompareTo(FactFactory.Priority.Interfaces.IPriorityFact)')

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

<a name='T-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1'></a>
## PriorityBase\`1 `type`

##### Namespace

GetcuReone.FactFactory.Priority.SpecialFacts

##### Summary

Base class for [IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TPriorityValue | Priority value type. |

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-#ctor-`0-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='P-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-PriorityValue'></a>
### PriorityValue `property`

##### Summary

Priority value.

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact-'></a>
### CompareTo(other) `method`

##### Summary

Compares the priority fact to the `other`.

##### Returns

1 - more, 0 - equal, -1 less.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [FactFactory.Priority.Interfaces.IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact') | Priority fact for comparison |

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-CreateIncompatibilityVersionException-FactFactory-Priority-Interfaces-IPriorityFact-'></a>
### CreateIncompatibilityVersionException(priorityFact) `method`

##### Summary

Creates an error creating incompatibility priority facts.

##### Returns

Error creating incompatibility priority facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| priorityFact | [FactFactory.Priority.Interfaces.IPriorityFact](#T-FactFactory-Priority-Interfaces-IPriorityFact 'FactFactory.Priority.Interfaces.IPriorityFact') | Priority fact. |

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-op_Implicit-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase{`0}-~`0'></a>
### op_Implicit(fact) `method`

##### Summary

Extracts the [PriorityValue](#P-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase`1-PriorityValue 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase`1.PriorityValue').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase{\`0})~\`0](#T-GetcuReone-FactFactory-Priority-SpecialFacts-PriorityBase{`0}-~`0 'GetcuReone.FactFactory.Priority.SpecialFacts.PriorityBase{`0})~`0') | Priority fact. |

<a name='T-GetcuReone-FactFactory-Priority-PriorityFactFactory'></a>
## PriorityFactFactory `type`

##### Namespace

GetcuReone.FactFactory.Priority

##### Summary

Default priority fact factory.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}-'></a>
### #ctor(getDefaultFactsFunc) `constructor`

##### Summary

Constructot.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| getDefaultFactsFunc | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Function that returns default facts. |

<a name='P-GetcuReone-FactFactory-Priority-PriorityFactFactory-Rules'></a>
### Rules `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-GetDefaultContainer'></a>
### GetDefaultContainer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}-'></a>
### GetDefaultFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Priority-PriorityFactFactoryBase`4'></a>
## PriorityFactFactoryBase\`4 `type`

##### Namespace

GetcuReone.FactFactory.Priority

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-Priority-PriorityFactFactoryBase`4-GetSingleEntityOperations'></a>
### GetSingleEntityOperations() `method`

##### Summary

Returns the [PrioritySingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade').

##### Returns

Instance [PrioritySingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Priority-Facades-SingleEntityOperations-PrioritySingleEntityOperationsFacade 'GetcuReone.FactFactory.Priority.Facades.SingleEntityOperations.PrioritySingleEntityOperationsFacade').

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase'></a>
## UintPriorityBase `type`

##### Namespace

GetcuReone.FactFactory.Priority.SpecialFacts

##### Summary

Base class for priority fact with value of type [UInt32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt32 'System.UInt32').

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase-#ctor-System-UInt32-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-UintPriorityBase-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase'></a>
## ULongPriorityBase `type`

##### Namespace

GetcuReone.FactFactory.Priority.SpecialFacts

##### Summary

Base class for priority fact with value of type [UInt64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UInt64 'System.UInt64').

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase-#ctor-System-UInt64-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Priority-SpecialFacts-ULongPriorityBase-CompareTo-FactFactory-Priority-Interfaces-IPriorityFact-'></a>
### CompareTo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
