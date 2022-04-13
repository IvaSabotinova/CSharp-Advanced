using System;
using System.Linq;


namespace SetCover
{
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            int numOfSets = int.Parse(Console.ReadLine());
            List<int[]> allSets = new List<int[]>();

            for (int i = 0; i < numOfSets; i++)
            {
                int[] currSet = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                allSets.Add(currSet);

            }

            allSets = ChooseSets(allSets, universe);
            Console.WriteLine($"Sets to take ({allSets.Count}):");
            foreach (int[] set in allSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }

        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> result = new List<int[]>();
            int[] longestSet = sets.OrderByDescending(x => x.Length).First();

            for (int i = 0; i < longestSet.Length; i++)
            {
                universe.Remove(longestSet[i]);
            }
            result.Add(longestSet);
            sets.Remove(longestSet);

            while (universe.Count > 0)
            {
                int[] biggestCoincidence = sets.OrderByDescending(x => x.Count(x => universe.Contains(x))).First();
                foreach (int item in biggestCoincidence)
                {
                    universe.Remove(item);
                }

                sets.Remove(biggestCoincidence);
                result.Add(biggestCoincidence);

            }

            return result;
        }
    }
}

