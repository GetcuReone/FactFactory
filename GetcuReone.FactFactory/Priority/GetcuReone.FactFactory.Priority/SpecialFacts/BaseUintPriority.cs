using GetcuReone.FactFactory.Priority.Interfaces;

namespace GetcuReone.FactFactory.Priority.SpecialFacts
{
    /// <summary>
    /// Base class for priority fact with value of type <see cref="uint"/>
    /// </summary>
    public abstract class BaseUintPriority : BasePriority<uint>
    {
        /// <inheritdoc/>
        protected BaseUintPriority(uint value) : base(value) { }

        /// <inheritdoc/>
        public override int CompareTo(IPriorityFact other)
        {
            return other switch
            {
                BasePriority<int> priority => priority.PriorityValue.CompareTo(PriorityValue),
                BasePriority<uint> priority => priority.PriorityValue.CompareTo(PriorityValue),
                BasePriority<long> priority => priority.PriorityValue.CompareTo(PriorityValue),
                BasePriority<ulong> priority => priority.PriorityValue.CompareTo(PriorityValue),
                BaseFact<int> priority => priority.Value.CompareTo(PriorityValue),
                BaseFact<uint> priority => priority.Value.CompareTo(PriorityValue),
                BaseFact<long> priority => priority.Value.CompareTo(PriorityValue),
                BaseFact<ulong> priority => priority.Value.CompareTo(PriorityValue),
                _ => throw CreateIncompatibilityVersionException(other),
            };
        }
    }
}
