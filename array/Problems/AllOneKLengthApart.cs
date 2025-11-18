// Link - https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/

public class AllOneKLengthApart 
{
    public bool KLengthApart(int[] nums, int k) 
    {
        var min = int.MaxValue;
        var count = 0;
        var one = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) 
            {
                one = i;
                break;
            }
        }
        for (var i = one + 1; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                min = Math.Min(min, count);
                count = 0;
            }
            else
            {
                count++;
            }
        }
        return min >= k;
    }
}
