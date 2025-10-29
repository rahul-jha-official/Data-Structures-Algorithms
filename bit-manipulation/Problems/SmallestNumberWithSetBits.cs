// LINK - https://leetcode.com/problems/smallest-number-with-all-set-bits/description/

public class SmallestNumberWithSetBits 
{
    public int SmallestNumber(int n) 
    {
        var result = 1;
        var shift = 0;
        while (n > 0) 
        {
            result = result | (1 << shift++);
            n >>= 1;
        }       
        return result;
    }
}
