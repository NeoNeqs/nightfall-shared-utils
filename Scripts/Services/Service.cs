using Godot;

namespace SharedUtils.Scripts.Services
{
    public class Service : Node
    {
        public void QuitOnError(int errorCode)
        {
#if DEBUG
            if (IsInsideTree())
#endif
                if (errorCode != 0)
                    GetTree().Quit(-errorCode);
        }
    }
}