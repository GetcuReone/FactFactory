﻿using GetcuReone.FactFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetcuReone.FactFactory
{
    /// <summary>
    /// Base class for fact.
    /// </summary>
    public abstract class FactBase : IFact
    {
        private List<IFactParameter> _parameters;

        /// <inheritdoc/>
        public virtual IFactType GetFactType()
        {
            Type genericType = typeof(FactType<>).MakeGenericType(GetType());
            return (IFactType)Activator.CreateInstance(genericType);
        }

        /// <inheritdoc/>
        public virtual void AddParameter(IFactParameter parameter)
        {
            if (_parameters == null)
                _parameters = new List<IFactParameter>();
            else if (_parameters.Exists(param => param.Code.Equals(parameter.Code, StringComparison.Ordinal)))
                throw new ArgumentException($"FactParameter with {parameter.Code} code already contained.");

            _parameters.Add(parameter);
        }

        /// <inheritdoc/>
        public virtual IFactParameter GetParameter(string parameterCode)
        {
            return _parameters?.FirstOrDefault(p => p.Code.Equals(parameterCode, StringComparison.Ordinal));
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<IFactParameter> GetParameters()
        {
            return _parameters?.ToReadOnlyCollection() 
                ?? new ReadOnlyCollection<IFactParameter>(new List<IFactParameter>(0));
        }
    }

    /// <inheritdoc/>
    /// <typeparam name="TFactValue">Type fact value.</typeparam>
    public abstract class FactBase<TFactValue> : FactBase
    {
        /// <summary>
        /// Value fact.
        /// </summary>
        public virtual TFactValue Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Fact value.</param>
        protected FactBase(TFactValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Extracts <see cref="FactBase{TFactValue}.Value"/>.
        /// </summary>
        /// <param name="fact">Fact.</param>
        public static implicit operator TFactValue(FactBase<TFactValue> fact)
        {
            return fact.Value;
        }
    }
}
