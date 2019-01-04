using System;
namespace Algorithms.Examples
{
    public class ExampleRunnerFactory : IExampleRunnerFactory
    {
        public ExampleRunnerFactory()
        {
        }

        public IExampleRunner Create(ExampleCase exampleCase)
        {
            switch (exampleCase)
            {
                case ExampleCase.SortMerge:
                    return new SortMergeExampleRunner();
                case ExampleCase.SortInsertion:
                    return new SortInsertionExampleRunner();
                case ExampleCase.NumbersAdd:
                    return new NumbersAddExampleRunner();
                case ExampleCase.Unknown:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
