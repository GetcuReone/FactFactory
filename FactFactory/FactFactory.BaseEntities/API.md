<a name='assembly'></a>
# GetcuReone.FactFactory.BaseEntities

## Contents

- [ArrayExtensions](#T--ArrayExtensions '.ArrayExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ArrayExtensions-IsNullOrEmpty``1-``0[]- 'ArrayExtensions.IsNullOrEmpty``1(``0[])')
- [BaseFactContainer](#T-GetcuReone-FactFactory-BaseEntities-BaseFactContainer 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer')
  - [#ctor()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.#ctor')
  - [#ctor(facts)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [#ctor(facts,isReadOnly)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Boolean)')
  - [Comparer](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Comparer 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Comparer')
  - [ContainerList](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-ContainerList 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.ContainerList')
  - [EqualityComparer](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-EqualityComparer 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.EqualityComparer')
  - [IsReadOnly](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-IsReadOnly 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.IsReadOnly')
  - [AddRange()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.AddRange(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [Add\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Add``1-``0- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Add``1(``0)')
  - [CheckReadOnly()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-CheckReadOnly 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.CheckReadOnly')
  - [Clear()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Clear 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Clear')
  - [Contains\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Contains``1 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Contains``1')
  - [Contains\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Contains``1-``0- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Contains``1(``0)')
  - [GetEnumerator()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetEnumerator 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.GetEnumerator')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetFactType``1 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.GetFactType``1')
  - [GetFact\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetFact``1 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.GetFact``1')
  - [Remove\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Remove``1 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Remove``1')
  - [Remove\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Remove``1-``0- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.Remove``1(``0)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-System#Collections#IEnumerable#GetEnumerator 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.System#Collections#IEnumerable#GetEnumerator')
  - [TryGetFact\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-TryGetFact``1-``0@- 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.TryGetFact``1(``0@)')
- [BaseFactParameter](#T-GetcuReone-FactFactory-BaseEntities-BaseFactParameter 'GetcuReone.FactFactory.BaseEntities.BaseFactParameter')
  - [#ctor(code,value)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-#ctor-System-String,System-Object- 'GetcuReone.FactFactory.BaseEntities.BaseFactParameter.#ctor(System.String,System.Object)')
  - [Code](#P-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-Code 'GetcuReone.FactFactory.BaseEntities.BaseFactParameter.Code')
  - [Value](#P-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-Value 'GetcuReone.FactFactory.BaseEntities.BaseFactParameter.Value')
- [BaseFactRule](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRule 'GetcuReone.FactFactory.BaseEntities.BaseFactRule')
  - [#ctor(func,inputFactTypes,outputFactType,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [#ctor(funcAsync,inputFactTypes,outputFactType,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [OutputFactType](#P-GetcuReone-FactFactory-BaseEntities-BaseFactRule-OutputFactType 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.OutputFactType')
  - [Calculate()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-Calculate-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.Calculate(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [CalculateAsync()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-CalculateAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.CalculateAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [EqualsWork()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.EqualsWork(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [ToString()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-ToString 'GetcuReone.FactFactory.BaseEntities.BaseFactRule.ToString')
- [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection')
  - [#ctor()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.#ctor')
  - [#ctor(factRules)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule})')
  - [#ctor(factRules,isReadOnly)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule},System-Boolean- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.#ctor(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule},System.Boolean)')
  - [Count](#P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Count 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Count')
  - [IsReadOnly](#P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-IsReadOnly 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.IsReadOnly')
  - [Item](#P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Item-System-Int32- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Item(System.Int32)')
  - [Add(item)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [AddRange()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.AddRange(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule})')
  - [Add\`\`1(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``1-System-Func{``0},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``1(System.Func{``0},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`1(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``1-System-Func{System-Threading-Tasks-ValueTask{``0}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``1(System.Func{System.Threading.Tasks.ValueTask{``0}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`10(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``10(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`10(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask{``9}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``10(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask{``9}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`11(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``11(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`11(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask{``10}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``11(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask{``10}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`12(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``12(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`12(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask{``11}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``12(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask{``11}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`13(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``13(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`13(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask{``12}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``13(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask{``12}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`14(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``14(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`14(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask{``13}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``14(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask{``13}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`15(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``15(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`15(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask{``14}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``15(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask{``14}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`16(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``16(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`16(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask{``15}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``16(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask{``15}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`17(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``17-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,``16},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``17(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,``16},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`17(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``17-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask{``16}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``17(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask{``16}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`2(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``2-System-Func{``0,``1},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``2(System.Func{``0,``1},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`2(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``2-System-Func{``0,System-Threading-Tasks-ValueTask{``1}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``2(System.Func{``0,System.Threading.Tasks.ValueTask{``1}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`3(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``3-System-Func{``0,``1,``2},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``3(System.Func{``0,``1,``2},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`3(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``3-System-Func{``0,``1,System-Threading-Tasks-ValueTask{``2}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``3(System.Func{``0,``1,System.Threading.Tasks.ValueTask{``2}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`4(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``4-System-Func{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``4(System.Func{``0,``1,``2,``3},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`4(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``4-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask{``3}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``4(System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask{``3}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`5(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``5-System-Func{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``5(System.Func{``0,``1,``2,``3,``4},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`5(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``5-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask{``4}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``5(System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask{``4}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`6(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``6-System-Func{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``6(System.Func{``0,``1,``2,``3,``4,``5},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`6(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``6-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask{``5}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``6(System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask{``5}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`7(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``7-System-Func{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``7(System.Func{``0,``1,``2,``3,``4,``5,``6},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`7(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``7-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask{``6}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``7(System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask{``6}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`8(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``8(System.Func{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`8(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``8-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask{``7}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``8(System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask{``7}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`9(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``9(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Add\`\`9(rule,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask{``8}},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Add``9(System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask{``8}},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Clear()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Clear 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Clear')
  - [Contains(item)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Contains-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Contains(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [Copy()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Copy 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Copy')
  - [CopyTo(array,arrayIndex)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CopyTo-GetcuReone-FactFactory-Interfaces-IFactRule[],System-Int32- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.CopyTo(GetcuReone.FactFactory.Interfaces.IFactRule[],System.Int32)')
  - [CreateFactRule(func,inputFactTypes,outputFactType,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.CreateFactRule(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [CreateFactRule(func,inputFactTypes,outputFactType,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.CreateFactRule(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.IFactType,GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [Empty()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Empty 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Empty')
  - [EqualsRules(firstRule,secondRule)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-EqualsRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.EqualsRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [FindAll()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-FindAll-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,System-Boolean}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.FindAll(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,System.Boolean})')
  - [ForEach(action)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-ForEach-System-Action{GetcuReone-FactFactory-Interfaces-IFactRule}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.ForEach(System.Action{GetcuReone.FactFactory.Interfaces.IFactRule})')
  - [GetEnumerator()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-GetEnumerator 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.GetEnumerator')
  - [GetFactType\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-GetFactType``1 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.GetFactType``1')
  - [IndexOf(item)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-IndexOf-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.IndexOf(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [Insert(index,item)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Insert-System-Int32,GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Insert(System.Int32,GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [Remove(item)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Remove-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Remove(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [RemoveAt(index)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-RemoveAt-System-Int32- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.RemoveAt(System.Int32)')
  - [Sort(comparer)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Sort-System-Collections-Generic-IComparer{GetcuReone-FactFactory-Interfaces-IFactRule}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.Sort(System.Collections.Generic.IComparer{GetcuReone.FactFactory.Interfaces.IFactRule})')
  - [SortByDescending\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-SortByDescending``1-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,``0},System-Collections-Generic-IComparer{``0}- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.SortByDescending``1(System.Func{GetcuReone.FactFactory.Interfaces.IFactRule,``0},System.Collections.Generic.IComparer{``0})')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-System#Collections#IEnumerable#GetEnumerator 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.System#Collections#IEnumerable#GetEnumerator')
- [BaseFactType\`1](#T-GetcuReone-FactFactory-BaseEntities-BaseFactType`1 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1')
  - [FactName](#P-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-FactName 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1.FactName')
  - [CreateBuildConditionFact\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-CreateBuildConditionFact``1 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1.CreateBuildConditionFact``1')
  - [CreateRuntimeConditionFact\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-CreateRuntimeConditionFact``1 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1.CreateRuntimeConditionFact``1')
  - [EqualsFactType\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-EqualsFactType``1-``0- 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1.EqualsFactType``1(``0)')
  - [IsFactType\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-IsFactType``1 'GetcuReone.FactFactory.BaseEntities.BaseFactType`1.IsFactType``1')
- [BaseFactWork](#T-GetcuReone-FactFactory-BaseEntities-BaseFactWork 'GetcuReone.FactFactory.BaseEntities.BaseFactWork')
  - [#ctor(factTypes,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-#ctor-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseFactWork.#ctor(System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [InputFactTypes](#P-GetcuReone-FactFactory-BaseEntities-BaseFactWork-InputFactTypes 'GetcuReone.FactFactory.BaseEntities.BaseFactWork.InputFactTypes')
  - [Option](#P-GetcuReone-FactFactory-BaseEntities-BaseFactWork-Option 'GetcuReone.FactFactory.BaseEntities.BaseFactWork.Option')
  - [EqualsFactTypes(first,second)](#M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-EqualsFactTypes-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}- 'GetcuReone.FactFactory.BaseEntities.BaseFactWork.EqualsFactTypes(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType},System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType})')
  - [EqualsWork()](#M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseEntities.BaseFactWork.EqualsWork(GetcuReone.FactFactory.Interfaces.IFactWork,GetcuReone.FactFactory.Interfaces.IWantAction,GetcuReone.FactFactory.Interfaces.IFactContainer)')
- [BaseWantAction](#T-GetcuReone-FactFactory-BaseEntities-BaseWantAction 'GetcuReone.FactFactory.BaseEntities.BaseWantAction')
  - [#ctor(wantAction,factTypes,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-#ctor-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.#ctor(System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [#ctor(wantActionAsync,factTypes,option)](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption- 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.#ctor(System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask},System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType},GetcuReone.FactFactory.Interfaces.FactWorkOption)')
  - [AddUsedRule()](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-AddUsedRule-GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.AddUsedRule(GetcuReone.FactFactory.Interfaces.IFactRule)')
  - [GetUsedRules()](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-GetUsedRules 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.GetUsedRules')
  - [Invoke()](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-Invoke-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.Invoke(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [InvokeAsync()](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-InvokeAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.InvokeAsync(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [ToString()](#M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-ToString 'GetcuReone.FactFactory.BaseEntities.BaseWantAction.ToString')
- [EnumerableExtensions](#T--EnumerableExtensions '.EnumerableExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-EnumerableExtensions-IsNullOrEmpty``1-System-Collections-Generic-IEnumerable{``0}- 'EnumerableExtensions.IsNullOrEmpty``1(System.Collections.Generic.IEnumerable{``0})')
- [FactContainerWriter](#T-GetcuReone-FactFactory-BaseEntities-FactContainerWriter 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter')
  - [#ctor(container)](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-#ctor-GetcuReone-FactFactory-Interfaces-IFactContainer- 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.#ctor(GetcuReone.FactFactory.Interfaces.IFactContainer)')
  - [AddRange(facts)](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}- 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.AddRange(System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact})')
  - [Add\`\`1(fact)](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Add``1-``0- 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.Add``1(``0)')
  - [Dispose()](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Dispose 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.Dispose')
  - [Remove\`\`1()](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Remove``1 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.Remove``1')
  - [Remove\`\`1(fact)](#M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Remove``1-``0- 'GetcuReone.FactFactory.BaseEntities.FactContainerWriter.Remove``1(``0)')
- [FactEqualityComparer](#T-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer')
  - [#ctor(equalsFunc)](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,System-Boolean}- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.#ctor(System.Func{GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,System.Boolean})')
  - [Equals()](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-Equals-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.Equals(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)')
  - [EqualsFactParameters(first,second)](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-EqualsFactParameters-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.EqualsFactParameters(GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.IFactParameter)')
  - [EqualsFacts(first,second,cache,includeFactParams)](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-EqualsFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache,System-Boolean- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.EqualsFacts(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache,System.Boolean)')
  - [GetDefault()](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-GetDefault 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.GetDefault')
  - [GetHashCode()](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-GetHashCode-GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.GetHashCode(GetcuReone.FactFactory.Interfaces.IFact)')
- [FactFactoryContext](#T-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext')
  - [Cache](#P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-Cache 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext.Cache')
  - [Engine](#P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-Engine 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext.Engine')
  - [ParameterCache](#P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-ParameterCache 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext.ParameterCache')
  - [SingleEntity](#P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-SingleEntity 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext.SingleEntity')
  - [TreeBuilding](#P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-TreeBuilding 'GetcuReone.FactFactory.BaseEntities.Context.FactFactoryContext.TreeBuilding')
- [FactRulesContext](#T-GetcuReone-FactFactory-BaseEntities-Context-FactRulesContext 'GetcuReone.FactFactory.BaseEntities.Context.FactRulesContext')
  - [FactRules](#P-GetcuReone-FactFactory-BaseEntities-Context-FactRulesContext-FactRules 'GetcuReone.FactFactory.BaseEntities.Context.FactRulesContext.FactRules')
- [FactTypeCache](#T-GetcuReone-FactFactory-BaseEntities-FactTypeCache 'GetcuReone.FactFactory.BaseEntities.FactTypeCache')
  - [GetFactType()](#M-GetcuReone-FactFactory-BaseEntities-FactTypeCache-GetFactType-GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.BaseEntities.FactTypeCache.GetFactType(GetcuReone.FactFactory.Interfaces.IFact)')
- [FactType\`1](#T-GetcuReone-FactFactory-FactType`1 'GetcuReone.FactFactory.FactType`1')
- [ListExtensions](#T--ListExtensions '.ListExtensions')
  - [IsNullOrEmpty\`\`1(items)](#M-ListExtensions-IsNullOrEmpty``1-System-Collections-Generic-List{``0}- 'ListExtensions.IsNullOrEmpty``1(System.Collections.Generic.List{``0})')
- [WantActionContext](#T-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext 'GetcuReone.FactFactory.BaseEntities.Context.WantActionContext')
  - [Container](#P-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext-Container 'GetcuReone.FactFactory.BaseEntities.Context.WantActionContext.Container')
  - [WantAction](#P-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext-WantAction 'GetcuReone.FactFactory.BaseEntities.Context.WantActionContext.WantAction')

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

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactContainer'></a>
## BaseFactContainer `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Base class for fact container.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### #ctor(facts) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | An array of facts to add to the container. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Boolean-'></a>
### #ctor(facts,isReadOnly) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | An array of facts to add to the container. |
| isReadOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Comparer'></a>
### Comparer `property`

##### Summary

*Inherit from parent.*

##### Remarks

If the value is not specified, then [CompareTo](#M-GetcuReone-FactFactory-Extensions-FactExtensions-CompareTo-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact- 'GetcuReone.FactFactory.Extensions.FactExtensions.CompareTo(GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact)') will be used.

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-ContainerList'></a>
### ContainerList `property`

##### Summary

List storing facts.

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-EqualityComparer'></a>
### EqualityComparer `property`

##### Summary

*Inherit from parent.*

##### Remarks

If the value is not specified, then [GetDefault](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-GetDefault 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.GetDefault') will be used.

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### AddRange() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | Attempt to add an existing fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Add``1-``0-'></a>
### Add\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | Attempt to add an existing fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-CheckReadOnly'></a>
### CheckReadOnly() `method`

##### Summary

If [IsReadOnly](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-IsReadOnly 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.IsReadOnly') is true then throw [FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException').

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | If [IsReadOnly](#P-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-IsReadOnly 'GetcuReone.FactFactory.BaseEntities.BaseFactContainer.IsReadOnly') is true. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Clear'></a>
### Clear() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Contains``1'></a>
### Contains\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Contains``1-``0-'></a>
### Contains\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-GetFact``1'></a>
### GetFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Returns



##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [GetcuReone.FactFactory.Exceptions.FactFactoryException](#T-GetcuReone-FactFactory-Exceptions-FactFactoryException 'GetcuReone.FactFactory.Exceptions.FactFactoryException') | Did not find fact type `TFact`. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Remove``1'></a>
### Remove\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-Remove``1-``0-'></a>
### Remove\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactContainer-TryGetFact``1-``0@-'></a>
### TryGetFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactParameter'></a>
## BaseFactParameter `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Base class for parameter.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-#ctor-System-String,System-Object-'></a>
### #ctor(code,value) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | parameter code |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parameter value |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-Code'></a>
### Code `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactParameter-Value'></a>
### Value `property`

##### Summary

*Inherit from parent.*

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactRule'></a>
## BaseFactRule `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Base class for rules.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor(func,inputFactTypes,outputFactType,option) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact}') | Func for calculate. |
| inputFactTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Information on input factacles rules. |
| outputFactType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Information on output fact. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `func` or `outputFactType` is null. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | The fact is requested at the input, which the rule calculates. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor(funcAsync,inputFactTypes,outputFactType,option) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| funcAsync | [System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}}') | Func for calculate. |
| inputFactTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Information on input factacles rules. |
| outputFactType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | Information on output fact. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `funcAsync` or `outputFactType` is null. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | The fact is requested at the input, which the rule calculates. |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactRule-OutputFactType'></a>
### OutputFactType `property`

##### Summary

Information on output fact.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-Calculate-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### Calculate() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-CalculateAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### CalculateAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### EqualsWork() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRule-ToString'></a>
### ToString() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection'></a>
## BaseFactRuleCollection `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Base collection for [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructor.

##### Parameters

This constructor has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}-'></a>
### #ctor(factRules) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-#ctor-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule},System-Boolean-'></a>
### #ctor(factRules,isReadOnly) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factRules | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactRule}') |  |
| isReadOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |  |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Count'></a>
### Count `property`

##### Summary

Gets the number of rules contained in the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-IsReadOnly'></a>
### IsReadOnly `property`

##### Summary

Gets a value indicating whether the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') is read-only.

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Item-System-Int32-'></a>
### Item `property`

##### Summary

Gets or sets the rule at the specified index.

##### Returns

The rule at the specified index

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index of the element to get or set. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | index is not a valid index in the [List\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1 'System.Collections.Generic.List`1'). |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | The property is set and the [List\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List`1 'System.Collections.Generic.List`1') is read-only. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### Add(item) `method`

##### Summary

Adds rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactRule}-'></a>
### AddRange() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | collection is null |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``1-System-Func{``0},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`1(rule,option) `method`

##### Summary

Adds a rule without input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactOut | Type of fact result. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``1-System-Func{System-Threading-Tasks-ValueTask{``0}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`1(rule,option) `method`

##### Summary

Adds a rule without input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{System.Threading.Tasks.ValueTask{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Threading.Tasks.ValueTask{``0}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactOut | Type of fact result. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`10(rule,option) `method`

##### Summary

Adds a rule with 9 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``10-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System-Threading-Tasks-ValueTask{``9}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`10(rule,option) `method`

##### Summary

Adds a rule with 9 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,System.Threading.Tasks.ValueTask{\`\`9}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,System.Threading.Tasks.ValueTask{``9}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`11(rule,option) `method`

##### Summary

Adds a rule with 10 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``11-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System-Threading-Tasks-ValueTask{``10}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`11(rule,option) `method`

##### Summary

Adds a rule with 10 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,System.Threading.Tasks.ValueTask{\`\`10}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,System.Threading.Tasks.ValueTask{``10}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`12(rule,option) `method`

##### Summary

Adds a rule with 11 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``12-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System-Threading-Tasks-ValueTask{``11}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`12(rule,option) `method`

##### Summary

Adds a rule with 11 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,System.Threading.Tasks.ValueTask{\`\`11}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,System.Threading.Tasks.ValueTask{``11}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`13(rule,option) `method`

##### Summary

Adds a rule with 12 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``13-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System-Threading-Tasks-ValueTask{``12}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`13(rule,option) `method`

##### Summary

Adds a rule with 12 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,System.Threading.Tasks.ValueTask{\`\`12}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,System.Threading.Tasks.ValueTask{``12}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`14(rule,option) `method`

##### Summary

Adds a rule with 13 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``14-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System-Threading-Tasks-ValueTask{``13}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`14(rule,option) `method`

##### Summary

Adds a rule with 13 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,System.Threading.Tasks.ValueTask{\`\`13}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,System.Threading.Tasks.ValueTask{``13}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`15(rule,option) `method`

##### Summary

Adds a rule with 14 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``15-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System-Threading-Tasks-ValueTask{``14}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`15(rule,option) `method`

##### Summary

Adds a rule with 14 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,System.Threading.Tasks.ValueTask{\`\`14}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,System.Threading.Tasks.ValueTask{``14}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`16(rule,option) `method`

##### Summary

Adds a rule with 15 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactIn15 | Type 15 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``16-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System-Threading-Tasks-ValueTask{``15}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`16(rule,option) `method`

##### Summary

Adds a rule with 15 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,System.Threading.Tasks.ValueTask{\`\`15}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,System.Threading.Tasks.ValueTask{``15}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactIn15 | Type 15 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``17-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,``16},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`17(rule,option) `method`

##### Summary

Adds a rule with 16 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15,\`\`16}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,``16}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactIn15 | Type 15 input fact. |
| TFactIn16 | Type 16 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``17-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System-Threading-Tasks-ValueTask{``16}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`17(rule,option) `method`

##### Summary

Adds a rule with 16 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8,\`\`9,\`\`10,\`\`11,\`\`12,\`\`13,\`\`14,\`\`15,System.Threading.Tasks.ValueTask{\`\`16}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8,``9,``10,``11,``12,``13,``14,``15,System.Threading.Tasks.ValueTask{``16}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactIn9 | Type 9 input fact. |
| TFactIn10 | Type 10 input fact. |
| TFactIn11 | Type 11 input fact. |
| TFactIn12 | Type 12 input fact. |
| TFactIn13 | Type 13 input fact. |
| TFactIn14 | Type 14 input fact. |
| TFactIn15 | Type 15 input fact. |
| TFactIn16 | Type 16 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``2-System-Func{``0,``1},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`2(rule,option) `method`

##### Summary

Adds a rule with 1 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``2-System-Func{``0,System-Threading-Tasks-ValueTask{``1}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`2(rule,option) `method`

##### Summary

Adds a rule with 1 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,System.Threading.Tasks.ValueTask{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.ValueTask{``1}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``3-System-Func{``0,``1,``2},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`3(rule,option) `method`

##### Summary

Adds a rule with 2 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``3-System-Func{``0,``1,System-Threading-Tasks-ValueTask{``2}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`3(rule,option) `method`

##### Summary

Adds a rule with 2 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,System.Threading.Tasks.ValueTask{\`\`2}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,System.Threading.Tasks.ValueTask{``2}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``4-System-Func{``0,``1,``2,``3},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`4(rule,option) `method`

##### Summary

Adds a rule with 3 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``4-System-Func{``0,``1,``2,System-Threading-Tasks-ValueTask{``3}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`4(rule,option) `method`

##### Summary

Adds a rule with 3 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,System.Threading.Tasks.ValueTask{\`\`3}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,System.Threading.Tasks.ValueTask{``3}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``5-System-Func{``0,``1,``2,``3,``4},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`5(rule,option) `method`

##### Summary

Adds a rule with 4 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``5-System-Func{``0,``1,``2,``3,System-Threading-Tasks-ValueTask{``4}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`5(rule,option) `method`

##### Summary

Adds a rule with 4 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,System.Threading.Tasks.ValueTask{\`\`4}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,System.Threading.Tasks.ValueTask{``4}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``6-System-Func{``0,``1,``2,``3,``4,``5},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`6(rule,option) `method`

##### Summary

Adds a rule with 5 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5}') | Rule of fact calculation.. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``6-System-Func{``0,``1,``2,``3,``4,System-Threading-Tasks-ValueTask{``5}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`6(rule,option) `method`

##### Summary

Adds a rule with 5 input facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,System.Threading.Tasks.ValueTask{\`\`5}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,System.Threading.Tasks.ValueTask{``5}}') | Rule of fact calculation.. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``7-System-Func{``0,``1,``2,``3,``4,``5,``6},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`7(rule,option) `method`

##### Summary

Adds a rule with 6 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``7-System-Func{``0,``1,``2,``3,``4,``5,System-Threading-Tasks-ValueTask{``6}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`7(rule,option) `method`

##### Summary

Adds a rule with 6 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,System.Threading.Tasks.ValueTask{\`\`6}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,System.Threading.Tasks.ValueTask{``6}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``8-System-Func{``0,``1,``2,``3,``4,``5,``6,``7},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`8(rule,option) `method`

##### Summary

Adds a rule with 7 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``8-System-Func{``0,``1,``2,``3,``4,``5,``6,System-Threading-Tasks-ValueTask{``7}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`8(rule,option) `method`

##### Summary

Adds a rule with 7 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,System.Threading.Tasks.ValueTask{\`\`7}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,System.Threading.Tasks.ValueTask{``7}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,``8},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`9(rule,option) `method`

##### Summary

Adds a rule with 8 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,\`\`8}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,``8}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Add``9-System-Func{``0,``1,``2,``3,``4,``5,``6,``7,System-Threading-Tasks-ValueTask{``8}},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### Add\`\`9(rule,option) `method`

##### Summary

Adds a rule with 8 input facts

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rule | [System.Func{\`\`0,\`\`1,\`\`2,\`\`3,\`\`4,\`\`5,\`\`6,\`\`7,System.Threading.Tasks.ValueTask{\`\`8}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1,``2,``3,``4,``5,``6,``7,System.Threading.Tasks.ValueTask{``8}}') | Rule of fact calculation. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFactIn1 | Type 1 input fact. |
| TFactIn2 | Type 2 input fact. |
| TFactIn3 | Type 3 input fact. |
| TFactIn4 | Type 4 input fact. |
| TFactIn5 | Type 5 input fact. |
| TFactIn6 | Type 6 input fact. |
| TFactIn7 | Type 7 input fact. |
| TFactIn8 | Type 8 input fact. |
| TFactOut | Type output fact. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Clear'></a>
### Clear() `method`

##### Summary

Removes all elements from the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection')

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Contains-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### Contains(item) `method`

##### Summary

Determines whether an element is in the [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule').
Use method [EqualsRules](#M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-EqualsRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule- 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection.EqualsRules(GetcuReone.FactFactory.Interfaces.IFactRule,GetcuReone.FactFactory.Interfaces.IFactRule)').

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Copy'></a>
### Copy() `method`

##### Summary

[BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') copy method.

##### Returns

Copied [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CopyTo-GetcuReone-FactFactory-Interfaces-IFactRule[],System-Int32-'></a>
### CopyTo(array,arrayIndex) `method`

##### Summary

Copies the entire [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') to a compatible one-dimensional array, starting at the specified index of the target array.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| array | [GetcuReone.FactFactory.Interfaces.IFactRule[]](#T-GetcuReone-FactFactory-Interfaces-IFactRule[] 'GetcuReone.FactFactory.Interfaces.IFactRule[]') | The one-dimensional System.Array that is the destination of the elements copied from [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'). The System.Array must have zero-based indexing. |
| arrayIndex | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index in array at which copying begins. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | array is null. |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | arrayIndex is less than 0. |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | The number of elements in the source [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') is greater than the available space from arrayIndex to the end of the destination array. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},GetcuReone-FactFactory-Interfaces-IFact},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateFactRule(func,inputFactTypes,outputFactType,option) `method`

##### Summary

Creation method [IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule')

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},GetcuReone.FactFactory.Interfaces.IFact}') | func for calculate. |
| inputFactTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | information on input factacles rules. |
| outputFactType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | information on output fact. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-CreateFactRule-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-IFactType,GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### CreateFactRule(func,inputFactTypes,outputFactType,option) `method`

##### Summary

Creates .

##### Returns

Fact rule.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask{GetcuReone.FactFactory.Interfaces.IFact}}') | func for calculate. |
| inputFactTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | information on input factacles rules. |
| outputFactType | [GetcuReone.FactFactory.Interfaces.IFactType](#T-GetcuReone-FactFactory-Interfaces-IFactType 'GetcuReone.FactFactory.Interfaces.IFactType') | information on output fact. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | Options for a rule. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Empty'></a>
### Empty() `method`

##### Summary

Return a copy of an object without rules.

##### Returns

Copy of object without rules.

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-EqualsRules-GetcuReone-FactFactory-Interfaces-IFactRule,GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### EqualsRules(firstRule,secondRule) `method`

##### Summary

Rules equality.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| firstRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |
| secondRule | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-FindAll-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,System-Boolean}-'></a>
### FindAll() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `predicate` is null. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-ForEach-System-Action{GetcuReone-FactFactory-Interfaces-IFactRule}-'></a>
### ForEach(action) `method`

##### Summary

Performs the specified action on each element of the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| action | [System.Action{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{GetcuReone.FactFactory.Interfaces.IFactRule}') | The System.Action\`1 delegate to perform on each element of the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'). |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-GetFactType``1'></a>
### GetFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-IndexOf-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### IndexOf(item) `method`

##### Summary

Searches for the specified object and returns the zero-based index of the first occurrence within the entire [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Returns

The zero-based index of the first occurrence of item within the entire [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'), if found; otherwise, –1.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | The object to locate in the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') be null for reference types. The value can |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Insert-System-Int32,GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### Insert(index,item) `method`

##### Summary

Inserts an element into the[BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection') at the specified index.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index at which item should be inserted. |
| item | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | The object to insert. The value can be null for reference types. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | index is less than 0. -or- index is greater than [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'). |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Remove-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### Remove(item) `method`

##### Summary

Removes the first occurrence of a specific object from the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Returns

true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| item | [GetcuReone.FactFactory.Interfaces.IFactRule](#T-GetcuReone-FactFactory-Interfaces-IFactRule 'GetcuReone.FactFactory.Interfaces.IFactRule') | The object to remove from the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'). The value can be null for reference types. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-RemoveAt-System-Int32-'></a>
### RemoveAt(index) `method`

##### Summary

Removes the element at the specified index of the [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The zero-based index of the element to remove. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | index is less than 0. -or- index is equal to or greater than [BaseFactRuleCollection](#T-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection 'GetcuReone.FactFactory.BaseEntities.BaseFactRuleCollection'). |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-Sort-System-Collections-Generic-IComparer{GetcuReone-FactFactory-Interfaces-IFactRule}-'></a>
### Sort(comparer) `method`

##### Summary

Sorts collection.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| comparer | [System.Collections.Generic.IComparer{GetcuReone.FactFactory.Interfaces.IFactRule}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IComparer 'System.Collections.Generic.IComparer{GetcuReone.FactFactory.Interfaces.IFactRule}') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-SortByDescending``1-System-Func{GetcuReone-FactFactory-Interfaces-IFactRule,``0},System-Collections-Generic-IComparer{``0}-'></a>
### SortByDescending\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | `keySelector` is null. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactRuleCollection-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactType`1'></a>
## BaseFactType\`1 `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Contains fact type information.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Fact type. |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-FactName'></a>
### FactName `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-CreateBuildConditionFact``1'></a>
### CreateBuildConditionFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-CreateRuntimeConditionFact``1'></a>
### CreateRuntimeConditionFact\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-EqualsFactType``1-``0-'></a>
### EqualsFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactType`1-IsFactType``1'></a>
### IsFactType\`\`1() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseFactWork'></a>
## BaseFactWork `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Basic interface for objects that work directly with facts.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-#ctor-System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor(factTypes,option) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| factTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Fact types. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | FactWork option. |

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactWork-InputFactTypes'></a>
### InputFactTypes `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-BaseFactWork-Option'></a>
### Option `property`

##### Summary

*Inherit from parent.*

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-EqualsFactTypes-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType},System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFactType}-'></a>
### EqualsFactTypes(first,second) `method`

##### Summary

Determining the equality of a set of fact types.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}') |  |
| second | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFactType}') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseFactWork-EqualsWork-GetcuReone-FactFactory-Interfaces-IFactWork,GetcuReone-FactFactory-Interfaces-IWantAction,GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### EqualsWork() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-BaseWantAction'></a>
## BaseWantAction `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Base class for [IWantAction](#T-GetcuReone-FactFactory-Interfaces-IWantAction 'GetcuReone.FactFactory.Interfaces.IWantAction').

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-#ctor-System-Action{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor(wantAction,factTypes,option) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantAction | [System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}}') | Action taken after deriving a fact. |
| factTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Facts required to launch an action. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | WantAction options. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-#ctor-System-Func{System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact},System-Threading-Tasks-ValueTask},System-Collections-Generic-List{GetcuReone-FactFactory-Interfaces-IFactType},GetcuReone-FactFactory-Interfaces-FactWorkOption-'></a>
### #ctor(wantActionAsync,factTypes,option) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| wantActionAsync | [System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact},System.Threading.Tasks.ValueTask}') | Action taken after deriving a fact. |
| factTypes | [System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{GetcuReone.FactFactory.Interfaces.IFactType}') | Facts required to launch an action. |
| option | [GetcuReone.FactFactory.Interfaces.FactWorkOption](#T-GetcuReone-FactFactory-Interfaces-FactWorkOption 'GetcuReone.FactFactory.Interfaces.FactWorkOption') | WantAction options. |

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-AddUsedRule-GetcuReone-FactFactory-Interfaces-IFactRule-'></a>
### AddUsedRule() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-GetUsedRules'></a>
### GetUsedRules() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-Invoke-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### Invoke() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-InvokeAsync-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### InvokeAsync() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-BaseWantAction-ToString'></a>
### ToString() `method`

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

<a name='T-GetcuReone-FactFactory-BaseEntities-FactContainerWriter'></a>
## FactContainerWriter `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Writer to write facts in a container.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-#ctor-GetcuReone-FactFactory-Interfaces-IFactContainer-'></a>
### #ctor(container) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [GetcuReone.FactFactory.Interfaces.IFactContainer](#T-GetcuReone-FactFactory-Interfaces-IFactContainer 'GetcuReone.FactFactory.Interfaces.IFactContainer') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-AddRange-System-Collections-Generic-IEnumerable{GetcuReone-FactFactory-Interfaces-IFact}-'></a>
### AddRange(facts) `method`

##### Summary

Adds facts.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| facts | [System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{GetcuReone.FactFactory.Interfaces.IFact}') | Fact set. |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Add``1-``0-'></a>
### Add\`\`1(fact) `method`

##### Summary

Adds fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') | Fact. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to add. |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Dispose'></a>
### Dispose() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Remove``1'></a>
### Remove\`\`1() `method`

##### Summary

Removes fact.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to delete. |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactContainerWriter-Remove``1-``0-'></a>
### Remove\`\`1(fact) `method`

##### Summary

Removes fact.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fact | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TFact | Type of fact to delete. |

<a name='T-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer'></a>
## FactEqualityComparer `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Class for comparing facts.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-#ctor-System-Func{GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,System-Boolean}-'></a>
### #ctor(equalsFunc) `constructor`

##### Summary

Constructor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| equalsFunc | [System.Func{GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{GetcuReone.FactFactory.Interfaces.IFact,GetcuReone.FactFactory.Interfaces.IFact,System.Boolean}') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-Equals-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact-'></a>
### Equals() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-EqualsFactParameters-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter-'></a>
### EqualsFactParameters(first,second) `method`

##### Summary

Checking the equality of fact parameters.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFactParameter](#T-GetcuReone-FactFactory-Interfaces-IFactParameter 'GetcuReone.FactFactory.Interfaces.IFactParameter') |  |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-EqualsFacts-GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-IFact,GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache,System-Boolean-'></a>
### EqualsFacts(first,second,cache,includeFactParams) `method`

##### Summary

Checking the equality of facts.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| first | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| second | [GetcuReone.FactFactory.Interfaces.IFact](#T-GetcuReone-FactFactory-Interfaces-IFact 'GetcuReone.FactFactory.Interfaces.IFact') |  |
| cache | [GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache](#T-GetcuReone-FactFactory-Interfaces-Operations-IFactTypeCache 'GetcuReone.FactFactory.Interfaces.Operations.IFactTypeCache') |  |
| includeFactParams | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | True - parameters of facts will be compared using the [EqualsFactParameters](#M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-EqualsFactParameters-GetcuReone-FactFactory-Interfaces-IFactParameter,GetcuReone-FactFactory-Interfaces-IFactParameter- 'GetcuReone.FactFactory.BaseEntities.FactEqualityComparer.EqualsFactParameters(GetcuReone.FactFactory.Interfaces.IFactParameter,GetcuReone.FactFactory.Interfaces.IFactParameter)') method.
False - Parameters of facts will be compared using the method. |

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-GetDefault'></a>
### GetDefault() `method`

##### Summary

Returns default.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactEqualityComparer-GetHashCode-GetcuReone-FactFactory-Interfaces-IFact-'></a>
### GetHashCode() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext'></a>
## FactFactoryContext `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities.Context

##### Summary

A context containing information within which current actions are taking place.

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-Cache'></a>
### Cache `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-Engine'></a>
### Engine `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-ParameterCache'></a>
### ParameterCache `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-SingleEntity'></a>
### SingleEntity `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactFactoryContext-TreeBuilding'></a>
### TreeBuilding `property`

##### Summary

*Inherit from parent.*

<a name='T-GetcuReone-FactFactory-BaseEntities-Context-FactRulesContext'></a>
## FactRulesContext `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-FactRulesContext-FactRules'></a>
### FactRules `property`

##### Summary

*Inherit from parent.*

<a name='T-GetcuReone-FactFactory-BaseEntities-FactTypeCache'></a>
## FactTypeCache `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities

##### Summary

Fact type cache.

<a name='M-GetcuReone-FactFactory-BaseEntities-FactTypeCache-GetFactType-GetcuReone-FactFactory-Interfaces-IFact-'></a>
### GetFactType() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-GetcuReone-FactFactory-FactType`1'></a>
## FactType\`1 `type`

##### Namespace

GetcuReone.FactFactory

##### Summary

*Inherit from parent.*

##### Summary

Fact type.

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

<a name='T-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext'></a>
## WantActionContext `type`

##### Namespace

GetcuReone.FactFactory.BaseEntities.Context

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext-Container'></a>
### Container `property`

##### Summary

*Inherit from parent.*

<a name='P-GetcuReone-FactFactory-BaseEntities-Context-WantActionContext-WantAction'></a>
### WantAction `property`

##### Summary

*Inherit from parent.*
