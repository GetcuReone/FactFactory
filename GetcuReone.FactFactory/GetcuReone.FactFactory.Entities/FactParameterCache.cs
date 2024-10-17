using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.FactFactory.Entities
{
    /// <inheritdoc cref="IFactParameterCache"/>
    public class FactParameterCache : IFactParameterCache
    {
        private readonly List<IFactParameter> _parameters = new List<IFactParameter>();

        /// <inheritdoc />
        public IFactParameter GetOrCreate(string parameterCode, object parameterValue)
        {
            return GetOrCreate(parameterCode, parameterValue, (code, value) => new FactParameter(code, value));
        }

        /// <inheritdoc />
        public IFactParameter GetOrCreate(string parameterCode, object parameterValue, Func<string, object, IFactParameter> createParameterFunc)
        {
            if (string.IsNullOrEmpty(parameterCode))
                throw new ArgumentNullException(nameof(parameterCode));

            if (createParameterFunc == null)
                throw new ArgumentNullException(nameof(createParameterFunc));

            IFactParameter? parameter = _parameters
                .FirstOrDefault(p => p.Code.Equals(parameterCode, StringComparison.OrdinalIgnoreCase) && p.Value == parameterValue);

            if (parameter != null)
                return parameter;

            lock (_parameters)
            {
                parameter = _parameters
                    .FirstOrDefault(p => p.Code.Equals(parameterCode, StringComparison.OrdinalIgnoreCase) && p.Value == parameterValue);

                if (parameter != null)
                    return parameter;

                parameter = createParameterFunc(parameterCode, parameterValue);

                _parameters.Add(parameter);

                return parameter;
            }
        }
    }
}
