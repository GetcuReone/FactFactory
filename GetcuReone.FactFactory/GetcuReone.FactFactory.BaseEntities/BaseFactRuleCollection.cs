﻿using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Extensions;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelper = GetcuReone.FactFactory.FactFactoryHelper;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base collection for <see cref="IFactRule"/>.
    /// </summary>
    public abstract class BaseFactRuleCollection: IFactRuleCollection, IFactTypeCreation
    {
        private List<IFactRule> _list;

        /// <summary>
        /// Gets or sets the rule at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is not a valid index in the <see cref="List{IFactRule}"/>.</exception>
        /// <exception cref="NotSupportedException">The property is set and the <see cref="List{IFactRule}"/> is read-only.</exception>
        /// <returns>The rule at the specified index</returns>
        public IFactRule this[int index]
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
        /// Gets the number of rules contained in the <see cref="BaseFactRuleCollection"/>.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="BaseFactRuleCollection"/> is read-only.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BaseFactRuleCollection() : this(null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        protected BaseFactRuleCollection(IEnumerable<IFactRule>? factRules) : this(factRules, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factRules"></param>
        /// <param name="isReadOnly"></param>
        protected BaseFactRuleCollection(IEnumerable<IFactRule>? factRules, bool isReadOnly)
        {
            if (factRules != null)
                _list = new List<IFactRule>(factRules);
            else
                _list = new List<IFactRule>();

            IsReadOnly = isReadOnly;
        }

        private void CheckReadOnly()
        {
            if (IsReadOnly)
                throw CommonHelper.CreateException(ErrorCode.InvalidOperation, $"Rule collection is read-only.");
        }

        /// <inheritdoc/>
        public virtual IFactType GetFactType<TFact>() where TFact : IFact
        {
            return new FactType<TFact>();
        }

        /// <summary>
        /// Creation method <see cref="IFactRule"/>
        /// </summary>
        /// <param name="func">func for calculate.</param>
        /// <param name="inputFactTypes">information on input factacles rules.</param>
        /// <param name="outputFactType">information on output fact.</param>
        /// <param name="option"></param>
        /// <returns></returns>
        protected abstract IFactRule CreateFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType>? inputFactTypes, IFactType outputFactType, FactWorkOption option);

        /// <summary>
        /// Creates <ses cref="IFactRule"/>.
        /// </summary>
        /// <param name="func">func for calculate.</param>
        /// <param name="inputFactTypes">information on input factacles rules.</param>
        /// <param name="outputFactType">information on output fact.</param>
        /// <param name="option">Options for a rule.</param>
        /// <returns>Fact rule.</returns>
        protected abstract IFactRule CreateFactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> func, List<IFactType>? inputFactTypes, IFactType outputFactType, FactWorkOption option);

        /// <summary>
        /// Rules equality.
        /// </summary>
        /// <param name="firstRule"></param>
        /// <param name="secondRule"></param>
        /// <returns></returns>
        protected virtual bool EqualsRules(IFactRule firstRule, IFactRule secondRule)
        {
            if (firstRule == null && secondRule == null)
                return true;

            if (firstRule == null || secondRule == null)
                return false;

            if (firstRule.OutputFactType != null)
            {
                if (secondRule.OutputFactType == null)
                    return false;

                if (!firstRule.OutputFactType.EqualsFactType(secondRule.OutputFactType))
                    return false;
            }
            else if (secondRule.OutputFactType != null)
                return false;

            if (firstRule.InputFactTypes.IsNullOrEmpty())
                return secondRule.InputFactTypes.IsNullOrEmpty();
            else if (secondRule.InputFactTypes.IsNullOrEmpty())
                return false;

            if (firstRule.InputFactTypes!.Count != secondRule.InputFactTypes!.Count)
                return false;

            return firstRule.InputFactTypes
                .All(firstType => secondRule.InputFactTypes
                    .Any(secondType => firstType.EqualsFactType(secondType)));
        }

        /// <summary>
        /// Adds rule.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IFactRule item)
        {
            CheckReadOnly();

            item.OutputFactType.CannotIsType<ISpecialFact>(nameof(item));

            if (Contains(item))
                throw new ArgumentException("This rule is already in the rule collection.");

            _list.Add(item);
        }

        /// <summary>
        /// Adds a rule without input facts.
        /// </summary>
        /// <typeparam name="TFactOut">Type of fact result.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactOut>(Func<TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
        {
            Add(CreateFactRule(facts => rule(),
                null,
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 1 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactOut>(
            Func<TFactIn1, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>()),
                new List<IFactType> { GetFactType<TFactIn1>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 2 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 3 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 4 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 5 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation..</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 6 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 7 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
        {
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 8 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 9 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 10 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 11 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 12 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 13 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 14 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>()},
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 15 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>(), facts.GetFact<TFactIn15>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 16 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut> rule, FactWorkOption option = FactWorkOption.CanExecuteSync)
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
            Add(CreateFactRule(
                facts => rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>(), facts.GetFact<TFactIn15>(), facts.GetFact<TFactIn16>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>(), GetFactType<TFactIn16>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule without input facts.
        /// </summary>
        /// <typeparam name="TFactOut">Type of fact result.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactOut>(Func<ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
        {
            Add(CreateFactRule(
                async facts => await rule().ConfigureAwait(false),
                null,
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 1 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactOut>(
            Func<TFactIn1, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>()),
                new List<IFactType> { GetFactType<TFactIn1>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 2 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactOut>(
            Func<TFactIn1, TFactIn2, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 3 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 4 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 5 input facts.
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation..</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 6 input facts
        /// </summary>
        /// <typeparam name="TFactIn1">Type 1 input fact.</typeparam>
        /// <typeparam name="TFactIn2">Type 2 input fact.</typeparam>
        /// <typeparam name="TFactIn3">Type 3 input fact.</typeparam>
        /// <typeparam name="TFactIn4">Type 4 input fact.</typeparam>
        /// <typeparam name="TFactIn5">Type 5 input fact.</typeparam>
        /// <typeparam name="TFactIn6">Type 6 input fact.</typeparam>
        /// <typeparam name="TFactOut">Type output fact.</typeparam>
        /// <param name="rule">Rule of fact calculation.</param>
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 7 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
            where TFactOut : IFact
            where TFactIn1 : IFact
            where TFactIn2 : IFact
            where TFactIn3 : IFact
            where TFactIn4 : IFact
            where TFactIn5 : IFact
            where TFactIn6 : IFact
            where TFactIn7 : IFact
        {
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 8 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 9 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 10 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 11 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 12 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 13 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 14 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 15 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>(), facts.GetFact<TFactIn15>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <summary>
        /// Adds a rule with 16 input facts
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
        /// <param name="option">Options for a rule.</param>
        public void Add<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, TFactOut>(
            Func<TFactIn1, TFactIn2, TFactIn3, TFactIn4, TFactIn5, TFactIn6, TFactIn7, TFactIn8, TFactIn9, TFactIn10, TFactIn11, TFactIn12, TFactIn13, TFactIn14, TFactIn15, TFactIn16, ValueTask<TFactOut>> rule, FactWorkOption option = FactWorkOption.CanExecuteAsync)
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
            Add(CreateFactRule(
                async facts => await rule(facts.GetFact<TFactIn1>(), facts.GetFact<TFactIn2>(), facts.GetFact<TFactIn3>(), facts.GetFact<TFactIn4>(), facts.GetFact<TFactIn5>(), facts.GetFact<TFactIn6>(), facts.GetFact<TFactIn7>(), facts.GetFact<TFactIn8>(), facts.GetFact<TFactIn9>(), facts.GetFact<TFactIn10>(), facts.GetFact<TFactIn11>(), facts.GetFact<TFactIn12>(), facts.GetFact<TFactIn13>(), facts.GetFact<TFactIn14>(), facts.GetFact<TFactIn15>(), facts.GetFact<TFactIn16>()),
                new List<IFactType> { GetFactType<TFactIn1>(), GetFactType<TFactIn2>(), GetFactType<TFactIn3>(), GetFactType<TFactIn4>(), GetFactType<TFactIn5>(), GetFactType<TFactIn6>(), GetFactType<TFactIn7>(), GetFactType<TFactIn8>(), GetFactType<TFactIn9>(), GetFactType<TFactIn10>(), GetFactType<TFactIn11>(), GetFactType<TFactIn12>(), GetFactType<TFactIn13>(), GetFactType<TFactIn14>(), GetFactType<TFactIn15>(), GetFactType<TFactIn16>() },
                GetFactType<TFactOut>(),
                option));
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">collection is null</exception>
        public virtual void AddRange(IEnumerable<IFactRule> rules)
        {
            CheckReadOnly();

            foreach (IFactRule rule in rules)
            {
                rule.OutputFactType.CannotIsType<ISpecialFact>(nameof(rule));

                if (Contains(rule))
                    throw new ArgumentException("This rule is already in the rule collection.");
            }

            _list.AddRange(rules);
        }

        /// <summary>
        /// Removes all elements from the <see cref="BaseFactRuleCollection"/>
        /// </summary>
        public void Clear()
        {
            CheckReadOnly();

            _list.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="IFactRule"/>.
        /// Use method <see cref="EqualsRules(IFactRule, IFactRule)"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(IFactRule item)
        {
            return _list.Any(r => EqualsRules(item, r));
        }

        /// <summary>
        /// Copies the entire <see cref="BaseFactRuleCollection"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="BaseFactRuleCollection"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source <see cref="BaseFactRuleCollection"/> is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(IFactRule[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<IFactRule> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Sorts collection.
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<IFactRule> comparer)
        {
            _list.Sort(comparer);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="BaseFactRuleCollection"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BaseFactRuleCollection"/> be null for reference types. The value can</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire <see cref="BaseFactRuleCollection"/>, if found; otherwise, –1.</returns>
        public int IndexOf(IFactRule item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the<see cref="BaseFactRuleCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is greater than <see cref="BaseFactRuleCollection"/>.</exception>
        public void Insert(int index, IFactRule item)
        {
            CheckReadOnly();

            _list.Insert(index, item);
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="BaseFactRuleCollection"/>.
        /// </summary>
        /// <param name="action">The System.Action`1 delegate to perform on each element of the <see cref="BaseFactRuleCollection"/>.</param>
        public void ForEach(Action<IFactRule> action)
        {
            _list.ForEach(action);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="BaseFactRuleCollection"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="BaseFactRuleCollection"/>. The value can be null for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="BaseFactRuleCollection"/>.</returns>
        public bool Remove(IFactRule item)
        {
            CheckReadOnly();

            return _list.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the <see cref="BaseFactRuleCollection"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0. -or- index is equal to or greater than <see cref="BaseFactRuleCollection"/>.</exception>
        public void RemoveAt(int index)
        {
            CheckReadOnly();

            _list.RemoveAt(index);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// <see cref="BaseFactRuleCollection"/> copy method.
        /// </summary>
        /// <returns>Copied <see cref="BaseFactRuleCollection"/>.</returns>
        public virtual IFactRuleCollection Copy()
        {
            var result = (BaseFactRuleCollection) Empty();

            result._list = new List<IFactRule>(_list);

            return result;
        }

        /// <summary>
        /// Return a copy of an object without rules.
        /// </summary>
        /// <returns>Copy of object without rules.</returns>
        protected abstract IFactRuleCollection Empty();

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is null.</exception>
        public virtual IFactRuleCollection FindAll(Func<IFactRule, bool> predicate)
        {
            var result = (BaseFactRuleCollection)Empty();

            result._list = _list.FindAll(r => predicate(r));

            return result;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is null.</exception>
        public IFactRuleCollection SortByDescending<TKey>(Func<IFactRule, TKey> keySelector, IComparer<TKey> comparer)
        {
            var result = (BaseFactRuleCollection)Empty();

            result._list = new List<IFactRule>(_list.OrderByDescending(keySelector, comparer));

            return result;
        }
    }
}
