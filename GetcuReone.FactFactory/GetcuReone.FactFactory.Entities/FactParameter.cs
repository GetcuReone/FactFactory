using GetcuReone.FactFactory.BaseEntities;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact parameter.
    /// </summary>
    public class FactParameter : BaseFactParameter
    {
        /// <inheritdoc/>
        public FactParameter(string code, object value) : base(code, value)
        {
        }
    }
}
