using GetcuReone.FactFactory.Interfaces;

namespace GetcuReone.FactFactory.Resources
{
    /// <summary>
    /// Error resources.
    /// </summary>
    public static class ErrorResources
    {
        /// <summary>
        /// Action cannot be performed synchronously.
        /// </summary>
        /// <typeparam name="TWantAction">Type wantAction.</typeparam>
        /// <param name="wantAction">WantAction.</param>
        /// <returns>Error text.</returns>
        public static string OnWantActionCannotBePerformedSynchronously<TWantAction>(TWantAction wantAction)
            where TWantAction : IWantAction
        {
            return $"{wantAction} cannot be performed synchronously.";
        }
    }
}
