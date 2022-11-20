using DotNetAlgo.Sorts;
using DotNetAlgo.Recursion;
using DotNetAlgo.Search;
using DotNetAlgo.Lists;
using System.Text.Json;
using DotNetAlgo.Trees;
using DotNetAlgo.TreesAVL;
using DotNetAlgo.Graphs;
using Node = DotNetAlgo.Trees.Node;
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
        //var avlTree = new AvlTree();
        //avlTree.Add(8);
        //avlTree.Add(9);
        //avlTree.Add(10);
        //avlTree.Add(11);
        //avlTree.Add(12);
        //avlTree.Add(13);
        //avlTree.Add(14);
        //avlTree.Add(15);


        //Console.WriteLine(JsonSerializer.Serialize(avlTree.Root, new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //}));

        //var binarySearchTree = new BinarySearchTree();
        //binarySearchTree.Add(8);
        //binarySearchTree.Add(3);
        //binarySearchTree.Add(1);
        //binarySearchTree.Add(6);
        //binarySearchTree.Add(4);
        //binarySearchTree.Add(7);
        //binarySearchTree.Add(10);
        //binarySearchTree.Add(14);
        //binarySearchTree.Add(13);
        //Console.WriteLine(String.Join(",", binarySearchTree.PreOrder(binarySearchTree.Root, new List<int>())));
        //Console.WriteLine(String.Join(",", binarySearchTree.InOrder(binarySearchTree.Root, new List<int>())));
        //Console.WriteLine(String.Join(",", binarySearchTree.PostOrder(binarySearchTree.Root, new List<int>())));
        //Console.WriteLine(String.Join(",", binarySearchTree.BreadthFirst(binarySearchTree.Root, new List<int>())));
        //var queue = new Queue<Node>();
        //queue.Enqueue(binarySearchTree.Root);
        //Console.WriteLine(String.Join(",", binarySearchTree.BreadthFirstRecursive(queue, new List<int>())));
        //var arr = new int[] { 2, 4, 1, 6, 4, 9 };
        //var heapSort = new HeapSort(arr);
        //Console.WriteLine(String.Join(",", heapSort.Sort()));
        //var retrieveData = new RetrieveData();
        //Console.WriteLine(retrieveData.FindMostCommonTitle(306,4));
        var pathFinding = new PathFinding();
        pathFinding.Matrix = JsonSerializer.Deserialize<List<List<int>>>("""

            [
                [2, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, 2, 0],
                [0, 0, 0, 0]
              ]

            """)!;
        Console.WriteLine(pathFinding.FindShortestPath(0,0, 2,2));
    }
}