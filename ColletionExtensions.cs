using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace asim.unity.extensions
{
    /// <summary>
    /// Extension class for everything to do with collections, list, dictionarys etc..
    /// </summary>
    public static class ColletionExtensions
    {
        /// <summary>
        /// Fisher-Yates shuffle using unity random range
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /// <summary>
        /// IEnumerable version of Fisher-Yates shuffle using unity random range
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            T[] s = source.ToArray();
            for (var i = s.Length - 1; i >= 0; i--)
            {
                int swapIndex = Random.Range(0, i + 1);
                yield return s[swapIndex];
                s[swapIndex] = s[i];
            }
        }
    }
}
