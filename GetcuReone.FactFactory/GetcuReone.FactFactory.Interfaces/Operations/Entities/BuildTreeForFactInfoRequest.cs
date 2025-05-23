﻿using GetcuReone.FactFactory.Interfaces.Context;
using System.Collections.Generic;
using GetcuReone.FactFactory.Exceptions.Entities;

namespace GetcuReone.FactFactory.Interfaces.Operations.Entities
{
    /// <summary>
    /// Request for <see cref="ITreeBuildingOperations.TryBuildTreeForFactInfo(BuildTreeForFactInfoRequest, out TreeByFactRule, out List{DeriveFactErrorDetail})"/>
    /// </summary>
    public class BuildTreeForFactInfoRequest
    {
        /// <summary>
        /// The type of fact for which you want to build a tree
        /// </summary>
        public IFactType WantFactType { get; }

        /// <summary>
        /// Context
        /// </summary>
        public IFactRulesContext Context { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wantFactType">The type of fact for which you want to build a tree</param>
        /// <param name="context">Context</param>
        public BuildTreeForFactInfoRequest(IFactType wantFactType, IFactRulesContext context)
        {
            WantFactType = wantFactType;
            Context = context;
        }
    }
}
