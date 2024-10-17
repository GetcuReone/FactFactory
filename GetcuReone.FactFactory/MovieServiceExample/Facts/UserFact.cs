using GetcuReone.FactFactory;
using MovieServiceExample.Entities;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user information.
    /// </summary>
    public sealed class UserFact : BaseFact<User>
    {
        public UserFact(User value) : base(value) { }
    }
}
