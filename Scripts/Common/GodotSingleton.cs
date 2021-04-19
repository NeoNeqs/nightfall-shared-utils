using Godot;

namespace SharedUtils.Common
{
    public abstract class GodotSingleton<T> : Node where T : Node
    {
        public static T Instance { get; private set; }

        public GodotSingleton()
        {
            Instance = GetNodeOrNull<T>(".");
        }
    }
}
