namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Error detail
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="reason"></param>
        public ErrorDetail(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }

        /// <summary>
        /// Error code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Error reason
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// String representation of an object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Code}] {Reason}";
        }
    }
}
