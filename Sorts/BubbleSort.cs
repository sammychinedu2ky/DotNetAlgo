using System.Text.Json;


namespace DotNetAlgo.Sorts
{
    internal class BubbleSort
    {
        public static int[] WithForLoop(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
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
        public static int[] WithWhileLoop(int[] array)
        {
            var swapped = true;
            while (swapped)
            {
                swapped = false;
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                        Console.WriteLine(JsonSerializer.Serialize(array));
                    }
                }
            }
            return array;
        }
    }

}
