// LINK - https://leetcode.com/problems/minimum-time-to-make-rope-colorful/

public class MinimumTimeToMakeRopeColorful 
{
    public int MinCost(string colors, int[] neededTime) 
    {
        var result = 0;
        var max = neededTime[0];
        var sum = neededTime[0];

        for (int i = 1; i < colors.Length; i++)
        {
            if (colors[i - 1] == colors[i])
            {
                sum += neededTime[i];
                max = Math.Max(max, neededTime[i]);
            }
            else
            {
                result += sum - max;
                sum = neededTime[i];
                max = neededTime[i];
            }
        }        

        result += sum - max;

        return result;
    }
}
