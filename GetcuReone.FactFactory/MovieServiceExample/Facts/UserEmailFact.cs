using GetcuReone.FactFactory;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user email information.
    /// </summary>
    public sealed class UserEmailFact : BaseFact<string>
    {
        public UserEmailFact(string value) : base(value) { }
    }
}
