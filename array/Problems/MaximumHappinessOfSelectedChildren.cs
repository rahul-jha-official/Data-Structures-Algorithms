// LINK - https://leetcode.com/problems/maximize-happiness-of-selected-children/description/

public class MaximumHappinessOfSelectedChildren
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness);
        var result = 0L;
        var count = 0;
        var index = happiness.Length - 1;
        while (k > 0)
        {
            result += (happiness[index] - count) > 0 ? (happiness[index] - count) : 0;
            count++;
            k--;
            index--;
        }
        return result;
    }
}
