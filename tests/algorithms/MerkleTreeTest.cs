using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Nightfall.SharedUtils.Algorithms;
using Xunit;

namespace Nightfall.SharedUtils.Tests.Algorithms
{
    public class MerkleTreeTest
    {
        [Fact]
        public async void ComputeTest()
        {
            var data = new[]
            {
                new byte[] {1, 2, 3, 4, 5, 6},
                new byte[] {1, 2, 3, 4, 32, 6},
                new byte[] {1, 2, 3, 4, 5, 6},
                new byte[] {1, 45, 3, 4, 5, 6},
                new byte[] {1, 2, 3, 12, 5, 6},
                new byte[] {1, 2, 3, 4, 5, 6}
            };
            Assert.Equal(
                "B7-86-A8-F7-F3-63-8B-19-05-67-98-AB-21-6F-42-CC-F5-76-A6-3B-4F-FE-8C-07-8E-8C-73-B3-99-92-59-D3",
                await ComputeStringHashOf(data));
        }

        private static async Task<string> ComputeStringHashOf(IReadOnlyList<byte[]> data)
        {
            return BitConverter.ToString(await MerkleTree.Compute<SHA256Managed>(data));
        }
    }
}