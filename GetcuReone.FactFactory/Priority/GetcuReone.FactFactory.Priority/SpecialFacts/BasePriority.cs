using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.SpecialFacts;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IPriorityFact"/>.
    /// </summary>
    /// <typeparam name="TPriorityValue">Priority value type.</typeparam>
    public abstract class BasePriority<TPriorityValue> : BaseSpecialFact, IPriorityFact
    {
        /// <summary>
        /// Priority value.
        /// </summary>
        public TPriorityValue PriorityValue { get; }

        /// <inheritdoc/>
        protected BasePriority(TPriorityValue value)
        {
            PriorityValue = value;
        }

        /// <summary>
        /// Compares the priority fact to the <paramref name="other"/>.
        /// </summary>
        /// <param name="other">Priority fact for comparison</param>
        /// <returns>1 - more, 0 - equal, -1 less.</returns>
        public abstract int CompareTo(IPriorityFact other);

        /// <summary>
        /// Creates an error creating incompatibility priority facts.
        /// </summary>
        /// <param name="priorityFact">Priority fact.</param>
        /// <returns>Error creating incompatibility priority facts.</returns>
        protected virtual FactFactoryException CreateIncompatibilityVersionException(IPriorityFact priorityFact)
        {
            return FactFactoryHelper.CreateException(
                ErrorCode.InvalidFactType,
                $"Unable to compare priorities {GetFactType().FactName} and {priorityFact.GetFactType().FactName}.");
        }

        /// <summary>
        /// Extracts the <see cref="BasePriority{TPriorityValue}.PriorityValue"/>.
        /// </summary>
        /// <param name="fact">Priority fact.</param>
        public static implicit operator TPriorityValue(BasePriority<TPriorityValue> fact)
        {
            return fact.PriorityValue;
        }

        /// <inheritdoc/>
        public override bool EqualsInfo(ISpecialFact specialFact)
        {
            return specialFact != null
                && specialFact is IPriorityFact priorityFact
                && CompareTo(priorityFact) == 0;
        }
    }
}
