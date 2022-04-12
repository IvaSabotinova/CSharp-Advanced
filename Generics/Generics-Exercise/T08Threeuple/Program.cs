using System;

namespace T08Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddressTown = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstLastName = nameAddressTown[0] + " " + nameAddressTown[1];
            string address = nameAddressTown[2];
            string town = (string.Join(" ", nameAddressTown[3..^0]));
            Threeuple<string, string, string> outputOne = new Threeuple<string, string, string>();
            outputOne.FirstItem = firstLastName;
            outputOne.SecondItem = address;
            outputOne.ThirdItem = town;


            string[] nameQntyBoolean = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = nameQntyBoolean[0];
            int quantity = int.Parse(nameQntyBoolean[1]);
            bool isDrunk = nameQntyBoolean[2] == "drunk";
            Threeuple<string, int, string> outputTwo = new Threeuple<string, int, string>();
            outputTwo.FirstItem = name;
            outputTwo.SecondItem = quantity;
            outputTwo.ThirdItem = isDrunk.ToString();


            string[] nameBalanceBank = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string _name = nameBalanceBank[0];
            double bankAccBalance = double.Parse(nameBalanceBank[1]);
            string bank = nameBalanceBank[2];
            Threeuple<string, double, string> outputThree = new Threeuple<string, double, string>();
            outputThree.FirstItem = _name;
            outputThree.SecondItem = bankAccBalance;
            outputThree.ThirdItem = bank;

            Console.WriteLine(outputOne.ToString());
            Console.WriteLine(outputTwo.ToString());
            Console.WriteLine(outputThree.ToString());
        }
    }
}
