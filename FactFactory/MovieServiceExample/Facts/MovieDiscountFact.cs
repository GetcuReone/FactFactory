using GetcuReone.FactFactory;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the size of the discount.
    /// </summary>
    public sealed class MovieDiscountFact : BaseFact<int>
    {
        public MovieDiscountFact(int value) : base(value) { }
    }
}
