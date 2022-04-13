using System;
using System.Collections.Generic;


namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList(new int[] { 3, 5, 7, 12 });
            Console.WriteLine(myList.Contains(134));

            ListNode myNode = myList.Find(12);
            myList.AddAfter(myNode, 25);
            myList.AddBefore(myList.First, 5);
            myNode = myList.Find(7);
            myList.AddBefore(myNode, 5);
            myList.Remove(myNode);
            myList.RemoveAll(5);

            foreach (int item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(myList.Count);
        }
    }
}

