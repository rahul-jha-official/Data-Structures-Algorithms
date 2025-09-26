// LINK - https://leetcode.com/problems/valid-triangle-number/description/

public class ValidTriangleTripletCount
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        var count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue;
            var k = i + 2;
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                while (k < nums.Length && nums[k] < nums[i] + nums[j])
                {
                    k++;
                }
                count += k - j - 1;
            }
        }
        return count;
    }
}
