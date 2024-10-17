namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Interface for copying objects.
    /// </summary>
    /// <typeparam name="TCopyObj">Type of object to copy.</typeparam>
    public interface ICopy<TCopyObj>
    {
        /// <summary>
        /// Object copy method
        /// </summary>
        /// <returns>Copied object.</returns>
        TCopyObj Copy();
    }
}
