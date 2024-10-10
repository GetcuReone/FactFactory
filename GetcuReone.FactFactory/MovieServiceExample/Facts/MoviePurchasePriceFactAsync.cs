using GetcuReone.FactFactory;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the cost of buying a movie for the user.
    /// </summary>
    public sealed class MoviePurchasePriceFactAsync : BaseFact<int>
    {
        public MoviePurchasePriceFactAsync(int value) : base(value) { }
    }
}
