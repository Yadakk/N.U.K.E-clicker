using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class IntBoolParseUtility
    {
        public static int BoolToInt(bool val) => val ? 1 : 0;

        public static bool IntToBool(int val) => val != 0;
    }
}
