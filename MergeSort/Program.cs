using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace MergeSort
{
    class Program
    {
        private static void Main()
        {
            var unsorted = ArrayHelpers.RandomNumericArray(15);

            Console.WriteLine("Unsorted:");
            foreach (var i in unsorted)
            {
                Console.WriteLine($"{i} ");
            }

            var sorted = MergeSort(unsorted);

            Console.WriteLine("Sorted:");
            foreach (var i in sorted)
            {
                Console.WriteLine($"{i} ");
            }

            Console.ReadLine();
        }

        private static ICollection<int> MergeSort(ICollection<int> unsorted)
        {
            var count = unsorted.Count;

            if (count <= 1)
            {
                return unsorted;
            }

            var leftCount = count / 2;
            var rightCount = count - leftCount;

            // MergeSort left
            var left = MergeSort(unsorted.Take(leftCount).ToArray());

            // MergeSort right            
            var right = MergeSort(unsorted.Skip(leftCount).Take(rightCount).ToArray());

            // Merge
            return Merge(left, right).ToArray();
        }


        private static IEnumerable<int> Merge(ICollection<int> left, ICollection<int> right)
        {
            var leftIndex = 0;
            var rightIndex = 0;

            var leftCount = left.Count;
            var rightCount = right.Count;

            while (leftIndex < leftCount || rightIndex < rightCount)
            {
                if (leftIndex < leftCount && rightIndex < rightCount)
                {
                    yield return left.ElementAt(leftIndex) < right.ElementAt(rightIndex)
                        ? left.ElementAt(leftIndex++)
                        : right.ElementAt(rightIndex++);
                }
                else if (leftIndex < leftCount)
                {
                    yield return left.ElementAt(leftIndex++);
                }
                else
                {
                    yield return right.ElementAt(rightIndex++);
                }
            }
        }
    }
}
