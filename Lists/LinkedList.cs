using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Lists
{
    internal class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public Node? Next { get; set; }
        public int Value { get; set; }
    }
    internal class LinkedList
    {
        public Node? Head { get; set; }
        public Node? Tail { get; set; }
        public int Length { get; set; }

        public Node? Delete(int index)
        {
            var start = 0;
            Node? res = default;
            Node? node = Head;
            if (index >= Length || index < 0) throw new ArgumentOutOfRangeException("index");
            if (index == 0)
            {
                res = Head;
                Head = Head.Next;
                Length--;
                if (Length == 0)
                {
                    Tail = Head;
                }
                return res;
            }
            while (start < index)
            {
                if (start == index - 1)
                {
                    if (node?.Next == Tail)
                    {
                        Tail = node;
                    }
                    res = node?.Next;
                    node!.Next = node.Next!.Next;
                    Length--;
                    break;
                }
                else
                {
                    node = node!.Next;
                    start++;
                }
            }
            return res;
        }

        public Node? Get(int index)
        {
            var start = 0;
            Node? answer = Head;
            if (index >= Length || index < 0) return null;
            while (start < index)
            {
                answer = answer!.Next;
                start++;
            }
            return answer;
        }

        public Node? Pop()
        {
            return Delete(Length - 1);
        }

        public void Push(int value)
        {
            var node = new Node(value);
            if (Head is null)
            {
                Head = node;
            }
            else
            {
                Tail!.Next = node;
            }
            Tail = node;
            Length++;
        }
    }

    interface ILinkedList<T>
    {
        public T Head { get; set; }
        public T Tail { get; set; }
        public int Length { get; set; }
        public void Push(int value);
        public Node Pop();
        public Node Get(int index);
        public Node Delete(int index);

    }

}
