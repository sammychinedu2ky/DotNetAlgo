using DotNetAlgo.Sorts;
using DotNetAlgo.Recursion;
using DotNetAlgo.Search;
using DotNetAlgo.Lists;
using System.Text.Json;
using DotNetAlgo.Trees;
using DotNetAlgo.TreesAVL;
class Program
{


    public static void Main()
    {
        // var bubbleSort = BubbleSort.WithForLoop(new int[] { 6,2});
        //var fibonacci = Fibonacci.Solve2(5);
        // var nestedAddition = new NestedAddition().Solve(new object[] { 2, 6, new object[] { 5, 5 } });
        //  var mergeSort = MergeSort.Sort(new int[] { 0, 6, 9, 8, 7, 2, 1, 5, 3, 4 });
        // var quickSort = QuickSort.Solve(new List<int>() { 1, 2, 5, 4, 7 });
        //  Console.WriteLine(JsonSerializer.Serialize(mergeSort));
        // Console.WriteLine(MergeSort.Count);
        //  Console.WriteLine(mergeSort);
        // Console.WriteLine(bubbleSort);
        //var radixSort = RadixSort.Sort(new List<int>() { 23, 54, 1, 5, 32, 9, 900 });
        //var r2 = RadixSort.SortUsingBinary(new List<int>() { 23, 54, 1, 5, 32, 9,900 });
        //Console.WriteLine(JsonSerializer.Serialize(radixSort));
        //  Console.WriteLine(JsonSerializer.Serialize(r2));
        // Console.WriteLine(BinarySearch.Search2(new List<int>() { 1, 2 }, 9));
        // var arrayList = new ArrayList<int>();
        // arrayList.Push(1);
        // arrayList.Push(2);
        // arrayList.Push(3);
        // arrayList.Push(4);
        // arrayList.Push(5);
        //// arrayList.Pop();
        // arrayList.Delete(2);
        //// Console.WriteLine(JsonSerializer.Serialize(arrayList.GetItems()));
        //var linkedList = new LinkedList();
        //linkedList.Push(1);
        //linkedList.Push(2);
        //linkedList.Push(3);
        // var getStuff = linkedList.Get(2);
        //Console.WriteLine(JsonSerializer.Serialize(linkedList, new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //}));
        //Console.WriteLine(JsonSerializer.Serialize(linkedList.Delete(2)));
        //Console.WriteLine(JsonSerializer.Serialize(linkedList, new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //})); ;
        //var binarySearchTree = new BinarySearchTree();
        //binarySearchTree.Add(8);
        //binarySearchTree.Add(3);
        //binarySearchTree.Add(10);
        //binarySearchTree.Add(2);
        //Console.WriteLine(JsonSerializer.Serialize(binarySearchTree.Delete(180), new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //}));
        var avlTree = new AvlTree();
        avlTree.Add(8);
        avlTree.Add(9);
        avlTree.Add(10);
        avlTree.Add(11);
        avlTree.Add(12);
      
        Console.WriteLine(JsonSerializer.Serialize(avlTree.Root, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }
}