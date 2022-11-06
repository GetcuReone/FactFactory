using GetcuReone.FactFactory;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the cost of buying a movie for the user
    /// </summary>
    public class MoviePurchasePriceFact : BaseFact<int>
    {
        public MoviePurchasePriceFact(int value) : base(value) { }
    }
}
