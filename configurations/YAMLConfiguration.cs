using System;
using System.IO;
using Nightfall.SharedUtils.InfoCodes;
using Nightfall.SharedUtils.Logging;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nightfall.SharedUtils.Configurations
{
    internal static class YAMLConfiguration
    {
        private static readonly Logger ConfigLogger = NFInstance.GetLogger("Config");

        internal static (NFError, TConfig) Load<TConfig>(string path) where TConfig : class, new()
        {
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            TConfig config;
            try
            {
                config = deserializer.Deserialize<TConfig>(File.OpenText(path));
            }
            catch (YamlException exception)
            {
                ConfigLogger.LogException(exception);
                ConfigLogger.CriticalCrash($"An critical error has occured while parsing file: {path}.",
                    NFError.YAMLError);
                throw; // Logger.CriticalCrash calls Exit so this is most likely never called.
            }
            catch (FileNotFoundException exception)
            {
                ConfigLogger.LogException(exception);
                return (NFError.FileNotFound, null);
            }
            catch (Exception exception)
            {
                ConfigLogger.LogException(exception);
                ConfigLogger.CriticalCrash("TODO: properly handle this exception.", NFError.Bug); // TODO:
                throw; // Logger.CriticalCrash calls Exit so this is most likely never called.
            }

            return (NFError.Ok, config);
        }

        public static NFError Save(string path, IConfiguration configuration)
        {
            var serializer = new SerializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();

            try
            {
                File.WriteAllText(path, serializer.Serialize(configuration));
            }
            catch (YamlException exception)
            {
                ConfigLogger.LogException(exception);
                ConfigLogger.CriticalCrash($"An critical error has occured while serializing file: {path}.",
                    NFError.YAMLError);
                throw; // Logger.CriticalCrash calls Exit so this is most likely never called.
            }
            catch (IOException exception)
            {
                ConfigLogger.LogException(exception);
                return NFError.FileNotFound;
            }
            catch (Exception exception)
            {
                ConfigLogger.LogException(exception);
                ConfigLogger.CriticalCrash("TODO: properly handle this exception.", NFError.Bug); // TODO:
                throw; // Logger.CriticalCrash calls Exit so this is most likely never called.
            }

            return NFError.Ok;
        }
    }
}