using GetcuReone.FactFactory.Default;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the cost of buying a movie for the user
    /// </summary>
    public class MoviePurchasePriceFact : FactBase<int>
    {
        public MoviePurchasePriceFact(int value) : base(value)
        {
        }
    }
}
