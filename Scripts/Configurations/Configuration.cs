using Godot;

using SharedUtils.Common;

namespace SharedUtils.Configurations
{
    public abstract class Configuration<T> : GodotSingleton<T> where T : Node
    {
        private readonly ConfigFile _configFile;
        private readonly string path = "user://config/config.ini";

        protected string Path { set; get; }
        private bool _isLoaded;


        protected Configuration()
        {
            _configFile = new ConfigFile();
        }

        protected ErrorCode LoadConfiguration()
        {
            DirectoryUtils.MakeDirRecursive(path);
            FileUtils.CreateFileIfNotExists(path);

            Error error = _configFile.Load(path);
            _isLoaded = error == Error.Ok;
            return (ErrorCode)(int)error;
        }

        protected V GetValue<V>(string section, string key, V @default)
        {
            return !_isLoaded ? @default : (V)_configFile.GetValue(section, key, @default);
        }

        protected void SetValue<R>(string section, string key, R value)
        {
            if (!_isLoaded)
            {
                return;
            }

            _configFile.SetValue(section, key, value);
        }

        protected ErrorCode SaveConfiguration()
        {
            if (!_isLoaded)
            {
                return ErrorCode.CantSave;
            }

            Error error = _configFile.Save(path);
            _isLoaded = false;
            return (ErrorCode)(int)error;
        }
    }
}