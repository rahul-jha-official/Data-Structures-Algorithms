// LINK - https://leetcode.com/problems/delete-columns-to-make-sorted/description/

public class DeleteColumnsToMakeSorted 
{
    public int MinDeletionSize(string[] strs) 
    {
        var result = 0;
        for (var c = 0; c < strs[0].Length; c++)
        {
            for (var r = 1; r < strs.Length; r++) 
            {
                if (strs[r][c] < strs[r - 1][c])
                {
                    result++;
                    break;
                }
            }
        }        
        return result;
    }
}
