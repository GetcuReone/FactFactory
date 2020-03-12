using GetcuReone.FactFactory.Versioned;
using Versioned_MovieServiceExample.Entities;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user information
    /// </summary>
    public class UserFact : VersionedFactBase<User>
    {
        public UserFact(User value) : base(value)
        {
        }
    }
}
