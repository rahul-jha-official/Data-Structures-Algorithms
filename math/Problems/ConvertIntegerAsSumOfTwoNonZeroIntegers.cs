// LINK - https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/description

public class ConvertIntegerAsSumOfTwoNonZeroIntegers
{
    public int[] GetNoZeroIntegers(int n) 
    {
        for (int i = n - 1; i >= 1; i--)
        {
            if (IsNonZero(i) && IsNonZero(n - i))
            {
                return [n - i, i];
            }
        }        
        return [];
    }
    private static bool IsNonZero(int n)
    {
        while (n > 0)
        {
            if ((n % 10) == 0)
            {
                return false;
            }
            n /= 10;
        }
        return true;
    }
}

