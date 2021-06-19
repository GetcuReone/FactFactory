<a name='assembly'></a>
# GetcuReone.FactFactory.Entities

## Contents

- [FactContainer](#T-GetcuReone-FactFactory-Entities-FactContainer 'GetcuReone.FactFactory.Entities.FactContainer')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactContainer-#ctor 'GetcuReone.FactFactory.Entities.FactContainer.#ctor')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Entities.FactContainer.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean- 'GetcuReone.FactFactory.Entities.FactContainer.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Boolean)')
- [FactParameter](#T-GetcuReone-FactFactory-Entities-FactParameter 'GetcuReone.FactFactory.Entities.FactParameter')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactParameter-#ctor-System-String,System-Object- 'GetcuReone.FactFactory.Entities.FactParameter.#ctor(System.String,System.Object)')
- [FactRule](#T-GetcuReone-FactFactory-Entities-FactRule 'GetcuReone.FactFactory.Entities.FactRule')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.FactRule.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.FactRule.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
- [FactRuleCollection](#T-GetcuReone-FactFactory-Entities-FactRuleCollection 'GetcuReone.FactFactory.Entities.FactRuleCollection')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor 'GetcuReone.FactFactory.Entities.FactRuleCollection.#ctor')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Entities-FactRule}- 'GetcuReone.FactFactory.Entities.FactRuleCollection.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Entities.FactRule})')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Entities-FactRule},System-Boolean- 'GetcuReone.FactFactory.Entities.FactRuleCollection.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Entities.FactRule},System.Boolean)')
  - [Copy()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-Copy 'GetcuReone.FactFactory.Entities.FactRuleCollection.Copy')
  - [CreateFactRule()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.FactRuleCollection.CreateFactRule(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateFactRule()](#M-GetcuReone-FactFactory-Entities-FactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.FactRuleCollection.CreateFactRule(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
- [WantAction](#T-GetcuReone-FactFactory-Entities-WantAction 'GetcuReone.FactFactory.Entities.WantAction')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-WantAction-#ctor-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.WantAction.#ctor(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [#ctor()](#M-GetcuReone-FactFactory-Entities-WantAction-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Entities.WantAction.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')

<a name='T-GetcuReone-FactFactory-Entities-FactContainer'></a>
## FactContainer `type`

##### Namespace

GetcuReone.FactFactory.Entities

##### Summary

Fact collection.

<a name='M-GetcuReone-FactFactory-Entities-FactContainer-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='T-GetcuReone-FactFactory-Entities-FactParameter'></a>
## FactParameter `type`

##### Namespace

GetcuReone.FactFactory.Entities

##### Summary

Fact parameter.

<a name='M-GetcuReone-FactFactory-Entities-FactParameter-#ctor-System-String,System-Object-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='T-GetcuReone-FactFactory-Entities-FactRule'></a>
## FactRule `type`

##### Namespace

GetcuReone.FactFactory.Entities

##### Summary

Rule of fact calculation.

<a name='M-GetcuReone-FactFactory-Entities-FactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='T-GetcuReone-FactFactory-Entities-FactRuleCollection'></a>
## FactRuleCollection `type`

##### Namespace

GetcuReone.FactFactory.Entities

##### Summary

Collection for [FactRule](#T-GetcuReone-FactFactory-Entities-FactRule 'GetcuReone.FactFactory.Entities.FactRule').

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Entities-FactRule}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Entities-FactRule},System-Boolean-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-Copy'></a>
### Copy() `method`

##### Summary

[FactRuleCollectionBase\`1](#T-GetcuReone-FactFactory-BaseEntities-FactRuleCollectionBase`1 'GetcuReone.FactFactory.BaseEntities.FactRuleCollectionBase`1') copy method.

##### Returns

Copied [FactRuleCollection](#T-GetcuReone-FactFactory-Entities-FactRuleCollection 'GetcuReone.FactFactory.Entities.FactRuleCollection').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateFactRule() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-FactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateFactRule() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Entities-WantAction'></a>
## WantAction `type`

##### Namespace

GetcuReone.FactFactory.Entities

##### Summary

Desired action information.

<a name='M-GetcuReone-FactFactory-Entities-WantAction-#ctor-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Entities-WantAction-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.
