using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Base collection for <typeparamref name="TFactRule"/>
    /// </summary>
    public abstract class FactRuleCollection<TFactRule>: IList<TFactRule>
        where TFactRule : IFactRule
    {
        private readonly List<TFactRule> _list;

        /// <summary>
        /// Gets or sets the rule at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set</param>
        /// <exception cref="ArgumentOutOfRangeException">index is not a valid index in the <see cref="List{TFactRule}"/></exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="List{TFactRule}"/> is read-only.</exception>
        /// <returns>The rule at the specified index</returns>
        public TFactRule this[int index]
        {
            get => _list[index];
            set
            {

                if (value.Equals(_list[index]))
                    return;
                else if (Contains(value))
                    throw new ArgumentException("This rule is already in the rule collection");

                _list[index] = value;
            }
        }

        /// <summary>
        /// Gets the number of rules contained in the <see cref="FactRuleCollection{TFactRule}"/>
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="FactRuleCollection{TFactRule}"/> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Constructor
        /// </summary>
        protected FactRuleCollection()
        {
            _list = new List<TFactRule>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factRules"></param>
        protected FactRuleCollection(IEnumerable<TFactRule> factRules)
        {
            _list = new List<TFactRule>(factRules);
        }

        /// <summary>
        /// Return <see cref="IFactType"/>
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <returns></returns>
        protected virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Creation method <typeparamref name="TFactRule"/>
        /// </summary>
        /// <param name="func">func for calculate</param>
        /// <param name="inputFactTypes">information on input factacles rules</param>
        /// <param name="outputFactType">information on output fact</param>
        /// <returns></returns>
        protected abstract TFactRule CreateFactRule(Func<IFactContainer, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType);

        /// <summary>
        /// Add rule
        /// </summary>
        /// <param name="item"></param>
        public void Add(TFactRule item)
        {
            if (item.OutputFactType.IsFactType<INotContainedFact>())
                throw new ArgumentException($"A rule cannot return a {item.OutputFactType.FactName}");
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
            Add(CreateFactRule(_ => rule(),
                null,
                GetFactType<TFactResult>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>() ),
                new List<IFactType> { GetFactType<TFactIn1>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>()},
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>(), ct.GetFact<TFactIn15>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>() },
                GetFactType<TFactOut>()));
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
            Add(CreateFactRule(ct => rule(ct.GetFact<TFactIn1>(), ct.GetFact<TFactIn2>(), ct.GetFact<TFactIn3>(), ct.GetFact<TFactIn4>(), ct.GetFact<TFactIn5>(), ct.GetFact<TFactIn6>(), ct.GetFact<TFactIn7>(), ct.GetFact<TFactIn8>(), ct.GetFact<TFactIn9>(), ct.GetFact<TFactIn10>(), ct.GetFact<TFactIn11>(), ct.GetFact<TFactIn12>(), ct.GetFact<TFactIn13>(), ct.GetFact<TFactIn14>(), ct.GetFact<TFactIn15>(), ct.GetFact<TFactIn16>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>(), GetFactType<TFactIn16>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="FactRuleCollection{TFactRule}"/>
        /// </summary>
        /// <param name="rules">The collection whose elements should be added to the end of the  <see cref="FactRuleCollection{TFactRule}"/>. 
        /// The collection itself cannot be null, but it can contain elements that are null,
        /// if type T is a reference type.</param>
        /// <exception cref="ArgumentNullException">collection is null</exception>
        public void AddRange(IEnumerable<TFactRule> rules)
        {
            _list.AddRange(rules);
        }

        /// <summary>
        /// Removes all elements from the <see cref="FactRuleCollection{TFactRule}"/>
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <typeparamref name="TFactRule"/>. Use method <see cref="IFactRule.Compare{TFactRule}(TFactRule)"/>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TFactRule item)
        {
            return _list.Any(r => r.Compare(item));
        }

        /// <summary>
        /// Copies the entire <see cref="FactRuleCollection{TFactRule}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="FactRuleCollection{TFactRule}"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source <see cref="FactRuleCollection{TFactRule}"/> is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(TFactRule[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FactRuleCollection{TFactRule}"/>.
        /// </summary>
        /// <returns>A <see cref="FactRuleCollection{TFactRule}.GetEnumerator"/> for the <see cref="FactRuleCollection{TFactRule}"/>.</returns>
        public IEnumerator<TFactRule> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="FactRuleCollection{TFactRule}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="FactRuleCollection{TFactRule}"/> be null for reference types. The value can</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="FactRuleCollection{TFactRule}"/>, if found; otherwise, –1.</returns>
        public int IndexOf(TFactRule item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the<see cref="FactRuleCollection{TFactRule}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is greater than <see cref="FactRuleCollection{TFactRule}"/>.</exception>
        public void Insert(int index, TFactRule item)
        {
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="FactRuleCollection{TFactRule}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="FactRuleCollection{TFactRule}"/>. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="FactRuleCollection{TFactRule}"/>.</returns>
        public bool Remove(TFactRule item)
        {
            return _list.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="FactRuleCollection{TFactRule}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is equal to or greater than <see cref="FactRuleCollection{TFactRule}"/>.</exception>
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
