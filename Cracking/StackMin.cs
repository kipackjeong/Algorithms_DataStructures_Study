using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cracking
{
    public class StackMin: Stack<int>
    {
        private Stack<int> _minCont = new Stack<int>();
        

        public StackMin()
        {
            
        }
        public new void Push(int num)
        {
            
            if (isEmpty()) // if input is first val or minimum value
            {
                
                _minCont.Push(num);
            }
            else if (_minCont.Peek() >= num)
            {
                _minCont.Push(num);
            }

            base.Push(num);
        }
        public int Min()
        {
            if(isEmpty())
            {
                throw new Exception("The stack is empty.");
            }
            return _minCont.Peek();
        }
        public new int Pop()
        {
            if(isEmpty())
            {
                throw new Exception("The stack is empty.");
            }
            // if the latest element was min value
            if(Peek() == _minCont.Peek())
            {
                _minCont.Pop();
            }
            return base.Pop();
        }

        
        public bool isEmpty()
        {
            if (Count == 0)
                return true;
            return false;
        }
    }
}
