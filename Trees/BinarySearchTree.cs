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
        public Node Delete(int value)
        {

            return DeleteItem(value, this.Root);
        }

        public Node DeleteItem(int value, Node node)
        {
            if (node == null)
            {
                return null;
            }
            else if (value < node.Value) node.Left = DeleteItem(value, node.Left);
            else if (value > node.Value) node.Right = DeleteItem(value, node.Right);
            else
            {
                if(node.Right is null)
                {
                    return node.Left;
                }
                else if( node.Left is null)
                {
                    return node.Right;
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
       
    }
}
