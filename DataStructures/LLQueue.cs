using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace DataStructures
{
    public class Node
    {

        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int num)
        {
            Value = num;
            Next = null;
        }
    }
    public class LLQueue
    {

        public Node Start { get; set; }
        public Node End { get; set; }
        public int Count = 0;
        

        // ctor

        public void Enqueue(int num)
        {
            var node = new Node(num);
            if (Start == null && End == null)
            {
                Start = node;
                End = node;
            }
            else
            {
                End.Next = node;
                End = node;
            }
            Count++;
        }
        public int Dequeue()
        {
            if(IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            // remove head
            // 1-2-3-4
            // -2-3-4 
            var item = Start;
            Start = Start.Next;
            item.Next = null;
            Count--;
            return item.Value;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
        public int Peek()
        {
            if(IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            return End.Value;
        }

        
        public override string ToString()
        {
            Node p = Start;
            var builder = new StringBuilder(); 
            while(p != null)
            {
                builder.Append(p.Value);
                p = p.Next;
            }
            return builder.ToString();
        }
    }

        
}