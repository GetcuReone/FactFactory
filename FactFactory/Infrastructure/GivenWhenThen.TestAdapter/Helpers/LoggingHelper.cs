using System;
using System.Collections.Generic;
using System.Text;

namespace GivenWhenThen.TestAdapter.Helpers
{
    public static class LoggingHelper
    {
        public static void Info(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}
