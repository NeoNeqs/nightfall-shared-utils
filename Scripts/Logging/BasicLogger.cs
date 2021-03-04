using Godot;

namespace SharedUtils.Scripts.Logging
{
    public abstract class BasicLogger
    {
        enum Level
        {
            Verbose,
            Debug,
            Info,
            Warn,
            Error,
            Max
        }

        private Level _currentLevel;
        private string _moduleName;

        public BasicLogger(string moduleName)
        {
            _currentLevel = Level.Verbose;
            _moduleName = moduleName;
        }

        // Puts a string to a logger file.
        // Format: `[ModuleName][HH:MM:SS ErrorLevel]: output`
        private void Put(Level level, string output)
        {
            if (level < _currentLevel) return;
            GD.Print($"[{_moduleName}][{GetTime()} {level.ToString("g").ToUpper()}]: {output}");
        }

        public void Verbose(string output)
        {
            Put(Level.Verbose, output);
        }

        public void Debug(string output)
        {
            Put(Level.Debug, output);
        }

        public void Info(string output)
        {
            Put(Level.Info, output);
        }

        public void Warn(string output)
        {
            Put(Level.Warn, output);
        }

        public void Error(string output)
        {
            Put(Level.Error, output);
        }

        // Returns time as string.
        // Format: HH:MM:SS
        private string GetTime()
        {
            var time = OS.GetTime();

            var hour = time["hour"].ToString().PadLeft(2, '0');
            var minute = time["minute"].ToString().PadLeft(2, '0');
            var second = time["second"].ToString().PadLeft(2, '0');

            return $"{hour}:{minute}:{second}";
        }
    }
}