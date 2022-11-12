<a name='assembly'></a>
# GetcuReone.FactFactory.Interfaces

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [BuildTreeForFactInfoRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest.Context')
  - [WantFactType](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest-WantFactType 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest.WantFactType')
- [BuildTreesForWantActionRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest.Context')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest-FactRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest.FactRules')
- [BuildTreesForWantActionResult](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult')
  - [DeriveErrorDetail](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-DeriveErrorDetail 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult.DeriveErrorDetail')
  - [TreesResult](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-TreesResult 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult.TreesResult')
  - [WantActionInfo](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult.WantActionInfo')
- [BuildTreesRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-FactRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest.FactRules')
  - [Filters](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-Filters 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest.Filters')
  - [WantActionContexts](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-WantActionContexts 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest.WantActionContexts')
- [BuildTreesResult](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult')
  - [DeriveErrorDetails](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult-DeriveErrorDetails 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult.DeriveErrorDetails')
  - [TreesByActions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult-TreesByActions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult.TreesByActions')
- [DeriveErrorDetail](#T-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail')
  - [#ctor(code,reason,requiredAction,container,requiredFacts)](#M-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-#ctor-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}- 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.#ctor(System.String,System.String,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer,System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail})')
  - [Container](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-Container 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.Container')
  - [RequiredAction](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredAction 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.RequiredAction')
  - [RequiredFacts](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredFacts 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.RequiredFacts')
- [DeriveFactErrorDetail](#T-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail')
  - [#ctor(requiredFact,needFacts)](#M-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-#ctor-GetcuReone-FactFactory-Interfaces-IFactType,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Interfaces-IFactType}- 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.#ctor(GetcuReone.FactFactory.Interfaces.IFactType,System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Interfaces.IFactType})')
  - [NeedFacts](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-NeedFacts 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.NeedFacts')
  - [RequiredFact](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-RequiredFact 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.RequiredFact')
- [DeriveWantActionRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest.Context')
  - [Rules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest-Rules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest.Rules')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [ErrorDetail](#T-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail 'GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail')
  - [#ctor(code,reason)](#M-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-#ctor-System-String,System-String- 'GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail.#ctor(System.String,System.String)')
  - [Code](#P-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-Code 'GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail.Code')
  - [Reason](#P-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-Reason 'GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail.Reason')
  - [ToString()](#M-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-ToString 'GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail.ToString')
- [FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException')
  - [#ctor()](#M-GetcuReone-FactFactory-Exceptions-FactFactoryException-#ctor-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail}- 'GetcuReone.FactFactory.Exceptions.FactFactoryException.#ctor(System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.ErrorDetail})')
- [FactFactoryExceptionBase\`1](#T-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1 'GetcuReone.FactFactory.Exceptions.FactFactoryExceptionBase`1')
  - [#ctor(details)](#M-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1-#ctor-System-Collections-Generic-IReadOnlyCollection{`0}- 'GetcuReone.FactFactory.Exceptions.FactFactoryExceptionBase`1.#ctor(System.Collections.Generic.IReadOnlyCollection{`0})')
  - [Details](#P-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1-Details 'GetcuReone.FactFactory.Exceptions.FactFactoryExceptionBase`1.Details')
- [FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption')
  - [CanExcecuteParallel](#F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExcecuteParallel 'GetcuReone.FactFactory.Interfaces.FactWorkOption.CanExcecuteParallel')
  - [CanExecuteAsync](#F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExecuteAsync 'GetcuReone.FactFactory.Interfaces.FactWorkOption.CanExecuteAsync')
  - [CanExecuteSync](#F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExecuteSync 'GetcuReone.FactFactory.Interfaces.FactWorkOption.CanExecuteSync')
- [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact')
  - [Condition(factWork,getCompatibleRules,context)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection})')
- [ICopy\`1](#T-GetcuReone-FactFactory-Interfaces-ICopy`1 'GetcuReone.FactFactory.Interfaces.ICopy`1')
  - [Copy()](#M-GetcuReone-FactFactory-Interfaces-ICopy`1-Copy 'GetcuReone.FactFactory.Interfaces.ICopy`1.Copy')
- [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')
  - [AddParameter(parameter)](#M-GetcuReone-FactFactory-Interfaces-IFact-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter- 'GetcuReone.FactFactory.Interfaces.IFact.AddParameter(GetcuReone.FactFactory.Interfaces.IFactParameter)')
  - [GetFactType()](#M-GetcuReone-FactFactory-Interfaces-IFact-GetFactType 'GetcuReone.FactFactory.Interfaces.IFact.GetFactType')
  - [GetParameter(parameterCode)](#M-GetcuReone-FactFactory-Interfaces-IFact-GetParameter-System-String- 'GetcuReone.FactFactory.Interfaces.IFact.GetParameter(System.String)')
  - [GetParameters()](#M-GetcuReone-FactFactory-Interfaces-IFact-GetParameters 'GetcuReone.FactFactory.Interfaces.IFact.GetParameters')
- [IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer')
  - [Comparer](#P-GetcuReone-FactFactory-Interfaces-IFactContainer-Comparer 'GetcuReone.FactFactory.Interfaces.IFactContainer.Comparer')
  - [EqualityComparer](#P-GetcuReone-FactFactory-Interfaces-IFactContainer-EqualityComparer 'GetcuReone.FactFactory.Interfaces.IFactContainer.EqualityComparer')
  - [IsReadOnly](#P-GetcuReone-FactFactory-Interfaces-IFactContainer-IsReadOnly 'GetcuReone.FactFactory.Interfaces.IFactContainer.IsReadOnly')
  - [AddRange(facts)](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IFactContainer.AddRange(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [Add\`\`1(fact)](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Add``1-``0- 'GetcuReone.FactFactory.Interfaces.IFactContainer.Add``1(``0)')
  - [Clear()](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Clear 'GetcuReone.FactFactory.Interfaces.IFactContainer.Clear')
  - [Contains\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Contains``1 'GetcuReone.FactFactory.Interfaces.IFactContainer.Contains``1')
  - [Contains\`\`1(fact)](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Contains``1-``0- 'GetcuReone.FactFactory.Interfaces.IFactContainer.Contains``1(``0)')
  - [GetFact\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-GetFact``1 'GetcuReone.FactFactory.Interfaces.IFactContainer.GetFact``1')
  - [Remove\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Remove``1 'GetcuReone.FactFactory.Interfaces.IFactContainer.Remove``1')
  - [Remove\`\`1(fact)](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-Remove``1-``0- 'GetcuReone.FactFactory.Interfaces.IFactContainer.Remove``1(``0)')
  - [TryGetFact\`\`1(fact)](#M-GetcuReone-FactFactory-Interfaces-IFactContainer-TryGetFact``1-``0@- 'GetcuReone.FactFactory.Interfaces.IFactContainer.TryGetFact``1(``0@)')
- [IFactEngine](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine 'GetcuReone.FactFactory.Interfaces.Operations.IFactEngine')
  - [DeriveWantAction(requests)](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantAction-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest}- 'GetcuReone.FactFactory.Interfaces.Operations.IFactEngine.DeriveWantAction(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest})')
  - [DeriveWantActionAsync(requests)](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantActionAsync-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest}- 'GetcuReone.FactFactory.Interfaces.Operations.IFactEngine.DeriveWantActionAsync(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest})')
- [IFactFactory](#T-GetcuReone-FactFactory-Interfaces-IFactFactory 'GetcuReone.FactFactory.Interfaces.IFactFactory')
  - [Rules](#P-GetcuReone-FactFactory-Interfaces-IFactFactory-Rules 'GetcuReone.FactFactory.Interfaces.IFactFactory.Rules')
  - [Derive()](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-Derive 'GetcuReone.FactFactory.Interfaces.IFactFactory.Derive')
  - [DeriveAsync()](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-DeriveAsync 'GetcuReone.FactFactory.Interfaces.IFactFactory.DeriveAsync')
  - [WantFacts(wantAction,container)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts-GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts(GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [WantFacts\`\`1(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``1-System-Action{``0},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``1(System.Action{``0},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`1(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``1(System.Func{``0,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``10(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`10(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``10(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``11(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`11(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``11(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``12(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`12(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``12(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``13(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`13(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``13(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``14(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`14(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``14(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``15(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`15(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``15(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``16(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`16(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``16(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``2-System-Action{``0,``1},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``2(System.Action{``0,``1},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`2(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``2(System.Func{``0,``1,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``3-System-Action{``0,``1,``2},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``3(System.Action{``0,``1,``2},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`3(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``3(System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``4-System-Action{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``4(System.Action{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`4(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``4(System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``5-System-Action{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``5(System.Action{``0,``1,``2,``3,``4},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`5(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``5(System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``6(System.Action{``0,``1,``2,``3,``4,``5},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`6(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``6(System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``7(System.Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`7(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``7(System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``8(System.Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`8(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``8(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactAction,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``9(System.Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [WantFacts\`\`9(wantFactActionAsync,container,option)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.IFactFactory.WantFacts``9(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask},GetcuReone.FactFactory.Interfaces.IFactContainer,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
- [IFactFactoryContext](#T-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext')
  - [Cache](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Cache 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.Cache')
  - [Engine](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Engine 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.Engine')
  - [SingleEntity](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-SingleEntity 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.SingleEntity')
  - [TreeBuilding](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-TreeBuilding 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.TreeBuilding')
- [IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter')
  - [Code](#P-GetcuReone-FactFactory-Interfaces-IFactParameter-Code 'GetcuReone.FactFactory.Interfaces.IFactParameter.Code')
  - [Value](#P-GetcuReone-FactFactory-Interfaces-IFactParameter-Value 'GetcuReone.FactFactory.Interfaces.IFactParameter.Value')
- [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule')
  - [OutputFactType](#P-GetcuReone-FactFactory-Interfaces-IFactRule-OutputFactType 'GetcuReone.FactFactory.Interfaces.IFactRule.OutputFactType')
  - [Calculate(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IFactRule-Calculate-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IFactRule.Calculate(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [CalculateAsync(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IFactRule-CalculateAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IFactRule.CalculateAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
- [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection')
  - [IsReadOnly](#P-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-IsReadOnly 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection.IsReadOnly')
  - [AddRange(rules)](#M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}- 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection.AddRange(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule})')
  - [FindAll(predicate)](#M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-FindAll-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,System-Boolean}- 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection.FindAll(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,System.Boolean})')
  - [SortByDescending\`\`1(keySelector,comparer)](#M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-SortByDescending``1-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,``0},System-Collections-Generic-IComparer{``0}- 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection.SortByDescending``1(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,``0},System.Collections.Generic.IComparer{``0})')
- [IFactRulesContext](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-FactRules 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext.FactRules')
- [IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType')
  - [FactName](#P-GetcuReone-FactFactory-Interfaces-IFactType-FactName 'GetcuReone.FactFactory.Interfaces.IFactType.FactName')
  - [CreateBuildConditionFact\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactType-CreateBuildConditionFact``1 'GetcuReone.FactFactory.Interfaces.IFactType.CreateBuildConditionFact``1')
  - [CreateRuntimeConditionFact\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactType-CreateRuntimeConditionFact``1 'GetcuReone.FactFactory.Interfaces.IFactType.CreateRuntimeConditionFact``1')
  - [EqualsFactType\`\`1(factInfo)](#M-GetcuReone-FactFactory-Interfaces-IFactType-EqualsFactType``1-``0- 'GetcuReone.FactFactory.Interfaces.IFactType.EqualsFactType``1(``0)')
  - [IsFactType\`\`1()](#M-GetcuReone-FactFactory-Interfaces-IFactType-IsFactType``1 'GetcuReone.FactFactory.Interfaces.IFactType.IsFactType``1')
- [IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache')
  - [GetFactType\`\`1(fact)](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-GetFactType``1-``0- 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache.GetFactType``1(``0)')
- [IFactTypeCreation](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCreation 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCreation')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCreation-GetFactType``1 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCreation.GetFactType``1')
- [IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork')
  - [InputFactTypes](#P-GetcuReone-FactFactory-Interfaces-IFactWork-InputFactTypes 'GetcuReone.FactFactory.Interfaces.IFactWork.InputFactTypes')
  - [Option](#P-GetcuReone-FactFactory-Interfaces-IFactWork-Option 'GetcuReone.FactFactory.Interfaces.IFactWork.Option')
  - [EqualsWork(workFact,wantAction,container)](#M-GetcuReone-FactFactory-Interfaces-IFactWork-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Interfaces.IFactWork.EqualsWork(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
- [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact')
  - [Condition(factWork,context)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.Condition(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext)')
  - [SetGetRelatedRulesFunc(getRelatedRulesFunc,rule,rules)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-SetGetRelatedRulesFunc-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection},GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.SetGetRelatedRulesFunc(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection},GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection)')
  - [TryGetRelatedRules(context,relatedRules)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-TryGetRelatedRules-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection@- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.TryGetRelatedRules(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection@)')
- [ISingleEntityOperations](#T-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations')
  - [CalculateFact(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CalculateFactAsync(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CalculateFactAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CanExtractFact(factType,factWork,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CanExtractFact-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CanExtractFact(GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CompatibleRule(target,rule,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CompatibleRule-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CompatibleRule(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [CreateWantAction(wantAction,factTypes,option)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CreateWantAction(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CreateWantAction(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [DeriveWantFacts(wantActionInfo)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.DeriveWantFacts(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo)')
  - [DeriveWantFactsAsync(wantActionInfo)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.DeriveWantFactsAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo)')
  - [GetCompatibleRules(target,factRules,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetCompatibleRules-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetCompatibleRules(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFactComparer()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetFactComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetFactEqualityComparer()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactEqualityComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetFactEqualityComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRequiredTypesOfFacts(factWork,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRequiredTypesOfFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetRequiredTypesOfFacts(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [GetRuleComparer(context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRuleComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetRuleComparer(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [NeedCalculateFact(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-NeedCalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.NeedCalculateFact(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext)')
  - [ValidateAndGetRules(ruleCollection)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateAndGetRules-GetcuReone-FactFactory-Interfaces-IFactRuleCollection- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.ValidateAndGetRules(GetcuReone.FactFactory.Interfaces.IFactRuleCollection)')
  - [ValidateContainer(container)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateContainer-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.ValidateContainer(GetcuReone.FactFactory.Interfaces.IFactContainer)')
- [ISpecialFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact')
  - [EqualsInfo(specialFact)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
- [ITreeBuildingOperations](#T-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations')
  - [CalculateTreeAndDeriveWantFacts(wantActionInfo,treeByFactRules)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.CalculateTreeAndDeriveWantFacts(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule})')
  - [CalculateTreeAndDeriveWantFactsAsync(wantActionInfo,treeByFactRules)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.CalculateTreeAndDeriveWantFactsAsync(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo,System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule})')
  - [GetIndependentNodeGroups(treeByFactRule)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-GetIndependentNodeGroups-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.GetIndependentNodeGroups(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule)')
  - [TryBuildTreeForFactInfo(request,treeResult,deriveFactErrorDetails)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreeForFactInfo(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest,GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)')
  - [TryBuildTreesForWantAction(request,result)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreesForWantAction-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreesForWantAction(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest,GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult@)')
- [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction')
  - [AddUsedRule(rule)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-AddUsedRule-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.Interfaces.IWantAction.AddUsedRule(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [GetUsedRules()](#M-GetcuReone-FactFactory-Interfaces-IWantAction-GetUsedRules 'GetcuReone.FactFactory.Interfaces.IWantAction.GetUsedRules')
  - [Invoke(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-Invoke-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IWantAction.Invoke(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [InvokeAsync(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-InvokeAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IWantAction.InvokeAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
- [IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext')
  - [Container](#P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-Container 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext.Container')
  - [WantAction](#P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-WantAction 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext.WantAction')
- [IndependentNodeGroup](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup')
  - [#ctor()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-#ctor 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup.#ctor')
  - [#ctor()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}- 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule})')
  - [CanAdd(node)](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-CanAdd-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule- 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup.CanAdd(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule)')
- [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException')
  - [#ctor()](#M-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException-#ctor-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail}- 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException.#ctor(System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule')
  - [Childs](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Childs 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule.Childs')
  - [Info](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Info 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule.Info')
  - [Parent](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Parent 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule.Parent')
- [NodeByFactRuleInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo')
  - [BuildFailedConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-BuildFailedConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.BuildFailedConditions')
  - [BuildSuccessConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-BuildSuccessConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.BuildSuccessConditions')
  - [CompatibleRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-CompatibleRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.CompatibleRules')
  - [RequiredFactTypes](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-RequiredFactTypes 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.RequiredFactTypes')
  - [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.Rule')
  - [RuntimeConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-RuntimeConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.RuntimeConditions')
  - [ToString()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-ToString 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.ToString')
- [TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Context')
  - [Levels](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Levels 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Levels')
  - [NodeInfos](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-NodeInfos 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.NodeInfos')
  - [Root](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Root 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Root')
  - [Status](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Status 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Status')
  - [Built()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Built 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Built')
  - [Cencel()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Cencel 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule.Cencel')
- [TreeStatus](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus')
  - [BeingBuilt](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-BeingBuilt 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.BeingBuilt')
  - [Built](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Built 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.Built')
  - [Cencel](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Cencel 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.Cencel')
- [WantActionInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo')
  - [BuildFailedConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-BuildFailedConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.BuildFailedConditions')
  - [BuildSuccessConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-BuildSuccessConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.BuildSuccessConditions')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.Context')
  - [RuntimeConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-RuntimeConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.RuntimeConditions')
- [WantFactsInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo')
  - [Container](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo-Container 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo.Container')
  - [WantAction](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo-WantAction 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo.WantAction')

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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest'></a>
## BuildTreeForFactInfoRequest `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request for [TryBuildTreeForFactInfo](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreeForFactInfo(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest,GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest-WantFactType'></a>
### WantFactType `property`

##### Summary

The type of fact for which you want to build a tree.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest'></a>
## BuildTreesForWantActionRequest `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest-FactRules'></a>
### FactRules `property`

##### Summary

Fact rules.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult'></a>
## BuildTreesForWantActionResult `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Result.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-DeriveErrorDetail'></a>
### DeriveErrorDetail `property`

##### Summary

Errors that occurred while building a tree.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-TreesResult'></a>
### TreesResult `property`

##### Summary

Build trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult-WantActionInfo'></a>
### WantActionInfo `property`

##### Summary

WantAction info.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest'></a>
## BuildTreesRequest `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-FactRules'></a>
### FactRules `property`

##### Summary

List of rules that take part in the construction of trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-Filters'></a>
### Filters `property`

##### Summary

Filter for WantAction and FactRule.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest-WantActionContexts'></a>
### WantActionContexts `property`

##### Summary

The contexts within which to build trees.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult'></a>
## BuildTreesResult `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Result.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult-DeriveErrorDetails'></a>
### DeriveErrorDetails `property`

##### Summary

Errors when constructing trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult-TreesByActions'></a>
### TreesByActions `property`

##### Summary

Constructed trees by actions.

<a name='T-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail'></a>
## DeriveErrorDetail `type`

##### Namespace

GetcuReone.FactFactory.Exceptions.Entities

##### Summary

Detailed information about the calculation error action.

<a name='M-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-#ctor-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}-'></a>
### #ctor(code,reason,requiredAction,container,requiredFacts) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code. |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error reason. |
| requiredAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | Action for which it was not possible to derive the facts. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |
| requiredFacts | [System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}') | The facts that tried to derive. |

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-Container'></a>
### Container `property`

##### Summary

The container that was used for [RequiredAction](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredAction 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.RequiredAction').

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredAction'></a>
### RequiredAction `property`

##### Summary

Action for which it was not possible to derive the facts.

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredFacts'></a>
### RequiredFacts `property`

##### Summary

The facts that tried to derive.

<a name='T-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail'></a>
## DeriveFactErrorDetail `type`

##### Namespace

GetcuReone.FactFactory.Exceptions.Entities

##### Summary

Detailed fact calculation error information

<a name='M-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-#ctor-GetcuReone-FactFactory-Interfaces-IFactType,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Interfaces-IFactType}-'></a>
### #ctor(requiredFact,needFacts) `constructor`

##### Summary

Contsructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requiredFact | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | The fact that tried to derive. |
| needFacts | [System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Interfaces.IFactType}') | Facts that were not enough to derive. |

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-NeedFacts'></a>
### NeedFacts `property`

##### Summary

Facts that were not enough to derive.

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-RequiredFact'></a>
### RequiredFact `property`

##### Summary

The fact that tried to derive.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest'></a>
## DeriveWantActionRequest `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest-Context'></a>
### Context `property`

##### Summary

The context in which the calculations will be made.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest-Rules'></a>
### Rules `property`

##### Summary

Collection of rules used for calculations.

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

<a name='T-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail'></a>
## ErrorDetail `type`

##### Namespace

GetcuReone.FactFactory.Exceptions.Entities

##### Summary

Error detail.

<a name='M-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-#ctor-System-String,System-String-'></a>
### #ctor(code,reason) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error code. |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Error reason. |

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-Code'></a>
### Code `property`

##### Summary

Error code.

<a name='P-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-Reason'></a>
### Reason `property`

##### Summary

Error reason.

<a name='M-GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail-ToString'></a>
### ToString() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Exceptions-FactFactoryException'></a>
## FactFactoryException `type`

##### Namespace

GetcuReone.FactFactory.Exceptions

##### Summary

Base error for FactFactory

<a name='M-GetcuReone-FactFactory-Exceptions-FactFactoryException-#ctor-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-ErrorDetail}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='T-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1'></a>
## FactFactoryExceptionBase\`1 `type`

##### Namespace

GetcuReone.FactFactory.Exceptions

##### Summary

Base error for FactFactory.

<a name='M-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1-#ctor-System-Collections-Generic-IReadOnlyCollection{`0}-'></a>
### #ctor(details) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| details | [System.Collections.Generic.IReadOnlyCollection{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IReadOnlyCollection 'System.Collections.Generic.IReadOnlyCollection{`0}') |  |

<a name='P-GetcuReone-FactFactory-Exceptions-FactFactoryExceptionBase`1-Details'></a>
### Details `property`

##### Summary

More info exception.

<a name='T-GetcuReone-FactFactory-Interfaces-FactWorkOption'></a>
## FactWorkOption `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Options for [IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork').

<a name='F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExcecuteParallel'></a>
### CanExcecuteParallel `constants`

##### Summary

Work can be done asynchronously.

<a name='F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExecuteAsync'></a>
### CanExecuteAsync `constants`

##### Summary

Work can be done asynchronously.

<a name='F-GetcuReone-FactFactory-Interfaces-FactWorkOption-CanExecuteSync'></a>
### CanExecuteSync `constants`

##### Summary

Work can be done synchronously.

<a name='T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact'></a>
## IBuildConditionFact `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.SpecialFacts

##### Summary

A special fact that is created when building a tree. Used to check the condition.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection}-'></a>
### Condition(factWork,getCompatibleRules,context) `method`

##### Summary

A condition that determines whether the current fact can be added to the container when deriving.

##### Returns

Has the condition been met?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | Work for which we learn about the possibility of using the fact. |
| getCompatibleRules | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Func for get compatible rules. |
| context | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection}') | Context. |

##### Remarks

Using it, you can determine which rule and under what conditions can be used to build a rule tree.

<a name='T-GetcuReone-FactFactory-Interfaces-ICopy`1'></a>
## ICopy\`1 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Interface for copying objects.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TCopyObj | Type of object to copy. |

<a name='M-GetcuReone-FactFactory-Interfaces-ICopy`1-Copy'></a>
### Copy() `method`

##### Summary

Object copy method

##### Returns

Copied object.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Interfaces-IFact'></a>
## IFact `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact interface.

<a name='M-GetcuReone-FactFactory-Interfaces-IFact-AddParameter-GetcuReone-FactFactory-Interfaces-IFactParameter-'></a>
### AddParameter(parameter) `method`

##### Summary

Add parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameter | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |

<a name='M-GetcuReone-FactFactory-Interfaces-IFact-GetFactType'></a>
### GetFactType() `method`

##### Summary

Return fact information as an output parameter.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFact-GetParameter-System-String-'></a>
### GetParameter(parameterCode) `method`

##### Summary

Get parameter by code.

##### Returns

Fact parameter.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameterCode | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Parameter code. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFact-GetParameters'></a>
### GetParameters() `method`

##### Summary

Return parameters of a fact.

##### Returns

Fact parameters.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Interfaces-IFactContainer'></a>
## IFactContainer `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Container interface with facts for deriving other facts.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactContainer-Comparer'></a>
### Comparer `property`

##### Summary

[IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

<a name='P-GetcuReone-FactFactory-Interfaces-IFactContainer-EqualityComparer'></a>
### EqualityComparer `property`

##### Summary

[IEqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEqualityComparer`1 'System.Collections.Generic.IEqualityComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

<a name='P-GetcuReone-FactFactory-Interfaces-IFactContainer-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

Gets a value indicating whether the [IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') is read-only.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### AddRange(facts) `method`

##### Summary

Add facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Fact set. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Add``1-``0-'></a>
### Add\`\`1(fact) `method`

##### Summary

Add fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to add. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Clear'></a>
### Clear() `method`

##### Summary

Clear this container.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Contains``1'></a>
### Contains\`\`1() `method`

##### Summary

Is this type of fact contained.

##### Returns

Did you manage to get the fact?

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | type of fact to check for. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Contains``1-``0-'></a>
### Contains\`\`1(fact) `method`

##### Summary

Is this type of fact contained.

##### Returns

Is the fact contained?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | type of fact to check for. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-GetFact``1'></a>
### GetFact\`\`1() `method`

##### Summary

Get fact.

##### Returns

Fact.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to return. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Remove``1'></a>
### Remove\`\`1() `method`

##### Summary

Remove fact.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to delete. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-Remove``1-``0-'></a>
### Remove\`\`1(fact) `method`

##### Summary

Remove fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to delete. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactContainer-TryGetFact``1-``0@-'></a>
### TryGetFact\`\`1(fact) `method`

##### Summary

Try get fact.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0@](#T-``0@ '``0@') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to return. |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine'></a>
## IFactEngine `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Engine for calculating facts

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantAction-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest}-'></a>
### DeriveWantAction(requests) `method`

##### Summary

Build a trees and calculate facts for `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest}') | Requests. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantActionAsync-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest}-'></a>
### DeriveWantActionAsync(requests) `method`

##### Summary

Build a trees and calculate facts for `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest}') | Requests. |

<a name='T-GetcuReone-FactFactory-Interfaces-IFactFactory'></a>
## IFactFactory `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact factory interface.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactFactory-Rules'></a>
### Rules `property`

##### Summary

Collection of rules for derive facts.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-Derive'></a>
### Derive() `method`

##### Summary

Derive the facts.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-DeriveAsync'></a>
### DeriveAsync() `method`

##### Summary

Asynchronously derive the facts.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts-GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### WantFacts(wantAction,container) `method`

##### Summary

Requesting a desired fact through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | WantAction. |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') | Fact container. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``1-System-Action{``0},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``1-System-Func{``0,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``10-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``11-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``12-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``13-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``14-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``15-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``16-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``2-System-Action{``0,``1},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``2-System-Func{``0,``1,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``3-System-Action{``0,``1,``2},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``3-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``4-System-Action{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``4-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``5-System-Action{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``5-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``6-System-Action{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``6-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``7-System-Action{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``7-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``8-System-Action{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``9-System-Action{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory-WantFacts``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask},GetcuReone-FactFactory-Interfaces-IFactContainer,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
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

<a name='T-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext'></a>
## IFactFactoryContext `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Context

##### Summary

A context containing information within which current actions are taking place.

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Cache'></a>
### Cache `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Engine'></a>
### Engine `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-SingleEntity'></a>
### SingleEntity `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-TreeBuilding'></a>
### TreeBuilding `property`

##### Summary

*Inherit from parent.*

<a name='T-GetcuReone-FactFactory-Interfaces-IFactParameter'></a>
## IFactParameter `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact parameter.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactParameter-Code'></a>
### Code `property`

##### Summary

Parameter code.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactParameter-Value'></a>
### Value `property`

##### Summary

Parameter value.

<a name='T-GetcuReone-FactFactory-Interfaces-IFactRule'></a>
## IFactRule `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Rule of fact calculation.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactRule-OutputFactType'></a>
### OutputFactType `property`

##### Summary

Information on output fact.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRule-Calculate-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### Calculate(requireFacts) `method`

##### Summary

Calculate fact.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requireFacts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | The facts required for the calculation. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRule-CalculateAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### CalculateAsync(requireFacts) `method`

##### Summary

Calculate fact asynchronously.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requireFacts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Facts for calculation. |

<a name='T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection'></a>
## IFactRuleCollection `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Collection of rules.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

Gets a value indicating whether the [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') is read-only.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}-'></a>
### AddRange(rules) `method`

##### Summary

Adds the elements of the specified collection to the end of the [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}') | The collection whose elements should be added to the end of the  [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection'). 
The collection itself cannot be null, but it can contain elements that are null,
if type T is a reference type. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-FindAll-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,System-Boolean}-'></a>
### FindAll(predicate) `method`

##### Summary

Filters a sequence of values based on a predicate.

##### Returns

An [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') that contains elements from the input
sequence that satisfy the condition.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,System.Boolean}') | A function to test each element for a condition. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-SortByDescending``1-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,``0},System-Collections-Generic-IComparer{``0}-'></a>
### SortByDescending\`\`1(keySelector,comparer) `method`

##### Summary

Sorts the elements of a sequence in descending order according to a key.

##### Returns

An [IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') whose elements are sorted in
descending orderaccording to a key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keySelector | [System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,``0}') | A function to extract a key from an element. |
| comparer | [System.Collections.Generic.IComparer{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer 'System.Collections.Generic.IComparer{``0}') | An [IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') to compare keys. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey | The type of the key returned by keySelector. |

<a name='T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext'></a>
## IFactRulesContext `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-FactRules'></a>
### FactRules `property`

##### Summary

Fact rules in context.

<a name='T-GetcuReone-FactFactory-Interfaces-IFactType'></a>
## IFactType `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact type.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactType-FactName'></a>
### FactName `property`

##### Summary

Fact name.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactType-CreateBuildConditionFact``1'></a>
### CreateBuildConditionFact\`\`1() `method`

##### Summary

Create an fact of this type. Method created for [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact').

##### Returns

Instans fact.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactType-CreateRuntimeConditionFact``1'></a>
### CreateRuntimeConditionFact\`\`1() `method`

##### Summary

Create an fact of this type. Method created for [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

##### Returns

Instans fact.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type fact. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactType-EqualsFactType``1-``0-'></a>
### EqualsFactType\`\`1(factInfo) `method`

##### Summary

[IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') equality.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factInfo | [\`\`0](#T-``0 '``0') |  |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactType-IsFactType``1'></a>
### IsFactType\`\`1() `method`

##### Summary

Is it possible to convert a fact type to a `TFact`.

##### Returns

Can a fact be converted to a `TFact` type.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact |  |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache'></a>
## IFactTypeCache `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Fact type cache.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache-GetFactType``1-``0-'></a>
### GetFactType\`\`1(fact) `method`

##### Summary

Returns fact type from cache or new.

##### Returns

Fact type info.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Fact type. |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCreation'></a>
## IFactTypeCreation `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Interface for creating a fact type.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCreation-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

Returns fact type from `TFact`.

##### Returns

Instance [IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType')

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Fact type. |

<a name='T-GetcuReone-FactFactory-Interfaces-IFactWork'></a>
## IFactWork `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Basic interface for objects that work directly with facts.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactWork-InputFactTypes'></a>
### InputFactTypes `property`

##### Summary

Information on input factacles rules.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactWork-Option'></a>
### Option `property`

##### Summary

FactWork option.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactWork-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### EqualsWork(workFact,wantAction,container) `method`

##### Summary

Work equality.

##### Returns

`workFact` equal `wantAction`?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workFact | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | Work with which equality is determined. |
| wantAction | [GetcuReone.FactFactory.Interfaces.IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction') | The action in the context of which this occurs |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

<a name='T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact'></a>
## IRuntimeConditionFact `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.SpecialFacts

##### Summary

A special fact that is created when calculating facts. Used to check the condition.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext-'></a>
### Condition(factWork,context) `method`

##### Summary

A condition that determines whether the current fact can be added to the container when deriving.

##### Returns

Has the condition been met?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | Work for which we learn about the possibility of using the fact. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext') | Context. |

##### Remarks

With it, you can determine which rule and under what conditions can be used when calculating facts.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-SetGetRelatedRulesFunc-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection},GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRuleCollection-'></a>
### SetGetRelatedRulesFunc(getRelatedRulesFunc,rule,rules) `method`

##### Summary

Sets the method for getting related fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| getRelatedRulesFunc | [System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRuleCollection,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext,GetcuReone.FactFactory.Interfaces.IFactRuleCollection}') | Method for getting related fact rules. |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Rule in which the condition was found. |
| rules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') | Fact rules under which the condition was found. |

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-TryGetRelatedRules-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext,GetcuReone-FactFactory-Interfaces-IFactRuleCollection@-'></a>
### TryGetRelatedRules(context,relatedRules) `method`

##### Summary

Try get method for related fact rules.

##### Returns

True - was able to return the associated fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |
| relatedRules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection@](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection@ 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection@') | Related fact rules. |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations'></a>
## ISingleEntityOperations `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Single operations on entities of the FactFactory.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFact(node,context) `method`

##### Summary

Calculate fact by rule from node.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFactAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CalculateFactAsync(node,context) `method`

##### Summary

Calculate fact by rule from node.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CanExtractFact-GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CanExtractFact(factType,factWork,context) `method`

##### Summary

Is it possible to get a fact by type `factType` from a container for a `factWork`.

##### Returns

Is it possible to extract a fact?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Extracted fact type. |
| factWork | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | [IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') for which to extract a fact. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CompatibleRule-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### CompatibleRule(target,rule,context) `method`

##### Summary

True - if the target is consistent with the rule.

##### Returns

Are the rules compatible?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | The purpose with which the rules must be compatible. |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Fact rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction(wantAction,factTypes,option) `method`

##### Summary

Creates instanse [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction').

##### Returns

WantAction.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Action taken after deriving a fact. |
| factTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Facts required to launch an action. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | WantAction option. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-'></a>
### DeriveWantFacts(wantActionInfo) `method`

##### Summary

Run `wantActionInfo` with input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo') | WantAction info. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-'></a>
### DeriveWantFactsAsync(wantActionInfo) `method`

##### Summary

Async run `wantActionInfo` with input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo') | WantAction info. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetCompatibleRules-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IFactRuleCollection,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetCompatibleRules(target,factRules,context) `method`

##### Summary

Returns rules compatible with `target`.

##### Returns

Compatible rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | The purpose with which the rules must be compatible. |
| factRules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') | List of rules. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetFactComparer() `method`

##### Summary

Returns [IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

##### Returns

[IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactEqualityComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetFactEqualityComparer() `method`

##### Summary

Returns [IEqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEqualityComparer`1 'System.Collections.Generic.IEqualityComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

##### Returns

[IEqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEqualityComparer`1 'System.Collections.Generic.IEqualityComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRequiredTypesOfFacts-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRequiredTypesOfFacts(factWork,context) `method`

##### Summary

Returns types of facts that cannot be extracted from the container.

##### Returns

Types of facts that cannot be extracted from the container.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [GetcuReone.FactFactory.Interfaces.IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') | Purpose for which facts are needed. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRuleComparer-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### GetRuleComparer(context) `method`

##### Summary

Returns comparer for [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

##### Returns

Compare for rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-NeedCalculateFact-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-'></a>
### NeedCalculateFact(node,context) `method`

##### Summary

Do I need to recalculate the fact.

##### Returns

Do I need to recalculate the fact?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateAndGetRules-GetcuReone-FactFactory-Interfaces-IFactRuleCollection-'></a>
### ValidateAndGetRules(ruleCollection) `method`

##### Summary

Validate and return a copy of the rules.

##### Returns

Rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ruleCollection | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection') | Rules. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateContainer-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### ValidateContainer(container) `method`

##### Summary

Validate and return a copy of the container.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

<a name='T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact'></a>
## ISpecialFact `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.SpecialFacts

##### Summary

Basic interface for special facts.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-'></a>
### EqualsInfo(specialFact) `method`

##### Summary

Checks equality with `specialFact`.

##### Returns

Are the facts equal?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| specialFact | [GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact') | Special fact. |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations'></a>
## ITreeBuildingOperations `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Tree building operations.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFacts-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}-'></a>
### CalculateTreeAndDeriveWantFacts(wantActionInfo,treeByFactRules) `method`

##### Summary

Calculate trees and derive fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo') | Information about the WantAction. |
| treeByFactRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule}') | Trees that need to be calculated to output a facts. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFactsAsync-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo,System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule}-'></a>
### CalculateTreeAndDeriveWantFactsAsync(wantActionInfo,treeByFactRules) `method`

##### Summary

Async calculate trees and derive fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo') | Information about the WantAction. |
| treeByFactRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule}') | Trees that need to be calculated to output a facts. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-GetIndependentNodeGroups-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-'></a>
### GetIndependentNodeGroups(treeByFactRule) `method`

##### Summary

List of groups of independent nodes.

##### Returns

Independent node groups.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule') | Decision tree built for the rule. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@-'></a>
### TryBuildTreeForFactInfo(request,treeResult,deriveFactErrorDetails) `method`

##### Summary

Try build tree for wantFact.

##### Returns

True - build tree. False - not build tree.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest') | Request. |
| treeResult | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule@](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule@ 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule@') | Build tree. |
| deriveFactErrorDetails | [System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@') | Errors that occurred while building a tree. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreesForWantAction-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest,GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult@-'></a>
### TryBuildTreesForWantAction(request,result) `method`

##### Summary

Try build trees for wantAction.

##### Returns

True - build trees. False - not build trees.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest') | Request. |
| result | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult@](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult@ 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult@') | Result. |

<a name='T-GetcuReone-FactFactory-Interfaces-IWantAction'></a>
## IWantAction `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Desired action information.

<a name='M-GetcuReone-FactFactory-Interfaces-IWantAction-AddUsedRule-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### AddUsedRule(rule) `method`

##### Summary

Adds a rule used to calculate the fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | Fact rule. |

<a name='M-GetcuReone-FactFactory-Interfaces-IWantAction-GetUsedRules'></a>
### GetUsedRules() `method`

##### Summary

Returns the rules used to calculate facts.

##### Returns

Rules used to calculate facts.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IWantAction-Invoke-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### Invoke(requireFacts) `method`

##### Summary

Run action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requireFacts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | The facts required for run. |

<a name='M-GetcuReone-FactFactory-Interfaces-IWantAction-InvokeAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### InvokeAsync(requireFacts) `method`

##### Summary

Async run action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requireFacts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | The facts required for run. |

<a name='T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext'></a>
## IWantActionContext `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-Container'></a>
### Container `property`

##### Summary

Fact container.

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext-WantAction'></a>
### WantAction `property`

##### Summary

WantAction.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup'></a>
## IndependentNodeGroup `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Independent node group.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-#ctor'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup-CanAdd-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-'></a>
### CanAdd(node) `method`

##### Summary

Can add node.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule') |  |

<a name='T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException'></a>
## InvalidDeriveOperationException `type`

##### Namespace

GetcuReone.FactFactory.Exceptions

##### Summary

[FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') for method [IFactFactory](#T-GetcuReone-FactFactory-Interfaces-IFactFactory 'GetcuReone.FactFactory.Interfaces.IFactFactory').

<a name='M-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException-#ctor-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule'></a>
## NodeByFactRule `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Node.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Childs'></a>
### Childs `property`

##### Summary

Childs node.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Info'></a>
### Info `property`

##### Summary

Node info.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule-Parent'></a>
### Parent `property`

##### Summary

Parent node.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo'></a>
## NodeByFactRuleInfo `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Node info.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-BuildFailedConditions'></a>
### BuildFailedConditions `property`

##### Summary

List of failed [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Failed conditions for [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.Rule').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-BuildSuccessConditions'></a>
### BuildSuccessConditions `property`

##### Summary

List of successfully [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Successfully completed conditions for [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo.Rule').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-CompatibleRules'></a>
### CompatibleRules `property`

##### Summary

Compatible rules.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-RequiredFactTypes'></a>
### RequiredFactTypes `property`

##### Summary

Required fact types.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-Rule'></a>
### Rule `property`

##### Summary

Rule.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-RuntimeConditions'></a>
### RuntimeConditions `property`

##### Summary

List of [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo-ToString'></a>
### ToString() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule'></a>
## TreeByFactRule `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

A tree built by type of fact rule.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Levels'></a>
### Levels `property`

##### Summary

Tree levels.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-NodeInfos'></a>
### NodeInfos `property`

##### Summary

Information about all the rules that were tested for the ability to use when building a tree.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Root'></a>
### Root `property`

##### Summary

Root node.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Status'></a>
### Status `property`

##### Summary

Tree work status.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Built'></a>
### Built() `method`

##### Summary

Tree built.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule-Cencel'></a>
### Cencel() `method`

##### Summary

The tree is canceled.

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus'></a>
## TreeStatus `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums

##### Summary

Tree build status.

<a name='F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-BeingBuilt'></a>
### BeingBuilt `constants`

##### Summary

Tree is being built.

<a name='F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Built'></a>
### Built `constants`

##### Summary

Tree built.

<a name='F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Cencel'></a>
### Cencel `constants`

##### Summary

The tree is canceled.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo'></a>
## WantActionInfo `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Info for WantAction from context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-BuildFailedConditions'></a>
### BuildFailedConditions `property`

##### Summary

List of failed [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Failed conditions for WantAction from [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.Context').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-BuildSuccessConditions'></a>
### BuildSuccessConditions `property`

##### Summary

List of successfully [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Successfully completed conditions for WantAction from [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo.Context').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo-RuntimeConditions'></a>
### RuntimeConditions `property`

##### Summary

List of [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo'></a>
## WantFactsInfo `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Information about 'WantFacts'.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo-Container'></a>
### Container `property`

##### Summary

Fact container.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo-WantAction'></a>
### WantAction `property`

##### Summary

WantAction.
