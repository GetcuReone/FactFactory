using GetcuReone.FactFactory.Interfaces.SpecialFacts;
using System;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Fact containing version information.
    /// </summary>
    public interface IVersionFact : ISpecialFact, IComparable<IVersionFact>
    {
    }
}
