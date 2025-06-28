// LINK - https://leetcode.com/problems/search-in-rotated-sorted-array/description/

public class SearchInRotatedSortedArray 
{
    public int Search(int[] nums, int target)
    {
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (nums[mid] == target) return mid;
            if (nums[low] <= nums[mid])
            {
                if (target >= nums[low] && target <= nums[mid]) high = mid - 1;
                else low = mid + 1;
            }
            else
            {
                if (target >= nums[mid] && target <= nums[high]) low = mid + 1;
                else high = mid - 1;
            }
        }
        return -1;
    }
}
