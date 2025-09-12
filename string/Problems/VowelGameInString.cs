// LINK - https://leetcode.com/problems/vowels-game-in-a-string/description/

public class VowelGameInString 
{
    public bool DoesAliceWin(string s) 
    {
        HashSet<int> vowels = ['A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'];
        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i])) return true;
        }        
        return false;
    }
}
