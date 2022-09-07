using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAlgo.Sorts
{
    internal class InsertionSort
    {
        public static int[] WithForLoop(int[] array)
        {
            for(var i=1; i<array.Length; i++)
            {
                var j = i;
                while (array[j-1] > array[j])
                {
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    j--;
                    Console.WriteLine(JsonSerializer.Serialize(array));
                    if (j==0) break;

                }
            }
            return array;
        }
    }
}
