using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Exceptions
{
    /// <summary>
    /// Fact not found error
    /// </summary>
    /// <typeparam name="TFact"></typeparam>
    public class FactNotFoundException<TFact> : Exception
        where TFact : IFact
    {
        /// <inheritdoc />
        public FactNotFoundException() : base($"Not found fact of {typeof(TFact).FullName} type")
        {
        }
    }
}
