using JwtTestAdapter.Entities;
using JwtTestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JwtTestAdapter
{
    [TestClass]
    public abstract class TestBase
    {
        protected virtual GivenBlock<object> Given(string description, Action action)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            action();

            LoggingHelper.Info($"[given] (end) {description}");

            return new GivenBlock<object>();
        }

        protected virtual GivenBlock<TResult> Given<TResult>(string description, Func<TResult> func)
        {
            LoggingHelper.Info($"[given] (start) {description}");

            var given = new GivenBlock<TResult> { Result = func() };

            LoggingHelper.Info($"[given] (end) {description}");

            return given;
        }

        protected virtual TException ExpectedException<TException>(Action action)
            where TException: Exception
        {
            try
            {
                action();
            }
            catch(TException e)
            {
                return e;
            }
            catch
            {
                throw;
            }

            Assert.Fail("Error did not occur");
            return default;
        }
    }
}
