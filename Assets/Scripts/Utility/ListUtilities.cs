using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class ListUtilities
    {
        public static List<T> ShuffleWithoutRepetition<T>(List<T> list)
        {
            T lastElem = list[^1];
            list = list.OrderBy(elem => Random.Range(0, list.Count)).ToList();
            int matchingLastCount = 0;
            while (EqualityComparer<T>.Default.Equals(list[matchingLastCount], lastElem))
            {
                matchingLastCount++;
                if (matchingLastCount >= list.Count) return list;
            }
            int servingIndex = 0;
            for (int i = matchingLastCount; i > 0; i--)
            {
                T servingElem = list[servingIndex];
                list.Remove(servingElem);
                list.Insert(Random.Range(matchingLastCount - servingIndex, list.Count), servingElem);
            }
            return list;
        }
    }
}
