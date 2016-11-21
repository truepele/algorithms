using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertionSort();
            _214AddNumbers();
        }

        private static void _214AddNumbers()
        {
            while (true)
            {
                Console.Write("Enter numeral base:");
                var numeralBase = uint.Parse(Console.ReadLine());
                Console.Write("Enter first operand:");
                var num1 = Integer.Parse(Console.ReadLine(), numeralBase);
                Console.Write("Enter second operand:");
                var num2 = Integer.Parse(Console.ReadLine(), numeralBase);

                Console.WriteLine(num1 + num2);
                Console.ReadLine();
            }
        }

        private static void InsertionSort()
        {
            var elementsCount = 100000;

            Console.Write("Number of threads (4 is default):");
            var threadCountStr = Console.ReadLine();

            int threadCount;
            if (!int.TryParse(threadCountStr, out threadCount))
            {
                threadCount = 4;
                if (!string.IsNullOrEmpty(threadCountStr))
                {
                    Console.WriteLine("Wrong input. Using default...");
                }
            }

            Console.WriteLine($"Starting {threadCount} threads ({elementsCount} elements per each thread)...");

            for (var i = 1; i <= threadCount; i++)
            {
                StartInsertionSortJobTask(i, elementsCount);
            }

            Console.ReadKey();
        }

        private static Task StartInsertionSortJobTask(int orderNumber, int elementsCount = 10000)
        {
            return Task.Run(() =>
            {
                var array = ArrayHelpers.RandomNumericArray(elementsCount);
                //  Console.WriteLine($"Input array: {string.Join(",", array)}");
                var wd = new Stopwatch();
                wd.Start();
                array.SortInsertion();
                wd.Stop();
                //   Console.WriteLine($"Result array: {string.Join(",", array)}");
                Console.WriteLine($"[{orderNumber}]Time spent: {wd.Elapsed.ToString("g")}");
            });
        }
    }
}
