using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OhmsLibraries.Utilities.Extensions {
    public static class ExtensionUtilities {
        public static T PickOne<T>( this List<T> list ) {
            return list[Random.Range( 0, list.Count )];
        }

        public static T PickOne<T>( this T[] array ) {
            return array[Random.Range( 0, array.Length )];
        }

        /// <summary>
        /// Returns a new list with the elements shuffled using the Fisher-Yates algorithm.
        /// </summary>
        /// <param name="source">The source collection to shuffle.</param>
        /// <returns>A new list containing the shuffled elements.</returns>
        public static List<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var list = source.ToList();
            for (int n = list.Count - 1; n > 0; n--)
            {
                // UnityEngine.Random.Range's upper bound is exclusive, so n + 1 will generate a random number between 0 and n (inclusive).
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}