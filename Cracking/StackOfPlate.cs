using System;
using System.Collections.Generic;

namespace Cracking
{
    public class StackOfPlate<T>
    {
        private List<Stack<T>> _cont = new List<Stack<T>>();
        public int _currStack = 0;
        public int Count = 0;

        public StackOfPlate()
        {
            var dummy = new Stack<T>();
            _cont.Add(dummy);
        }

        public void Push(T item)
        {
            if (Count % 10 == 0) // if substack if full, move to next substack
            {
                _cont.Add(new Stack<T>()); // create new substack
                _currStack++; // move pointer forward
            }
            _cont[_currStack].Push(item);
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
            var currStack = _cont[_currStack];
            var itemToPop = currStack.Pop();
            Count--;
            if (Count % 10 == 0)
            {
                _cont.Remove(currStack);
                _currStack--; // move pointer back
            }

            return itemToPop;
        }

        public T SubPop(int stackNum)
        {
            if (_cont[stackNum] == null || _cont[stackNum].Count == 0)
            {
                throw new Exception("Stack does not exists");
            }
            var substack = _cont[stackNum];

            var itemToPop = substack.Pop();

            if (substack.Count == 0)
            {
                _cont.Remove(substack);
                _currStack--;
            }
            Count--;
            return itemToPop;
        }

        public void SubPush(int requestedStack, T num)
        {
            var currStack = _cont[requestedStack];
            if (currStack.Count == 10)
            {
                Push(num);
                return;
            }
            else
            {
                _cont[requestedStack].Push(num);
            }
            Count++;
        }
    }
}