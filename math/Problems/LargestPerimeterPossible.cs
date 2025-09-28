// LINK - https://leetcode.com/problems/largest-perimeter-triangle/description/

public class LargestPerimeterPossible 
{
    public int LargestPerimeter(int[] nums) 
    {
        Array.Sort(nums);
        var perimeter = 0;
        for (int i = 2; i < nums.Length; i++)
        {
            if (IsTriangle(nums[i - 1], nums[i - 2], nums[i]))
            {
                perimeter = Math.Max(perimeter, nums[i - 1] + nums[i - 2] + nums[i]);
            }
        }    
        return perimeter;    
    }
    private static bool IsTriangle(int a, int b, int c)
    {
        return (a + b) > c && (a + c) > b && (b + c) > a;
    }
}
