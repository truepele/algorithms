﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using truepele.Common;

namespace Algorithms.Examples
{
    internal class SortInsertionExampleRunner : IExampleRunner
    {
        public void Run()
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
                var array = new Random().NextIntEnumerable(elementsCount).ToArray();
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