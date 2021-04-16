using Godot;
using Godot.Collections;

using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using SharedUtils.Common;

namespace SharedUtils.Logging
{
    public sealed class Logger
    {
        private static Logger Instance { get; } = new Logger();
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

            // TODO: add this to config.
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

        public static void Error(System.Exception e)
        {
            Error(e.Message);
            Error(e.StackTrace);
        }

        private static async void Store(Level level, string message)
        {
            if (CurrentLevel > level) return;

            if (buffer.Overflows())
            {
                await FlushAsync();
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

        private static async Task FlushAsync()
        {
            string fullName = Path.PlusFile(ConstructFileName());

            using FileStream fs = new FileStream(fullName, FileMode.Append, FileAccess.Write, FileShare.None, 4096, true);

            for (int i = 0; i < buffer.position; i++)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(buffer[i]);
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        ~Logger()
        {
            _ = Task.Run(async () => await FlushAsync());
        }
    }
}
