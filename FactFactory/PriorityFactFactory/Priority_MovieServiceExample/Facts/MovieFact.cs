using GetcuReone.FactFactory;
using Priority_MovieServiceExample.Entities;

namespace Priority_MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the movie
    /// </summary>
    public class MovieFact : FactBase<Movie>
    {
        public MovieFact(Movie value) : base(value)
        {
        }
    }
}
