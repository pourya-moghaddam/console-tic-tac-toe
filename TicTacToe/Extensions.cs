using System;

namespace TicTacToe
{
    public static class Extensions
    {
        public static int[] GetRow(this int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                             .Select(x => matrix[rowNumber, x])
                             .ToArray();
        }
        public static int[] GetColumn(this int[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                             .Select(x => matrix[x, columnNumber])
                             .ToArray();
        }
        public static bool IsAllSame(this int[] items)
        {
            if (items[0] == 0)
            {
                return false;
            }
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i] != items[0])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
