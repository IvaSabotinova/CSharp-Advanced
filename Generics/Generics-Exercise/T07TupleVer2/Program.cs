using System;

namespace T07TupleVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameTown = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstLastName = nameTown[0] + " " + nameTown[1];
            string town = nameTown[2];
            MyTuple<string, string> outputOne = new MyTuple<string, string>();
            outputOne.FirstItem = firstLastName;
            outputOne.SecondItem = town;
            

            string[] nameQuantity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = nameQuantity[0];
            int quantity = int.Parse(nameQuantity[1]);
            MyTuple<string, int> outputTwo = new MyTuple<string, int>();
            outputTwo.FirstItem = name;
            outputTwo.SecondItem = quantity;
           

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(numbers[0]);
            double num2 = double.Parse(numbers[1]);
            MyTuple<int, double> outputThree = new MyTuple<int, double>();
            outputThree.FirstItem = num1;
            outputThree.SecondItem = num2;
            
            Console.WriteLine(outputOne);
            Console.WriteLine(outputTwo.ToString());
            Console.WriteLine(outputThree.ToString());

        }
    }
}
