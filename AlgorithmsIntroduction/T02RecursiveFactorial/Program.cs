using System;

namespace T02RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int result = Factoriel(number);

            Console.WriteLine(result);
            
        }

        public static int Factoriel(int num)
        {
            if (num == 1)
            {
                return 1;
            }

            int result = num * Factoriel(num - 1);
            return result;

        }
    }
}
