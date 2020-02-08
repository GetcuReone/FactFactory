using JwtTestAdapter.Helpers;
using System;

namespace JwtTestAdapter.Entities
{
    public class GivenBlock<TResult> : BlockBase<TResult>
    {
        internal GivenBlock() { }

        public virtual GivenBlock<TResult> And(string description, Action action)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            action();

            LoggingHelper.Info($"[given] (end) {description}");

            return new GivenBlock<TResult> { Result = Result };
        }

        public virtual GivenBlock<TResult> And(string description, Action<TResult> action)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            action((TResult)Result);

            LoggingHelper.Info($"[given] (end) {description}");

            return new GivenBlock<TResult> { Result = Result };
        }

        public virtual GivenBlock<TResult1> And<TResult1>(string description, Func<TResult1> func)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            var given = new GivenBlock<TResult1> { Result = func() };

            LoggingHelper.Info($"[given] (end) {description}");

            return given;
        }

        public virtual GivenBlock<TResult1> And<TResult1>(string description, Func<TResult, TResult1> func)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            var given = new GivenBlock<TResult1> { Result = func((TResult)Result) };

            LoggingHelper.Info($"[given] (end) {description}");

            return given;
        }

        public virtual WhenBlock<TResult> When(string description, Action action)
        {
            LoggingHelper.Info($"[when] (start) {description}");

            action();

            LoggingHelper.Info($"[when] (end) {description}");

            return new WhenBlock<TResult> { Result = Result };
        }

        public virtual WhenBlock<TResult> When(string description, Action<TResult> action)
        {
            LoggingHelper.Info($"[when] (start) {description}");

            action((TResult)Result);

            LoggingHelper.Info($"[when] (end) {description}");

            return new WhenBlock<TResult> { Result = Result };
        }

        public virtual WhenBlock<TResult1> When<TResult1>(string description, Func<TResult1> func)
        {
            LoggingHelper.Info($"[when] (start) {description}");

            var when = new WhenBlock<TResult1> { Result = func() };

            LoggingHelper.Info($"[when] (end) {description}");

            return when;
        }

        public virtual WhenBlock<TResult1> When<TResult1>(string description, Func<TResult, TResult1> func)
        {
            LoggingHelper.Info($"[when] (start) {description}");

            var when = new WhenBlock<TResult1> { Result = func((TResult)Result) };

            LoggingHelper.Info($"[when] (end) {description}");

            return when;
        }
    }
}
