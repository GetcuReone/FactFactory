﻿using GetcuReone.FactFactory.Exceptions.Entities;
using System.Collections.Generic;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Result.
    /// </summary>
    /// <typeparam name="TFactRule"></typeparam>
    /// <typeparam name="TWantAction"></typeparam>
    /// <typeparam name="TFactContainer"></typeparam>
    public class BuildTreesForWantActionResult<TFactRule, TWantAction, TFactContainer>
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        /// <summary>
        /// WantAction info.
        /// </summary>
        public WantActionInfo<TWantAction, TFactContainer> WantActionInfo { get; set; }

        /// <summary>
        /// Errors that occurred while building a tree.
        /// </summary>
        public DeriveErrorDetail DeriveErrorDetail { get; set; }

        /// <summary>
        /// Build trees.
        /// </summary>
        public List<TreeByFactRule<TFactRule, TWantAction, TFactContainer>> TreesResult { get; set; }
    }
}
