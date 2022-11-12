using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Trees
{
    internal class Node { 
     public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    internal class BinarySearchTree
    {
        public Node? Root { get; set; }
        public void Add(int input)
        {
            var current = Root;
            while (current is not null)
            {
                if(input<current?.Value)
                {
                    if (current.Left is null)
                    {
                        current.Left = new Node(input);
                        return;
                     }
                    else current = current.Left;
                }
                else
                {
                   if(current!.Right is null)
                    {
                        current.Right = new Node(input);
                        return;
                    }
                   else current = current.Right;
                }
            }
            Root = new Node(input);
        }
        public Node? Delete(int value)
        {

            return DeleteItem(value, this.Root);
        }

        public Node? DeleteItem(int value, Node? node)
        {
            if (node == null)
            {
                node = null;
            }
            else if (value < node.Value) node.Left = DeleteItem(value, node.Left);
            else if (value > node.Value) node.Right = DeleteItem(value, node.Right);
            else
            {
                // handles leaf nodes although not necessary
                if(node.Left is null && node.Right is null)
                {
                    node = null;
                }
                // can handle both leaf nodes and nodes with one children if returned
                else if(node.Right is null)
                {
                   node = node.Left;
                }
                else if( node.Left is null)
                {
                   node = node.Right;
                }
                else
                {
                    node.Value = findLeastRight(node.Right);
                    node.Right = DeleteItem(node.Value, node.Right);
                }
           
            }
            return node;
        }

        public int findLeastRight(Node node)
        {
            int least = node.Value;
            while(node.Left is not null)
            {
                node = node.Left;
                least = node.Value;
            }
            return least;
        }

        public List<int>? PreOrder(Node? node,List<int> list)
        {
            if (node is null) return null;
            list.Add(node.Value);
           PreOrder(node.Left, list);
           PreOrder(node.Right, list);
            return list;
        }
        public List<int> InOrder(Node node, List<int> list)
        {
            if (node.Left is not null)
            {
                InOrder(node.Left, list);
            }
            list.Add(node.Value);
            if (node.Right is not null)
            {
                InOrder(node.Right, list);
            }
            return list;
        }
        public List<int> PostOrder(Node node, List<int> list)
        {
            if (node.Left is not null)
            {
                PostOrder(node.Left, list);
            }
            if (node.Right is not null)
            {
                PostOrder(node.Right, list);
            }
            list.Add(node.Value);
            return list;
        }

        public List<int> BreadthFirst(Node node, List<int> list)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                list.Add(current.Value);
                if(current.Left != null) queue.Enqueue(current.Left);
                if(current.Right != null) queue.Enqueue(current.Right);
            }

            return list;
        }
        public List<int> BreadthFirstRecursive(Queue<Node> queue, List<int> list)
        {
            if (queue.Count < 1) return list;
            var item = queue.Dequeue();
            list.Add(item.Value);
            if(item.Left != null)queue.Enqueue(item.Left);
            if(item.Right != null) queue.Enqueue(item.Right);
            return BreadthFirstRecursive(queue, list);
        }
    }
}
