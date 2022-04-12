using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> numbers = new DoublyLinkedList<int>();

            numbers.AddFirst(9);
            numbers.AddFirst(7);
            numbers.AddFirst(5);
            numbers.AddFirst(3);
            numbers.AddFirst(1);

            numbers.AddLast(11);
            numbers.AddLast(13);

            numbers.RemoveFirst();

            numbers.RemoveLast();

            numbers.ToArray();

            numbers.ForEach(numbers.action());

           
        }
    }
}
