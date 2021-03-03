using Godot;

using SharedUtils.Scripts.Common;
using SharedUtils.Scripts.Logging;

namespace SharedUtils.Scripts.Configurations
{
    public abstract class Configuration : Node
    {
        private readonly ConfigFile _configFile;
        private string path = "user://config/config.ini";

        protected string Path { set; get; }
        private bool _isLoaded;


        protected Configuration()
        {
            _configFile = new ConfigFile();
        }

        protected Error LoadConfiguration()
        {
            DirectoryUtils.MakeDirRecursive(path);
            FileUtils.CreateFileIfNotExists(path);
            var error = _configFile.Load(path);
            _isLoaded = (error == Error.Ok);
            return error;
        }

        protected T GetValue<T>(string section, string key, T @default)
        {
            if (!_isLoaded) return @default;
            return (T)_configFile.GetValue(section, key, @default);
        }

        protected void SetValue<T>(string section, string key, T value)
        {
            if (!_isLoaded) return;
            _configFile.SetValue(section, key, value);
        }

        protected Error SaveConfiguration()
        {
            if (!_isLoaded) return Error.Failed;
            var error = _configFile.Save(path);
            _isLoaded = false;
            return error;
        }
    }
}