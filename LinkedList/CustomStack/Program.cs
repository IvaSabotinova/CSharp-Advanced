using System;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            CustomStack stack = new CustomStack();

            stack.Push(5);
            //stack.Push(7);
            //stack.Push(9);
            //stack.Push(11);
            //stack.Push(13);
            //stack.Push(15);

            Console.WriteLine(stack.Peek());
            
            stack.Pop();
            stack.Peek();
            stack.ForEach(stack.action());
            
        }
    }
}
