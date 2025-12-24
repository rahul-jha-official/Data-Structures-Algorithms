// LINK - https://leetcode.com/problems/apple-redistribution-into-boxes/description/

public class AppleRedistributionIntoBoxes
{
    public int MinimumBoxes(int[] apple, int[] capacity) 
    {
        Array.Sort(capacity);
        var sum = 0;
        foreach (var a in apple)     
        {
            sum += a;
        }  
        var i  = capacity.Length - 1;
        for (; i >= 0; i--)
        {
            sum = Math.Max(0, sum - capacity[i]);
            if (sum == 0) break; 
        }
        return capacity.Length - i;
    }
}
