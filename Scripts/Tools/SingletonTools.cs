using SharedUtils.Common;

namespace SharedUtils.Tools
{
    public class SingletonTools : GodotSingleton<SingletonTools>
    {
        public delegate void ExitTree();

        public event ExitTree ExitTreeSignal;

        SingletonTools()
        {
            _singleton = this;
        }

        public override void _ExitTree()
        {
            ExitTreeSignal?.Invoke();
        }
    }
}
