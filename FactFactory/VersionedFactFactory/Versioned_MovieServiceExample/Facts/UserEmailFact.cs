using GetcuReone.FactFactory.Versioned;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user email information
    /// </summary>
    public class UserEmailFact : VersionedFactBase<string>
    {
        public UserEmailFact(string value) : base(value)
        {
        }
    }
}
