using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DataStructures
{
    public class ArrayQueue
    {
        // Implementing a Queue using an Array;
        private int[] _array;
        private int End;
        private int Start;
        private bool IsValid = true;
        public int Count;

        public ArrayQueue(int capacity)
        {
            _array = new int[capacity];
            End = 0;
            Start = 0;
            Count = 0;
        }
        public void Enqueue(int num)
        {
            End = End % _array.Length;
            if(Count == _array.Length)
            {
                throw new Exception();
            }
            // {0,0,1,2,3}
            //          E
            // In case of this, make it circular array.
            _array[End++] = num;
            Count++;
            IsValid = true;
        }
        public int Dequeue()
        {
            
            Start = Start % _array.Length;
            if(!IsValid)
            {
                throw new Exception();
            }
            // If there is no element to Dequeue;
            if (Start == _array.Length - 1)
            {
                IsValid = false;
            }
            var result = _array[Start];
            Start++;
            Count--;
            return result;
        }
        public static void ReverseQueue(Queue<int> q)
        {
            var stack = new Stack<int>();
            while(q.Count !=0)
            {
                stack.Push(q.Dequeue());   
            }

            while(stack.Count !=0 )
            {
                q.Enqueue(stack.Pop());
            }

        }
    }
}