using System;

namespace CustomQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(12);
            queue.Enqueue(19);
            queue.Enqueue(31);
            queue.Enqueue(50);


            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Peek();
            //queue.Clear();
            queue.ForEach(queue.action());




        }
    }
}
