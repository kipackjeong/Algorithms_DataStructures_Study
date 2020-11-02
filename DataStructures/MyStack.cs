using System;

namespace DataStructures
{
    public class MyStack
    {
        private int[] _array = new int[5];
        private int _count = 0;
        public void Push(int num)
        {
            _array[_count++] = num;
        }

        public int Pop()
        {
            if(_count == 0)
            {
                throw new NullReferenceException();
            }
            int last = _array[_count - 1];
            _array[_count - 1] = 0;
            _count--;
            return last;
        }
        public int Peek()
        {
            return _array[_count - 1];
        }
        public override string ToString()
        {
            return string.Join(",", _array);
        }

    }
}