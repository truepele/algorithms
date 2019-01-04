using System;
using System.Linq;

namespace Algorithms.Examples
{
    class Program
    {
        private static readonly IExampleRunnerFactory _runnerFactory = new ExampleRunnerFactory();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter case number...");

            var cases = Enum.GetValues(typeof(ExampleCase)).Cast<ExampleCase>();

            foreach(var c in cases)
            {
                Console.WriteLine($"{(int)c}: {c.ToString()}");
            }

            var caseSelected = (ExampleCase)int.Parse(Console.ReadLine());

            _runnerFactory.Create(caseSelected).Run();
        }
    }
}
