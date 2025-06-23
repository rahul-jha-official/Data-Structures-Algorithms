// Approach 1 - Using 2 Arrays
// Using 2 arrays, first for storing prefix product and other for storing postfix product
// Multiplying prefix and postfix array to compute result

public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefix = new int[nums.Length];
        var postfix = new int[nums.Length];
        prefix[0] = postfix[^1] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] * nums[i - 1];
            postfix[^(i + 1)] = postfix[^i] * nums[^i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = prefix[i] * postfix[i];
        }

        return nums;
    }
}

// Approach 2 - Using 2 variable to store prefix and postfix product
public class ProductOfArrayElementExceptSelf {
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefix = 1;
        var postfix = 1;
        var result = new int[nums.Length];
        Array.Fill(result, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] *= prefix;
            result[^(i + 1)] *= postfix;

            prefix *= nums[i];
            postfix *= nums[^(i + 1)];
        }
        return result;
    }
}
