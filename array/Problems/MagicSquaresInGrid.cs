// LINK - https://leetcode.com/problems/magic-squares-in-grid/description/

public class MagicSquaresInGrid
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        var count = 0;

        for (var i = 0; i <= grid.Length - 3; i++)
        {
            for (var j = 0; j <= grid[0].Length - 3; j++)
            {
                if (IsMagic(grid, i, j))
                {
                    count++;
                }                    
            }
        }

        return count;
    }

    private bool IsMagic(int[][] g, int r, int c)
    {
        // Center must be 5
        if (g[r + 1][c + 1] != 5)
        {
            return false;
        }            

        // Check digits 1..9 uniqueness
        var seen = new bool[10];
        for (var i = r; i < r + 3; i++)
        {
            for (var j = c; j < c + 3; j++)
            {
                var current = g[i][j];
                if (current < 1 || current > 9 || seen[current])
                {
                    return false;
                }
                seen[current] = true;
            }
        }

        // Rows
        for (var i = 0; i < 3; i++)
        {
            if (g[r + i][c] + g[r + i][c + 1] + g[r + i][c + 2] != 15)
            {
                return false;
            }
        }

        // Columns
        for (var j = 0; j < 3; j++)
        {
            if (g[r][c + j] + g[r + 1][c + j] + g[r + 2][c + j] != 15)
            {
                return false;
            }
        }

        // Diagonals
        if (g[r][c] + g[r + 1][c + 1] + g[r + 2][c + 2] != 15)
            return false;

        if (g[r][c + 2] + g[r + 1][c + 1] + g[r + 2][c] != 15)
            return false;

        return true;
    }
}
