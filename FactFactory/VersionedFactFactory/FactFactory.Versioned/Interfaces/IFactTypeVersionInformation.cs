using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Versioned.Interfaces
{
    /// <summary>
    /// Fact type version information. Contains information about the type of fact with the desired version.
    /// </summary>
    public interface IFactTypeVersionInformation
    {
        /// <summary>
        /// Type fact version
        /// </summary>
        IFactType TypeFactVersion { get; }
    }
}
