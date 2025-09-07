// LINK - https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/description/

public class NIntegersSum 
{
    public int[] SumZero(int n) 
    {
        var result = new int[n];
        result[0] = -((n - 1) * n) / 2;
        for (int i = 1; i < n; i++)
        {
            result[i] = i;
        }
        return result;  
    }
}
