using DotNetAlgo.Sorts;

class Program
{


    public static void Main()
    {
        var bubbleSort = InsertionSort.WithForLoop(new int[] { 10, 5, 3, 8, 2, 6, 4, 7, 9, 1 });
        Console.WriteLine(bubbleSort);
    }
}