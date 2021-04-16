namespace SharedUtils.Exception
{
    public class NodeNotFoundException : NightFallException
    {
        public NodeNotFoundException(string message) : base($"Could not find node at '{message}'") { }
    }
}
