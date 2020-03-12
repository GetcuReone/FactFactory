using GetcuReone.FactFactory.Default;
using MovieServiceExample.Entities;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user information
    /// </summary>
    public class UserFact : FactBase<User>
    {
        public UserFact(User value) : base(value)
        {
        }
    }
}
