using System;

namespace JwtTestAdapter.Helpers
{
    public static class LoggingHelper
    {
        public static void Info(string message)
            => Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}
