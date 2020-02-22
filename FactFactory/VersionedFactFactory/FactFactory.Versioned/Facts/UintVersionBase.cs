using GetcuReone.FactFactory.Facts;

namespace GetcuReone.FactFactory.Versioned.Facts
{
    /// <summary>
    /// base class for factors determining version by number <see cref="uint"/>
    /// </summary>
    public abstract class UintVersionBase : FactBase<uint>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="version"></param>
        protected UintVersionBase(uint version) : base(version)
        {
        }
    }
}
