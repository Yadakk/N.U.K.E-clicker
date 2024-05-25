using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class RandomRollUtility
    {
        public static bool Roll(float chance)
        {
            float roll = Random.Range(0f, 100f);
            return roll <= chance;
        }
    }
}
