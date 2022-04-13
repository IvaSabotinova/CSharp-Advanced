using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomDoublyLinkedList;

namespace CustomDoublyLinkedList
{
    /// <summary>
    ///linked list if integers
    /// 
    /// </summary>
    public class LinkedList : IEnumerable<int>
    {

        /// <summary>
        /// first node of the list
        /// </summary>
        public ListNode First { get; set; }
        /// <summary>
        /// last node of the list
        /// </summary>
        public ListNode Last { get; set; }
        /// <summary>
        /// number of elements in the list
        /// </summary>
        public int Count { get; set; }
        public LinkedList()
        {
            Count = 0;
        }
        public LinkedList(IEnumerable<int> collection) : this()
        {
            foreach (int item in collection)
            {
                this.AddLast(item);
            }
        }
        /// <summary>
        ///Add node at the end of the linkedlist
        /// </summary>
        /// <param name="item">value to add</param>
        public void AddLast(int item)
        {
            ListNode newElement = new ListNode(item);
            if (Count == 0)
            {
                First = Last = newElement;
            }
            else
            {
                Last.Next = newElement;
                Last = newElement;
            }

            Count++;
        }

        public void AddFirst(int value)
        {
            ListNode newElement = new ListNode(value);

            if (Count == 0)
            {
                First = Last = newElement;
            }
            else
            {
                newElement.Next = First;
                First = newElement;
            }

            Count++;
        }

        public IEnumerator<int> GetEnumerator()
        {
            ListNode current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Contains(int value)
        {
            bool isFound = false;
            ListNode current = First;
            while (current != null)
            {
                if (current.Value == value)
                {
                    isFound = true;
                    break;
                }

                current = current.Next;
            }

            return isFound;
        }

        public ListNode Find(int value)
        {
            ListNode result = null;
            ListNode current = First;
            while (current != null)
            {
                if (current.Value == value)
                {
                    result = current;
                    break;
                }

                current = current.Next;
            }

            return result;
        }

        public void AddAfter(ListNode node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Nodes cannot be null");
            }

            ListNode myNode = new ListNode(value);

            myNode.Next = node.Next;
            node.Next = myNode;

            Count++;
        }

        public void AddBefore(ListNode node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Nodes cannot be null");
            }
            else
            {
                ListNode newElement = new ListNode(value);

                if (node == First)
                {
                    newElement.Next = First;
                    First = newElement;
                }
                else
                {
                    ListNode current = First;
                    while (current != null)
                    {
                        if (current.Next == node)
                        {
                            newElement.Next = node;
                            current.Next = newElement;
                            break;
                        }

                        current = current.Next;
                    }
                }

                Count++;
            }

        }

        public void Remove(ListNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Nodes cannot be null");
            }


            if (First == node)
            {
                First = First.Next;
            }
            else
            {
                ListNode current = First;
                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        break;

                    }

                    current = current.Next;
                }
            }

            Count--;
        }

        public void Remove(int value)
        {

            ListNode myNode = Find(value);

            if (myNode != null)
            {
                Remove(myNode);
            }

        }

        public void RemoveFirst()
        {
            if (First != null)
            {
                First = First.Next;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Last != null)
            {
                if (First == Last)
                {
                    //RemoveFirst();
                    Last = First = null;
                }
                ListNode current = First;
                while (current != null)
                {
                    
                    if (current.Next == Last)
                    {
                        current.Next = null;
                        Last = current;
                    }

                    current = current.Next;
                }

            }

            Count--;
        }

        public void RemoveAll(int value)
        {
            ListNode current = Find(value);

            while (current != null)
            {
                Remove(current);
                current = Find(value);
            }
            
        }
    }
}
