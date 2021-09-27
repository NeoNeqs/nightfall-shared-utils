using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Godot;
using Nightfall.SharedUtils.InfoCodes;

// ReSharper disable ExplicitCallerInfoArgument

namespace Nightfall.SharedUtils.Logging
{
    public sealed class Logger
    {
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private static readonly Destructor DestructorObject = new(Flush);

        private static readonly ConcurrentQueue<string> MessageQueue = new();

        private static readonly LoggerConfig LoggerConfig = NFInstance.GetConfig<LoggerConfig>();
        public static Level CurrentLogLevel => LoggerConfig.Level;
        private const int Capacity = 300;
        public string ModuleName { set; get; }


        [Conditional("DEBUG")]
        public void Debug(string msg, [CallerFilePath] string path = "", [CallerMemberName] string functionName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            if (CurrentLogLevel > Level.Debug)
            {
                return;
            }

            StoreLine(Level.Debug, msg);
            StoreCallerInfo(path, functionName, lineNumber);
        }

        public void Info(string msg)
        {
            if (CurrentLogLevel > Level.Info)
            {
                return;
            }

            StoreLine(Level.Info, msg);
        }

        public void Warn(string msg)
        {
            if (CurrentLogLevel > Level.Warn)
            {
                return;
            }

            StoreLine(Level.Warn, msg);
        }

        public void LogException(Exception exception)
        {
            // TODO:
        }

        public void Error(string msg)
        {
            if (CurrentLogLevel > Level.Error)
            {
                return;
            }

            StoreLine(Level.Error, msg);
        }

        public void Critical(string msg, [CallerFilePath] string path = "", [CallerMemberName] string functionName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            StoreLine(Level.Critical, msg);
            StoreCallerInfo(path, functionName, lineNumber);
        }

        public void CriticalCrash(string msg, NFError error, [CallerFilePath] string path = "",
            [CallerMemberName] string functionName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Critical(msg, path, functionName, lineNumber);
            System.Environment.Exit((int) -error);
        }

        private void StoreLine(Level level, string message)
        {
            if (MessageQueue.Count >= Capacity)
            {
                Flush();
            }

            var fullMessage = BuildMessage(new[]
            {
                "[",
                Time.GetTimeStringFromSystem(),
                " ",
                level.ToString(),
                "]",
                "[",
                ModuleName,
                "]: ",
                message,
            });
            Store(fullMessage);
        }

        private static void StoreCallerInfo(string path, string functionName, int lineNumber)
        {
            var fullMessage = BuildMessage(new[]
            {
                "   at: ",
                path.GetFile().GetBaseName(),
                "::",
                functionName,
                " (",
                path,
                ":",
                lineNumber.ToString(),
                ")"
            });
            Store(fullMessage);
        }

        private static void Store(string line)
        {
#if (EXPORTRELEASE == false)
            Console.WriteLine(line);
#endif
            MessageQueue.Enqueue(line);
        }

        private static string BuildMessage(string[] array)
        {
            var totalMessageCount = array.Sum(str => str.Length);

            var stringBuilder = new StringBuilder(totalMessageCount);

            foreach (var part in array)
            {
                stringBuilder.Append(part);
            }

            return stringBuilder.ToString();
        }

        private static void Flush()
        {
            if (MessageQueue.Count == 0)
            {
                return;
            }

            var file = new File();
            var filePath = $"user://logs/runtime-{Time.GetDateStringFromSystem()}.nflog";

            Error error;
            if (file.FileExists(filePath))
            {
                error = file.Open(filePath, File.ModeFlags.ReadWrite);
                file.SeekEnd();
            }
            else
            {
                error = file.Open(filePath, File.ModeFlags.WriteRead);
            }

            if (error != Godot.Error.Ok)
            {
                // TODO: Messaging class for storing common cases to avoid repeating.
                Console.WriteLine($"Could not open file {filePath}. Error code: {((NFError)error).ToString()}.");  
                return;
            }

            while (MessageQueue.TryDequeue(out var msg))
            {
                file.StoreLine(msg);
            }

            file.Close();
        }
    }
}