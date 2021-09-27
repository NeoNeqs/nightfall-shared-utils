using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Nightfall.SharedUtils.Collections.Extensions;

namespace Nightfall.SharedUtils.Algorithms
{
    public static class MerkleTree
    {
        public static async Task<byte[]> Compute<T>(IReadOnlyList<byte[]> data) where T : HashAlgorithm, new()
        {
            using var t = new T();
            return data.Count == 0 ? new byte[] { } : await Compute(data, t);
        }

        private static async Task<byte[]> Compute<T>(IReadOnlyList<byte[]> data, T hashAlgorithm)
            where T : HashAlgorithm, new()
        {
            if (data.Count == 1)
            {
                return hashAlgorithm.ComputeHash(data[0]);
            }

            return (data.Count & 1) == 0
                ? await ComputeEven(data, hashAlgorithm)
                : await ComputeOdd(data, hashAlgorithm);
        }

        private static async Task<byte[]> ComputeEven<T>(IReadOnlyList<byte[]> data, T hashAlgorithm)
            where T : HashAlgorithm, new()
        {
            if (data.Count <= 2)
                return hashAlgorithm.ComputeHash(hashAlgorithm.ComputeHash(data[0])
                    .Concat(hashAlgorithm.ComputeHash(data[1])));

            var tasks = new Task<byte[]>[data.Count / 2];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Factory.StartNew(obj =>
                {
                    var (index, localData) = ((int, IReadOnlyList<byte[]>)) obj;
                    var localHashAlgorithm = new T();

                    return localHashAlgorithm.ComputeHash(localData[2 * index])
                        .Concat(localHashAlgorithm.ComputeHash(localData[2 * index + 1]));
                }, (i, data));
            }

            var newData = await Task.WhenAll(tasks);

            return await Compute(newData, hashAlgorithm);
        }

        private static async Task<byte[]> ComputeOdd<T>(IReadOnlyList<byte[]> data, T hashAlgorithm)
            where T : HashAlgorithm, new()
        {
            return hashAlgorithm.ComputeHash(
                (await ComputeEven(data, hashAlgorithm)).Concat(hashAlgorithm.ComputeHash(data[^1])));
        }
    }
}