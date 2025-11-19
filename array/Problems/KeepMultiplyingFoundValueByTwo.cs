// Link - https://leetcode.com/problems/keep-multiplying-found-values-by-two/description/

public class KeepMultiplyingFoundValueByTwo 
{
    public int FindFinalValue(int[] nums, int original) 
    {
        Array.Sort(nums);
        while (Find(nums, original))
        {
            original = 2 * original;
        }
        return original;        
    }

    private static bool Find(int[] nums, int n)
    {
        return BinarySearch(nums, 0, nums.Length - 1, n);
    }
    
    private static bool BinarySearch(int[] nums, int l, int h, int n)
    {
        if (l > h) return false;
        var m = (h - l) / 2 + l;
        if (nums[m] == n) return true;
        else if (nums[m] > n) return BinarySearch(nums, l, m - 1, n);
        else return BinarySearch(nums, m + 1, h, n);        
    }
}
