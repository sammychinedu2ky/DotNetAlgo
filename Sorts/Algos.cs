using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Sorts
{
    internal class Algos
    {
    public static int[] BubbleSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var swapped = true;
                for (var j = 0; j < array.Length; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = false;
                    }
                }
                if (!swapped) return array;
            }

            return array;
        }
    }
}
