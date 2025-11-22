// LINK - https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/

public class MinimumOperationsToMakeAllElementDivisibleByThree 
{
    public int MinimumOperations(int[] nums) 
    {
        var ops = 0;
        foreach (var num in nums)
        {
            if (num % 3 != 0) ops++;
        }        
        return ops;
    }
}
