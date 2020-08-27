using FactFactory.Priority.Interfaces;
using GetcuReone.FactFactory.Constants;
using GetcuReone.FactFactory.Exceptions;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for <see cref="IPriorityFact"/>.
    /// </summary>
    /// <typeparam name="TPriorityValue">Priority value type.</typeparam>
    public abstract class PriorityBase<TPriorityValue> : FactBase, IPriorityFact
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
    }
}
