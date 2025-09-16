// LINK - https://leetcode.com/problems/replace-non-coprime-numbers-in-array/description/

public class ReplaceNonCoprimesInArray 
{
    public IList<int> ReplaceNonCoprimes(int[] nums) 
    {
        var stack = new List<int>();
        foreach (var num in nums)
        {
            var n = num;
            while (stack.Count > 0)
            {
                var top = stack[^1];
                var gcd = GCD(top, n);
                if (gcd == 1)
                {
                    break;
                } 
                stack.RemoveAt(stack.Count - 1);
                n = (top / gcd) * n;
            }
            stack.Add(n);
        }
        return stack;
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            (b, a)  = (a % b, b);
        }
        return a;
    }
}
