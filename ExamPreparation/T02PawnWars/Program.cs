using System;




namespace T02PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {

            string[,] matrixChessBoard =
            {
                {"a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"},
                {"a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7"},
                {"a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6"},
                {"a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5"},
                {"a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4"},
                {"a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3"},
                {"a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2"},
                {"a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1"}

            };

            char[,] matrix = new char[8, 8];
            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;
            for (int i = 0; i < 8; i++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = currRow[j];
                    if (matrix[i, j] == 'w')
                    {
                        whitePawnRow = i;
                        whitePawnCol = j;
                    }

                    if (matrix[i, j] == 'b')
                    {
                        blackPawnRow = i;
                        blackPawnCol = j;
                    }
                }
            }

            while (true)
            {

                if ((blackPawnRow == whitePawnRow - 1 && blackPawnCol == whitePawnCol - 1) ||
                    (blackPawnRow == whitePawnRow - 1 && blackPawnCol == whitePawnCol + 1))
                {
                    Console.WriteLine($"Game over! White capture on {matrixChessBoard[blackPawnRow, blackPawnCol]}.");
                    return;

                }

                matrix[whitePawnRow, whitePawnCol] = '-';

                whitePawnRow -= 1;
                matrix[whitePawnRow, whitePawnCol] = 'w';
                if (whitePawnRow == 0)
                {

                    Console.WriteLine(
                        $"Game over! White pawn is promoted to a queen at {matrixChessBoard[whitePawnRow, whitePawnCol]}.");
                    return;
                }

                if ((whitePawnRow == blackPawnRow + 1 && whitePawnCol == blackPawnCol - 1) ||
                    (whitePawnRow == blackPawnRow + 1 && whitePawnCol == blackPawnCol + 1))
                {
                    Console.WriteLine($"Game over! Black capture on {matrixChessBoard[whitePawnRow, whitePawnCol]}.");
                    return;
                }

                matrix[blackPawnRow, blackPawnCol] = '-';
                blackPawnRow += 1;
                matrix[blackPawnRow, blackPawnCol] = 'b';
                if (blackPawnRow == 7)
                {

                    Console.WriteLine(
                        $"Game over! Black pawn is promoted to a queen at {matrixChessBoard[blackPawnRow, blackPawnCol]}.");
                    Environment.Exit(0);
                }

            }

        }
    }
}
    


    



