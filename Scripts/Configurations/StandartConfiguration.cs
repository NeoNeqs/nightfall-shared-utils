using Godot;

namespace SharedUtils.Configurations
{
    public abstract class StandartConfiguration<T> : Configuration<T> where T : Node
    {
        protected StandartConfiguration() : base()
        {
        }

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