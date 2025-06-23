// LINK - https://leetcode.com/problems/two-sum/description/
// Approach - Using Dictionary to store element with index 

public class TwoElementSumIndices
{
    public int[] TwoSum(int[] nums, int target)
    {
        var pair = new Dictionary<int, int>()
        {
            {nums[0], 0}
        };

        for (int i = 1; i < nums.Length; i++)
        {
            int secondNumber = target - nums[i];
            if (pair.ContainsKey(secondNumber))
            {
                return [pair[secondNumber], i];
            }
            pair[nums[i]] = i;
        }
        return [];
    }
}
