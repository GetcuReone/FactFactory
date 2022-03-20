<a name='assembly'></a>
# GetcuReone.FactFactory.Main

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [BuildCanDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCanDerived`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCanDerived`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
- [BuildCannotDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCannotDerived`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCannotDerived`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
- [BuildConditionFactBase](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildConditionFactBase')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildConditionFactBase.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildConditionFactBase.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
- [BuildConditionFactBase\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildConditionFactBase`1')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase`1-GetFactType``1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildConditionFactBase`1.GetFactType``1')
- [BuildContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildContained`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildContained`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
- [BuildNotContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildNotContained`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildNotContained`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactBase](#T-GetcuReone-FactFactory-FactBase 'GetcuReone.FactFactory.FactBase')
  - [AddParameter()](#M-GetcuReone-FactFactory-FactBase-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter- 'GetcuReone.FactFactory.FactBase.AddParameter(GetcuReone.FactFactory.Interfaces.IFactParameter)')
  - [GetFactType()](#M-GetcuReone-FactFactory-FactBase-GetFactType 'GetcuReone.FactFactory.FactBase.GetFactType')
  - [GetParameter()](#M-GetcuReone-FactFactory-FactBase-GetParameter-System-String- 'GetcuReone.FactFactory.FactBase.GetParameter(System.String)')
  - [GetParameters()](#M-GetcuReone-FactFactory-FactBase-GetParameters 'GetcuReone.FactFactory.FactBase.GetParameters')
- [FactBase\`1](#T-GetcuReone-FactFactory-FactBase`1 'GetcuReone.FactFactory.FactBase`1')
  - [#ctor(value)](#M-GetcuReone-FactFactory-FactBase`1-#ctor-`0- 'GetcuReone.FactFactory.FactBase`1.#ctor(`0)')
  - [Value](#P-GetcuReone-FactFactory-FactBase`1-Value 'GetcuReone.FactFactory.FactBase`1.Value')
  - [op_Implicit(fact)](#M-GetcuReone-FactFactory-FactBase`1-op_Implicit-GetcuReone-FactFactory-FactBase{`0}-~`0 'GetcuReone.FactFactory.FactBase`1.op_Implicit(GetcuReone.FactFactory.FactBase{`0})~`0')
- [FactFactory](#T-GetcuReone-FactFactory-FactFactory 'GetcuReone.FactFactory.FactFactory')
  - [#ctor()](#M-GetcuReone-FactFactory-FactFactory-#ctor 'GetcuReone.FactFactory.FactFactory.#ctor')
  - [#ctor(getDefaultFactsFunc)](#M-GetcuReone-FactFactory-FactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}- 'GetcuReone.FactFactory.FactFactory.#ctor(System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}})')
  - [Rules](#P-GetcuReone-FactFactory-FactFactory-Rules 'GetcuReone.FactFactory.FactFactory.Rules')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-FactFactory-GetDefaultContainer 'GetcuReone.FactFactory.FactFactory.GetDefaultContainer')
  - [GetDefaultFacts()](#M-GetcuReone-FactFactory-FactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}- 'GetcuReone.FactFactory.FactFactory.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer})')
- [FactFactoryBase\`4](#T-GetcuReone-FactFactory-FactFactoryBase`4 'GetcuReone.FactFactory.FactFactoryBase`4')
  - [Rules](#P-GetcuReone-FactFactory-FactFactoryBase`4-Rules 'GetcuReone.FactFactory.FactFactoryBase`4.Rules')
  - [WantFactsInfos](#P-GetcuReone-FactFactory-FactFactoryBase`4-WantFactsInfos 'GetcuReone.FactFactory.FactFactoryBase`4.WantFactsInfos')
  - [Derive()](#M-GetcuReone-FactFactory-FactFactoryBase`4-Derive 'GetcuReone.FactFactory.FactFactoryBase`4.Derive')
  - [DeriveAsync()](#M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveAsync 'GetcuReone.FactFactory.FactFactoryBase`4.DeriveAsync')
  - [DeriveFactAsync\`\`1(container)](#M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveFactAsync``1-`3- 'GetcuReone.FactFactory.FactFactoryBase`4.DeriveFactAsync``1(`3)')
  - [DeriveFact\`\`1(container)](#M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveFact``1-`3- 'GetcuReone.FactFactory.FactFactoryBase`4.DeriveFact``1(`3)')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetDefaultContainer 'GetcuReone.FactFactory.FactFactoryBase`4.GetDefaultContainer')
  - [GetDefaultFacts(context)](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{`2,`3}- 'GetcuReone.FactFactory.FactFactoryBase`4.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{`2,`3})')
  - [GetFacade\`\`1()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetFacade``1 'GetcuReone.FactFactory.FactFactoryBase`4.GetFacade``1')
  - [GetFactEngine()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetFactEngine 'GetcuReone.FactFactory.FactFactoryBase`4.GetFactEngine')
  - [GetFactTypeCache()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetFactTypeCache 'GetcuReone.FactFactory.FactFactoryBase`4.GetFactTypeCache')
  - [GetSingleEntityOperations()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetSingleEntityOperations 'GetcuReone.FactFactory.FactFactoryBase`4.GetSingleEntityOperations')
  - [GetSingleEntityOperationsOnce()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetSingleEntityOperationsOnce 'GetcuReone.FactFactory.FactFactoryBase`4.GetSingleEntityOperationsOnce')
  - [GetTreeBuildingOperations()](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetTreeBuildingOperations 'GetcuReone.FactFactory.FactFactoryBase`4.GetTreeBuildingOperations')
  - [WantFacts(wantAction,container)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts-`2,`3- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts(`2,`3)')
  - [WantFacts\`\`1(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``1-System-Action{``0},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``1(System.Action{``0},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`1(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``1(System.Func{``0,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``10(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``10(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``11(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``11(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``12(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``12(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``13(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``13(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``14(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``14(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``15(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``15(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``16(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``16(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``2-System-Action{``0,``1},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``2(System.Action{``0,``1},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``2(System.Func{``0,``1,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``3-System-Action{``0,``1,``2},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``3(System.Action{``0,``1,``2},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``3(System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``4-System-Action{``0,``1,``2,``3},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``4(System.Action{``0,``1,``2,``3},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``4(System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``5-System-Action{``0,``1,``2,``3,``4},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``5(System.Action{``0,``1,``2,``3,``4},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``5(System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``6(System.Action{``0,``1,``2,``3,``4,``5},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``6(System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``7(System.Action{``0,``1,``2,``3,``4,``5,``6},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``7(System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``8(System.Action{``0,``1,``2,``3,``4,``5,``6,``7},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``8(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactAction,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``9(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.FactFactoryBase`4.WantFacts``9(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask},`3,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [RCanDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCanDerived`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCanDerived`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
- [RCannotDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCannotDerived`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCannotDerived`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
- [RContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RContained`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RContained`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
- [RNotContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RNotContained`1')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RNotContained`1.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
- [RuntimeConditionFactBase](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase')
  - [Condition\`\`4()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
  - [SetGetRelatedRulesFunc\`\`3()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-SetGetRelatedRulesFunc``3-System-Func{``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}},``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase.SetGetRelatedRulesFunc``3(System.Func{``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}},``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0})')
  - [TryGetRelatedRules\`\`3()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-TryGetRelatedRules``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}@- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase.TryGetRelatedRules``3(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}@)')
- [RuntimeConditionFactBase\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase`1')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase`1-GetFactType``1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RuntimeConditionFactBase`1.GetFactType``1')
- [SpecialFactBase](#T-GetcuReone-FactFactory-SpecialFacts-SpecialFactBase 'GetcuReone.FactFactory.SpecialFacts.SpecialFactBase')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-SpecialFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.SpecialFactBase.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')

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

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1'></a>
## BuildCanDerived\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

Fact condition that checks if a tree can be built for the fact `TFact` at the tree building stage.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a tree can be built for the fact.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1'></a>
## BuildCannotDerived\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

A fact condition that tests whether a tree cannot be built for the `TFact` fact at the tree building stage.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a tree cannot be built for the `TFact` fact.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase'></a>
## BuildConditionFactBase `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

Base class for [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase`1'></a>
## BuildConditionFactBase\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

*Inherit from parent.*

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildConditionFactBase`1-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1'></a>
## BuildContained\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

Fact condition. Checks if a `TFact` fact can be retrieved from a container at the tree building stage.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact can be retrieved from a container.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1'></a>
## BuildNotContained\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

Fact condition. Checks if a `TFact` fact cannot be retrieved from a container at the tree building stage.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact cannot be retrieved from a container.

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

<a name='T-GetcuReone-FactFactory-FactBase'></a>
## FactBase `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Base class for fact.

<a name='M-GetcuReone-FactFactory-FactBase-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter-'></a>
### AddParameter() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactBase-GetFactType'></a>
### GetFactType() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactBase-GetParameter-System-String-'></a>
### GetParameter() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactBase-GetParameters'></a>
### GetParameters() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-FactBase`1'></a>
## FactBase\`1 `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

*Inherit from parent.*

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactValue | Type fact value. |

<a name='M-GetcuReone-FactFactory-FactBase`1-#ctor-`0-'></a>
### #ctor(value) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`0](#T-`0 '`0') | Fact value. |

<a name='P-GetcuReone-FactFactory-FactBase`1-Value'></a>
### Value `property`

##### Summary

Value fact.

<a name='M-GetcuReone-FactFactory-FactBase`1-op_Implicit-GetcuReone-FactFactory-FactBase{`0}-~`0'></a>
### op_Implicit(fact) `method`

##### Summary

Extracts [Value](#P-GetcuReone-FactFactory-FactBase`1-Value 'GetcuReone.FactFactory.FactBase`1.Value').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.FactBase{\`0})~\`0](#T-GetcuReone-FactFactory-FactBase{`0}-~`0 'GetcuReone.FactFactory.FactBase{`0})~`0') | Fact. |

<a name='T-GetcuReone-FactFactory-FactFactory'></a>
## FactFactory `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Factory default implementation.

<a name='M-GetcuReone-FactFactory-FactFactory-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}-'></a>
### #ctor(getDefaultFactsFunc) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| getDefaultFactsFunc | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{GetcuReone.FactFactory.Entities.WantAction,GetcuReone.FactFactory.Entities.FactContainer},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Function that returns a list of facts by default. |

<a name='P-GetcuReone-FactFactory-FactFactory-Rules'></a>
### Rules `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-FactFactory-GetDefaultContainer'></a>
### GetDefaultContainer() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{GetcuReone-FactFactory-Entities-WantAction,GetcuReone-FactFactory-Entities-FactContainer}-'></a>
### GetDefaultFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-FactFactoryBase`4'></a>
## FactFactoryBase\`4 `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Base class for fact factory.

<a name='P-GetcuReone-FactFactory-FactFactoryBase`4-Rules'></a>
### Rules `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-FactFactoryBase`4-WantFactsInfos'></a>
### WantFactsInfos `property`

##### Summary

WantFacts.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-Derive'></a>
### Derive() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveAsync'></a>
### DeriveAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveFactAsync``1-`3-'></a>
### DeriveFactAsync\`\`1(container) `method`

##### Summary

Derive `TFactResult`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [\`3](#T-`3 '`3') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-DeriveFact``1-`3-'></a>
### DeriveFact\`\`1(container) `method`

##### Summary

Derive `TFactResult`.

##### Returns

Fact `TFactResult`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [\`3](#T-`3 '`3') | Fact container. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetDefaultContainer'></a>
### GetDefaultContainer() `method`

##### Summary

Returns default container.

##### Returns

Default container.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{`2,`3}-'></a>
### GetDefaultFacts(context) `method`

##### Summary

Returns the fact set that will be contained in the default container.

##### Returns

The set of facts added to the default container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`2,\`3}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{`2,`3} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{`2,`3}') | Context. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetFacade``1'></a>
### GetFacade\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetFactEngine'></a>
### GetFactEngine() `method`

##### Summary

Returns [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade').

##### Returns

Instanse [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetFactTypeCache'></a>
### GetFactTypeCache() `method`

##### Summary

Returns [FactTypeCache](#T-GetcuReone-FactFactory-BaseEntities-FactTypeCache 'GetcuReone.FactFactory.BaseEntities.FactTypeCache').

##### Returns

Instanse [FactTypeCache](#T-GetcuReone-FactFactory-BaseEntities-FactTypeCache 'GetcuReone.FactFactory.BaseEntities.FactTypeCache').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetSingleEntityOperations'></a>
### GetSingleEntityOperations() `method`

##### Summary

Returns [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade').

##### Returns

Instanse [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetSingleEntityOperationsOnce'></a>
### GetSingleEntityOperationsOnce() `method`

##### Summary

*Inherit from parent.*

##### Summary

Calls the [GetSingleEntityOperationsOnce](#M-GetcuReone-FactFactory-FactFactoryBase`4-GetSingleEntityOperationsOnce 'GetcuReone.FactFactory.FactFactoryBase`4.GetSingleEntityOperationsOnce') once.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-GetTreeBuildingOperations'></a>
### GetTreeBuildingOperations() `method`

##### Summary

Returns [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade').

##### Returns

Instanse [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts-`2,`3-'></a>
### WantFacts(wantAction,container) `method`

##### Summary

Requesting a desired fact through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [\`2](#T-`2 '`2') |  |
| container | [\`3](#T-`3 '`3') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | The action has already been requested before. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``1-System-Action{``0},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`1(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`1(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`10(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`10(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`11(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`11(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`12(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`12(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`13(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`13(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`14(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`14(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`15(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |
| TFact15 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`15(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |
| TFact15 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`16(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |
| TFact15 | Type fact. |
| TFact16 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`16(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |
| TFact10 | Type fact. |
| TFact11 | Type fact. |
| TFact12 | Type fact. |
| TFact13 | Type fact. |
| TFact14 | Type fact. |
| TFact15 | Type fact. |
| TFact16 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``2-System-Action{``0,``1},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`2(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`2(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``3-System-Action{``0,``1,``2},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`3(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`3(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``4-System-Action{``0,``1,``2,``3},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`4(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`4(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``5-System-Action{``0,``1,``2,``3,``4},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`5(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`5(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`6(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`6(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`7(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`7(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`8(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`8(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`9(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |

<a name='M-GetcuReone-FactFactory-FactFactoryBase`4-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},`3,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`9(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [\`3](#T-`3 '`3') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |
| TFact6 | Type fact. |
| TFact7 | Type fact. |
| TFact8 | Type fact. |
| TFact9 | Type fact. |

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

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1'></a>
## RCanDerived\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Fact condition that checks if a tree can be built for the fact `TFact`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact can be retrieved from a container.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1'></a>
## RCannotDerived\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Fact condition that checks if a tree can be built for the fact `TFact`.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact can be retrieved from a container.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1'></a>
## RContained\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Fact condition. Checks if a `TFact` fact can be retrieved from a container.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact can be retrieved from a container.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1'></a>
## RNotContained\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Fact condition. Checks if a `TFact` fact cannot be retrieved from a container.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact cannot be retrieved from a container.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase'></a>
## RuntimeConditionFactBase `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Base class for [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-SetGetRelatedRulesFunc``3-System-Func{``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}},``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}-'></a>
### SetGetRelatedRulesFunc\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase-TryGetRelatedRules``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}@-'></a>
### TryGetRelatedRules\`\`3() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase`1'></a>
## RuntimeConditionFactBase\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RuntimeConditionFactBase`1-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-SpecialFactBase'></a>
## SpecialFactBase `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts

##### Summary

Base class for [ISpecialFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-SpecialFactBase-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.
