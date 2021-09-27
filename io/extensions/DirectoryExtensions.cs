using Nightfall.SharedUtils.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Godot;
using Directory = System.IO.Directory;

namespace Nightfall.SharedUtils.IO.Extensions
{
    public static class DirectoryExtensions
    {
        public static async Task<byte[]> HashDirRecursive(string path)
        {
            var hashes = GetAllFiles(path).Select(FileExtensions.HashAllBytesAsync).ToList();

            var data = await Task.WhenAll(hashes);

            return await MerkleTree.Compute<SHA256Managed>(data);
        }

        private static IEnumerable<string> GetAllFiles(string path)
        {
            var queue = new Queue<string>();
            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (var subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception)
                {
                    //ignored
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception)
                {
                    //ignored
                }

                if (files == null) continue;
                foreach (var t in files)
                {
                    yield return t;
                }
            }
        }

        public static bool DirExists(string path)
        {
            var dir = new Godot.Directory();

            return dir.DirExists(path);
        }

        public static void CreateDirIfNotExist(string path)
        {
            var file = new Godot.Directory();

            if (!file.DirExists(path))
            {
                file.MakeDirRecursive(path);
            }
        }
    }
}