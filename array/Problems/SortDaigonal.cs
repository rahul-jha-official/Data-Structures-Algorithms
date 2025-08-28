// LINK - https://leetcode.com/problems/sort-matrix-by-diagonals/description/

public class SortDaigonal 
{
    public int[][] SortMatrix(int[][] grid) 
    {
        for (int i = grid.Length - 2; i > 0; i--)
        {
            SortDiagonal(grid, i, 0);
            SortDiagonal(grid, 0, i);
        }    
        SortDiagonal(grid, 0, 0);
        return grid;                    
    }

    private static void SortDiagonal(int[][] grid, int i, int j)
    {
        var arr = new int[grid.Length - i - j];
        for (int r = i, c = j, index = 0; c < grid.Length && r < grid.Length; c++, r++, index++)
        {
            arr[index] = grid[r][c];
        }

        Array.Sort(arr, j == 0 ? (a, b) => b.CompareTo(a) : (a, b) => a.CompareTo(b));

        for (int index = 0; index < arr.Length; index++)
        {
            grid[i++][j++] = arr[index];
        }
    }
}
