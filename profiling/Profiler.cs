using System;
using Nightfall.SharedUtils;

#if DEBUG
using Godot;
using Nightfall.SharedUtils.Logging;
using System.Runtime.CompilerServices;
#endif

// ReSharper disable UseFormatSpecifierInInterpolation
namespace Nightfall.ServerUtils.Profiling
{
    public static class Profiler
    {
#if (EXPORTRELEASE == false)

        private static readonly Logger ProfilerLogger = NFInstance.GetLogger("Profiler");

        public static Clock Profile([CallerFilePath] string filePath = "", [CallerMemberName] string functionName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return new Clock(filePath, functionName, lineNumber);
        }

        public static Clock ProfileScope(string scopeName = "Unknown Scope", [CallerFilePath] string filePath = "",
            [CallerMemberName] string functionName = "", [CallerLineNumber] int lineNumber = 0)
        {
            return new ScopedClock(scopeName, filePath, functionName, lineNumber);
        }

        public class Clock : IDisposable
        {
            protected ulong Start { set; get; }

            protected string FilePath { set; get; }
            protected string FunctionName { set; get; }
            protected int LineNumber { set; get; }

            public double Elapsed { private set; get; }

            protected Clock()
            {
            }

            public Clock(string filePath, string functionName, int lineNumber)
            {
                FilePath = filePath;
                FunctionName = functionName;
                LineNumber = lineNumber;
                Start = Time.GetTicksUsec();
            }

            protected virtual string GetResultString()
            {
                var timePrefix = Elapsed switch
                {
                    >= 1000 * 60 => "min",
                    >= 1000 => "s",
                    >= 1 => "ms",
                    >= 0.001 => "μs",
                    >= 0.000001 => "ns",
                    >= 0.000000001 => "ps",
                    _ => "h",
                };

                return $"Timed: {Elapsed.ToString("0.###")}{timePrefix}";
            }

            public void Dispose()
            {
                var end = Time.GetTicksUsec();
                Elapsed = (end - Start) / 1000.0d;

                // ReSharper disable ExplicitCallerInfoArgument
                ProfilerLogger.Debug(GetResultString(), FilePath, FunctionName, LineNumber);
            }
        }

        private sealed class ScopedClock : Clock
        {
            private string ScopeName { get; }

            public ScopedClock(string scopeName, string filePath, string functionName, int lineNumber)
            {
                ScopeName = scopeName;
                FilePath = filePath;
                FunctionName = functionName;
                LineNumber = lineNumber;
                Start = Time.GetTicksUsec();
            }

            protected override string GetResultString()
            {
                return $"({ScopeName}) - {base.GetResultString()}";
            }
        }
#else
        public static Clock Profile() => new();

        public static Clock ProfileScope(string _ = "") => Profile();

        public class Clock : IDisposable
        {
            public double Elapsed => 0.0d;

            public void Dispose() { }
        }
#endif
    }
}