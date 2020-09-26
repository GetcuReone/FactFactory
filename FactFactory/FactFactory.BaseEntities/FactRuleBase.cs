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
        private readonly Func<IEnumerable<IFact>, IFact> _func;

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
        protected FactRuleBase(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType)
            : base(inputFactTypes, FactWorkOption.CanExecuteSync)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            OutputFactType = outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            if (InputFactTypes.Any(factType => factType.EqualsFactType(outputFactType)))
                throw new ArgumentException("Cannot request a fact calculated according to the rule.", nameof(inputFactTypes));
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
        public virtual IFact Calculate(IEnumerable<IFact> requireFacts)
        {
            return _func(requireFacts);
        }
    }
}
