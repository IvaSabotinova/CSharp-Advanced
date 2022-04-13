using System;

using System.Linq;

namespace T0SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfLives = int.Parse(Console.ReadLine());
            int numCastleRows = int.Parse(Console.ReadLine());

            char[][] maze = new char[numCastleRows][];
            for (int i = 0; i < numCastleRows; i++)
            {
                maze[i] = Console.ReadLine().ToCharArray();
            }

            int MarioRow = 0;
            int MarioCol = 0;
            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] == 'M')
                    {
                        MarioRow = i;
                        MarioCol = j;
                        break;
                    }
                }
            }

            while (true)
            {
                char[] dirBowserCoordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                string marioDirection = dirBowserCoordinates[0].ToString();
                int bowserRow = int.Parse(dirBowserCoordinates[1].ToString());
                int bowserCol = int.Parse(dirBowserCoordinates[2].ToString());
                int marioOldRow = MarioRow;
                int marioOldCol = MarioCol;
                maze[bowserRow][bowserCol] = 'B';

                if (marioDirection == "W")
                {
                    MarioRow -= 1;

                }
                else if (marioDirection == "S")
                {
                    MarioRow += 1;
                }
                else if (marioDirection == "A")
                {
                    MarioCol -= 1;
                }
                else if (marioDirection == "D")
                {
                    MarioCol += 1;
                }
                numOfLives--;
                maze[marioOldRow][marioOldCol] = '-';

                if (!IsWithinMaze(MarioRow, MarioCol, maze))
                {
                    MarioRow = marioOldRow;
                    MarioCol = marioOldCol;
                    maze[MarioRow][MarioCol] = 'M';
                }
                else if (IsWithinMaze(MarioRow, MarioCol, maze))
                {

                    if (maze[MarioRow][MarioCol] == 'B')
                    {
                        numOfLives -= 2;
                    }
                    else if (maze[MarioRow][MarioCol] == 'P')
                    {

                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {numOfLives}");
                        maze[MarioRow][MarioCol] = '-';
                        PrintMaze(maze);
                        return;
                    }
                    else
                    {
                        maze[MarioRow][MarioCol] = 'M';
                    }
                    
                }

                if (numOfLives <= 0)
                {
                    maze[MarioRow][MarioCol] = 'X';
                    Console.WriteLine($"Mario died at {MarioRow};{MarioCol}.");
                    PrintMaze(maze);
                    return;
                }

            }

        }

        public static bool IsWithinMaze(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        public static void PrintMaze(char[][] maze)
        {
            for (int i = 0; i < maze.Length; i++)
            {
                Console.WriteLine(string.Join("", maze[i]));
            }
        }
    }
}
