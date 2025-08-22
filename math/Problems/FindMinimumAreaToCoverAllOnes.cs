// LINK - https://leetcode.com/problems/find-the-minimum-area-to-cover-all-ones-i/description/

public class FindMinimumAreaToCoverAllOnes 
{
    public int MinimumArea(int[][] grid) 
    {
        var min_i = 1001;
        var max_i = 0;
        var min_j = 1001;
        var max_j = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    min_i = Math.Min(min_i, i);
                    max_i = Math.Max(max_i, i);  
                    min_j = Math.Min(min_j, j);
                    max_j = Math.Max(max_j, j);              
                }
            }
        }

        return (max_i - min_i + 1) * (max_j - min_j + 1);   
    }
}
