//LINK - https://leetcode.com/problems/contains-duplicate/description/

//Approach 1 - Using LINQ
public class ContainsDuplicateElements
{
    public bool ContainsDuplicate(int[] nums)
    {
        return nums.Distinct().Count() != nums.Length;
    }
}

//Approach 2 - Using HashSet
public class ContainsDuplicateElements
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();
        foreach (int n in nums)
        {
            bool isDuplicateNumber = !set.Add(n);
            if (isDuplicateNumber) return true;
        }
        return false;
    }
}

//Approach 3 - Sorting the Array
public class ContainsDuplicateElements
{
    public bool ContainsDuplicate(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return true;
            }
        }
        return false;
    }
}
