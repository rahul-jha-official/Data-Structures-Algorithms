// LINK - https://leetcode.com/problems/group-anagrams/description/

// Approach 1 - Use Sorting
public class GroupingAnagramsTogether
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> pairs = new Dictionary<string, IList<string>>();
        foreach (string str in strs)
        {
            string sorted = str.Sort();
            if (!pairs.ContainsKey(sorted)) pairs.Add(sorted, new List<string>());
            pairs[sorted].Add(str);
        }
        return pairs.Select(e => e.Value).ToList();
    }
}

public static class Extensions
{
    public static string Sort(this string s)
    {
        var chs = s.ToCharArray();
        Array.Sort(chs);
        return string.Join("", chs);
    }
}


// Approach 2 - Use Frequency
public class GroupingAnagramsTogether
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var memo = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var encryptedString = StringEncryption(str);
            if (!memo.ContainsKey(encryptedString))
            {
                memo.Add(encryptedString, new List<string>());
            }
            memo[encryptedString].Add(str);
        }
        return memo.Select(e => e.Value).ToList();
    }

    private static string StringEncryption(string str)
    {
        var frequency = new int[26];
        foreach (var ch in str)
        {
            frequency[ch - 'a']++;
        }
        return string.Join('.', frequency);
    }
}
