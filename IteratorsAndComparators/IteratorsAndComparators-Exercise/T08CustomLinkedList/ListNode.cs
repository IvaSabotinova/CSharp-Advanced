﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode<T> 
    {
        
        public T Value { get; set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviosNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;

        }
        
    }
}
