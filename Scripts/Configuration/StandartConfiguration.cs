namespace SharedUtils.Configuration
{
    public class StandartConfiguration : Configuration
    {
        public int GetPort(int defaultPort)
        {
            return GetValue("NETWORKING", "port", defaultPort);
        }

        public int GetMaxAttempts(int defaultAttemps)
        {
            return GetValue("NETWORKING", "max_attempts", defaultAttemps);
        }
    }
}