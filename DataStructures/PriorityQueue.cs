using System;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class PriorityQueue
    { // Implement PriorityQueu using an Array.
        private int[] _arr;
        private int _start = 0;
        private int _end = -1;
        public int Count = 0;

        public PriorityQueue(int capacity)
        {
            _arr = new int[capacity];
        }

        // Implement Add method in PriorityQueue,
        // [1,2,3,4,6] add = 5 --> [1,2,3,4,5,6]
        public void Insert(int num)
        {
            // if array is full,
            if(IsFull())
            {
                throw new Exception("No more capacity");
            }
            if (_end == -1)
            {
                _end++;
                _arr[_end] = num;
            }
            else
            {
                _arr[ShiftAndInsert(num)] = num;
                _end++;
            }
            Count++;
        }
        /// <summary>
        /// shift all the elements bigger than input num to right.
        /// </summary>
        /// <param name="num"></param>
        /// <returns> return index to insert new item.</returns>
        private int ShiftAndInsert(int num)
        {
            // iterate from back of _arr
            int i;
            for (i = _end; i >= 0; i--)
            {
                // if input item is smaller than current item at index i,
                //copy the current item and push it to the back.
                if (num < _arr[i])
                {
                    _arr[i + 1] = _arr[i];
                }
                else
                {
                    break;
                }
            }
            // i is where shifting stopped,
            // it's where we found smaller or equal number than input
            return i + 1;
        }

        /// <summary>
        /// Remove the first number.
        /// </summary>
        /// <returns> integer removed.</returns>
        public int Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("No Item to remove");
            }
            // store removed item to return
            var temp = _arr[_start];
            // remove item [0,1,2,3]
            _arr[_start] = 0;
            // pull the array to the front [1,2,3,0]
            for (var i = _start; i < _end + 1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            Count--;
            _end--;
            // return removed item
            return temp;

        }
        /// <summary>
        /// Check to see if queue is empty.
        /// </summary>
        private bool IsEmpty()
        {
            return Count == 0;
        }
        /// <summary>
        /// Check to see if queue is full.
        /// </summary>
        private bool IsFull() 
        {
            return _end == _arr.Length - 1;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for(var i = _start; i < _end + 1; i++)
            {
                if(i == _start)
                {
                    builder.Append(_arr[i]);
                    continue;
                }
                builder.Append($",{_arr[i]}");
            }

            return builder.ToString();
        }
    }
}