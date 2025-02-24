using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordSearchDfs
{
    public class WordSearchService
    {
        public static bool Exist(char[][] board, string word)
        {
            var rows = board.Length;
            var columns = board[0].Length;

            var used = new bool[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (dfs(board, word, i, j, 0, used, rows, columns))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private static bool dfs(char[][] board, string word, int row, int column, int index, bool[,] used, int rows, int columns)
        {


            // the current location does not equal the index of the word or we are looking at a location we have already seen
            if (board[row][column] != word[index] || used[row, column]) return false;

            // we can't reuse the same one we have already found
            used[row, column] = true;
            // if we get here then we have found the char for the current index, increment index and continue the search
            index++;
            if (index == word.Length) return true;

            // traverse
            if ((row + 1 < rows && dfs(board, word, row + 1, column, index, used, rows, columns))
            || (row - 1 >= 0 && dfs(board, word, row - 1, column, index, used, rows, columns))
            || (column + 1 < columns && dfs(board, word, row, column + 1, index, used, rows, columns))
            || (column - 1 >= 0 && dfs(board, word, row, column - 1, index, used, rows, columns))
            )
            {
                return true;
            }

            // if we get here then we have not found the word, so we need to backtrack
            used[row, column] = false;

            return false;
        }
    }
}