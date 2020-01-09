using FactFactory.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FactFactory.Entities
{
    /// <summary>
    /// Collection fo <see cref="FactRule"/>
    /// </summary>
    public class FactRuleCollection: IList<FactRule>
    {
        private readonly List<FactRule> _list;

        /// <summary>
        /// Constructor
        /// </summary>
        public FactRuleCollection()
        {
            _list = new List<FactRule>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factRules"></param>
        public FactRuleCollection(IEnumerable<FactRule> factRules)
        {
            _list = new List<FactRule>(factRules);
        }

        /// <inheritdoc />
        public FactRule this[int index] 
        { 
            get => _list[index]; 
            set
            {

                if (value == _list[index])
                    return;
                else if (Contains(value))
                    throw new ArgumentException("This rule is already in the rule collection");

                _list[index] = value;
            }
        }

        /// <inheritdoc />
        public int Count => _list.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public void Add(FactRule item)
        {
            if (Contains(item))
                throw new ArgumentException("This rule is already in the rule collection");

            _list.Add(item);
        }

        /// <summary>
        /// Add a rule without input facts
        /// </summary>
        /// <typeparam name="TFactResult">type of fact result</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactResult>(Func<TFactResult> rule)
            where TFactResult: IFact
        {
            Add(new FactRule(_ => rule(),
                null,
                new FactInfo<TFactResult>()));
        }

        /// <summary>
        /// Add a rule with 1 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactOut>(
            Func<TFactIn1, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>() ),
                new List<IFactInfo> { new FactInfo<TFactIn1>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 2 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 3 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 4 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 5 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 6 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 7 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 8 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 9 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 10 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 11 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 12 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactIn12">type 12 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
            where TFactIn12 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>(), new FactInfo<TFactIn12>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 13 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactIn12">type 12 input fact</typeparam>
        /// <typeparam name="TFactIn13">type 13 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
            where TFactIn12 : IFact
            where TFactIn13 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>(), new FactInfo<TFactIn12>(), new FactInfo<TFactIn13>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 14 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactIn12">type 12 input fact</typeparam>
        /// <typeparam name="TFactIn13">type 13 input fact</typeparam>
        /// <typeparam name="TFactIn14">type 14 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
            where TFactIn12 : IFact
            where TFactIn13 : IFact
            where TFactIn14 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>(), new FactInfo<TFactIn12>(), new FactInfo<TFactIn13>(), new FactInfo<TFactIn14>()},
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 15 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactIn12">type 12 input fact</typeparam>
        /// <typeparam name="TFactIn13">type 13 input fact</typeparam>
        /// <typeparam name="TFactIn14">type 14 input fact</typeparam>
        /// <typeparam name="TFactIn15">type 15 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
            where TFactIn12 : IFact
            where TFactIn13 : IFact
            where TFactIn14 : IFact
            where TFactIn15 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>(), ct.GetFact<TFactIn15>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>(), new FactInfo<TFactIn12>(), new FactInfo<TFactIn13>(), new FactInfo<TFactIn14>(), new FactInfo<TFactIn15>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 16 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">type 1 input fact</typeparam>
        /// <typeparam name="TFactIn2">type 2 input fact</typeparam>
        /// <typeparam name="TFactIn3">type 3 input fact</typeparam>
        /// <typeparam name="TFactIn4">type 4 input fact</typeparam>
        /// <typeparam name="TFactIn5">type 5 input fact</typeparam>
        /// <typeparam name="TFactIn6">type 6 input fact</typeparam>
        /// <typeparam name="TFactIn7">type 7 input fact</typeparam>
        /// <typeparam name="TFactIn8">type 8 input fact</typeparam>
        /// <typeparam name="TFactIn9">type 9 input fact</typeparam>
        /// <typeparam name="TFactIn10">type 10 input fact</typeparam>
        /// <typeparam name="TFactIn11">type 11 input fact</typeparam>
        /// <typeparam name="TFactIn12">type 12 input fact</typeparam>
        /// <typeparam name="TFactIn13">type 13 input fact</typeparam>
        /// <typeparam name="TFactIn14">type 14 input fact</typeparam>
        /// <typeparam name="TFactIn15">type 15 input fact</typeparam>
        /// <typeparam name="TFactIn16">type 16 input fact</typeparam>
        /// <typeparam name="TFactOut">type output fact</typeparam>
        /// <param name="rule">rule of fact derivation</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut> rule)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
            where TFactIn8 : IFact
            where TFactIn9 : IFact
            where TFactIn10 : IFact
            where TFactIn11 : IFact
            where TFactIn12 : IFact
            where TFactIn13 : IFact
            where TFactIn14 : IFact
            where TFactIn15 : IFact
            where TFactIn16 : IFact
        {
            Add(new FactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>(), ct.GetFact<TFactIn15>(), ct.GetFact<TFactIn16>()),
                new List<IFactInfo> { new FactInfo<TFactIn1>(), new FactInfo<TFactIn2>(), new FactInfo<TFactIn3>(), new FactInfo<TFactIn4>(), new FactInfo<TFactIn5>(), new FactInfo<TFactIn6>(), new FactInfo<TFactIn7>(), new FactInfo<TFactIn8>(), new FactInfo<TFactIn9>(), new FactInfo<TFactIn10>(), new FactInfo<TFactIn11>(), new FactInfo<TFactIn12>(), new FactInfo<TFactIn13>(), new FactInfo<TFactIn14>(), new FactInfo<TFactIn15>(), new FactInfo<TFactIn16>() },
                new FactInfo<TFactOut>()));
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="FactRuleCollection"/>
        /// </summary>
        /// <param name="rules">The collection whose elements should be added to the end of the  <see cref="FactRuleCollection"/>. 
        /// The collection itself cannot be null, but it can contain elements that are null,
        /// if type T is a reference type.</param>
        /// <exception cref="ArgumentNullException">collection is null</exception>
        public void AddRange(IEnumerable<FactRule> rules)
        {
            _list.AddRange(rules);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _list.Clear();
        }

        /// <inheritdoc />
        public bool Contains(FactRule item)
        {
            return _list.Any(r => r.Compare(item));
        }

        /// <inheritdoc />
        public void CopyTo(FactRule[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public IEnumerator<FactRule> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <inheritdoc />
        public int IndexOf(FactRule item)
        {
            return _list.IndexOf(item);
        }

        /// <inheritdoc />
        public void Insert(int index, FactRule item)
        {
            _list.Insert(index, item);
        }

        /// <inheritdoc />
        public bool Remove(FactRule item)
        {
            return _list.Remove(item);
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
