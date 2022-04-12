using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = String.Empty;

            int numberOfCommands = int.Parse(Console.ReadLine());

            Stack<string> stackToUndo = new Stack<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = commands[0];

                if (command == "1")
                {
                    stackToUndo.Push(text);
                    StringBuilder sb = new StringBuilder(text);
                    string textToAppend = commands[1];
                    sb.Append(textToAppend);
                    text = sb.ToString();


                }
                else if (command == "2")
                {
                    stackToUndo.Push(text);
                    Stack<char> textToErase = new Stack<char>(text);
                    int numberOfElementsToErase = int.Parse(commands[1]);
                    for (int j = 0; j < numberOfElementsToErase; j++)
                    {
                        textToErase.Pop();
                    }

                    char[] temp = textToErase.ToArray();
                    text = string.Empty;
                    for (int k = temp.Length - 1; k >= 0; k--)
                    {
                        text += temp[k];
                    }

                }
                else if (command == "3")
                {
                    int elementToReturn = int.Parse(commands[1]);
                    Console.WriteLine(text[elementToReturn - 1]);
                }
                else if (command == "4")
                {
                    text = stackToUndo.Pop();
                }

            }

        }
    }
}
