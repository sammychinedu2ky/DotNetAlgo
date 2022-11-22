using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAlgo.Graphs
{
    internal class PathFinding
    {
        public List<List<int>> Matrix = JsonSerializer.Deserialize<List<List<int>>>("""

            [
                [2, 0, 0, 0],
                [0, 0, 0, 0],
                [0, 0, 0, 0],
                [0, 0, 0, 2]
              ]

            """)!;
        public enum OpenedBy
        {
            NO_ONE = 0,
            BY_A = 1,
            BY_B = 2
        }
        public class DataPoint
        {
            public bool Closed { get; set; }
            public int Length { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public OpenedBy OpenedBy { get; set; }
        }
        public int FindShortestPath(int Ax, int Ay, int Bx, int By)
        {
            var visited = Matrix.Select(
                (yValue, yIndex) => yValue.Select(
                    (xValue, xIndex) => new DataPoint
                    {
                        Closed = xValue == 1,
                        OpenedBy = OpenedBy.NO_ONE,
                        Length = 0,
                        X = xIndex,
                        Y = yIndex
                    }).ToList()).ToList();
            visited[Ay][Ax].OpenedBy = OpenedBy.BY_A;
            visited[By][Bx].OpenedBy = OpenedBy.BY_B;

            var aQueue = new Queue<DataPoint>();
            aQueue.Enqueue(visited[Ay][Ax]);
            var bQueue = new Queue<DataPoint>();
            bQueue.Enqueue(visited[By][Bx]);
            var iteration = 0;
            while (aQueue.Count > 0 & bQueue.Count > 0)
            {
                iteration++;
                //78-82 same with 61-62
                var aNeighbours = aQueue.ToList().Aggregate(new List<DataPoint>(), (acc, next) => acc.Concat(GetNeighbours(visited, next.X, next.Y)).ToList());
                aQueue = new Queue<DataPoint>();
                Console.WriteLine(aNeighbours.Count);
                for (var i = 0; i < aNeighbours.Count; i++)
                {
                    var neighbour = aNeighbours[i];
                    if (neighbour.OpenedBy == OpenedBy.BY_B)
                    {
                        return neighbour.Length + iteration;
                    }
                    else if (neighbour.OpenedBy == OpenedBy.NO_ONE)
                    {
                        neighbour.Length = iteration;
                        neighbour.OpenedBy = OpenedBy.BY_A;
                        aQueue.Enqueue(neighbour);
                    }
                }
                var bNeighbours = new List<DataPoint>();
                //78-82 same with 61-62
                while (bQueue.Count > 0)
                {
                    var item = bQueue.Dequeue();
                    bNeighbours.AddRange(GetNeighbours(visited, item.X, item.Y));
                }
                for (var i = 0; i < bNeighbours.Count; i++)
                {
                    var neighbour = bNeighbours[i];
                    if (neighbour.OpenedBy == OpenedBy.BY_A)
                    {
                        return neighbour.Length + iteration;
                    }
                    else if (neighbour.OpenedBy == OpenedBy.NO_ONE)
                    {
                        neighbour.Length = iteration;
                        neighbour.OpenedBy = OpenedBy.BY_B;
                        bQueue.Enqueue(neighbour);
                    }
                }
            }
            return -1;
        }

        public List<DataPoint> GetNeighbours(List<List<DataPoint>> visited, int x, int y)
        {
            var result = new List<DataPoint>();
            //left
            if (x - 1 >= 0 && !visited[y][x - 1].Closed) result.Add(visited[y][x - 1]);
            //right
            if (x + 1 < visited[y].Count && !visited[y][x + 1].Closed) result.Add(visited[y][x + 1]);
            //up
            if (y - 1 >= 0 && !visited[y - 1][x].Closed) result.Add(visited[y - 1][x]);
            // down
            if (y + 1 < visited.Count && !visited[y + 1][x].Closed) result.Add(visited[y + 1][x]);

            return result;
        }
    }
}
