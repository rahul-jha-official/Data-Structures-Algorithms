// LINK - https://leetcode.com/problems/count-elements-with-maximum-frequency/description/

public class CountElementsWithMaxFrequency 
{
    public int MaxFrequencyElements(int[] nums) 
    {
        var freq = new int[101];
        foreach (var num in nums)
        {
            freq[num]++;
        }        
        var max = 0;
        for (int i = 1; i <= 100; i++)
        {
            max = Math.Max(max, freq[i]);
        }

        var count = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (freq[i] == max)
            {
                count += freq[i];
            }
        }

        return count;
    }
}
