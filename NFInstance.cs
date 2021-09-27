using System;
using Godot;
using Godot.Collections;
using Nightfall.SharedUtils.Algorithms.Extensions;
using Nightfall.SharedUtils.Configurations;
using Nightfall.SharedUtils.InfoCodes;
using Nightfall.SharedUtils.IO.Extensions;
using Nightfall.SharedUtils.Logging;
using YamlDotNet.Core;

namespace Nightfall.SharedUtils
{
    public static class NFInstance
    {
        // ReSharper disable once UnusedMember.Local
        private static readonly Destructor DestructorObject = new(Destruct);
        private static readonly Dictionary<string, Logger> Loggers = new();
        private static readonly Dictionary<string, IConfiguration> Configurations = new();

        public static Logger GetLogger(string moduleName)
        {
            if (Loggers.ContainsKey(moduleName))
            {
                return Loggers[moduleName];
            }

            var logger = new Logger
            {
                ModuleName = moduleName.Length == 0 ? "Main" : moduleName
            };

            Loggers[moduleName] = logger;

            return logger;
        }

        /// <typeparam name="T"><see cref="IConfiguration"/> object whose fields represent config file graph.</typeparam>
        /// <exception cref="InvalidCastException">When T does not match with any existing configuration.</exception>
        /// <exception cref="YamlException">If the config file has errors.</exception>
        public static T GetConfig<T>() where T : class, IConfiguration, new()
        {
            var fileName = typeof(T).Name.ToSnakeCase();

            if (Configurations.ContainsKey(fileName))
            {
                // InvalidCastException should be thrown here. This should only ever happen if there are two classes (in different namespace) with the same name. 
                return (T) Configurations[fileName];
            }

            var path = ProjectSettings.GlobalizePath($"user://config/{fileName}.yml");
            DirectoryExtensions.CreateDirIfNotExist(path);
            var (error, configuration) = YAMLConfiguration.Load<T>(path);

            if (error != NFError.Ok)
            {
                var t = new T();
                Configurations[fileName] = t;
                return t;
            }

            Configurations[fileName] = configuration;
            return configuration;
        }

        public static Logger GetNetLogger()
        {
            return GetLogger("Net");
        }

        private static void Destruct()
        {
            var path = ProjectSettings.GlobalizePath("user://config");
            foreach (var (fileName, config) in Configurations)
            {
                _ = YAMLConfiguration.Save($"{path}/{fileName}", config);
            }
        }
    }
}