using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class StackUseQueue
    {
        private Queue<int> _q1 = new Queue<int>();
        private Queue<int> _q2 = new Queue<int>();
        // q1 = [1,2,3,4]
        // q2 = [5]

        public int Count = 0;
        

        public void Push(int num) //O(n)
        {
            var empty = EmptyQ();
            var nEmpty = NEmptyQ();
            if(empty.Count == nEmpty.Count)
            {
                empty.Enqueue(num);
            }
            else
            {
                empty.Enqueue(num);
                for (var i = 0; i < Count; i++)
                {
                    
                    empty.Enqueue(nEmpty.Dequeue());
                }
            }

            Count++;
        }
        public int Pop() //O(1)
        {
            if(IsEmpty())
            {
                throw new Exception("Stack is empty");
            }
            
            Count--;
            return NEmptyQ().Dequeue();
        }

        public int Peek()
        {
            return NEmptyQ().Peek();
        }
        private Queue<int> EmptyQ()
        {
            return _q2.Count == 0 ? _q2 : _q1;
        }
        private Queue<int> NEmptyQ()
        {
            return _q2.Count == 0 ? _q1 : _q2;
        }
        private bool IsEmpty()
        {
            return Count == 0;
        }
        public override string ToString()
        {
            if(_q1.Count == 0 && _q2.Count == 0)
            {
                return "empty";
            }

            return String.Join(",", NEmptyQ());
        }
    }
}
