// See https://aka.ms/new-console-template for more information
using WordSearchDfs;

char[][] board = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];


var result = WordSearchService.Exist(board, "ABCCED");
Console.WriteLine(result); // True