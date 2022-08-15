using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T03JediCode_X
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfInputLines = int.Parse(Console.ReadLine());

            StringBuilder input = new StringBuilder();

            for (int i = 0; i < numOfInputLines; i++)
            {
               input.Append(Console.ReadLine());
            }

            string prefixJediNames = Console.ReadLine();
            string prefixJediMessages = Console.ReadLine();

            string patternJediNames = $"{prefixJediNames}[A-Za-z]{{{prefixJediNames.Length}}}(?![A-Za-z])";
             string patternJediMessages =$"{prefixJediMessages}[A-Za-z0-9]{{{prefixJediMessages.Length}}}(?![A-Za-z0-9])";
        
            Queue<string> JediNames = new Queue<string>();
            Queue<string> JediMessages = new Queue<string>();


            MatchCollection regex_JediNames = Regex.Matches(input.ToString(), patternJediNames);
            foreach (Match JediName in regex_JediNames)
            {
                JediNames.Enqueue(JediName.ToString().Substring(prefixJediNames.Length));
            }

            MatchCollection regex_JediMessages = Regex.Matches(input.ToString(), patternJediMessages);
            foreach (Match JediMessage in regex_JediMessages)
            {
                JediMessages.Enqueue(JediMessage.ToString().Substring(prefixJediMessages.Length));
            }


            int[] messagesIndices = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < messagesIndices.Length; i++)
            {
                if (messagesIndices[i] > 0 && messagesIndices[i] <= JediMessages.Count && JediNames.Count > 0)
                {
                    output.AppendLine($"{JediNames.Dequeue()} - {JediMessages.ElementAt(messagesIndices[i] - 1)}");
                }

            }
            Console.WriteLine(output);
        }
    }
}
