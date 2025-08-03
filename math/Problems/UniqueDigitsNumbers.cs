// LINK - https://leetcode.com/problems/count-numbers-with-unique-digits/
// Hint - Permutation
public class UniqueDigitsNumbers
{
    public int CountNumbersWithUniqueDigits(int n) 
    {
        if (n == 0)
        {
            return 1;
        }
        else 
        {
            var result = 10;
            var current = 9;
            for (int i = 2;  i < n + 1; i++) 
            {
                current *= (10 - i + 1);
                result += current;
            }
            return result;
        }        
    }
}
