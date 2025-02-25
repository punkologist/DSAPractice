    int[][] grid = new int[4][];
    grid[0] = new int[] { 1, 1, 1, 1, 0 };
    grid[1] = new int[] { 1, 1, 0, 1, 0 };
    grid[2] = new int[] { 1, 0, 1, 0, 0 };
    grid[3] = new int[] { 0, 0, 0, 1, 1 };



var result = findIslands(grid);
Console.WriteLine(result); // True


int findIslands(int[][] grid)
{
    int islands = 0;
    var rows = grid.Length;
    var columns = grid[0].Length;
    var visited = new bool[rows, columns];

    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == 1 && !visited[i,j])
            {
                bfs(grid, i, j, visited);
                islands++;
            }
        }
    }

    return islands;
}

void bfs(int[][] grid, int i, int j, bool[,] visited)
{
    visited[i,j] = true;
    var queue = new Queue<(int, int)>();
    queue.Enqueue((i, j));

    while(queue.Any()){
        var (row,column)= queue.Dequeue();
        if (row + 1 < grid.Length && grid[row + 1][column] == 1 && !visited[row + 1, column])
        {
            visited[row + 1, column] = true;
            queue.Enqueue((row + 1, column));
        }
        if(row - 1 >= 0 && grid[row - 1][column] == 1 && !visited[row - 1, column])
        {
            visited[row - 1, column] = true;
            queue.Enqueue((row - 1, column));
        }
        if(column + 1 < grid[0].Length && grid[row][column + 1] == 1 && !visited[row, column + 1])
        {
            visited[row, column + 1] = true;
            queue.Enqueue((row, column + 1));
        }
        if(column - 1 >= 0 && grid[row][column - 1] == 1 && !visited[row, column - 1])
        {
            visited[row, column - 1] = true;
            queue.Enqueue((row, column - 1));
        }
    }


    

}

