using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class ListUtility
    {
        public static List<T> ShuffleWithoutRepetition<T>(List<T> list)
        {
            if (list.Count <= 2) return list;
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

        public static List<T> ShuffleWithoutRepetition<T>(List<T> list, T customLast)
        {
            list = list.OrderBy(elem => Random.Range(0, list.Count)).ToList();
            int matchingLastCount = 0;
            while (EqualityComparer<T>.Default.Equals(list[matchingLastCount], customLast))
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

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> elements, int countToTake)
        {
            var internalList = elements.ToList();

            var selected = new List<T>();
            for (var i = 0; i < countToTake; ++i)
            {
                var next = Random.Range(0, internalList.Count - selected.Count);
                selected.Add(internalList[next]);
                internalList[next] = internalList[^selected.Count];
            }
            return selected;
        }
    }
}
