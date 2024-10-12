using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for <see cref="IWantAction"/>.
    /// </summary>
    public abstract class BaseWantAction : BaseFactWork, IWantAction
    {
        private readonly Action<IEnumerable<IFact>> _action;
        private readonly Func<IEnumerable<IFact>, ValueTask> _actionAsync;
        private List<IFactRule> _usedRules;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <param name="option">WantAction options.</param>
        protected BaseWantAction(Action<IEnumerable<IFact>> wantAction, List<IFactType> factTypes, FactWorkOption option)
            : base(factTypes, option)
        {
            _action = wantAction ?? throw new ArgumentNullException(nameof(wantAction));
            Validate(factTypes);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantActionAsync">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        /// <param name="option">WantAction options.</param>
        protected BaseWantAction(Func<IEnumerable<IFact>, ValueTask> wantActionAsync, List<IFactType> factTypes, FactWorkOption option)
            : base(factTypes, option)
        {
            _actionAsync = wantActionAsync ?? throw new ArgumentNullException(nameof(wantActionAsync));
            Validate(factTypes);
        }

        private void Validate(List<IFactType> factTypes)
        {
            if (InputFactTypes.IsNullOrEmpty())
                throw new ArgumentException("factTypes cannot be empty. The desired action should request a fact on entry.");
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({string.Join(", ", InputFactTypes.Select(f => f.FactName))})";
        }

        /// <inheritdoc/>
        public virtual void Invoke(IEnumerable<IFact> requireFacts)
        {
            _action(requireFacts);
        }

        /// <inheritdoc/>
        public virtual async ValueTask InvokeAsync(IEnumerable<IFact> requireFacts)
        {
            await _actionAsync(requireFacts).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual void AddUsedRule(IFactRule rule)
        {
            if (_usedRules == null)
                _usedRules = new List<IFactRule>();

            _usedRules.Add(rule);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IFactRule> GetUsedRules()
        {
            return _usedRules?.AsReadOnly() ?? Enumerable.Empty<IFactRule>();
        }
    }
}
