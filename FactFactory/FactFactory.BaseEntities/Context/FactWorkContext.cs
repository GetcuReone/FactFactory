using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Interfaces.Context;

namespace GetcuReone.FactFactory.BaseEntities.Context
{
    ///<inheritdoc/>
    public class FactWorkContext<TFactWork, TFactRule, TWantAction, TFactContainer> : FactRulesContext<TFactRule, TWantAction, TFactContainer>, IFactWorkContext<TFactWork, TFactRule, TWantAction, TFactContainer>
        where TFactWork : IFactWork
        where TFactRule : IFactRule
        where TWantAction : IWantAction
        where TFactContainer : IFactContainer
    {
        ///<inheritdoc/>
        public TFactWork FactWork { get; set; }
    }
}
