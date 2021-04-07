using Godot;

namespace SharedUtils.Common
{
    public sealed class FileUtils
    {
        public static void CreateFileIfNotExists(string pathToFile)
        {
            var file = new File();
            if (!file.FileExists(pathToFile))
            {
                file.Open(pathToFile, File.ModeFlags.Write);
            }
            file.Close();
        }

        public static long GetLength(string pathToFile)
        {
            var file = new File();
            if (file.FileExists(pathToFile))
            {
                var error = file.Open(pathToFile, File.ModeFlags.Read);
                if (error != Error.Ok) return -1L;
                long length = file.GetLen();
                file.Close();
                return length;
            }
            return -1L;
        }
    }
}