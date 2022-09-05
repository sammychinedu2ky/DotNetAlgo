using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAlgo.Sorts
{
    internal class Algos
    {
    public static int[] BubbleSortWithForLoop(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var swapped = false;
                for (var j = 0; j < array.Length-1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                         Console.WriteLine(JsonSerializer.Serialize(array));
                    }
                }
                if (!swapped) break;
            }

            return array;
        }
    public static int[] BubbleSortWithWhileLoop(int[] array)
    {
            while (true)
            {
            var swapped = false;
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                          Console.WriteLine(JsonSerializer.Serialize(array));
                    }
                }
                if (!swapped) break;
            }
        return array;
    }
    }

}
