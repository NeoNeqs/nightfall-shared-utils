using System;

namespace Nightfall.SharedUtils.Collections.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Concat<T>(this T[] left, T[] right)
        {
            var total = new T[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, total, 0, left.Length);
            Buffer.BlockCopy(right, 0, total, left.Length, right.Length);
            return total;
        }
    }
}