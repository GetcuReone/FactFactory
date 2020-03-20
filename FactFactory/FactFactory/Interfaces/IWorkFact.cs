namespace GetcuReone.FactFactory.Interfaces
{
    /// <summary>
    /// Basic interface for objects that work directly with facts.
    /// </summary>
    /// <typeparam name="TFactBase"></typeparam>
    public interface IWorkFact<TFactBase>
        where TFactBase : IFact
    {
        /// <summary>
        /// True, the current object is more priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsMorePriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;

        /// <summary>
        /// True, the current object is less priority than <paramref name="workFact"/>.
        /// </summary>
        /// <typeparam name="TWorkFact"></typeparam>
        /// <typeparam name="TFactContainer"></typeparam>
        /// <param name="workFact"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsLessPriorityThan<TWorkFact, TFactContainer>(TWorkFact workFact, TFactContainer container)
            where TWorkFact : IWorkFact<TFactBase>
            where TFactContainer : IFactContainer<TFactBase>;
    }
}
