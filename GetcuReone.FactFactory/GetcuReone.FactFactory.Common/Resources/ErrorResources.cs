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
        /// <param name="wantAction">WantAction.</param>
        /// <returns>Error text.</returns>
        public static string OnWantActionCannotBePerformedSynchronously(IWantAction wantAction)
        {
            return $"{wantAction} cannot be performed synchronously.";
        }
    }
}
