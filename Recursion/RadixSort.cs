using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAlgo.Recursion
{
    internal class RadixSort
    {
        public static List<int> Sort(List<int> numbers)
        {
            var output = new List<int>(numbers);
            var maxUnit = numbers.Max().ToString().Length;
            var bucket = new List<List<int>>();
            Enumerable.Range(0, 10).ToList().ForEach(i => bucket.Add(new List<int>()));
            for (var unit = 1; unit <= maxUnit; unit++)
            {
                // add into bucket
                while(output.Any())
                {
                    var removed = output[0];
                    output.RemoveAt(0);
                    var getModulus = (int)(removed % Math.Pow(10, unit));
                    var index = (int)(getModulus / Math.Pow(10, unit - 1));
                    bucket[index].Add(removed);
                    Console.WriteLine(JsonSerializer.Serialize(bucket));
                }
                // remove from bucket into output
                for(var i=0; i<bucket.Count; i++)
                {
                    while (bucket[i].Any())
                    {
                        output.Add(bucket[i][0]);
                        bucket[i].RemoveAt(0);
                    }
                }
            }
            return output;
        }

        public static List<int> SortUsingBinary(List<int> numbers)
        {
            var output = new List<int>(numbers);
            //  var maxUnit = numbers.Max().ToString().Length;
            var maxUnit = Convert.ToString(numbers.Max(), 2).Length;
            var bucket = new List<List<int>>();
            Enumerable.Range(0, 2).ToList().ForEach(i => bucket.Add(new List<int>()));
            for (var unit = 1; unit <= maxUnit; unit++)
            {
                // add into bucket
                while (output.Any())
                {
                    var removed = output[0];
                    output.RemoveAt(0);
                    var b = Convert.ToString(removed, 2);
                    var getModulus = (int)(Int64.Parse(b) % Math.Pow(10, unit));
                    var index = (int)(getModulus / Math.Pow(10, unit - 1));
                    bucket[index].Add(removed);
                    Console.WriteLine(JsonSerializer.Serialize(bucket));
                }
                // remove from bucket into output
                for (var i = 0; i < bucket.Count; i++)
                {
                    while (bucket[i].Any())
                    {
                        output.Add(bucket[i][0]);
                        bucket[i].RemoveAt(0);
                    }
                }
            }
            return output;
        }

    }
}
