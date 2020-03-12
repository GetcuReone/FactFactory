using GetcuReone.FactFactory.Versioned;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores movie id information
    /// </summary>
    public class MovieIdFact : VersionedFactBase<int>
    {
        public MovieIdFact(int value) : base(value)
        {
        }
    }
}
