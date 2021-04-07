using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Godot;
using Godot.Collections;

using SharedUtils.Common;

using File = Godot.File;

namespace SharedUtils.Logging
{
    public sealed class Logger
    {
        public static Logger Instance { get; } = new Logger();

        private static Buffer buffer;
        public static string Path { get; set; }
        public static Level CurrentLevel { get; set; }

        static Logger() { }

        private Logger() 
        {
            string path = "user://logs/";
            Path = ProjectSettings.GlobalizePath(path);

            if (!DirectoryUtils.DirExists(path))
            {
                DirectoryUtils.MakeDirRecursive(path);
            }

            buffer = new Buffer(100);

            CurrentLevel = Level.Debug;
        }

        [Conditional("DEBUG")]
        public static void Debug(string message)
        {
            Store(Level.Debug, message);
        }

        public static void Info(string message)
        {
            Store(Level.Info, message);
        }

        public static void Warn(string message)
        {
            Store(Level.Warn, message);
        }

        public static void Error(string message)
        {
            Store(Level.Error, message);
        }

        public static void Error(Exception e)
        {
            Error(e.Message);
            Error(e.StackTrace);
        }

        private static void Store(Level level, string message)
        {
            if (CurrentLevel > level) return;

            if (buffer.Overflows())
            {
                FlushAsync();
            }
            string line = ConstructPrefix(level) + message;
#if DEBUG
            GD.Print(line);
#endif
            buffer.Store(line);
            
        }

        private static string ConstructFileName()
        {
            Dictionary date = OS.GetDate();
            return $"nf_{date["year"]}-{date["month"]:00}-{date["day"]:00}.log";
        }

        private static string ConstructPrefix(Level level)
        {
            Dictionary time = OS.GetTime();
            return $"[{time["hour"]:00}:{time["minute"]:00}:{time["second"]:00} {level}]: ";
        }

        public static async void FlushAsync()
        {
            try
            {
                await Task.Run(() => Flush());
            } 
            catch (Exception e)
            {
                GD.PrintErr("General Exception was thrown: ");
                GD.PrintErr(e.Message);
                GD.PrintErr(e.StackTrace);
            }
        }

        private static void Flush()
        {
            string fullName = Path.PlusFile(ConstructFileName());

            File f = new File();
            f.Open(fullName, f.FileExists(fullName) ? File.ModeFlags.ReadWrite : File.ModeFlags.Write);
            f.SeekEnd();

            for (int i = 0; i < buffer.position; i++)
            {
                f.StoreLine(buffer[i]);
            }

            f.Close();
        }

        ~Logger()
        {
            Flush();
        }

    }
}
