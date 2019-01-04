using System;
namespace Algorithms.Examples
{
    public interface IExampleRunnerFactory
    {
        IExampleRunner Create(ExampleCase exampleCase);
    }
}
