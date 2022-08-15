using System;
using System.Collections.Generic;
using System.Linq;

namespace T04HitList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> allNames_Keys_Values = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] key_Values = input.Split(new char[] { '=' });
                string currentName = key_Values[0];

                if (!allNames_Keys_Values.ContainsKey(currentName))
                {
                    allNames_Keys_Values.Add(currentName, new Dictionary<string, string>());
                }


                string[] data = key_Values[1].Split(new char[] { ';' });

                for (int i = 0; i < data.Length; i++)
                {
                    string[] tokens = data[i].Split(new char[] { ':' });
                    string key = tokens[0];
                    string value = tokens[1];

                    if (!allNames_Keys_Values[currentName].ContainsKey(key))
                    {
                        allNames_Keys_Values[currentName].Add(key, null);
                    }
                    allNames_Keys_Values[currentName][key] = value;

                }
            }

            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string nameToPrint = command[1];

            allNames_Keys_Values = allNames_Keys_Values.Where(x => x.Key == nameToPrint).ToDictionary(k => k.Key, v => v.Value);

            int personInfoIndex = 0;

            foreach (KeyValuePair<string, Dictionary<string, string>> personName in allNames_Keys_Values)
            {
                Console.WriteLine($"Info on {personName.Key}:");
                foreach (KeyValuePair<string, string> person in personName.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"---{person.Key}: {person.Value}");
                    personInfoIndex += person.Key.Length + person.Value.Length;
                }
            }
            Console.WriteLine($"Info index: {personInfoIndex}");
            string result = personInfoIndex >= targetInfoIndex ? "Proceed" : $"Need {targetInfoIndex - personInfoIndex} more info.";
            Console.WriteLine(result);

        }

    }
}

