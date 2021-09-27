using Nightfall.SharedUtils.Algorithms;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Nightfall.SharedUtils.IO.Extensions
{
    public static class FileExtensions
    {
        public static async Task<byte[]> HashAllBytesAsync(string fullFileName)
        {
            var fileInfo = new FileInfo(fullFileName);
            // 1_500_000 is ~1.5 MB
            if (fileInfo.Length < 1_500_000)
            {
                return HashFile(fullFileName);
            }

            return await HashFileAsync(fileInfo);
        }

        private static byte[] HashFile(string fullName)
        {
            using var fileStream = new FileStream(fullName, FileMode.Open, FileAccess.Read, FileShare.Read);

            var data = new byte[fileStream.Length];

            _ = fileStream.Read(data, 0, data.Length);

            using var hash = SHA256.Create();
            return hash.ComputeHash(data);
        }

        private static async Task<byte[]> HashFileAsync(FileInfo fileInfo)
        {
            const int chunks = 30; // DO NOT CHANGE THIS! It will break the algorithm. Default value is 30!

            await using var fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read,
                FileShare.Read, (int) (fileInfo.Length / chunks));

            var data = new byte[chunks][];

            var chunkSize = (int) (fileStream.Length / chunks);

            int i;
            for (i = 0; i < chunks - 1; i++)
            {
                data[i] = new byte[chunkSize];
                _ = fileStream.Read(data[i], 0, chunkSize);
            }

            var leftover = (int) (fileStream.Length - i * chunkSize);

            data[i] = new byte[leftover];
            _ = fileStream.Read(data[i], 0, leftover);

            return await MerkleTree.Compute<SHA256Managed>(data);
        }
    }
}