using GetcuReone.FactFactory.BaseEntities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Versioned.Helpers;
using GetcuReone.FactFactory.Versioned.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Versioned.BaseEntities
{
    /// <summary>
    /// Version rule for calculating a fact.
    /// </summary>
    /// <typeparam name="TFactBase">Base class for facts.</typeparam>
    public abstract class VersionedFactRuleBase<TFactBase> : FactRuleBase<TFactBase>, IVersionedFactRule<TFactBase>
        where TFactBase : class, IVersionedFact
    {
        /// <summary>
        /// Type of fact with rule version.
        /// </summary>
        public IFactType VersionType { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="inputFactTypes"></param>
        /// <param name="outputFactType"></param>
        protected VersionedFactRuleBase(Func<IFactContainer<TFactBase>, IWantAction<TFactBase>, TFactBase> func, List<IFactType> inputFactTypes, IFactType outputFactType) : base(func, inputFactTypes, outputFactType)
        {
            outputFactType.CannotIsType<IVersionFact>(nameof(outputFactType));

            VersionType = inputFactTypes?.SingleOrNullFactVersion();
        }

        /// <summary>
        /// Comparison of rules for calculating facts without regard to version.
        /// </summary>
        /// <typeparam name="TVersionedFactRule"></typeparam>
        /// <param name="versionedFactRule"></param>
        /// <returns></returns>
        public bool CompareWithoutVersion<TVersionedFactRule>(TVersionedFactRule versionedFactRule) where TVersionedFactRule : IVersionedFactRule<TFactBase>
        {
            if (!OutputFactType.Compare(versionedFactRule.OutputFactType))
                return false;

            return EqualsFactTypes(
                InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList(),
                versionedFactRule.InputFactTypes.Where(factType => !factType.IsFactType<IVersionFact>()).ToList());
        }

        /// <summary>
        /// Rule of fact calculate.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        public override TFactBase Calculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
        {
            TFactBase versionedFact = base.Calculate(container, wantAction);

            if (versionedFact != null)
            {
                if (VersionType != null)
                    versionedFact.Version = (IVersionFact)container.GetRightFactByVersion(VersionType, null);
            }

            return versionedFact;
        }

        /// <summary>
        /// Is it possible to calculate the fact.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="wantAction"></param>
        /// <typeparam name="TContainer"></typeparam>
        /// <typeparam name="TWantAction"></typeparam>
        /// <returns></returns>
        public override bool CanCalculate<TContainer, TWantAction>(TContainer container, TWantAction wantAction)
        {
            IFactType versionType = wantAction is IFactTypeVersionInfo versionInfo
                ? versionInfo.VersionType
                : null;

            IVersionFact version = versionType != null
                ? container.GetVersionFact(versionType)
                : null;

            foreach(var type in InputFactTypes)
            {
                if (container.GetRightFactByVersion(type, version) == null)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override bool IsMorePriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
        {
            return VersionedFactFactoryHelper.IsMorePriorityThan(this, workFact, container);
        }

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TFactWork"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override bool IsLessPriorityThan<TFactWork, TFactContainer>(TFactWork workFact, TFactContainer container)
        {
            return VersionedFactFactoryHelper.IsLessPriorityThan(this, workFact, container);
        }
    }
}
