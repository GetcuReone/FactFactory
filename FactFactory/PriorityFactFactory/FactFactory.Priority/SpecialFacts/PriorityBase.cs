using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using GetcuReone.FactFactory.SpecialFacts;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IPriorityFact"/>.
    /// </summary>
    /// <typeparam name="TPriorityValue">Priority value type.</typeparam>
    public abstract class PriorityBase<TPriorityValue> : SpecialFactBase, IPriorityFact
    {
        /// <summary>
        /// Priority value.
        /// </summary>
        public TPriorityValue PriorityValue { get; }

        /// <inheritdoc/>
        protected PriorityBase(TPriorityValue value)
        {
            PriorityValue = value;
        }

        /// <inheritdoc/>
        public abstract int CompareTo(IPriorityFact other);

        /// <summary>
        /// Error creating version incompatibility.
        /// </summary>
        /// <param name="priorityFact"></param>
        /// <returns></returns>
        protected virtual FactFactoryException CreateIncompatibilityVersionException(IPriorityFact priorityFact)
        {
            return FactFactoryHelper.CreateException(
                ErrorCode.InvalidFactType,
                $"Unable to compare priorities {GetFactType().FactName} and {priorityFact.GetFactType().FactName}.");
        }

        /// <summary>
        /// Extract <see cref="PriorityBase{TPriorityValue}.PriorityValue"/>.
        /// </summary>
        /// <param name="fact"></param>
        public static implicit operator TPriorityValue(PriorityBase<TPriorityValue> fact)
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
