using GetcuReone.FactFactory.Facts;
using MovieServiceExample.Entities;

namespace MovieServiceExample.Facts
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
