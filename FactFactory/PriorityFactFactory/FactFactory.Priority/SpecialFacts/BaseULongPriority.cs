using GetcuReone.FactFactory.Priority.Interfaces;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for priority fact with value of type <see cref="ulong"/>.
    /// </summary>
    public class BaseULongPriority : BasePriority<ulong>
    {
        /// <inheritdoc/>
        public BaseULongPriority(ulong value) : base(value) { }

        /// <inheritdoc/>
        public override int CompareTo(IPriorityFact other)
        {
            switch (other)
            {
                case BasePriority<int> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case BasePriority<uint> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case BasePriority<long> priority:
                    return priority.PriorityValue.CompareTo(PriorityValue);
                case BasePriority<ulong> priority:
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
