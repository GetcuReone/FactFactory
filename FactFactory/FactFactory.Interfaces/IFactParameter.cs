namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Fact parameter.
    /// </summary>
    public interface IFactParameter
    {
        /// <summary>
        /// Parameter code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Parameter value.
        /// </summary>
        object Value { get; }
    }
}
