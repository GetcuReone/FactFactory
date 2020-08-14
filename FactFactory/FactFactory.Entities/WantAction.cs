using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Entities
{
    /// <summary>
    /// Desired action information.
    /// </summary>
    public class WantAction : WantActionBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wantAction">Action taken after deriving a fact.</param>
        /// <param name="factTypes">Facts required to launch an action.</param>
        public WantAction(Action<IFactContainer> wantAction, List<IFactType> factTypes) : base(wantAction, factTypes)
        {
        }
    }
}
