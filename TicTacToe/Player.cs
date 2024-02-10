using System;

namespace TicTacToe
{
    public abstract class Player
    {
        public Player() { }

        public abstract Tuple<int, int> GetChoice(Game game);
    }
}
