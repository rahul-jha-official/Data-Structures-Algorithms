// LINK - https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/

public class CountOddNumbersInAnIntervalRange 
{
    public int CountOdds(int low, int high) 
    {
        return (high - low) / 2 + ((low % 2 != 0 || high % 2 != 0) ? 1 : 0);        
    }
}
