using GetcuReone.FactFactory.Facts;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Desired action information
    /// </summary>
    public class WantAction : WantActionBase<FactBase>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        public WantAction(Action<IFactContainer<FactBase>> wantAction, IList<IFactType> factTypes) : base(wantAction, factTypes)
        {
        }
    }
}
