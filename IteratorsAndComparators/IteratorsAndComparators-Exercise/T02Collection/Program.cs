using System;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            ListyIterator<string> myList = new ListyIterator<string>();
            

            try
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];

                    if (command == "Create")
                    {
                        myList = new ListyIterator<string>(tokens.Skip(1).ToArray());
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(myList.MoveNext());

                    }
                    else if (command == "Print")
                    {
                        myList.Print();
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(myList.HasNext());

                    }
                    else if (command == "PrintAll")
                    {
                        myList.PrintAll();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
