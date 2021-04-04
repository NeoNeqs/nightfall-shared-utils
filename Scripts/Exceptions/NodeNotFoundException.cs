namespace SharedUtils.Exceptions
{
    public class NodeNotFoundException : NightFallException
    {
        public NodeNotFoundException(string message) : base($@"Could not found node at ""{message}""") { }
    }
}
