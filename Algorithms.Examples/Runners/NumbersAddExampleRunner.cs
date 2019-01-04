using System;

namespace Algorithms.Examples
{
    internal class NumbersAddExampleRunner : IExampleRunner
    {
        public void Run()
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
    }
}