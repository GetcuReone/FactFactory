using GetcuReone.FactFactory;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores movie id information.
    /// </summary>
    public sealed class MovieIdFact : BaseFact<int>
    {
        public MovieIdFact(int value) : base(value) { }
    }
}
