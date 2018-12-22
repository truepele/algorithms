using System;

namespace Algorithms
{
    public static class ArrayHelpers
    {
        public static int[] RandomNumericArray(int count, int maxValue = 0)
        {
            if (count < 1)
            {
                throw new ArgumentException(nameof(count));
            }

            if (maxValue == 0) maxValue = count;

            var result = new int[count];
            var r = new Random(0);

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = r.Next(maxValue);
            }

            return result;
        }
    }
}
