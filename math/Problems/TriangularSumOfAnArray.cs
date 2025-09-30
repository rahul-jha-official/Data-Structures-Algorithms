// LINK - https://leetcode.com/problems/find-triangular-sum-of-an-array/description/

public class TriangularSumOfAnArray 
{
    public int TriangularSum(int[] nums) 
    {
        while (nums.Length > 1)
        {
            var list = new int[nums.Length - 1];
            for (var i = 1; i < nums.Length; i++)
            {
                list[i - 1] = (nums[i] + nums[i - 1]) % 10;
            }
            nums = list;
        }        
        return nums[0];
    }
}
