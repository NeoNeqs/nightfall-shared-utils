using Godot;

using SharedUtils.Common;
using SharedUtils.Logging;

namespace SharedUtils.Configuration
{
    public abstract class Configuration : Node
    {
        private readonly ConfigFile _configFile;
        private readonly string path = "user://config/config.ini";

        protected string Path { set; get; }
        private bool _isLoaded;

        protected Configuration()
        {
            _configFile = new ConfigFile();
        }

        public override void _EnterTree()
        {
            ErrorCode errorCode = LoadConfiguration();
            if (!errorCode)
            {
                Logger.Error($"Could not load configuration file '{Path}'. Error code: '{errorCode}'");
            }
        }

        private ErrorCode LoadConfiguration()
        {
            DirectoryUtils.MakeDirRecursive(path);
            FileUtils.CreateFileIfNotExists(path);

            Error error = _configFile.Load(path);
            _isLoaded = error == Error.Ok;
            return (int)error;
        }

        protected V GetValue<V>(string section, string key, V @default)
        {
            return !_isLoaded ? @default : (V)_configFile.GetValue(section, key, @default);
        }

        protected void SetValue<V>(string section, string key, V value)
        {
            if (!_isLoaded)
            {
                return;
            }

            _configFile.SetValue(section, key, value);
        }

        private ErrorCode SaveConfiguration()
        {
            if (!_isLoaded)
            {
                return ErrorCode.CantSave;
            }

            Error error = _configFile.Save(path);
            _isLoaded = false;
            return (int)error;
        }

        public override void _ExitTree()
        {
            ErrorCode errorCode = SaveConfiguration();
            if (!errorCode)
            {
                Logger.Error($"Could not save configuration file '{Path}'. Error code: '{errorCode}'");
            }
        }
    }
}