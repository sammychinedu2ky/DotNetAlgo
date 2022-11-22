using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DotNetAlgo.TreesAVL
{
    internal class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; set; }
        public int Height { get; set; } = 1;
        public Node(int value)
        {
            Value = value;
        }

        public void Add(int value)
        {
            // Decide to go left or right 
            // Find the correct place to add

            //make sure you're updating heights

            if (value < Value)
            {
                if (Left is not null)
                {
                    Left.Add(value);
                }
                else
                {
                    Left = new Node(value);
                }
                if (Right is null || Right.Height < Left.Height)
                {
                    Height = Left.Height + 1;
                }
            }
            else
            {
                if (Right is not null)
                {
                    Right.Add(value);
                }
                else
                {
                    Right = new Node(value);
                }
                if (Left is null || Left.Height < Right.Height)
                {
                    Height = Right.Height + 1;
                }
            }

            Balance();
        }

        private void Balance()
        {
            // ask is this node out of balance
            // if not out of balance do nothing
            // if it is out of balance, do I need to single or double rotate
            // if it is single just call rotate on self
            // if it is double, call rotate on child then on self
            var leftHeight = (Left is null) ? 0 : Left.Height;
            var rightHeight = (Right is null) ? 0 : Right.Height;

            if (leftHeight > rightHeight + 1)
            {
                var leftRightHeight = (Left.Right is not null) ? Left.Right.Height : 0;
                var leftLeftHeight = (Left.Left is not null) ? Left.Left.Height : 0;
                // double rotation
                if (leftRightHeight > leftLeftHeight)
                {
                    Left.RotateLL();

                }
                RotateRR();

            }
            else if (rightHeight > leftHeight + 1)
            {
                var rightLeftHeight = Right.Left is not null ? Right.Left.Height : 0;
                var rightRightHeight = Right.Right is not null ? Right.Right.Height : 0;
                // double rotation
                if (rightLeftHeight > rightRightHeight + 1)
                {
                    Right.RotateRR();
                }
                RotateLL();
            }
        }

        private void RotateRR()
        {
            Right = new Node(Value) { Left = Left, Right = Right };
            Right.Left = Left?.Right;
            Value = Left!.Value;
            Left = Left.Left;
            Right.Height = Math.Max(Right.Left is not null ? Right.Left!.Height : 0, Right.Right is not null ? Right.Height : 0) + 1;
            Height = Math.Max(Left!.Height, Right.Height) + 1;

        }
        private void RotateLL()
        {
            Left = new Node(Value) { Left = Left, Right = Right };
            Left.Right = Right?.Left;
            Value = Right.Value;
            Right = Right.Right;
            Left.Height = Math.Max(Left.Left is not null ? Left.Left.Height : 0, Left.Right is not null ? Left.Right.Height : 0) + 1;
            Height = Math.Max(Left!.Height, Right.Height) + 1;
        }

    }
    internal class AvlTree
    {
        public Node? Root { get; set; }
        public AvlTree()
        {
            Root = null;
        }
        public void Add(int value)
        {
            if (Root is null)
            {
                Root = new Node(value);
            }
            else
            {
                Root.Add(value);
            }
        }
    }
}
