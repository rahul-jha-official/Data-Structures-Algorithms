// LINK - https://leetcode.com/problems/sort-vowels-in-a-string/description/

public class SortVowelsInString 
{
    public string SortVowels(string s) 
    {
        var isVowel = (char ch) => {
            ch = char.ToLower(ch);
            return ch == 'a' || ch == 'e' || ch == 'o' || ch == 'i' || ch == 'u';
        };
        var chs = s.ToCharArray();
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < chs.Length; i++)
        {
            if (isVowel(chs[i]))
            {
                dict.Add(i, (int)chs[i]);
            }
        }   

        var sorted = dict.Values.OrderBy(e => e).ToList();
        var index = 0;
        foreach (var k in dict.Keys)
        {
            chs[k] = (char)sorted[index++];
        } 


        return new string(chs);
    }
}
