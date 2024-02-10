using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Play();
                Console.Write("\nWanna play again? (y/n) ");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        static void Play()
        {
            Game game = new Game(3);
            HumanPlayer humanPlayer = new HumanPlayer();

            while (!game.IsWon() && !game.IsDraw())
            {
                game.CurrentPlayer = game.PlayerChoice;

                game.PrintBoard();
                Console.WriteLine("Current player: {0}", game.CurrentPlayer);

                bool played = false;
                do
                {
                    try
                    {
                        // Receive user position choice
                        Tuple<int, int> playerChoice = humanPlayer.GetChoice(game);
                        int rowChoice = playerChoice.Item1;
                        int colChoice = playerChoice.Item2;

                        played = game.MakeMove(
                            rowChoice, colChoice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error: " + ex.Message);
                    }
                } while (!played);

                if (game.IsWon() || game.IsDraw())
                {
                    game.PlayerChoice = 2; // Set PlayerChoice so that the game
                                           // would get started by player 1.
                    game.PrintBoard();

                    if (game.IsWon())
                    {
                        Console.WriteLine("player {0} won", game.CurrentPlayer);
                    }
                    else
                    {
                        Console.WriteLine("It is a draw.");
                    }
                }

                game.PlayerChoice = game.PlayerChoices[game.PlayerChoice];
            }
        }
    }
}
