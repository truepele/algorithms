using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new int[] { 1, 4, 2, 5, 0, 55, 21, 21, 55, 83, 95, 22, 111, 2, 3 };

            var sorted = MergeSort(unsorted);

            foreach (var i in sorted)
            {
                Console.WriteLine($"{i} ");
            }
        }

        static IList<int> MergeSort(IList<int> unsorted)
        {
            var count = unsorted.Count;

            if (count <= 1)
            {
                return unsorted;
            }

            var leftCount = count / 2;
            int rightCount = count - leftCount;

            // Divide
            IList<int> left = unsorted.Take(leftCount).ToList();
            IList<int> right = unsorted.Skip(leftCount).Take(rightCount).ToList();

            // MergeSort left
            left = MergeSort(left);

            // MergeSort right            
            right = MergeSort(right);

            // Merge
            return Merge(left, right);
        }

        private static IList<int> Merge(IList<int> left, IList<int> right)
        {
            int leftIndex = 0;
            var rightIndex = 0;

            var result = new List<int>(left.Count + right.Count);

            var leftCount = left.Count;
            var rightCount = right.Count;

            while (leftIndex < leftCount || rightIndex < rightCount)
            {
                if (leftIndex < leftCount && rightIndex < rightCount)
                {
                    if (left[leftIndex] < right[rightIndex])
                    {
                        result.Add(left[leftIndex++]);
                    }
                    else 
                    {
                        result.Add(right[rightIndex++]);
                    }
                }
                else if (leftIndex < leftCount)
                {
                    result.Add(left[leftIndex++]);
                }
                else
                {
                    result.Add(right[rightIndex++]);
                }
            }

            return result;
        }
    }
}
