﻿using FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FactFactory.Entities
{
    /// <summary>
    /// Error detail for method <see cref="FactFactoryBase{TFactContainer, TFactRule, TFactRuleCollection, TWantAction}.Derive"/>
    /// </summary>
    public sealed class DeriveErrorDetail : ErrorDetail
    {
        /// <inheritdoc />
        public DeriveErrorDetail(string code, string reason, IWantAction action, Dictionary<IFactInfo, List<List<IFactInfo>>> notFoundFacts) : base(code, reason)
        {
            Action = action;
            NotFoundFacts = notFoundFacts;
        }

        /// <summary>
        /// The action, the calculation of which led to an error
        /// </summary>
        public IWantAction Action { get; }

        /// <summary>
        /// The sets of facts which were not enough to calculate. The presence of any of these sets allows you to calculate <see cref="DeriveErrorDetail.Action"/>
        /// </summary>
        public Dictionary<IFactInfo, List<List<IFactInfo>>> NotFoundFacts { get; }
    }
}