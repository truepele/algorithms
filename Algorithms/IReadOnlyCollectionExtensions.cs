using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class IReadOnlyCollectionExtensions
    {
        public static IReadOnlyCollection<T> SortInsertion<T>(this IReadOnlyCollection<T> collection) where T : IComparable
        {
            var result = new T[collection.Count];
            for (var j = 1; j < collection.Count; j++)
            {
                var current = collection.ElementAt(j);

                var i = j - 1;
                for (; i > 0 && collection.ElementAt(i).CompareTo(current) > 0; i--)
                {
                    result[i + 1] = collection.ElementAt(i);
                }

                result[i + 1] = current;
            }

            return result;
        }

        public static IReadOnlyCollection<T> SortMerge<T>(this IReadOnlyCollection<T> collection) where T : IComparable
        {
            var count = collection.Count;

            if (count <= 1)
            {
                return collection;
            }

            var leftCount = count / 2;
            var rightCount = count - leftCount;

            // MergeSort left
            var left = SortMerge(collection.Take(leftCount).ToArray());

            // MergeSort right            
            var right = SortMerge(collection.Skip(leftCount).Take(rightCount).ToArray());

            // Merge
            return MergeSorted(left, right).ToArray();
        }

        private static IEnumerable<T> MergeSorted<T>(this IReadOnlyCollection<T> left, IReadOnlyCollection<T> right) where T : IComparable
        {
            var leftIndex = 0;
            var rightIndex = 0;

            var leftCount = left.Count;
            var rightCount = right.Count;

            while (leftIndex < leftCount || rightIndex < rightCount)
            {
                if (leftIndex < leftCount && rightIndex < rightCount)
                {
                    yield return left.ElementAt(leftIndex).CompareTo(right.ElementAt(rightIndex)) < 0
                        ? left.ElementAt(leftIndex++)
                        : right.ElementAt(rightIndex++);
                }
                else
                {
                    yield return leftIndex < leftCount ? left.ElementAt(leftIndex++) : right.ElementAt(rightIndex++);
                }
            }
        }
    }
}
