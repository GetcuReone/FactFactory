using GetcuReone.FactFactory;
using Priority_MovieServiceExample.Entities;

namespace Priority_MovieServiceExample.Facts
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
