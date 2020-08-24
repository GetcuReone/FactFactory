﻿using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Entities.Trees;
using GetcuReone.FactFactory.Exceptions;
using GetcuReone.FactFactory.Exceptions.Entities;
using GetcuReone.FactFactory.Helpers;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using GetcuReone.FactFactory.Versioned.BaseEntities;
using GetcuReone.FactFactory.Versioned.Constants;
using GetcuReone.FactFactory.Versioned.Entities;
using GetcuReone.FactFactory.Versioned.Facades.SingleEntityOperations;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CommonErrorCode = GetcuReone.FactFactory.Constants.ErrorCode;

namespace GetcuReone.FactFactory.Versioned
{
    /// <summary>
    /// Base class for versioned fact factory.
    /// </summary>
    public abstract class VersionedFactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer> : FactFactoryBase<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>, IVersionedFactFactory<TFactRule, TFactRuleCollection, TWantAction, TFactContainer>
        where TFactContainer : VersionedFactContainerBase
        where TFactRule : VersionedFactRuleBase
        where TFactRuleCollection : VersionedFactRuleCollectionBase<TFactRule>
        where TWantAction : VersionedWantActionBase
    {
        private List<IFactType> _calculatedFactTypes;
        private TWantAction _calculatingWantAction;

        /// <inheritdoc/>
        protected override TFact GetCorrectFact<TFact>(IFactContainer container, IReadOnlyCollection<IFactType> inputFactTypes)
        {
            IFactType versionType = inputFactTypes.SingleOrDefault(type => type.IsFactType<IVersionFact>());

            IVersionFact version = versionType != null
                ? container.GetVersionFact(versionType)
                : null;

            return (TFact)container.GetRightFactByVersion(GetFactType<TFact>(), version);
        }

        /// <summary>
        /// Returns instances of all used versions.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<IVersionFact> GetAllVersions();

        /// <inheritdoc/>
        protected override IEnumerable<IFact> GetDefaultFacts(TFactContainer container)
        {
            IEnumerable<IFact> allVersionFacts = GetAllVersions() ?? Enumerable.Empty<IFact>();

            List<IVersionFact> defaultVersions = container.Where(version => version is IVersionFact).Select(version => (IVersionFact)version).ToList();
            List<IFactType> defaultVersionTypes = defaultVersions.ConvertAll(version => version.GetFactType());

            foreach(var version in allVersionFacts)
            {
                if (defaultVersionTypes.All(defaultVersion => !defaultVersion.EqualsFactType(version.GetFactType())))
                    defaultVersions.Add((IVersionFact)version);
            }

            return defaultVersions;
        }

        /// <inheritdoc/>
        protected override bool NeedRecalculateFact(TFactRule rule, TFactContainer container, TWantAction wantAction, out IFact needRemoveFact)
        {
            bool result = false;
            needRemoveFact = null;

            IVersionFact maxVersion = wantAction.VersionType != null
                ? container.GetRightFactByVersionType(wantAction.VersionType, null) as IVersionFact
                : null;
            IVersionFact ruleVersion =  rule.VersionType != null
                ? container.GetRightFactByVersionType(rule.VersionType, null) as IVersionFact
                : null;
            var currentVersionedFact = container.GetRightFactByVersion(rule.OutputFactType, maxVersion) as VersionedFactBase;

            if (currentVersionedFact == null)
                result = true;
            else if (!currentVersionedFact.CalculatedByRule)
                result = false;
            else
            {
                // The last fact that is accepted or given by the rule
                IFactType lastSuitableFactType = _calculatedFactTypes.LastOrDefault(type => type.EqualsFactType(rule.OutputFactType) || rule.InputFactTypes.Any(t => t.EqualsFactType(type)));

                // If the last time one of the input facts was recounted
                if (lastSuitableFactType != null && !lastSuitableFactType.EqualsFactType(rule.OutputFactType))
                    result = true;

                if (!result)
                {
                    // If the maximum version is not specified
                    if (maxVersion == null)
                    {
                        if (currentVersionedFact.Version != null)
                        {
                            if (ruleVersion == null)
                                result = true;
                            else
                                result = currentVersionedFact.Version.CompareTo(ruleVersion) < 0;
                        }
                    }
                    else
                    {
                        if (currentVersionedFact.Version == null)
                            result = true;
                        else if (currentVersionedFact.Version.CompareTo(maxVersion) > 0)
                            result = true;
                        else if (ruleVersion == null)
                            result = true;
                        else
                            result = currentVersionedFact.Version.CompareTo(ruleVersion) < 0;
                    }
                }
            }

            if (result && currentVersionedFact != null)
            {
                if (ruleVersion == null)
                {
                    if (currentVersionedFact.Version == null)
                        needRemoveFact = currentVersionedFact;
                }
                else if (currentVersionedFact.Version != null && ruleVersion.CompareTo(currentVersionedFact.Version) == 0)
                    needRemoveFact = currentVersionedFact;
            }

            return result;
        }

        /// <inheritdoc/>
        protected override void OnFactCalculatedForWantAction(IFactType factType, TFactContainer container, TWantAction wantAction)
        {
            if (_calculatingWantAction == null)
                _calculatingWantAction = wantAction;
            else if (_calculatingWantAction != wantAction)
            {
                _calculatedFactTypes.Clear();
                _calculatingWantAction = wantAction;
            }

            _calculatedFactTypes.Add(factType);
        }

        /// <inheritdoc/>
        public override ISingleEntityOperations GetSingleEntityOperations()
        {
            return GetFacade<VersionedSingleEntityOperationsFacade>();
        }

        /// <inheritdoc/>
        public override void Derive()
        {
            _calculatedFactTypes = new List<IFactType>();

            base.Derive();

            _calculatedFactTypes.Clear();
            _calculatedFactTypes = null;
        }

        /// <summary>
        /// Derive <typeparamref name="TFact"/> with version.
        /// </summary>
        /// <typeparam name="TFact">Type of desired fact.</typeparam>
        /// <typeparam name="TVersion">Type of version fact.</typeparam>
        /// <returns></returns>
        public virtual TFact DeriveFact<TFact, TVersion>()
            where TFact : IFact
            where TVersion : IVersionFact
        {
            TFact fact = default;

            var wantActions = new List<TWantAction>(WantActions);
            WantActions.Clear();

            var inputFacts = new List<IFactType> { GetFactType<TFact>(), GetFactType<TVersion>() };

            WantFact(CreateWantAction(
                facts => fact = facts.GetFact<TFact>(),
                inputFacts));

            Derive();

            WantActions.AddRange(wantActions);

            return fact;
        }
    }
}
