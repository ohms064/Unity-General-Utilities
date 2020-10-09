using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OhmsLibraries.Utilities.Extensions {
    public static class ExtensionUtilities {
        public static T PickOne<T>( this List<T> list ) {
            return list[Random.Range( 0, list.Count )];
        }

        public static T PickOne<T>( this T[] array ) {
            return array[Random.Range( 0, array.Length )];
        }
    }
}