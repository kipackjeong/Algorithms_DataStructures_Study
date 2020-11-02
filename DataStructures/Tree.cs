using System;

namespace DataStructures
{
    public class Tree
    {
        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int num)
            {
                Value = num;
                Left = null;
                Right = null;
            }
        }
        ///////////////////////////
        // prop 
        public Node Root;

        // ctor
        public Tree(int num)
        {
            Root = new Node(num);
        }



        // method
        public bool ValidBinTree( )
        {
            Node root = Root;
            return Helper(root, Int32.MaxValue, Int32.MinValue);
        }
        private bool Helper(Node n, int high, int low)
        {
            if (n == null)
            {
                return true;
            }


            int val = n.Value;
            return (val > low && val < high) &&
                   (Helper(n.Left, n.Value, low)) &&
                   (Helper(n.Right, high, n.Value)); // depth first search.
        }
    }
}