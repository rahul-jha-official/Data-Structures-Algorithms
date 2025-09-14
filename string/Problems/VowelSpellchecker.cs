// LINK - https://leetcode.com/problems/vowel-spellchecker/description/

public class VowelSpellchecker
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var isVowel = (char ch) => ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' || ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U';
        var removeVowels = (string word) =>
        {
            var arr = word.ToCharArray();
            for (var i = 0; i < arr.Length; i++)
            {
                if (isVowel(arr[i]))
                {
                    arr[i] = '#';
                }
            }
            return new string(arr);
        };

        var perfect = new HashSet<string>(wordlist.Length);
        var caseInsensitive = new Dictionary<string, string>(wordlist.Length);
        var vowelError = new Dictionary<string, string>(wordlist.Length);
        foreach (var word in wordlist)
        {
            perfect.Add(word);
            caseInsensitive.TryAdd(word.ToLower(), word);
            vowelError.TryAdd(removeVowels(word.ToLower()), word);
        }

        var result = new string[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            if (perfect.Contains(query))
            {
                result[i] = query;
            }
            else if (caseInsensitive.ContainsKey(query.ToLower()))
            {
                result[i] = caseInsensitive[query.ToLower()];
            }
            else if (vowelError.ContainsKey(removeVowels(query.ToLower())))
            {
                result[i] = vowelError[removeVowels(query.ToLower())];
            }
            else
            {
                result[i] = string.Empty;
            }
        }
        return result;
    }
}
