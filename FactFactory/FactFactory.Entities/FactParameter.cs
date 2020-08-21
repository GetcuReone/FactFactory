using GetcuReone.FactFactory.BaseEntities;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Fact parameter.
    /// </summary>
    public class FactParameter : FactParameterBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public FactParameter(string code, object value) : base(code, value)
        {
        }
    }
}
