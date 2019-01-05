using System;
using System.Linq;
using truepele.Common;

namespace Algorithms.Examples
{
    internal class SortMergeExampleRunner : IExampleRunner
    {
        public void Run()
        {
            var unsorted = new Random().NextIntEnumerable(15).ToArray();

            Console.WriteLine("Unsorted:");
            foreach (var i in unsorted)
            {
                Console.WriteLine($"{i} ");
            }

            var sorted = unsorted.SortMerge();

            Console.WriteLine("Sorted:");
            foreach (var i in sorted)
            {
                Console.WriteLine($"{i} ");
            }

            Console.ReadLine();
        }
    }
}