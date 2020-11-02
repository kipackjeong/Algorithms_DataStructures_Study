namespace DataStructures
{
    public class MyStack2
    {
        public class ListNode
        {
            public int Data;
            public ListNode Next = null;
            
            public ListNode(int data)
            {
                this.Data = data;
            }
        }
        public ListNode Top = null;
       
        public void Push(int number)
        {
            var node = new ListNode(number);
            node.Next = Top;
            Top = node;
        }
        public int Pop()
        {
            var result = Top.Data;
            Top = Top.Next;
            return result;
        }

        
    }
}