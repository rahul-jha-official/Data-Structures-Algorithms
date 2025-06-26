// LINK: https://leetcode.com/problems/valid-palindrome/description/

using System.Runtime.CompilerServices;
public class Solution 
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public bool IsPalindrome(string s) 
    {
        var sbr = new StringBuilder();
        var i = 0;
        foreach (var c in s) sbr.AppendIfAlphanumeric(c);
        for (; i < sbr.Length / 2 && sbr[i] == sbr[sbr.Length - 1 - i]; i++);
        return i == (sbr.Length / 2);
    }
}

public static class Extensions
{
    public static void AppendIfAlphanumeric(this StringBuilder sb, char ch)
    {
        if ((ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z'))
        {
            sb.Append(ch);
            return;
        }

        if (ch >= 'A' && ch <= 'Z')
        {
            sb.Append((char)(ch + 32));
        }
    }
}
