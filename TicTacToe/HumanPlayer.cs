using System;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        public HumanPlayer() { }

        public override Tuple<int, int> GetChoice(Game game)
        {
            // Receive user input in 'x y' format and split it to row and column number.
            Console.Write("Choose position ([row] [column]): ");
            string? choice = Console.ReadLine();
            string[] splitedChoice = new string[2];
            if (choice != null)
            {
                splitedChoice = choice.Split(' ');
            }
            int[] myInts = Array.ConvertAll(splitedChoice, int.Parse);
            Tuple<int, int> moveChoice = Tuple.Create(myInts[0], myInts[1]);

            return moveChoice;
        }
    }
}
