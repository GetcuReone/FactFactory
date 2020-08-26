using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.BaseEntities
{
    /// <summary>
    /// Base class for parameter.
    /// </summary>
    public abstract class FactParameterBase : IFactParameter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        protected FactParameterBase(string code, object value)
        {
            Code = code;
            Value = value;
        }

        /// <inheritdoc/>
        public string Code { get; }

        /// <inheritdoc/>
        public object Value { get; }
    }
}
