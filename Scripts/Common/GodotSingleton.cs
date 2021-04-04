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
        public static T Singleton
        {
            get
            {
#if DEBUG
                if (_singleton == null)
                {
                    throw new System.NullReferenceException($@"Singleton {typeof(T).Name} was never initialized or got deinitialized. ""_singleton == null"" is true.");
                }
#endif
                return _singleton;
            }
        }

        protected void DeInit()
        {
            _singleton = null;
            QueueFree();
        }
    }
}