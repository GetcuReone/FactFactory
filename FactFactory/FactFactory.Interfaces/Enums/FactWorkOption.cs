using System;

namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Options for <see cref="IFactWork"/>.
    /// </summary>
    [Flags]
    public enum FactWorkOption
    {
        /// <summary>
        /// Work can be done synchronously.
        /// </summary>
        CanExecuteSync = 1 << 0,

        /// <summary>
        /// Work can be done asynchronously.
        /// </summary>
        CanExecuteAsync = 1 << 1,

        /// <summary>
        /// Work can be done asynchronously.
        /// </summary>
        CanExcecuteParallel = 1 << 2,
    }
}
