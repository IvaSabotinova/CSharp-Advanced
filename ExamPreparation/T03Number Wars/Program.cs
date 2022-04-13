using System;
using System.Collections.Generic;
using System.Linq;


namespace T03Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] firstPlayer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondPlayer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayerCards = new Queue<string>(firstPlayer);
            Queue<string> secondPlayerCards = new Queue<string>(secondPlayer);
            int countOfTurns = 0;

            while (countOfTurns < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                
                int firstPlayerCard =
                    int.Parse(firstPlayerCards.Peek().Substring(0, firstPlayerCards.Peek().Length - 1));
                int secondPlayerCard =
                    int.Parse(secondPlayerCards.Peek().Substring(0, secondPlayerCards.Peek().Length - 1));

                countOfTurns++;

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                    firstPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                }
                else if (firstPlayerCard < secondPlayerCard)
                {
                    secondPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                    secondPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                }
                else
                {
                    bool isFlag = false;
                    Queue<string> tempDeckOfCards = new Queue<string>();
                    tempDeckOfCards.Enqueue(firstPlayerCards.Dequeue());
                    tempDeckOfCards.Enqueue(secondPlayerCards.Dequeue());
                    while (true)
                    {
                        if (firstPlayerCards.Count < 3 || secondPlayerCards.Count < 3)
                        {
                            isFlag = true;
                            break;
                        }

                        int sumOfLettersFirstPlayer = 0;
                        int sumOfLettersSecondPlayer = 0;
                        
                        for (int i = 0; i < 3; i++)
                        {
                            sumOfLettersFirstPlayer += firstPlayerCards.Peek().ToLower().Last() - 96;
                            sumOfLettersSecondPlayer += secondPlayerCards.Peek().ToLower().Last() - 96;
                            tempDeckOfCards.Enqueue(firstPlayerCards.Dequeue());
                            tempDeckOfCards.Enqueue(secondPlayerCards.Dequeue());
                        }

                        if (sumOfLettersFirstPlayer > sumOfLettersSecondPlayer)
                        {
                            foreach (string card in tempDeckOfCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1)))
                                .ThenByDescending(x => x.ToLower().Last() - 96))
                            {
                                firstPlayerCards.Enqueue(card);
                            }

                            break;
                        }

                        if (sumOfLettersFirstPlayer < sumOfLettersSecondPlayer)
                        {
                            foreach (string card in tempDeckOfCards.OrderByDescending(x => int.Parse(x.Substring(0, x.Length - 1)))
                                .ThenByDescending(x => x.ToLower().Last() - 96))
                            {
                                secondPlayerCards.Enqueue(card);
                            }

                            break;
                        }
                        
                    }

                    if (isFlag)
                    {
                        break;
                    }

                }
            }

            string result = WinnerOrDrawResult(firstPlayerCards, secondPlayerCards);
            Console.WriteLine($"{result} after {countOfTurns} turns");

        }
        public static string WinnerOrDrawResult(Queue<string> firstPlayer, Queue<string> secondPlayer)
        {
            if (firstPlayer.Count > secondPlayer.Count)
            {
                return "First player wins";
            }

            if (secondPlayer.Count > firstPlayer.Count)
            {
                return "Second player wins";
            }

            return "Draw";
        }
        
    }
}

