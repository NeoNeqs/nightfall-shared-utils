using Godot;

namespace SharedUtils.Scripts.Logging
{
    public class Logger : Node
    {
        // one instance of LoggerFile for every Logger instance
        protected static LoggerFile _loggerFile = new LoggerFile("user://logs/");
        private static BasicLogger _main;


        protected Logger()
        {
            // _loggerFile passed by reference to always write to the same file
            _main = new BasicLogger(ref _loggerFile, "MAIN");
        }
        public override void _EnterTree()
        {
            _loggerFile.Open();
        }
        public static void Verbose(string output)
        {
            _main.Verbose(output);
        }
        public static void Debug(string output)
        {
            _main.Debug(output);
        }
        public static void Info(string output)
        {
            _main.Info(output);
        }
        public static void Warn(string output)
        {
            _main.Warn(output);
        }
        public static void Error(string output)
        {
            _main.Error(output);
        }
        public override void _ExitTree()
        {
            _loggerFile.Close();
        }

    }
}