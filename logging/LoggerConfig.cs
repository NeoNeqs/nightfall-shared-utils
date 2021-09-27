using Nightfall.SharedUtils.Configurations;

namespace Nightfall.SharedUtils.Logging
{
    public sealed class LoggerConfig : IConfiguration
    {
        public Level Level = Level.Debug;
    }
}