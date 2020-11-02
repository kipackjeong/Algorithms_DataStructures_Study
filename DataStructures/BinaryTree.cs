using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DataStructures
{
    public class BinaryTree
    {
        public class Node
        {
            // Prop
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }

            // ctor
            public Node(int val, Node left = null, Node right = null, Node parent = null)
            {
                Value = val;
                Left = left;
                Right = right;
                Parent = parent;
            }
        }

        public Node Head = null;
        // ctor
        public BinaryTree()
        {

        }

        // [ 10, 5, 15, 6, 1, 8, 12, 18, 17]

        // method
        public Node Lookup(int num, Node Head)
        {
            // compare with the head
            if (Head == null)
            {
                return new Node(-1);
            }
            if (Head.Value == num)
            {
                return Head;
            }
            if (Head.Value <= num)
            {
                return Lookup(num, Head.Right);
            }
            else
            {
                return Lookup(num, Head.Left);
            }
        }


        public void GenTree(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if( i == 0 )
                    Head = new Node(arr[0]);
                else
                {
                    var node = new Node(arr[i]);
                    Insert(node, Head);
                }
            }
        }

        public void Insert(Node node, Node cur)
        {
            if (Head == null)
            {

                Head = node;
                return;
            }
            // compare
            if (node.Value  < cur.Value)
            {
                // move left
                

                if (cur.Left == null)
                {
                    cur.Left = node;
                    return;
                }
                Insert(node, cur.Left);
            }
            else
            {
                // move right
                if (cur.Right == null)
                {
                    cur.Right = node;
                    return;
                }
                Insert(node, cur.Right);
            }
        }

        public void Delete()
        {

        }

        public void TraversePreOrder(Node p)
        {
            if (p == null)
            {
                return;
            }
            Console.Write(p.Value + " ");
            TraversePreOrder(p.Left);
            TraversePreOrder(p.Right);
        }

        public void TraverseInOrder(Node p)
        {
            if (p == null)
            {
                return;
            }
            TraverseInOrder(p.Left);
            Console.Write(p.Value + " ");
            TraverseInOrder(p.Right);
            
        }

        public void TraversePostOrder(Node p)
        {
            if (p == null)
            {
                return;
            }

            TraversePostOrder(p.Left);
            TraversePostOrder(p.Right);
            Console.Write(p.Value + " ");
        }

        public int GetHeight(Node root)
        {
            if (root == null)
            {
                return -1;
            }
            return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        }

        public int GetMin(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            var leftMin = GetMin(root.Left);
            var rightMin = GetMin(root.Right);
            return Math.Min(Math.Min(leftMin,rightMin), root.Value);
        }
    }
}