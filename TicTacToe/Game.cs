using System;

namespace TicTacToe
{
    public class Game
    {
        public Game(int gameSize)
        {
            GameBoard = new int[gameSize, gameSize];
            for (int i = 0; i < gameSize; i++)
            {
                for (int j = 0; j < gameSize; j++)
                {
                    GameBoard[i, j] = 0;
                }
            }
        }

        public int[,] GameBoard { get; private set; }
        public int[] PlayerChoices { get; } = { 0, 2, 1 };
        public int PlayerChoice { get; set; } = 1;
        public int CurrentPlayer { get; set; }

        public void PrintBoard()
        {
            // Print out the game board in a readable format
            Console.Clear();
            Console.WriteLine(
                "  " + String.Join(' ', Enumerable.Range(0, GameBoard.GetLength(0)))
            );

            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if (GameBoard[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (GameBoard[i, j] == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                Console.WriteLine();
            }
        }
        public bool MakeMove(int row, int column)
        {
            if (!IsOccupied(row, column))
            {
                GameBoard[row, column] = CurrentPlayer;
                return true;
            }
            else
            {
                Console.WriteLine("That spot is occupied. Please try again.");
                return false;
            }
        }
        public bool IsWon()
        {
            // Horizontal and vertical
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                if (GameBoard.GetRow(i).IsAllSame())
                {
                    return true;
                }
                else if (GameBoard.GetColumn(i).IsAllSame())
                {
                    return true;
                }
            }

            // Diagonal (\)
            int[] check;
            check = new int[GameBoard.GetLength(0)];
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                check[i] = GameBoard[i, i];
            }
            if (check.IsAllSame())
            {
                return true;
            }

            // Diagonal (/)
            check = new int[GameBoard.GetLength(0)];
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    if ((i + j) == (GameBoard.GetLength(0) - 1))
                    {
                        check[i] = GameBoard[i, j];
                    }
                }
            }
            if (check.IsAllSame())
            {
                return true;
            }

            return false;
        }
        public bool IsDraw()
        {
            int emptySpotsCount = 0;
            foreach (int i in GameBoard)
            {
                if (i == 0)
                {
                    emptySpotsCount++;
                }
            }

            if (emptySpotsCount == 0)
            {
                return true;
            }
            return false;
        }
        private bool IsOccupied(int row, int column)
        {
            return GameBoard[row, column] != 0;
        }
    }
}
