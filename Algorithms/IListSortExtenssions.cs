using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class IListSortExtenssions
    {
        public static void SortInsertion<T>(this IList<T> collection) where T : IComparable
        {
            for (var j = 1; j < collection.Count; j++)
            {
                var current = collection[j];

                var i = j - 1;
                for (; i > 0 && collection[i].CompareTo(current) > 0; i--)
                {
                    collection[i + 1] = collection[i];
                }

                collection[i + 1] = current;
            }
        }
    }
}
