using System;

namespace Algorithms
{
    public static class ArrayHelpers
    {
        public static int[] RandomNumericArray(int count)
        {
            var result = new int[count];
            var r = new Random(0);

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = r.Next();
            }

            return result;
        }
    }
}
