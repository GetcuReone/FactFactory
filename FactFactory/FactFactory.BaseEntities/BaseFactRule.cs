using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for rules.
    /// </summary>
    public abstract class BaseFactRule : BaseFactWork, IFactRule
    {
        private readonly Func<IEnumerable<IFact>, IFact> _func;
        private readonly Func<IEnumerable<IFact>, ValueTask<IFact>> _funcAsync;

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
        /// <param name="option">Options for a rule.</param>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        protected BaseFactRule(Func<IEnumerable<IFact>, IFact> func, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(inputFactTypes, option)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
            ValidateParam(inputFactTypes, outputFactType);
            OutputFactType = outputFactType;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="funcAsync">Func for calculate.</param>
        /// <param name="inputFactTypes">Information on input factacles rules.</param>
        /// <param name="outputFactType">Information on output fact.</param>
        /// <param name="option">Options for a rule.</param>
        /// <exception cref="ArgumentNullException"><paramref name="funcAsync"/> or <paramref name="outputFactType"/> is null.</exception>
        /// <exception cref="ArgumentException">The fact is requested at the input, which the rule calculates.</exception>
        protected BaseFactRule(Func<IEnumerable<IFact>, ValueTask<IFact>> funcAsync, List<IFactType> inputFactTypes, IFactType outputFactType, FactWorkOption option)
            : base(inputFactTypes, option)
        {
            _funcAsync = funcAsync ?? throw new ArgumentNullException(nameof(funcAsync));
            ValidateParam(inputFactTypes, outputFactType);
            OutputFactType = outputFactType;
        }

        private void ValidateParam(List<IFactType> inputFactTypes, IFactType outputFactType)
        {
            if (outputFactType == null)
                throw new ArgumentNullException(nameof(outputFactType));

            outputFactType.CannotIsType<ISpecialFact>(nameof(outputFactType));

            if (InputFactTypes.Any(factType => factType.EqualsFactType(outputFactType)))
                throw new ArgumentException("Cannot request a fact calculated according to the rule.", nameof(inputFactTypes));
        }

        /// <inheritdoc/>
        public override bool EqualsWork<TFactWork, TWantAction>(TFactWork workFact, TWantAction wantAction, IFactContainer container)
        {
            if (!(workFact is IFactRule factRule))
                return false;
            if (!OutputFactType.EqualsFactType(factRule.OutputFactType))
                return false;

            return base.EqualsWork(workFact, wantAction, container);
        }

        /// <inheritdoc/>
        public virtual ValueTask<IFact> CalculateAsync(IEnumerable<IFact> requireFacts)
        {
            return _funcAsync(requireFacts);
        }

        /// <inheritdoc/>
        public virtual IFact Calculate(IEnumerable<IFact> requireFacts)
        {
            return _func(requireFacts);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName))}) => ({OutputFactType.FactName})";
        }
    }
}
