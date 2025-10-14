// LINK - https://leetcode.com/problems/adjacent-increasing-subarrays-detection-i/description/

public class AdjacentIncreasingSubarraysDetection 
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k) 
    {
        if (k == 1)
        {
            return true;
        }
        
        var count = 1;
        for (var i = 1; i < nums.Count - k; i++)
        {
            if (nums[i] > nums[i - 1] && nums[i + k] > nums[i + k - 1])
            {
                count++;
            }
            else 
            {
                count = 1; 
            }

            if (count == k)
            {
                return true;
            }
        }
        return false;        
    }
}
