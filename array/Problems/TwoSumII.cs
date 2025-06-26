// LINK - https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/


public class TwoSumII 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + nums[right];
            if (sum == target) return new int[] {left + 1,right + 1};
            else if (sum > target) right--;
            else left++;
        }
        return new int[0];
    }
}
