// LINK - https://leetcode.com/problems/unique-length-3-palindromic-subsequences/description

public class UniqueLength3PalindromicSubsequence 
{
    public int CountPalindromicSubsequence(string s) 
    {
        var freq = new int[26];
        var low = 0;
        var result = 0;

        foreach (char ch in s)
        {
            freq[ch - 'a']++;
        }

        while (low < s.Length)
        {
            if (freq[s[low] - 'a'] <= 1)
            {
                low++;
                continue;
            }
            
            var high = s.Length - 1;
            
            while (high > low && s[high] != s[low])
            {
                high--;
            }

            if (high > low)
            {
                var flags = new bool[26];
                for (int i = low + 1; i < high; i++)
                {
                    if (!flags[s[i] - 'a'])
                    {
                        flags[s[i] - 'a'] = true;
                        result++;
                    }
                }
            }
            freq[s[low] - 'a'] = -1;
            low++;
        }
        return result;
    }
}
