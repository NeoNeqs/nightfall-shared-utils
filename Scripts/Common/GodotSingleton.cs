using Godot;

namespace SharedUtils.Common
{
    /// <summary>
    ///     Keeps refernce to a Godot autoload script.
    /// </summary>
    /// <typeparam name="T">A class that inherits <see cref="Node">Node</see></typeparam>
    public abstract class GodotSingleton<T> : Node where T : Node
    {
        protected static T _singleton;
        public static T Singleton => _singleton;
    }
}