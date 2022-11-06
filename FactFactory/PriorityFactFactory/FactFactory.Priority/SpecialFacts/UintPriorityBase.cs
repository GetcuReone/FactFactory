using FactFactory.Priority.Interfaces;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for priority fact with value of type <see cref="uint"/>.
    /// </summary>
    public abstract class UintPriorityBase : PriorityBase<uint>
    {
        /// <inheritdoc/>
        protected UintPriorityBase(uint value) : base(value)
        {
        }

        /// <inheritdoc/>
        public override int CompareTo(IPriorityFact other)
        {
            switch (other)
            {
                case PriorityBase<int> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case PriorityBase<uint> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case PriorityBase<long> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case PriorityBase<ulong> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);

                case BaseFact<int> priority:
                    return priority.Value.CompareTo(PriorityValue);
                case BaseFact<uint> priority:
                    return priority.Value.CompareTo(PriorityValue);
                case BaseFact<long> priority:
                    return priority.Value.CompareTo(PriorityValue);
                case BaseFact<ulong> priority:
                    return priority.Value.CompareTo(PriorityValue);

                default: throw CreateIncompatibilityVersionException(other);
            }
        }
    }
}
