using System;
using System.Collections.Generic;
using System.Linq;


namespace T01FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, char[]> allWordsAndLetters = new Dictionary<string, char[]>()
            {
                {"pear", "pear".ToCharArray()},
                {"flour", "flour".ToCharArray()},
                {"pork", "pork".ToCharArray()},
                {"olive", "olive".ToCharArray()},

            };

            char[] vowelsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                .ToArray();
            char[] consonantsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                .ToArray();
            Queue<char> vowels = new Queue<char>(vowelsInput);
            Stack<char> consonants = new Stack<char>(consonantsInput);

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonant = consonants.Pop();

                allWordsAndLetters["pear"] = allWordsAndLetters["pear"].Where(x => x != currVowel).Where(x => x != currConsonant).ToArray();

                allWordsAndLetters["flour"] = allWordsAndLetters["flour"].Where(x => x != currVowel).Where(x => x != currConsonant).ToArray();

                allWordsAndLetters["pork"] = allWordsAndLetters["pork"].Where(x => x != currVowel).Where(x => x != currConsonant).ToArray();

                allWordsAndLetters["olive"] = allWordsAndLetters["olive"].Where(x => x != currVowel).Where(x => x != currConsonant).ToArray();

                vowels.Enqueue(currVowel);

            }

            int numOfFoundWords = allWordsAndLetters.Count(x => x.Value.Length == 0);

            Console.WriteLine($"Words found: {numOfFoundWords}");
            foreach (KeyValuePair<string, char[]> word in allWordsAndLetters.Where(x => x.Value.Length == 0))
            {
                Console.WriteLine(word.Key);
            }

        }
    }
}
