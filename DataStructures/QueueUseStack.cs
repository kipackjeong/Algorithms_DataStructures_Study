using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class StackQueue
    {
        // Implementing a Queue using a Stack;
        private Stack<int> Stack1;
        private Stack<int> Stack2;
        private int Count;
        public StackQueue()
        {
            Stack1 = new Stack<int>();
            Stack2 = new Stack<int>();
            Count = 0;
        }
        public void Enqueue(int num)
        {
            Stack1.Push(num);
            Count++;

        }
        // O(n)
        public int Dequeue()
        {
            // to Dequeue using two stacks,
            // first push all the elements from stack1 to stack2.
            // then pop the stack2.
            if(IsEmpty())
            {
                throw new Exception();
            }
            while(Stack1.Count != 0)
            {
                Stack2.Push(Stack1.Pop());
            }
            Count--;
            return Stack2.Pop();
        }
        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            MoveElements();
            return Stack2.Peek();
        }

        public bool IsEmpty()
        {
            return Stack1.Count == 0 && Stack2.Count == 0;
        }
        public void MoveElements()
        {
            while (Stack1.Count != 0)
            {
                Stack2.Push(Stack1.Pop());
            }
        }
    }
}