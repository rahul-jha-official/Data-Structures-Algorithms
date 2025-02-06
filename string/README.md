# String
A string is an object of type String whose value is text. Internally, the text is stored as a sequential read-only collection of Char objects. The Length property of a string represents the number of Char objects it contains, not the number of Unicode characters. String is **immutable** type.

## Characters
- **char** is a keyword that is used to declare a variable which store a character value from the range of +U0000 to U+FFFF.
- The char type keyword is an alias for the .NET System.Char structure type that represents a Unicode UTF-16 character.
- Each character occupies 16 bits (2 Bytes) of memory.
- Some static methods of char
  - char.IsUpper
  - char.IsLower
  - char.IsLetter
  - char.IsWhiteSpace
  - char.IsBetween
  - char.ToUpper
  - char.ToLower
 
## String Interning
String interning in C# is a memory optimization technique used to reduce the memory usage by storing only one copy of each distinct string value. When a string is interned, the runtime ensures that all instances of the string with the same value point to the same memory location, rather than creating separate copies for each instance.

Interned strings are never garbage-collected until the application domain is unloaded, so they stay in memory for the duration of the program's execution. Therefore, interning too many strings can lead to excessive memory usage, especially if you are working with a large number of unique strings.


## String Problems
### Problem 1: Longest Common Prefix
Ref: https://leetcode.com/problems/longest-common-prefix/description/
```cs
public class Solution 
{
    public string LongestCommonPrefix(string[] strs) 
    {
        var init = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            var index = 0;

            while (index < init.Length && 
                    index < strs[i].Length && 
                    init[index] == strs[i][index])
            {
                index++;
            }

            init = init[0..index];

            if (string.IsNullOrWhiteSpace(init))
            {
                return init;
            }
        }

        return init;
    }
}
```

### Problem 2: Length of Last Word
Ref: https://leetcode.com/problems/length-of-last-word/description/
```cs
public class Solution
{
    public int LengthOfLastWord(string s) 
    {
        return s.Trim().Split(' ')[^1].Length;        
    }
}
```

### Problem 3: Greatest Common Divisor of Strings
Ref: https://leetcode.com/problems/greatest-common-divisor-of-strings/description/
```cs
public class Solution 
{
    public string GcdOfStrings(string str1, string str2) 
    {
        if(str1 + str2 != str2 + str1)
        {
            return "";
        }

        var len = gcd(str1.Length, str2.Length);

        return str1.Substring(0, len);
    }

    private int gcd(int len1, int len2)
    {
        if(len2 == 0)
        {
            return len1;
        }
        else
        {
            return gcd(len2, len1 % len2);
        }
    }
}
```

### Reverse Vowels of a String
Ref: https://leetcode.com/problems/reverse-vowels-of-a-string/description/
```cs
public class Solution 
{
    public string ReverseVowels(string s) 
    {
        var isVowel = (char ch) => {
            ch = char.ToLower(ch);
            return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
        };
        var chars = s.ToCharArray();
        var start = 0;
        var end = chars.Length - 1;

        while (start < end)
        {
            var startVowel = isVowel(chars[start]);
            var endVowel = isVowel(chars[end]);

            if (startVowel && endVowel)
            {
                var t = chars[start];
                chars[start] = chars[end];
                chars[end] = t;

                start++;
                end--;
            }

            if (!startVowel)
            {
                start++;
            }

            if (!endVowel)
            {
                end--;
            }
        }

        return new string(chars);     
    }
}
```
