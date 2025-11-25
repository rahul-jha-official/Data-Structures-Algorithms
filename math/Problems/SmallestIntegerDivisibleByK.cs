// LINK - https://leetcode.com/problems/smallest-integer-divisible-by-k/

public class SmallestIntegerDivisibleByK 
{
    public int SmallestRepunitDivByK(int k) 
    {
        var remainder = 0;
        for (var len = 1; len <= k; len++)
        {
            remainder = (remainder * 10 + 1) % k;
            if (remainder == 0)
            {
                return len;
            }
        }        
        return -1;
    }
}
