using GetcuReone.FactFactory;
using MovieServiceExample.Entities;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the movie.
    /// </summary>
    public sealed class MovieFact : BaseFact<Movie>
    {
        public MovieFact(Movie value) : base(value) { }
    }
}
