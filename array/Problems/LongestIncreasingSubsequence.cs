// LINK - https://leetcode.com/problems/longest-increasing-subsequence/

public class LongestIncreasingSubsequence 
{
    public int LengthOfLIS(int[] nums) 
    {
        List<int> cache = new List<int>();
        cache.Add(nums[0]);
        
        for (int i = 1; i < nums.Length; i++) 
        {
            var current = nums[i];
            if (current > cache[^1]) 
            {
                cache.Add(current);
            } 
            else if (current == cache[^1])
            {
                continue;
            }
            else 
            {
                var index = BinarySearch(cache, current);
                cache[index] = current;
            }
        }
        return cache.Count;
    }
    
    private static int BinarySearch(IList<int> cache, int num) 
    {
        var left = 0;
        var right = cache.Count - 1;
        
        while (left < right) 
        {
            var mid = (left + right) / 2;
            if (cache[mid] == num)
                return mid;
            if (cache[mid] < num)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}
