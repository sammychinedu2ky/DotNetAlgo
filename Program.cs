using DotNetAlgo.Sorts;
using DotNetAlgo.Recursion;
using System.Text.Json;

class Program
{


    public static void Main()
    {
        // var bubbleSort = InsertionSort.WithForLoop(new int[] { 0, 6, 9, 8, 7, 2, 1, 5, 3, 4});
        //var fibonacci = Fibonacci.Solve2(5);
        // var nestedAddition = new NestedAddition().Solve(new object[] { 2, 6, new object[] { 5, 5 } });
        // var mergeSort = MergeSort.Sort(new int[] { 2, 5, 3, 1 });
        var quickSort = QuickSort.Solve(new List<int>() { 1, 2, 5, 4, 7 });
        Console.WriteLine(JsonSerializer.Serialize(quickSort));
        //  Console.WriteLine(mergeSort);
    }
}