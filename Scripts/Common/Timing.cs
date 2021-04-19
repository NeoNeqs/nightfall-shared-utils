using System;
using System.Diagnostics;

namespace SharedUtils.Common
{
    public sealed class Timing
    {
        public static void Time(Action action, string funcName = "Unspecified")
        {
            Stopwatch timer = Stopwatch.StartNew();
            action();
            timer.Stop();
            Console.WriteLine($"Function {funcName} took {timer.Elapsed.TotalMilliseconds}ms");
        }

        public static void Time<T>(Func<T> func, out T ret, string funcName = "Unspecified")
        {
            Stopwatch timer = Stopwatch.StartNew();
            ret = func();
            timer.Stop();
            Console.WriteLine($"Function {funcName} took {timer.Elapsed.TotalMilliseconds}ms");
        }
    }
}
