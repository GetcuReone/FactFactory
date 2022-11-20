<a name='assembly'></a>
# GetcuReone.FactFactory.Main

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [BaseBuildConditionFact](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BaseBuildConditionFact')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BaseBuildConditionFact.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BaseBuildConditionFact.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
- [BaseBuildConditionFact\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BaseBuildConditionFact`1')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact`1-GetFactType``1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BaseBuildConditionFact`1.GetFactType``1')
- [BaseFact](#T-GetcuReone-FactFactory-BaseFact 'GetcuReone.FactFactory.BaseFact')
  - [AddParameter()](#M-GetcuReone-FactFactory-BaseFact-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter- 'GetcuReone.FactFactory.BaseFact.AddParameter(GetcuReone.FactFactory.Interfaces.IFactParameter)')
  - [GetFactType()](#M-GetcuReone-FactFactory-BaseFact-GetFactType 'GetcuReone.FactFactory.BaseFact.GetFactType')
  - [GetParameter()](#M-GetcuReone-FactFactory-BaseFact-GetParameter-System-String- 'GetcuReone.FactFactory.BaseFact.GetParameter(System.String)')
  - [GetParameters()](#M-GetcuReone-FactFactory-BaseFact-GetParameters 'GetcuReone.FactFactory.BaseFact.GetParameters')
- [BaseFactFactory](#T-GetcuReone-FactFactory-BaseFactFactory 'GetcuReone.FactFactory.BaseFactFactory')
  - [Rules](#P-GetcuReone-FactFactory-BaseFactFactory-Rules 'GetcuReone.FactFactory.BaseFactFactory.Rules')
  - [WantFactsInfos](#P-GetcuReone-FactFactory-BaseFactFactory-WantFactsInfos 'GetcuReone.FactFactory.BaseFactFactory.WantFactsInfos')
  - [Derive()](#M-GetcuReone-FactFactory-BaseFactFactory-Derive 'GetcuReone.FactFactory.BaseFactFactory.Derive')
  - [DeriveAsync()](#M-GetcuReone-FactFactory-BaseFactFactory-DeriveAsync 'GetcuReone.FactFactory.BaseFactFactory.DeriveAsync')
  - [DeriveFactAsync\`\`1(container)](#M-GetcuReone-FactFactory-BaseFactFactory-DeriveFactAsync``1-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseFactFactory.DeriveFactAsync``1(GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [DeriveFact\`\`1(container)](#M-GetcuReone-FactFactory-BaseFactFactory-DeriveFact``1-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseFactFactory.DeriveFact``1(GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-BaseFactFactory-GetDefaultContainer 'GetcuReone.FactFactory.BaseFactFactory.GetDefaultContainer')
  - [GetDefaultFacts(context)](#M-GetcuReone-FactFactory-BaseFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.BaseFactFactory.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFacade\`\`1()](#M-GetcuReone-FactFactory-BaseFactFactory-GetFacade``1 'GetcuReone.FactFactory.BaseFactFactory.GetFacade``1')
  - [GetFactEngine()](#M-GetcuReone-FactFactory-BaseFactFactory-GetFactEngine 'GetcuReone.FactFactory.BaseFactFactory.GetFactEngine')
  - [GetFactParameterCache()](#M-GetcuReone-FactFactory-BaseFactFactory-GetFactParameterCache 'GetcuReone.FactFactory.BaseFactFactory.GetFactParameterCache')
  - [GetFactTypeCache()](#M-GetcuReone-FactFactory-BaseFactFactory-GetFactTypeCache 'GetcuReone.FactFactory.BaseFactFactory.GetFactTypeCache')
  - [GetSingleEntityOperations()](#M-GetcuReone-FactFactory-BaseFactFactory-GetSingleEntityOperations 'GetcuReone.FactFactory.BaseFactFactory.GetSingleEntityOperations')
  - [GetSingleEntityOperationsOnce()](#M-GetcuReone-FactFactory-BaseFactFactory-GetSingleEntityOperationsOnce 'GetcuReone.FactFactory.BaseFactFactory.GetSingleEntityOperationsOnce')
  - [GetTreeBuildingOperations()](#M-GetcuReone-FactFactory-BaseFactFactory-GetTreeBuildingOperations 'GetcuReone.FactFactory.BaseFactFactory.GetTreeBuildingOperations')
  - [WantFacts(wantAction,container)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts-GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts(GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [WantFacts\`\`1(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``1-System-Action{``0},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``1(System.Action{``0},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`1(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``1(System.Func{``0,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``10(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``10(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``11(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``11(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``12(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``12(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``13(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``13(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``14(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``14(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``15(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``15(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``16(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``16(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``2-System-Action{``0,``1},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``2(System.Action{``0,``1},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``2(System.Func{``0,``1,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``3-System-Action{``0,``1,``2},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``3(System.Action{``0,``1,``2},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``3(System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``4-System-Action{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``4(System.Action{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``4(System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``5-System-Action{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``5(System.Action{``0,``1,``2,``3,``4},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``5(System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``6(System.Action{``0,``1,``2,``3,``4,``5},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``6(System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``7(System.Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``7(System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``8(System.Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``8(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactAction,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``9(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseFactFactory.WantFacts``9(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
- [BaseFact\`1](#T-GetcuReone-FactFactory-BaseFact`1 'GetcuReone.FactFactory.BaseFact`1')
  - [#ctor(value)](#M-GetcuReone-FactFactory-BaseFact`1-#ctor-`0- 'GetcuReone.FactFactory.BaseFact`1.#ctor(`0)')
  - [Value](#P-GetcuReone-FactFactory-BaseFact`1-Value 'GetcuReone.FactFactory.BaseFact`1.Value')
  - [op_Implicit(fact)](#M-GetcuReone-FactFactory-BaseFact`1-op_Implicit-GetcuReone-FactFactory-BaseFact{`0}-~`0 'GetcuReone.FactFactory.BaseFact`1.op_Implicit(GetcuReone.FactFactory.BaseFact{`0})~`0')
- [BaseRuntimeConditionFact](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
  - [SetGetRelatedRulesFunc()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-SetGetRelatedRulesFunc-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection},GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact.SetGetRelatedRulesFunc(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection},GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection)')
  - [TryGetRelatedRules()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-TryGetRelatedRules-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection@- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact.TryGetRelatedRules(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection@)')
- [BaseRuntimeConditionFact\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact`1')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact`1-GetFactType``1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.BaseRuntimeConditionFact`1.GetFactType``1')
- [BaseSpecialFact](#T-GetcuReone-FactFactory-SpecialFacts-BaseSpecialFact 'GetcuReone.FactFactory.SpecialFacts.BaseSpecialFact')
  - [EqualsInfo()](#M-GetcuReone-FactFactory-SpecialFacts-BaseSpecialFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.SpecialFacts.BaseSpecialFact.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
- [BuildCanDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCanDerived`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCanDerived`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
- [BuildCannotDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCannotDerived`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildCannotDerived`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
- [BuildContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildContained`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildContained`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
- [BuildNotContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildNotContained`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.SpecialFacts.BuildCondition.BuildNotContained`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactFactory](#T-GetcuReone-FactFactory-FactFactory 'GetcuReone.FactFactory.FactFactory')
  - [#ctor()](#M-GetcuReone-FactFactory-FactFactory-#ctor 'GetcuReone.FactFactory.FactFactory.#ctor')
  - [#ctor(getDefaultFactsFunc)](#M-GetcuReone-FactFactory-FactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}- 'GetcuReone.FactFactory.FactFactory.#ctor(System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}})')
  - [Rules](#P-GetcuReone-FactFactory-FactFactory-Rules 'GetcuReone.FactFactory.FactFactory.Rules')
  - [GetDefaultContainer()](#M-GetcuReone-FactFactory-FactFactory-GetDefaultContainer 'GetcuReone.FactFactory.FactFactory.GetDefaultContainer')
  - [GetDefaultFacts()](#M-GetcuReone-FactFactory-FactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.FactFactory.GetDefaultFacts(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
- [FactFactoryExtensions](#T-GetcuReone-FactFactory-Extensions-FactFactoryExtensions 'GetcuReone.FactFactory.Extensions.FactFactoryExtensions')
  - [DeriveFactAsync\`\`1(factory,container)](#M-GetcuReone-FactFactory-Extensions-FactFactoryExtensions-DeriveFactAsync``1-GetcuReone-FactFactory-Interfaces-IFactFactory,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Extensions.FactFactoryExtensions.DeriveFactAsync``1(GetcuReone.FactFactory.Interfaces.IFactFactory,GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [DeriveFact\`\`1(factory,container)](#M-GetcuReone-FactFactory-Extensions-FactFactoryExtensions-DeriveFact``1-GetcuReone-FactFactory-Interfaces-IFactFactory,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Extensions.FactFactoryExtensions.DeriveFact``1(GetcuReone.FactFactory.Interfaces.IFactFactory,GetcuReone.FactFactory.Interfaces.IFactContainer)')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [RCanDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCanDerived`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCanDerived`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
- [RCannotDerived\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCannotDerived`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RCannotDerived`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
- [RContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RContained`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RContained`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
- [RNotContained\`1](#T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RNotContained`1')
  - [Condition()](#M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.SpecialFacts.RuntimeCondition.RNotContained`1.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')

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

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact'></a>
## BaseBuildConditionFact `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

Base class for [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact`1'></a>
## BaseBuildConditionFact\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.BuildCondition

##### Summary

*Inherit from parent.*

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | The type of fact for which the condition is met. |

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BaseBuildConditionFact`1-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseFact'></a>
## BaseFact `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Base class for fact.

<a name='M-GetcuReone-FactFactory-BaseFact-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter-'></a>
### AddParameter() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFact-GetFactType'></a>
### GetFactType() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFact-GetParameter-System-String-'></a>
### GetParameter() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFact-GetParameters'></a>
### GetParameters() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseFactFactory'></a>
## BaseFactFactory `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

Base class for fact factory.

<a name='P-GetcuReone-FactFactory-BaseFactFactory-Rules'></a>
### Rules `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseFactFactory-WantFactsInfos'></a>
### WantFactsInfos `property`

##### Summary

WantFacts.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-Derive'></a>
### Derive() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-DeriveAsync'></a>
### DeriveAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-DeriveFactAsync``1-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### DeriveFactAsync\`\`1(container) `method`

##### Summary

Derive `TFactResult`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-DeriveFact``1-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### DeriveFact\`\`1(container) `method`

##### Summary

Derive `TFactResult`.

##### Returns

Fact `TFactResult`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | Type of desired fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetDefaultContainer'></a>
### GetDefaultContainer() `method`

##### Summary

Returns default container.

##### Returns

Default container.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetDefaultFacts(context) `method`

##### Summary

Returns the fact set that will be contained in the default container.

##### Returns

The set of facts added to the default container

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetFacade``1'></a>
### GetFacade\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetFactEngine'></a>
### GetFactEngine() `method`

##### Summary

Returns [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade').

##### Returns

Instanse [FactEngineFacade](#T-GetcuReone-FactFactory-Facades-FactEngine-FactEngineFacade 'GetcuReone.FactFactory.Facades.FactEngine.FactEngineFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetFactParameterCache'></a>
### GetFactParameterCache() `method`

##### Summary

Returns [IFactParameterCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactParameterCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactParameterCache')

##### Returns

Instanse [IFactParameterCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactParameterCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactParameterCache').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetFactTypeCache'></a>
### GetFactTypeCache() `method`

##### Summary

Returns [FactTypeCache](#T-GetcuReone-FactFactory-BaseEntities-FactTypeCache 'GetcuReone.FactFactory.BaseEntities.FactTypeCache').

##### Returns

Instanse [FactTypeCache](#T-GetcuReone-FactFactory-BaseEntities-FactTypeCache 'GetcuReone.FactFactory.BaseEntities.FactTypeCache').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetSingleEntityOperations'></a>
### GetSingleEntityOperations() `method`

##### Summary

Returns [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade').

##### Returns

Instanse [SingleEntityOperationsFacade](#T-GetcuReone-FactFactory-Facades-SingleEntityOperations-SingleEntityOperationsFacade 'GetcuReone.FactFactory.Facades.SingleEntityOperations.SingleEntityOperationsFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetSingleEntityOperationsOnce'></a>
### GetSingleEntityOperationsOnce() `method`

##### Summary

*Inherit from parent.*

##### Summary

Calls the [GetSingleEntityOperationsOnce](#M-GetcuReone-FactFactory-BaseFactFactory-GetSingleEntityOperationsOnce 'GetcuReone.FactFactory.BaseFactFactory.GetSingleEntityOperationsOnce') once.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-GetTreeBuildingOperations'></a>
### GetTreeBuildingOperations() `method`

##### Summary

Returns [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade').

##### Returns

Instanse [TreeBuildingOperationsFacade](#T-GetcuReone-FactFactory-Facades-TreeBuildingOperations-TreeBuildingOperationsFacade 'GetcuReone.FactFactory.Facades.TreeBuildingOperations.TreeBuildingOperationsFacade').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts-GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### WantFacts(wantAction,container) `method`

##### Summary

Requesting a desired fact through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') |  |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | The action has already been requested before. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``1-System-Action{``0},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`1(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`1(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`10(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`10(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`11(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`11(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`12(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`12(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`13(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`13(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`14(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`14(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`15(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`15(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`16(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`16(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``2-System-Action{``0,``1},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`2(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`2(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``3-System-Action{``0,``1,``2},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`3(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`3(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``4-System-Action{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`4(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`4(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``5-System-Action{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`5(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`5(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork options. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact1 | Type fact. |
| TFact2 | Type fact. |
| TFact3 | Type fact. |
| TFact4 | Type fact. |
| TFact5 | Type fact. |

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`6(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`6(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`7(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`7(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`8(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`8(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`9(wantFactAction,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactAction | [System.Action{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='M-GetcuReone-FactFactory-BaseFactFactory-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### WantFacts\`\`9(wantFactActionAsync,container,option) `method`

##### Summary

Requesting desired facts through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantFactActionAsync | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask}') | Desired action. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |
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

<a name='T-GetcuReone-FactFactory-BaseFact`1'></a>
## BaseFact\`1 `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

*Inherit from parent.*

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactValue | Type fact value. |

<a name='M-GetcuReone-FactFactory-BaseFact`1-#ctor-`0-'></a>
### #ctor(value) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`0](#T-`0 '`0') | Fact value. |

<a name='P-GetcuReone-FactFactory-BaseFact`1-Value'></a>
### Value `property`

##### Summary

Value fact.

<a name='M-GetcuReone-FactFactory-BaseFact`1-op_Implicit-GetcuReone-FactFactory-BaseFact{`0}-~`0'></a>
### op_Implicit(fact) `method`

##### Summary

Extracts [Value](#P-GetcuReone-FactFactory-BaseFact`1-Value 'GetcuReone.FactFactory.BaseFact`1.Value').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [GetcuReone.FactFactory.BaseFact{\`0})~\`0](#T-GetcuReone-FactFactory-BaseFact{`0}-~`0 'GetcuReone.FactFactory.BaseFact{`0})~`0') | Fact. |

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact'></a>
## BaseRuntimeConditionFact `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

Base class for [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-SetGetRelatedRulesFunc-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection},GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection-'></a>
### SetGetRelatedRulesFunc() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact-TryGetRelatedRules-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection@-'></a>
### TryGetRelatedRules() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact`1'></a>
## BaseRuntimeConditionFact\`1 `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts.RuntimeCondition

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-BaseRuntimeConditionFact`1-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-SpecialFacts-BaseSpecialFact'></a>
## BaseSpecialFact `type`

##### Namespace

GetcuReone.FactFactory.SpecialFacts

##### Summary

Base class for [ISpecialFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact').

<a name='M-GetcuReone-FactFactory-SpecialFacts-BaseSpecialFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCanDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildCannotDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a tree cannot be built for the `TFact` fact.

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-BuildCondition-BuildNotContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-FactFactory-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}}-'></a>
### #ctor(getDefaultFactsFunc) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| getDefaultFactsFunc | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Function that returns a list of facts by default. |

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

<a name='M-GetcuReone-FactFactory-FactFactory-GetDefaultFacts-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetDefaultFacts() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Extensions-FactFactoryExtensions'></a>
## FactFactoryExtensions `type`

##### Namespace

GetcuReone.FactFactory.Extensions

##### Summary

Extensions methods for [IFactFactory](#T-GetcuReone-FactFactory-Interfaces-IFactFactory 'GetcuReone.FactFactory.Interfaces.IFactFactory').

<a name='M-GetcuReone-FactFactory-Extensions-FactFactoryExtensions-DeriveFactAsync``1-GetcuReone-FactFactory-Interfaces-IFactFactory,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### DeriveFactAsync\`\`1(factory,container) `method`

##### Summary

Derive `TFactResult`.

##### Returns

Requested fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factory | [GetcuReone.FactFactory.Interfaces.IFactFactory](#T-GetcuReone-FactFactory-Interfaces-IFactFactory 'GetcuReone.FactFactory.Interfaces.IFactFactory') | Fact factory. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | The type of fact to get. |

<a name='M-GetcuReone-FactFactory-Extensions-FactFactoryExtensions-DeriveFact``1-GetcuReone-FactFactory-Interfaces-IFactFactory,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### DeriveFact\`\`1(factory,container) `method`

##### Summary

Derive `TFactResult`.

##### Returns

Requested fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factory | [GetcuReone.FactFactory.Interfaces.IFactFactory](#T-GetcuReone-FactFactory-Interfaces-IFactFactory 'GetcuReone.FactFactory.Interfaces.IFactFactory') | Fact factory. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactResult | The type of fact to get. |

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCanDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RCannotDerived`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition() `method`

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

<a name='M-GetcuReone-FactFactory-SpecialFacts-RuntimeCondition-RNotContained`1-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition() `method`

##### Summary

*Inherit from parent.*

##### Summary

Checks if a `TFact` fact cannot be retrieved from a container.

##### Parameters

This method has no parameters.
