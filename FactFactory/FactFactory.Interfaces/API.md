<a name='assembly'></a>
# GetcuReone.FactFactory.Interfaces

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [BuildTreeForFactInfoRequest\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest`3')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest`3.Context')
  - [WantFactType](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3-WantFactType 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest`3.WantFactType')
- [BuildTreesForWantActionRequest\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest`3')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest`3.Context')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3-FactRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest`3.FactRules')
- [BuildTreesForWantActionResult\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult`3')
  - [DeriveErrorDetail](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-DeriveErrorDetail 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult`3.DeriveErrorDetail')
  - [TreesResult](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-TreesResult 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult`3.TreesResult')
  - [WantActionInfo](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-WantActionInfo 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult`3.WantActionInfo')
- [BuildTreesRequest\`4](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest`4')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-FactRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest`4.FactRules')
  - [Filters](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-Filters 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest`4.Filters')
  - [WantActionContexts](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-WantActionContexts 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest`4.WantActionContexts')
- [BuildTreesResult\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult`3')
  - [DeriveErrorDetails](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3-DeriveErrorDetails 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult`3.DeriveErrorDetails')
  - [TreesByActions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3-TreesByActions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult`3.TreesByActions')
- [DeriveErrorDetail](#T-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail')
  - [#ctor(code,reason,requiredAction,container,requiredFacts)](#M-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-#ctor-System-String,System-String,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}- 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.#ctor(System.String,System.String,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer,System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail})')
  - [Container](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-Container 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.Container')
  - [RequiredAction](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredAction 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.RequiredAction')
  - [RequiredFacts](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail-RequiredFacts 'GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail.RequiredFacts')
- [DeriveFactErrorDetail](#T-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail')
  - [#ctor(requiredFact,needFacts)](#M-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-#ctor-GetcuReone-FactFactory-Interfaces-IFactType,System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Interfaces-IFactType}- 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.#ctor(GetcuReone.FactFactory.Interfaces.IFactType,System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Interfaces.IFactType})')
  - [NeedFacts](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-NeedFacts 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.NeedFacts')
  - [RequiredFact](#P-GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail-RequiredFact 'GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail.RequiredFact')
- [DeriveWantActionRequest\`4](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest`4')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest`4.Context')
  - [Rules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4-Rules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest`4.Rules')
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
  - [Condition\`\`4(factWork,getCompatibleRules,context)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}})')
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
  - [DeriveWantActionAsync\`\`4(requests)](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantActionAsync``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}- 'GetcuReone.FactFactory.Interfaces.Operations.IFactEngine.DeriveWantActionAsync``4(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}})')
  - [DeriveWantAction\`\`4(requests)](#M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantAction``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}- 'GetcuReone.FactFactory.Interfaces.Operations.IFactEngine.DeriveWantAction``4(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}})')
- [IFactFactoryContext](#T-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext')
  - [Cache](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Cache 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.Cache')
  - [Engine](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-Engine 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.Engine')
  - [SingleEntity](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-SingleEntity 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.SingleEntity')
  - [TreeBuilding](#P-GetcuReone-FactFactory-Interfaces-Context-IFactFactoryContext-TreeBuilding 'GetcuReone.FactFactory.Interfaces.Context.IFactFactoryContext.TreeBuilding')
- [IFactFactory\`4](#T-GetcuReone-FactFactory-Interfaces-IFactFactory`4 'GetcuReone.FactFactory.Interfaces.IFactFactory`4')
  - [Rules](#P-GetcuReone-FactFactory-Interfaces-IFactFactory`4-Rules 'GetcuReone.FactFactory.Interfaces.IFactFactory`4.Rules')
  - [Derive()](#M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-Derive 'GetcuReone.FactFactory.Interfaces.IFactFactory`4.Derive')
  - [DeriveAsync()](#M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-DeriveAsync 'GetcuReone.FactFactory.Interfaces.IFactFactory`4.DeriveAsync')
  - [WantFacts(wantAction,container)](#M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-WantFacts-`2,`3- 'GetcuReone.FactFactory.Interfaces.IFactFactory`4.WantFacts(`2,`3)')
- [IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter')
  - [Code](#P-GetcuReone-FactFactory-Interfaces-IFactParameter-Code 'GetcuReone.FactFactory.Interfaces.IFactParameter.Code')
  - [Value](#P-GetcuReone-FactFactory-Interfaces-IFactParameter-Value 'GetcuReone.FactFactory.Interfaces.IFactParameter.Value')
- [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule')
  - [OutputFactType](#P-GetcuReone-FactFactory-Interfaces-IFactRule-OutputFactType 'GetcuReone.FactFactory.Interfaces.IFactRule.OutputFactType')
  - [Calculate(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IFactRule-Calculate-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IFactRule.Calculate(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [CalculateAsync(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IFactRule-CalculateAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IFactRule.CalculateAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
- [IFactRuleCollection\`1](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1')
  - [IsReadOnly](#P-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-IsReadOnly 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1.IsReadOnly')
  - [FindAll(predicate)](#M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-FindAll-System-Func{`0,System-Boolean}- 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1.FindAll(System.Func{`0,System.Boolean})')
  - [SortByDescending\`\`1(keySelector,comparer)](#M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-SortByDescending``1-System-Func{`0,``0},System-Collections-Generic-IComparer{``0}- 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1.SortByDescending``1(System.Func{`0,``0},System.Collections.Generic.IComparer{``0})')
- [IFactRulesContext\`3](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext`3 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext`3')
  - [FactRules](#P-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext`3-FactRules 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext`3.FactRules')
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
  - [EqualsWork\`\`3(workFact,wantAction,container)](#M-GetcuReone-FactFactory-Interfaces-IFactWork-EqualsWork``3-``0,``1,``2- 'GetcuReone.FactFactory.Interfaces.IFactWork.EqualsWork``3(``0,``1,``2)')
- [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact')
  - [Condition\`\`4(factWork,context)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.Condition``4(``0,GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3})')
  - [SetRelatedRules\`\`1(rules)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-SetRelatedRules``1-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.SetRelatedRules``1(GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0})')
  - [TryGetRelatedRulse\`\`1(rules)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-TryGetRelatedRulse``1-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}@- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact.TryGetRelatedRulse``1(GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}@)')
- [ISingleEntityOperations](#T-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations')
  - [CalculateFactAsync\`\`3(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CalculateFactAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CalculateFact\`\`3(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CanExtractFact\`\`3(factType,factWork,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CanExtractFact``3(GetcuReone.FactFactory.Interfaces.IFactType,``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [CompatibleRule\`\`4(target,rule,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CompatibleRule``4(``0,``1,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [CreateWantAction\`\`1(wantAction,factTypes,option)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction``1-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CreateWantAction``1(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateWantAction\`\`1()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction``1-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.CreateWantAction``1(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [DeriveWantFactsAsync\`\`2(wantActionInfo)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFactsAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.DeriveWantFactsAsync``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [DeriveWantFacts\`\`2(wantActionInfo)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.DeriveWantFacts``2(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1})')
  - [GetCompatibleRules\`\`4(target,factRules,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetCompatibleRules``4-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetCompatibleRules``4(``0,GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3})')
  - [GetFactComparer\`\`2()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetFactComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetFactEqualityComparer\`\`2()](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactEqualityComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetFactEqualityComparer``2(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``0,``1})')
  - [GetRequiredTypesOfFacts\`\`3(factWork,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetRequiredTypesOfFacts``3(``0,GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [GetRuleComparer\`\`3(context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRuleComparer``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.GetRuleComparer``3(GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [NeedCalculateFact\`\`3(node,context)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-NeedCalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.NeedCalculateFact``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0},GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2})')
  - [ValidateAndGetRules\`\`2(ruleCollection)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateAndGetRules``2-``1- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.ValidateAndGetRules``2(``1)')
  - [ValidateContainer\`\`1(container)](#M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateContainer``1-``0- 'GetcuReone.FactFactory.Interfaces.Operations.ISingleEntityOperations.ValidateContainer``1(``0)')
- [ISpecialFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact')
  - [EqualsInfo(specialFact)](#M-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact-EqualsInfo-GetcuReone-FactFactory-Interfaces-SpecialFacts-ISpecialFact- 'GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact.EqualsInfo(GetcuReone.FactFactory.Interfaces.SpecialFacts.ISpecialFact)')
- [ITreeBuildingOperations](#T-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations')
  - [CalculateTreeAndDeriveWantFactsAsync\`\`3(wantActionInfo,treeByFactRules)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.CalculateTreeAndDeriveWantFactsAsync``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [CalculateTreeAndDeriveWantFacts\`\`3(wantActionInfo,treeByFactRules)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.CalculateTreeAndDeriveWantFacts``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}})')
  - [GetIndependentNodeGroups\`\`3(treeByFactRule)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.GetIndependentNodeGroups``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2})')
  - [TryBuildTreeForFactInfo\`\`3(request,treeResult,deriveFactErrorDetails)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreeForFactInfo``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)')
  - [TryBuildTreesForWantAction\`\`3(request,result)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreesForWantAction``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreesForWantAction``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult{``0,``1,``2}@)')
  - [TryBuildTrees\`\`4(request,result)](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTrees``4-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult{``0,``2,``3}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTrees``4(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult{``0,``2,``3}@)')
- [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction')
  - [AddUsedRule(rule)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-AddUsedRule-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.Interfaces.IWantAction.AddUsedRule(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [GetUsedRules()](#M-GetcuReone-FactFactory-Interfaces-IWantAction-GetUsedRules 'GetcuReone.FactFactory.Interfaces.IWantAction.GetUsedRules')
  - [Invoke(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-Invoke-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IWantAction.Invoke(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [InvokeAsync(requireFacts)](#M-GetcuReone-FactFactory-Interfaces-IWantAction-InvokeAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.Interfaces.IWantAction.InvokeAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
- [IWantActionContext\`2](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext`2')
  - [Container](#P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2-Container 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext`2.Container')
  - [WantAction](#P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2-WantAction 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext`2.WantAction')
- [IndependentNodeGroup\`1](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup`1')
  - [#ctor()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-#ctor 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup`1.#ctor')
  - [#ctor()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{`0}}- 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup`1.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{`0}})')
  - [CanAdd(node)](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-CanAdd-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{`0}- 'GetcuReone.FactFactory.Interfaces.Operations.Entities.IndependentNodeGroup`1.CanAdd(GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{`0})')
- [InvalidDeriveOperationException](#T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException')
  - [#ctor()](#M-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException-#ctor-System-Collections-Generic-IReadOnlyCollection{GetcuReone-FactFactory-Exceptions-Entities-DeriveErrorDetail}- 'GetcuReone.FactFactory.Exceptions.InvalidDeriveOperationException.#ctor(System.Collections.Generic.IReadOnlyCollection{GetcuReone.FactFactory.Exceptions.Entities.DeriveErrorDetail})')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [NodeByFactRuleInfo\`1](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1')
  - [BuildFailedConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-BuildFailedConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.BuildFailedConditions')
  - [BuildSuccessConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-BuildSuccessConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.BuildSuccessConditions')
  - [CompatibleRules](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-CompatibleRules 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.CompatibleRules')
  - [RequiredFactTypes](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-RequiredFactTypes 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.RequiredFactTypes')
  - [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.Rule')
  - [RuntimeConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-RuntimeConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.RuntimeConditions')
  - [ToString()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-ToString 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.ToString')
- [NodeByFactRule\`1](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule`1')
  - [Childs](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Childs 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule`1.Childs')
  - [Info](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Info 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule`1.Info')
  - [Parent](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Parent 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule`1.Parent')
- [TreeByFactRule\`3](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Context')
  - [Levels](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Levels 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Levels')
  - [NodeInfos](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-NodeInfos 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.NodeInfos')
  - [Root](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Root 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Root')
  - [Status](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Status 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Status')
  - [Built()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Built 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Built')
  - [Cencel()](#M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Cencel 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule`3.Cencel')
- [TreeStatus](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus')
  - [BeingBuilt](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-BeingBuilt 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.BeingBuilt')
  - [Built](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Built 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.Built')
  - [Cencel](#F-GetcuReone-FactFactory-Interfaces-Operations-Entities-Enums-TreeStatus-Cencel 'GetcuReone.FactFactory.Interfaces.Operations.Entities.Enums.TreeStatus.Cencel')
- [WantActionInfo\`2](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2')
  - [BuildFailedConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-BuildFailedConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.BuildFailedConditions')
  - [BuildSuccessConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-BuildSuccessConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.BuildSuccessConditions')
  - [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.Context')
  - [RuntimeConditions](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-RuntimeConditions 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.RuntimeConditions')
- [WantFactsInfo\`2](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo`2')
  - [Container](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2-Container 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo`2.Container')
  - [WantAction](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2-WantAction 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantFactsInfo`2.WantAction')

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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3'></a>
## BuildTreeForFactInfoRequest\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request for [TryBuildTreeForFactInfo\`\`3](#M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@- 'GetcuReone.FactFactory.Interfaces.Operations.ITreeBuildingOperations.TryBuildTreeForFactInfo``3(GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}@,System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@)').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest`3-WantFactType'></a>
### WantFactType `property`

##### Summary

The type of fact for which you want to build a tree.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3'></a>
## BuildTreesForWantActionRequest\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest`3-FactRules'></a>
### FactRules `property`

##### Summary

Fact rules.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3'></a>
## BuildTreesForWantActionResult\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Result.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-DeriveErrorDetail'></a>
### DeriveErrorDetail `property`

##### Summary

Errors that occurred while building a tree.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-TreesResult'></a>
### TreesResult `property`

##### Summary

Build trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult`3-WantActionInfo'></a>
### WantActionInfo `property`

##### Summary

WantAction info.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4'></a>
## BuildTreesRequest\`4 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |
| TFactRuleCollection | Fact rule collection type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-FactRules'></a>
### FactRules `property`

##### Summary

List of rules that take part in the construction of trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-Filters'></a>
### Filters `property`

##### Summary

Filter for WantAction and FactRule.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest`4-WantActionContexts'></a>
### WantActionContexts `property`

##### Summary

The contexts within which to build trees.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3'></a>
## BuildTreesResult\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Result.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3-DeriveErrorDetails'></a>
### DeriveErrorDetails `property`

##### Summary

Errors when constructing trees.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult`3-TreesByActions'></a>
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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4'></a>
## DeriveWantActionRequest\`4 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Request.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type of rules used. |
| TFactRuleCollection | Rule collection type. |
| TWantAction | Type wantAction |
| TFactContainer | Type container |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4-Context'></a>
### Context `property`

##### Summary

The context in which the calculations will be made.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest`4-Rules'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},System-Func{GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3},GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1}}-'></a>
### Condition\`\`4(factWork,getCompatibleRules,context) `method`

##### Summary

A condition that determines whether the current fact can be added to the container when deriving.

##### Returns

Has the condition been met?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [\`\`0](#T-``0 '``0') | Work for which we learn about the possibility of using the fact. |
| getCompatibleRules | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`2,\`\`3}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3}') | Func for get compatible rules. |
| context | [System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`2,\`\`3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3},GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Type `factWork`. |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

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

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantActionAsync``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}-'></a>
### DeriveWantActionAsync\`\`4(requests) `method`

##### Summary

Build a trees and calculate facts for `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{\`\`0,\`\`1,\`\`2,\`\`3}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}}') | Requests. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type of rules used. |
| TFactRuleCollection | Rule collection type. |
| TWantAction | Type wantAction |
| TFactContainer | Type container |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-IFactEngine-DeriveWantAction``4-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-Operations-Entities-DeriveWantActionRequest{``0,``1,``2,``3}}-'></a>
### DeriveWantAction\`\`4(requests) `method`

##### Summary

Build a trees and calculate facts for `requests`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| requests | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{\`\`0,\`\`1,\`\`2,\`\`3}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.Operations.Entities.DeriveWantActionRequest{``0,``1,``2,``3}}') | Requests. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Type of rules used. |
| TFactRuleCollection | Rule collection type. |
| TWantAction | Type wantAction |
| TFactContainer | Type container |

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

<a name='T-GetcuReone-FactFactory-Interfaces-IFactFactory`4'></a>
## IFactFactory\`4 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact factory interface.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactContainer | Type fact container. |
| TFactRule | Type fact rule. |
| TFactRuleCollection | Type set rule. |
| TWantAction | Type 'want action'. |

<a name='P-GetcuReone-FactFactory-Interfaces-IFactFactory`4-Rules'></a>
### Rules `property`

##### Summary

Collection of rules for derive facts.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-Derive'></a>
### Derive() `method`

##### Summary

Derive the facts.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-DeriveAsync'></a>
### DeriveAsync() `method`

##### Summary

Asynchronously derive the facts.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactFactory`4-WantFacts-`2,`3-'></a>
### WantFacts(wantAction,container) `method`

##### Summary

Requesting a desired fact through action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [\`2](#T-`2 '`2') | WantAction. |
| container | [\`3](#T-`3 '`3') | Fact container. |

<a name='T-GetcuReone-FactFactory-Interfaces-IFactParameter'></a>
## IFactParameter `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Fact parameter.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactParameter-Code'></a>
### Code `property`

##### Summary

Code.

<a name='P-GetcuReone-FactFactory-Interfaces-IFactParameter-Value'></a>
### Value `property`

##### Summary

Value.

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

<a name='T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1'></a>
## IFactRuleCollection\`1 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces

##### Summary

Collection of rules.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |

<a name='P-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

Gets a value indicating whether the [IFactRuleCollection\`1](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1') is read-only.

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-FindAll-System-Func{`0,System-Boolean}-'></a>
### FindAll(predicate) `method`

##### Summary

Filters a sequence of values based on a predicate.

##### Returns

An [IFactRuleCollection\`1](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1') that contains elements from the input
sequence that satisfy the condition.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Func{\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,System.Boolean}') | A function to test each element for a condition. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `predicate` is null. |

<a name='M-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1-SortByDescending``1-System-Func{`0,``0},System-Collections-Generic-IComparer{``0}-'></a>
### SortByDescending\`\`1(keySelector,comparer) `method`

##### Summary

Sorts the elements of a sequence in descending order according to a key.

##### Returns

An [IFactRuleCollection\`1](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection`1 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection`1') whose elements are sorted in
descending orderaccording to a key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| keySelector | [System.Func{\`0,\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`0,``0}') | A function to extract a key from an element. |
| comparer | [System.Collections.Generic.IComparer{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer 'System.Collections.Generic.IComparer{``0}') | An [IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') to compare keys. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TKey | The type of the key returned by keySelector. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `keySelector` is null. |

<a name='T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext`3'></a>
## IFactRulesContext\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext`3-FactRules'></a>
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

<a name='M-GetcuReone-FactFactory-Interfaces-IFactWork-EqualsWork``3-``0,``1,``2-'></a>
### EqualsWork\`\`3(workFact,wantAction,container) `method`

##### Summary

Work equality.

##### Returns

`workFact` equal `wantAction`?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workFact | [\`\`0](#T-``0 '``0') | Work with which equality is determined. |
| wantAction | [\`\`1](#T-``1 '``1') | The action in the context of which this occurs |
| container | [\`\`2](#T-``2 '``2') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork |  |
| TWantAction |  |
| TFactContainer |  |

<a name='T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact'></a>
## IRuntimeConditionFact `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.SpecialFacts

##### Summary

A special fact that is created when calculating facts. Used to check the condition.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-Condition``4-``0,GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3}-'></a>
### Condition\`\`4(factWork,context) `method`

##### Summary

A condition that determines whether the current fact can be added to the container when deriving.

##### Returns

Has the condition been met?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [\`\`0](#T-``0 '``0') | Work for which we learn about the possibility of using the fact. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{\`\`1,\`\`2,\`\`3}](#T-GetcuReone-FactFactory-Interfaces-Context-IFactRulesContext{``1,``2,``3} 'GetcuReone.FactFactory.Interfaces.Context.IFactRulesContext{``1,``2,``3}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Type `factWork`. |
| TFactRule | Type rule. |
| TWantAction | Type wantAction. |
| TFactContainer | Type fact container. |

##### Remarks

With it, you can determine which rule and under what conditions can be used when calculating facts.

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-SetRelatedRules``1-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}-'></a>
### SetRelatedRules\`\`1(rules) `method`

##### Summary

Set related fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0} 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}') | Fact rules. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FactRule type. |

<a name='M-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact-TryGetRelatedRulse``1-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}@-'></a>
### TryGetRelatedRulse\`\`1(rules) `method`

##### Summary

Try get related fact rules

##### Returns

True - was able to return the associated fact rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection{\`\`0}@](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``0}@ 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``0}@') | Fact rules. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | FactRule type. |

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations'></a>
## ISingleEntityOperations `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations

##### Summary

Single operations on entities of the FactFactory.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFactAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFactAsync\`\`3(node,context) `method`

##### Summary

Calculate fact by rule from node.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CalculateFact\`\`3(node,context) `method`

##### Summary

Calculate fact by rule from node.

##### Returns

Fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CanExtractFact``3-GetcuReone-FactFactory-Interfaces-IFactType,``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### CanExtractFact\`\`3(factType,factWork,context) `method`

##### Summary

Is it possible to get a fact by type `factType` from a container for a `factWork`.

##### Returns

Is it possible to extract a fact?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Extracted fact type. |
| factWork | [\`\`0](#T-``0 '``0') | [IFactWork](#T-GetcuReone-FactFactory-Interfaces-IFactWork 'GetcuReone.FactFactory.Interfaces.IFactWork') for which to extract a fact. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Work type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CompatibleRule``4-``0,``1,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### CompatibleRule\`\`4(target,rule,context) `method`

##### Summary

True - if the target is consistent with the rule.

##### Returns

Are the rules compatible?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [\`\`0](#T-``0 '``0') | The purpose with which the rules must be compatible. |
| rule | [\`\`1](#T-``1 '``1') | Fact rule. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`2,\`\`3}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Work type. |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction``1-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction\`\`1(wantAction,factTypes,option) `method`

##### Summary

Creates `TWantAction`.

##### Returns

WantAction.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Action taken after deriving a fact. |
| factTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Facts required to launch an action. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | WantAction option. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-CreateWantAction``1-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateWantAction\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFactsAsync``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}-'></a>
### DeriveWantFactsAsync\`\`2(wantActionInfo) `method`

##### Summary

Async run `wantActionInfo` with input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{\`\`0,\`\`1}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1}') | WantAction info. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-DeriveWantFacts``2-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1}-'></a>
### DeriveWantFacts\`\`2(wantActionInfo) `method`

##### Summary

Run `wantActionInfo` with input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{\`\`0,\`\`1}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``0,``1} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``0,``1}') | WantAction info. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetCompatibleRules``4-``0,GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3}-'></a>
### GetCompatibleRules\`\`4(target,factRules,context) `method`

##### Summary

Returns rules compatible with `target`.

##### Returns

Compatible rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| target | [\`\`0](#T-``0 '``0') | The purpose with which the rules must be compatible. |
| factRules | [GetcuReone.FactFactory.Interfaces.IFactRuleCollection{\`\`1}](#T-GetcuReone-FactFactory-Interfaces-IFactRuleCollection{``1} 'GetcuReone.FactFactory.Interfaces.IFactRuleCollection{``1}') | List of rules. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`2,\`\`3}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``2,``3} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``2,``3}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Work type. |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### GetFactComparer\`\`2() `method`

##### Summary

Returns [IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

##### Returns

[IComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer`1 'System.Collections.Generic.IComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetFactEqualityComparer``2-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``0,``1}-'></a>
### GetFactEqualityComparer\`\`2() `method`

##### Summary

Returns [IEqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEqualityComparer`1 'System.Collections.Generic.IEqualityComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact').

##### Returns

[IEqualityComparer\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEqualityComparer`1 'System.Collections.Generic.IEqualityComparer`1') for [IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact')

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRequiredTypesOfFacts``3-``0,GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRequiredTypesOfFacts\`\`3(factWork,context) `method`

##### Summary

Returns types of facts that cannot be extracted from the container.

##### Returns

Types of facts that cannot be extracted from the container.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factWork | [\`\`0](#T-``0 '``0') | Purpose for which facts are needed. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactWork | Work type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-GetRuleComparer``3-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### GetRuleComparer\`\`3(context) `method`

##### Summary

Returns comparer for [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

##### Returns

Compare for rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-NeedCalculateFact``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0},GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2}-'></a>
### NeedCalculateFact\`\`3(node,context) `method`

##### Summary

Do I need to recalculate the fact.

##### Returns

Do I need to recalculate the fact?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{``0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{``0}') | Node. |
| context | [GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext{``1,``2} 'GetcuReone.FactFactory.Interfaces.Context.IWantActionContext{``1,``2}') | Context. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateAndGetRules``2-``1-'></a>
### ValidateAndGetRules\`\`2(ruleCollection) `method`

##### Summary

Validate and return a copy of the rules.

##### Returns

Rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ruleCollection | [\`\`1](#T-``1 '``1') | Rules. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TFactRuleCollection | Rule collection type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ISingleEntityOperations-ValidateContainer``1-``0-'></a>
### ValidateContainer\`\`1(container) `method`

##### Summary

Validate and return a copy of the container.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactContainer | Fact container type. |

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

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFactsAsync``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFactsAsync\`\`3(wantActionInfo,treeByFactRules) `method`

##### Summary

Async calculate trees and derive fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2}') | Information about the WantAction. |
| treeByFactRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}}') | Trees that need to be calculated to output a facts. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-CalculateTreeAndDeriveWantFacts``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}}-'></a>
### CalculateTreeAndDeriveWantFacts\`\`3(wantActionInfo,treeByFactRules) `method`

##### Summary

Calculate trees and derive fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionInfo | [GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo{``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo{``1,``2}') | Information about the WantAction. |
| treeByFactRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}}') | Trees that need to be calculated to output a facts. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-GetIndependentNodeGroups``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}-'></a>
### GetIndependentNodeGroups\`\`3(treeByFactRule) `method`

##### Summary

List of groups of independent nodes.

##### Returns

Independent node groups.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| treeByFactRule | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}') | Decision tree built for the rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreeForFactInfo``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@,System-Collections-Generic-List{GetcuReone-FactFactory-Exceptions-Entities-DeriveFactErrorDetail}@-'></a>
### TryBuildTreeForFactInfo\`\`3(request,treeResult,deriveFactErrorDetails) `method`

##### Summary

Try build tree for wantFact.

##### Returns

True - build tree. False - not build tree.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreeForFactInfoRequest{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreeForFactInfoRequest{``0,``1,``2}') | Request. |
| treeResult | [GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{\`\`0,\`\`1,\`\`2}@](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule{``0,``1,``2}@ 'GetcuReone.FactFactory.Interfaces.Operations.Entities.TreeByFactRule{``0,``1,``2}@') | Build tree. |
| deriveFactErrorDetails | [System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Exceptions.Entities.DeriveFactErrorDetail}@') | Errors that occurred while building a tree. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTreesForWantAction``3-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@-'></a>
### TryBuildTreesForWantAction\`\`3(request,result) `method`

##### Summary

Try build trees for wantAction.

##### Returns

True - build trees. False - not build trees.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest{\`\`0,\`\`1,\`\`2}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionRequest{``0,``1,``2} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionRequest{``0,``1,``2}') | Request. |
| result | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult{\`\`0,\`\`1,\`\`2}@](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesForWantActionResult{``0,``1,``2}@ 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesForWantActionResult{``0,``1,``2}@') | Result. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-ITreeBuildingOperations-TryBuildTrees``4-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult{``0,``2,``3}@-'></a>
### TryBuildTrees\`\`4(request,result) `method`

##### Summary

Try build trees for wantActions.

##### Returns

Did you manage to build a tree?

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest{\`\`0,\`\`1,\`\`2,\`\`3}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesRequest{``0,``1,``2,``3} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesRequest{``0,``1,``2,``3}') | Request. |
| result | [GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult{\`\`0,\`\`2,\`\`3}@](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-BuildTreesResult{``0,``2,``3}@ 'GetcuReone.FactFactory.Interfaces.Operations.Entities.BuildTreesResult{``0,``2,``3}@') | Result. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |
| TFactRuleCollection | Rule collection type. |

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

<a name='T-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2'></a>
## IWantActionContext\`2 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2-Container'></a>
### Container `property`

##### Summary

Fact container.

<a name='P-GetcuReone-FactFactory-Interfaces-Context-IWantActionContext`2-WantAction'></a>
### WantAction `property`

##### Summary

WantAction.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1'></a>
## IndependentNodeGroup\`1 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Independent node group.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{`0}}-'></a>
### #ctor() `constructor`

##### Summary

*Inherit from parent.*

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-IndependentNodeGroup`1-CanAdd-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{`0}-'></a>
### CanAdd(node) `method`

##### Summary

Can add node.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| node | [GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{\`0}](#T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule{`0} 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRule{`0}') |  |

<a name='T-GetcuReone-FactFactory-Exceptions-InvalidDeriveOperationException'></a>
## InvalidDeriveOperationException `type`

##### Namespace

GetcuReone.FactFactory.Exceptions

##### Summary

[FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') for method [IFactFactory\`4](#T-GetcuReone-FactFactory-Interfaces-IFactFactory`4 'GetcuReone.FactFactory.Interfaces.IFactFactory`4').

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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1'></a>
## NodeByFactRuleInfo\`1 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Node info.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-BuildFailedConditions'></a>
### BuildFailedConditions `property`

##### Summary

List of failed [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Failed conditions for [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.Rule').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-BuildSuccessConditions'></a>
### BuildSuccessConditions `property`

##### Summary

List of successfully [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Successfully completed conditions for [Rule](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-Rule 'GetcuReone.FactFactory.Interfaces.Operations.Entities.NodeByFactRuleInfo`1.Rule').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-CompatibleRules'></a>
### CompatibleRules `property`

##### Summary

Compatible rules.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-RequiredFactTypes'></a>
### RequiredFactTypes `property`

##### Summary

Required fact types.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-Rule'></a>
### Rule `property`

##### Summary

Rule.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-RuntimeConditions'></a>
### RuntimeConditions `property`

##### Summary

List of [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRuleInfo`1-ToString'></a>
### ToString() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1'></a>
## NodeByFactRule\`1 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Node.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Childs'></a>
### Childs `property`

##### Summary

Childs node.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Info'></a>
### Info `property`

##### Summary

Node info.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-NodeByFactRule`1-Parent'></a>
### Parent `property`

##### Summary

Parent node.

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3'></a>
## TreeByFactRule\`3 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

A tree built by type of fact rule.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactRule | Rule type. |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Levels'></a>
### Levels `property`

##### Summary

Tree levels.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-NodeInfos'></a>
### NodeInfos `property`

##### Summary

Information about all the rules that were tested for the ability to use when building a tree.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Root'></a>
### Root `property`

##### Summary

Root node.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Status'></a>
### Status `property`

##### Summary

Tree work status.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Built'></a>
### Built() `method`

##### Summary

Tree built.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-Interfaces-Operations-Entities-TreeByFactRule`3-Cencel'></a>
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

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2'></a>
## WantActionInfo\`2 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Info for WantAction from context.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-BuildFailedConditions'></a>
### BuildFailedConditions `property`

##### Summary

List of failed [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Failed conditions for WantAction from [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.Context').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-BuildSuccessConditions'></a>
### BuildSuccessConditions `property`

##### Summary

List of successfully [IBuildConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IBuildConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IBuildConditionFact'). Successfully completed conditions for WantAction from [Context](#P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-Context 'GetcuReone.FactFactory.Interfaces.Operations.Entities.WantActionInfo`2.Context').

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-Context'></a>
### Context `property`

##### Summary

Context.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantActionInfo`2-RuntimeConditions'></a>
### RuntimeConditions `property`

##### Summary

List of [IRuntimeConditionFact](#T-GetcuReone-FactFactory-Interfaces-SpecialFacts-IRuntimeConditionFact 'GetcuReone.FactFactory.Interfaces.SpecialFacts.IRuntimeConditionFact').

<a name='T-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2'></a>
## WantFactsInfo\`2 `type`

##### Namespace

GetcuReone.FactFactory.Interfaces.Operations.Entities

##### Summary

Information about 'WantFacts'.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TWantAction | WantAction type. |
| TFactContainer | Fact container type. |

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2-Container'></a>
### Container `property`

##### Summary

Fact container.

<a name='P-GetcuReone-FactFactory-Interfaces-Operations-Entities-WantFactsInfo`2-WantAction'></a>
### WantAction `property`

##### Summary

WantAction.
