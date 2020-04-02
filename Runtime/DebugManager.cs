using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OhmsLibraries.Utilities {
    public static class DebugManager {
        [System.Diagnostics.Conditional( "ENABLE_LOGS" )]
        public static void Log ( object s ) {

            Debug.Log( s );

        }
        [System.Diagnostics.Conditional( "ENABLE_LOGS" )]
        public static void LogFormat ( string s, params object[] format ) {

            Debug.LogFormat( s, format );

        }
    }
}