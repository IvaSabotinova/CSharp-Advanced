using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>: IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                newHead.NextNode = head;
                head.PreviosNode = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                tail.NextNode = newTail;
                newTail.PreviosNode = tail;
                tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstElement = head.Value;
            head = head.NextNode;
            if (head != null)
            {
                head.PreviosNode = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastElement = tail.Value;
            tail = tail.PreviosNode;
            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public Action<T> action()
        {
            return x => Console.Write(x + " ");
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            ListNode<T> currentNode = head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
