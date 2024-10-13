using System.Threading;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Fact for <see cref="CancellationToken"/>
    /// </summary>
    public class FCancellationToken : BaseFact<CancellationToken>
    {
        /// <inheritdoc/>
        public FCancellationToken(CancellationToken value) : base(value) { }
    }
}
