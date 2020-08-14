namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact parameter.
    /// </summary>
    public interface IFactParameter
    {
        /// <summary>
        /// Code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Value.
        /// </summary>
        object Value { get; }
    }
}
