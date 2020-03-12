using GetcuReone.FactFactory.Default;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores user email information
    /// </summary>
    public class UserEmailFact : FactBase<string>
    {
        public UserEmailFact(string value) : base(value)
        {
        }
    }
}
