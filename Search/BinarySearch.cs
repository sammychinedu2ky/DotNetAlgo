using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Search
{
    internal class BinarySearch
    {
        public static bool Search(List<int> numbers,int target)
        {
            int middle = numbers.Count / 2;
            while (true)
            {
                if (numbers[middle] < target && numbers.Count > 1)
                {
                    numbers = numbers.Skip(middle).ToList();
                    middle = numbers.Count/2;
                }
                else if (numbers[middle] > target && numbers.Count>1)
                {
                    numbers = numbers.Take(middle).ToList();
                    middle = numbers.Count / 2;
                }
                else if (numbers[middle] == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           // return default;
        }
    }
}
