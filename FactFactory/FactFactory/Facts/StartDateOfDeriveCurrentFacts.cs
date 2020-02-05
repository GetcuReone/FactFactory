using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using System;

namespace GetcuReone.FactFactory.Facts
{
    /// <summary>
    /// Date of receipt of current facts
    /// <para>
    /// Only available for request in the rules
    /// </para>
    /// </summary>
    public sealed class StartDateOfDeriveCurrentFacts : FactBase<DateTime>
    {
        /// <inheritdoc />
        public StartDateOfDeriveCurrentFacts(DateTime fact) : base(fact)
        {
        }

        /// <inheritdoc />
        public override IFactType GetFactType()
        {
            return new FactInfo<StartDateOfDeriveCurrentFacts>();
        }
    }
}
