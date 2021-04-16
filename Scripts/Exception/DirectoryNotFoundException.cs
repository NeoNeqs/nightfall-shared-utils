namespace SharedUtils.Exception
{
    public class DirectoryNotFoundException : NightFallException
    {
        public DirectoryNotFoundException(string path) : base($"Directory {path} does not exist") { }
    }
}