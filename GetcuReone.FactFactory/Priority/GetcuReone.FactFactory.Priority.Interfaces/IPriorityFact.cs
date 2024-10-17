using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Priority.Interfaces
{
    /// <summary>
    /// A special fact. Stores information about priority.
    /// </summary>
    public interface IPriorityFact : ISpecialFact, IComparable<IPriorityFact> { }
}
