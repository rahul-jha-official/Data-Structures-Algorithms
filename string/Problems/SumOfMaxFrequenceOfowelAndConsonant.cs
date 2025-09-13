// LINK - https://leetcode.com/problems/find-most-frequent-vowel-and-consonant/description/

public class SumOfMaxFrequenceOfowelAndConsonant
{
    public int MaxFreqSum(string s) 
    {
        var freq = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
        }
        var v = 0;
        var c = 0;
        for (int i = 0; i < 26; i++)
        {
            if (i == 0 || i == 4 || i == 8 || i == 14 || i == 20)
            {
                v = Math.Max(v, freq[i]);
            }
            else
            {
                c = Math.Max(c, freq[i]);
            }
        }
        return v + c;
    }
}
