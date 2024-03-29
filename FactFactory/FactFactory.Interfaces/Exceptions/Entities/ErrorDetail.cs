﻿namespace GetcuReone.FactFactory.Exceptions.Entities
{
    /// <summary>
    /// Error detail.
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="reason">Error reason.</param>
        public ErrorDetail(string code, string reason)
        {
            Code = code;
            Reason = reason;
        }

        /// <summary>
        /// Error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Error reason.
        /// </summary>
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{Code}] {Reason}";
        }
    }
}
