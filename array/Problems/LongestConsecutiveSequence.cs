// LINK - https://leetcode.com/problems/longest-consecutive-sequence/description/

// Approach 1 - Use Sorted Set
public class LongestConsecutiveSequence 
{
    public int LongestConsecutive(int[] nums) 
    {
        if (nums.Length == 0) return 0;
        
        var set = new SortedSet<int>(nums);
        var result = 1;

        var init = set.First();
        int current = 1;
        
        foreach (int i in set.Skip(1))
        {
            if (init + 1 == i)
            {
                current++;
            }
            else
            {
                result = Math.Max(result, current);
                current = 1;
            }
            init = i;
        }

        result = Math.Max(result, current);

        return result;
    }
}
