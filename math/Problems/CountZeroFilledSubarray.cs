// LINK - https://leetcode.com/problems/number-of-zero-filled-subarrays/description

public class CountZeroFilledSubarray
{
    public long ZeroFilledSubarray(int[] nums) 
    {
        var result = 0L;
        var i = 0;
        while (i < nums.Length)
        {
            if (nums[i] is 0)
            {
                var counter = 1L;
                while ((i + 1) < nums.Length && nums[i + 1] is 0)
                {
                    counter++;
                    i++;
                }
                
                result += ((counter + 1) * counter) / 2;
            }
            i++;
        }

        return result;     
    }
}
