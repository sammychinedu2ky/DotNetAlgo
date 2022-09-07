using DotNetAlgo.Sorts;

class Program
{


    public static void Main()
    {
        var bubbleSort = InsertionSort.WithForLoop(new int[] { 0, 6, 9, 8, 7, 2, 1, 5, 3, 4});
        Console.WriteLine(bubbleSort);
    }
}