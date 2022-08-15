using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Т03CryptoBlockchain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());

            string pattern = @"{[^\[{]*?[0-9]{3,}[^\]}]*?}|\[[^\[{]*?[0-9]{3,}[^\]}]*?\]";

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numOfRows; i++)
            {
                text.Append(Console.ReadLine());
            }


            MatchCollection matches = Regex.Matches(text.ToString(), pattern);
                        
          

            StringBuilder finalText = new StringBuilder();

            foreach (Match match in matches)
            {
                Match digits = Regex.Match(match.Value, "[0-9]{3,}");

                if (digits.Success && digits.Value.Length % 3 == 0)
                {
                   
                    for (int i = 0; i < digits.Value.Length; i += 3)
                    {

                        int currentNumber = int.Parse(digits.Value[i] + "" + digits.Value[i+1] + "" + digits.Value[i+2]);

                        finalText.Append(Convert.ToChar(currentNumber - match.Value.Length));
                    }


                }
            }

            Console.WriteLine(finalText);
          
                 
        }
    }
}
