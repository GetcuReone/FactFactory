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
    public abstract class FactRuleBase : FactWorkBase, IFactRule
    {
        private readonly Func<IFactContainer, IWantAction, IFact> _func;
        private readonly Func<IEnumerable<IFact>, IFact> _func2;

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
        protected FactRuleBase(Func<IFactContainer, IWantAction, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(inputFactTypes)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            if (InputFactTypes.Any(factType => factType.EqualsFactType(outputFactType)))
                throw new ArgumentException("Cannot request a fact calculated according to the rule.", nameof(inputFactTypes));
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func">Func for calculate.</param>
        /// <param name="inputFactTypes">Information on input factacles rules.</param>
        /// <param name="outputFactType">Information on output fact.</param>
        /// /// <exception cref="ArgumentNullException"><paramref name="func"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        protected FactRuleBase(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(inputFactTypes)
        {
            _func2 = func ?? throw new ArgumentNullException(nameof(func));
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            if (InputFactTypes.Any(factType => factType.EqualsFactType(outputFactType)))
                throw new ArgumentException("Cannot request a fact calculated according to the rule.", nameof(inputFactTypes));
        }

        /// <inheritdoc/>
        public virtual IFact Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer
            where TWantAction : IWantAction
        {
            IFact fact = _func(container, wantAction);

            if (fact != null)
                fact.CalculatedByRule = true;

            return fact;
        }

        /// <inheritdoc/>
        public virtual bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
            where TContainer : IFactContainer
            where TWantAction : IWantAction
        {
            return InputFactTypes.All(factInfo => !factInfo.GetFacts(container).IsNullOrEmpty());
        }

        /// <inheritdoc/>
        public override bool EqualsWork<TFactWork, TWantAction, TFactContainer>(TFactWork workFact, TWantAction wantAction, TFactContainer container)
        {
            if (!(workFact is IFactRule factRule))
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
            where TWantAction : IWantAction
            where TFactContainer : IFactContainer
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
        public virtual IFact Calculate(IEnumerable<IFact> requireFacts)
        {
            return _func2(requireFacts);
        }
    }
}
