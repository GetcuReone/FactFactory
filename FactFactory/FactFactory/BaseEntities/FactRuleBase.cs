using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    /// <typeparam name="TFactBase">The type of fact from which the facts in the container should be inherited</typeparam>
    public abstract class FactRuleBase<TFactBase> : FactWorkBase<TFactBase>, IFactRule<TFactBase>
        where TFactBase : IFact
    {
        private readonly Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> _func;

        /// <summary>
        /// Information on output fact.
        /// </summary>
        public IFactType OutputFactType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func">Func for calculate.</param>
        /// <param name="inputFactTypes">Information on input factacles rules.</param>
        /// <param name="outputFactType">Information on output fact.</param>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        protected FactRuleBase(Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(inputFactTypes)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            new List<IFactType> { OutputFactType }.CheckArgumentFacts<TFactBase>();

            if (InputFactTypes.Any(factType => factType.EqualsFactType(outputFactType)))
                throw new ArgumentException("Cannot request a fact calculated according to the rule.");

        }

        /// <inheritdoc/>
        public virtual TFactBase Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>
        {
            TFactBase fact = _func(container, wantAction);

            if (fact != null)
                fact.CalculatedByRule = true;

            return fact;
        }

        /// <inheritdoc/>
        public virtual bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer<TFactBase>
            where TWantAction : IWantAction<TFactBase>
        {
            return InputFactTypes.All(factInfo => !factInfo.GetFacts(container).IsNullOrEmpty());
        }

        /// <inheritdoc/>
        public override bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
        {
            if (!(workFact is IFactRule<TFactBase> factRule))
                return false;
            if (!OutputFactType.EqualsFactType(factRule.OutputFactType))
                return false;

            return base.EqualsWork(workFact, wantAction, container);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName).ToList())}) => ({OutputFactType.FactName})";
        }

        /// <inheritdoc/>
        public virtual List<IFactType> GetNecessaryFactTypes<TWantAction, TFactContainer>(TWantAction wantAction, TFactContainer container)
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            List<IFactType> result = InputFactTypes.ToList();

            foreach(var fact in container)
            {
                IFactType type = fact.GetFactType();
                IFactType notNeedFact = InputFactTypes.FirstOrDefault(t => t.EqualsFactType(type));

                if (notNeedFact != null)
                    result.Remove(notNeedFact);
            }

            return result;
        }

        /// <inheritdoc/>
        public virtual bool Compatible<TFactRule, TWantAction, TFactContainer>(TFactRule factRule, TWantAction wantAction, TFactContainer container)
            where TFactRule : IFactRule<TFactBase>
            where TWantAction : IWantAction<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>
        {
            return true;
        }
    }
}
