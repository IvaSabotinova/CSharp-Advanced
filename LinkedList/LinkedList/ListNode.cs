using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    
    public class ListNode
    {

        public ListNode Next { get; set; }

        public ListNode Previous { get; set; }
        public int Value { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
        }
        
    }
}
