using GetcuReone.FactFactory;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the cost of buying a movie for the user.
    /// </summary>
    public sealed class MoviePurchasePriceFact : BaseFact<int>
    {
        public MoviePurchasePriceFact(int value) : base(value) { }
    }
}
