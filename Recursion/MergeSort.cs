using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class MergeSort
    {
        public static int Count = 0;
        public static int[] Sort(int[] array)
        {
            Count++;
            if (array.Length == 1) return array;
            var middle = array.Length / array.Length;
            var left = array.Take(middle).ToArray();
            var right = array.Skip(middle).ToArray();
            var sortLeft = Sort(left);
            var sortRight = Sort(right);
            return Merge(sortLeft, sortRight);
        }
        public static int[] Merge(int[] left, int[] right)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(left));
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(right));
            List<int> output = new();
            while (left.Length > 0 && right.Length > 0)
            {


                if (left[0] < right[0])
                {
                    output.Add(left[0]);
                    left = left.Skip(1).ToArray();
                }
                else
                {
                    output.Add(right[0]);
                    right = right.Skip(1).ToArray();
                }
            }
            // return output.Concat(left).Concat(right).ToArray();
            output.AddRange(left);
            output.AddRange(right);
            return output.ToArray();
        }
    }
}
