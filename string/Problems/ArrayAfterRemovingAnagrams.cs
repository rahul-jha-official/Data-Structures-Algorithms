// LINK - https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/description/?

public class ArrayAfterRemovingAnagrams 
{
    public IList<string> RemoveAnagrams(string[] words) 
    {
        var res = new List<string>();
        res.Add(words[0]);  // result array
        
        for (int i = 1; i < words.Length; i++) 
        {
            if (!IsAnagram(words[i], words[i - 1])) 
            {
                res.Add(words[i]);
            }
        }
        return res;
    }

    // determine if two words are anagrams
    private static bool IsAnagram(string word1, string word2) 
    {
        if (word1.Length != word2.Length) return false;
        if (word1.Equals(word2)) return true;

        var freq = new int[26];
        
        foreach (var ch in word1) 
        {
            freq[ch - 'a']++;
        }

        foreach (var ch in word2) 
        {
            freq[ch - 'a']--;
        }

        foreach (var x in freq) 
        {
            if (x != 0) 
            {
                return false;
            }
        }

        return true;
    }
}
