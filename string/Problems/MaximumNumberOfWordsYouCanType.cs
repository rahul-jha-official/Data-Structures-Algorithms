// LINK - https://leetcode.com/problems/maximum-number-of-words-you-can-type/

public class MaximumNumberOfWordsYouCanType 
{
    public int CanBeTypedWords(string text, string brokenLetters) 
    {
        var set = new HashSet<char>(brokenLetters);
        var result = 0;
        foreach (var word in text.Split(' '))
        {
            var flag = true;
            foreach (char ch in word)
            {
                if (set.Contains(ch))
                {
                    flag = false;
                    break;
                }
            }

            if (flag) 
            {
                result++;
            }
        }        
        return result;
    }
}
