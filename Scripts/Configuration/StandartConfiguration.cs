using Godot;

namespace SharedUtils.Configuration
{
    public class StandartConfiguration<T> : Configuration<T> where T : Node
    {
        public int GetPort(int defaultPort)
        {
            return GetValue("NETWORKING", "port", defaultPort);
        }

        public int GetMaxAttempts(int defaultAttemps = 30)
        {
            return GetValue("NETWORKING", "max_attempts", defaultAttemps);
        }
    }
}