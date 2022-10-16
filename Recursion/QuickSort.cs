using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class QuickSort
    {
        public static List<int> Solve(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }
            int pivot = numbers[numbers.Count - 1];
            //numbers.RemoveAt(numbers.Count - 1);
            List<int> left = new();
            List<int> right = new();
            List<int> output = new();
            for (int i = 0; i < numbers.Count-1; i++)
            {
                int val = numbers[i];
                if (val < pivot) left.Add(val);
                else right.Add(val);
            }
            output.AddRange(Solve(left));
            output.Add(pivot);
            output.AddRange(Solve(right));
            return output;
        }
    }
}
