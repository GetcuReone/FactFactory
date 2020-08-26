using GetcuReone.FactFactory;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the size of the discount
    /// </summary>
    public class MovieDiscountFact : FactBase<int>
    {
        public MovieDiscountFact(int value) : base(value)
        {
        }
    }
}
