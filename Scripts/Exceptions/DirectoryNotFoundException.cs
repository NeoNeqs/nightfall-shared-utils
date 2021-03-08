namespace SharedUtils.Exceptions
{
    public class DirectoryNotFoundException : NightFallException
    {
        public DirectoryNotFoundException(string message) : base(message)
        {
        }
    }
}