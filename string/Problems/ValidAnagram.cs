// LINK - https://leetcode.com/problems/valid-anagram/description/

// Approach 1 - Sort the string 
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        return s.Sort().Equals(t.Sort());
    }
}

public static class MyExtensions
{
    public static string Sort(this string s)
    {
        var sArray = s.ToCharArray();
        Array.Sort(sArray);
        return new string(sArray);
    }
}

// Approach 2 - Use an Array to maintain frequency
public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        var frequencies = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            int i1 = s[i] - 'a', i2 = t[i] - 'a';
            frequencies[i1]++;
            frequencies[i2]--;
        }

        foreach (var frequencie in frequencies)
        {
            if (frequencie != 0) return false;
        }

        return true;
    }
}
