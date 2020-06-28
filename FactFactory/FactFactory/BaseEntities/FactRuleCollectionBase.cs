using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base collection for <typeparamref name="TFactRule"/>.
    /// </summary>
    public abstract class FactRuleCollectionBase<TFactBase, TFactRule>: IList<TFactRule>, ICopy<FactRuleCollectionBase<TFactBase, TFactRule>>
        where TFactBase : IFact
        where TFactRule : IFactRule<TFactBase>
    {
        private readonly List<TFactRule> _list;

        /// <summary>
        /// Gets or sets the rule at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is not a valid index in the <see cref="List{TFactRule}"/>.</exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="List{TFactRule}"/> is read-only.</exception>
        /// <returns>The rule at the specified index</returns>
        public TFactRule this[int index]
        {
            get => _list[index];
            set
            {
                CheckReadOnly();
                if (value.Equals(_list[index]))
                    return;
                else if (Contains(value))
                    throw new ArgumentException("This rule is already in the rule collection");

                _list[index] = value;
            }
        }

        /// <summary>
        /// Gets the number of rules contained in the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> is read-only.
        /// </summary>
        public bool IsReadOnly { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected FactRuleCollectionBase() : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        protected FactRuleCollectionBase(IEnumerable<TFactRule> factRules) : this(factRules, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        protected FactRuleCollectionBase(IEnumerable<TFactRule> factRules, bool isReadOnly)
        {
            if (factRules != null)
                _list = new List<TFactRule>(factRules);
            else
                _list = new List<TFactRule>();

            IsReadOnly = isReadOnly;
        }

        private void CheckReadOnly()
        {
            if (IsReadOnly)
                throw FactFactoryHelper.CreateException(ErrorCode.InvalidOperation, $"Rule collection is read-only.");
        }

        /// <summary>
        /// Return <see cref="IFactType"/>.
        /// </summary>
        /// <typeparam name="TGetFact"></typeparam>
        /// <returns></returns>
        protected virtual IFactType GetFactType<TGetFact>() where TGetFact : TFactBase
        {
            return new FactType<TGetFact>();
        }

        /// <summary>
        /// Creation method <typeparamref name="TFactRule"/>.
        /// </summary>
        /// <param name="func">func for calculate.</param>
        /// <param name="inputFactTypes">information on input factacles rules.</param>
        /// <param name="outputFactType">information on output fact.</param>
        /// <returns></returns>
        protected abstract TFactRule CreateFactRule(Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType);

        /// <summary>
        /// Return the correct fact.
        /// </summary>
        /// <typeparam name="TFact"></typeparam>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <returns></returns>
        protected virtual TFact GetCorrectFact<TFact>(IFactContainer<TFactBase> container, IWantAction<TFactBase> wantAction)
            where TFact : TFactBase
        {
            return container.GetFact<TFact>();
        }

        /// <summary>
        /// Add rule.
        /// </summary>
        /// <param name="item"></param>
        public void Add(TFactRule item)
        {
            CheckReadOnly();

            if (item.OutputFactType.IsFactType<INotContainedFact>())
                throw new ArgumentException($"A rule cannot return a {item.OutputFactType.FactName}");
            if (Contains(item))
                throw new ArgumentException("This rule is already in the rule collection");

            _list.Add(item);
        }

        /// <summary>
        /// Add a rule without input facts.
        /// </summary>
        /// <typeparam name="TFactResult">Type of fact result.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactResult>(Func<TFactResult> rule)
            where TFactResult: TFactBase
        {
            Add(CreateFactRule((_, __) => rule(),
                null,
                GetFactType<TFactResult>()));
        }

        /// <summary>
        /// Add a rule with 1 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactOut>(
            Func<TFactIn1, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 2 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 3 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 4 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 5 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation..</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 6 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 7 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 8 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 9 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 10 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 11 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 12 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactIn12">Type 12 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
            where TFactIn12 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa), GetCorrectFact<TFactIn12>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 13 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactIn12">Type 12 input fact.</typeparam>
        /// <typeparam name="TFactIn13">Type 13 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
            where TFactIn12 : TFactBase
            where TFactIn13 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa), GetCorrectFact<TFactIn12>(ct, wa), GetCorrectFact<TFactIn13>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 14 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactIn12">Type 12 input fact.</typeparam>
        /// <typeparam name="TFactIn13">Type 13 input fact.</typeparam>
        /// <typeparam name="TFactIn14">Type 14 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
            where TFactIn12 : TFactBase
            where TFactIn13 : TFactBase
            where TFactIn14 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa), GetCorrectFact<TFactIn12>(ct, wa), GetCorrectFact<TFactIn13>(ct, wa), GetCorrectFact<TFactIn14>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>()},
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 15 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactIn12">Type 12 input fact.</typeparam>
        /// <typeparam name="TFactIn13">Type 13 input fact.</typeparam>
        /// <typeparam name="TFactIn14">Type 14 input fact.</typeparam>
        /// <typeparam name="TFactIn15">Type 15 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
            where TFactIn12 : TFactBase
            where TFactIn13 : TFactBase
            where TFactIn14 : TFactBase
            where TFactIn15 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa), GetCorrectFact<TFactIn12>(ct, wa), GetCorrectFact<TFactIn13>(ct, wa), GetCorrectFact<TFactIn14>(ct, wa), GetCorrectFact<TFactIn15>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Add a rule with 16 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactIn7">Type 7 input fact.</typeparam>
        /// <typeparam name="TFactIn8">Type 8 input fact.</typeparam>
        /// <typeparam name="TFactIn9">Type 9 input fact.</typeparam>
        /// <typeparam name="TFactIn10">Type 10 input fact.</typeparam>
        /// <typeparam name="TFactIn11">Type 11 input fact.</typeparam>
        /// <typeparam name="TFactIn12">Type 12 input fact.</typeparam>
        /// <typeparam name="TFactIn13">Type 13 input fact.</typeparam>
        /// <typeparam name="TFactIn14">Type 14 input fact.</typeparam>
        /// <typeparam name="TFactIn15">Type 15 input fact.</typeparam>
        /// <typeparam name="TFactIn16">Type 16 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut> rule)
            where TFactOut : TFactBase
            where TFactIn1 : TFactBase
            where TFactIn2 : TFactBase
            where TFactIn3 : TFactBase
            where TFactIn4 : TFactBase
            where TFactIn5 : TFactBase
            where TFactIn6 : TFactBase
            where TFactIn7 : TFactBase
            where TFactIn8 : TFactBase
            where TFactIn9 : TFactBase
            where TFactIn10 : TFactBase
            where TFactIn11 : TFactBase
            where TFactIn12 : TFactBase
            where TFactIn13 : TFactBase
            where TFactIn14 : TFactBase
            where TFactIn15 : TFactBase
            where TFactIn16 : TFactBase
        {
            Add(CreateFactRule(
                (ct, wa) => rule(GetCorrectFact<TFactIn1>(ct, wa), GetCorrectFact<TFactIn2>(ct, wa), GetCorrectFact<TFactIn3>(ct, wa), GetCorrectFact<TFactIn4>(ct, wa), GetCorrectFact<TFactIn5>(ct, wa), GetCorrectFact<TFactIn6>(ct, wa), GetCorrectFact<TFactIn7>(ct, wa), GetCorrectFact<TFactIn8>(ct, wa), GetCorrectFact<TFactIn9>(ct, wa), GetCorrectFact<TFactIn10>(ct, wa), GetCorrectFact<TFactIn11>(ct, wa), GetCorrectFact<TFactIn12>(ct, wa), GetCorrectFact<TFactIn13>(ct, wa), GetCorrectFact<TFactIn14>(ct, wa), GetCorrectFact<TFactIn15>(ct, wa), GetCorrectFact<TFactIn16>(ct, wa)),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>(), GetFactType<TFactIn16>() },
                GetFactType<TFactOut>()));
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>
        /// </summary>
        /// <param name="rules">The collection whose elements should be added to the end of the  <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>. 
        /// The collection itself cannot be null, but it can contain elements that are null,
        /// if type T is a reference type.</param>
        /// <exception cref="ArgumentNullException">collection is null</exception>
        public void AddRange(IEnumerable<TFactRule> rules)
        {
            foreach (TFactRule rule in rules)
                Add(rule);
        }

        /// <summary>
        /// Removes all elements from the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>
        /// </summary>
        public void Clear()
        {
            CheckReadOnly();

            _list.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <typeparamref name="TFactRule"/>. Use method <see cref="IFactRule{TFact}.Compare{TFactRule}(TFactRule)"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TFactRule item)
        {
            return _list.Any(r => r.Compare(item));
        }

        /// <summary>
        /// Copies the entire <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(TFactRule[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{TFactRule}"/> for the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.</returns>
        public IEnumerator<TFactRule> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> be null for reference types. The value can</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>, if found; otherwise, –1.</returns>
        public int IndexOf(TFactRule item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the<see cref="FactRuleCollectionBase{TFact, TFactRule}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is greater than <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.</exception>
        public void Insert(int index, TFactRule item)
        {
            CheckReadOnly();

            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.</returns>
        public bool Remove(TFactRule item)
        {
            CheckReadOnly();

            return _list.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is equal to or greater than <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.</exception>
        public void RemoveAt(int index)
        {
            CheckReadOnly();

            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// <see cref="FactRuleCollectionBase{TFact, TFactRule}"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="FactRuleCollectionBase{TFact, TFactRule}"/>.</returns>
        public abstract FactRuleCollectionBase<TFactBase, TFactRule> Copy();
    }
}
