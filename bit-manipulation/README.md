## [Bit Manipulation](#bit-manipulation)
Bit Manipulation is used in the variety of problems. Sometimes, the question explicitly calls for bit manipulation. Other times, it's simply useful technique to optimize your code.

### Truth Tables

**NOT (~)**
| A | ~A |
| :--- | ---: |
| 0 | 1 |
| 1 | 0 |

**OR (|)** 
| A | B | A &#124; B |
| :--- | :---: | ---: |
| 0 | 0 | 0 |
| 0 | 1 | 1 |
| 1 | 0 | 1 |
| 1 | 1 | 1 |

**AND (&)**
| A | B | A &#124; B |
| :--- | :---: | ---: |
| 0 | 0 | 0 |
| 0 | 1 | 1 |
| 1 | 0 | 1 |
| 1 | 1 | 1 |

**XOR (^)**
| A | B | A ^ B |
| :--- | :---: | ---: |
| 0 | 0 | 0 |
| 0 | 1 | 1 |
| 1 | 0 | 1 |
| 1 | 1 | 0 |

### Bit Facts and Tricks
The following expressions are useful in bit manipulation:

| Expression | Result | Notes |
| :--- | :---: | ---: |
| x ^ 0s | x | 1010 ^ 0000 = 1010 |
| x ^ 1s | ~x | 1010 ^ 1111 = 0101 |
| x ^ x | 0 | 1010 ^ 1010 = 0000 |
| x ^ ~x | 1 | |
| x & 0s | 0 |  |
| x & 1s | x |  |
| x & x  | x |  |
| x &#124; 0s | x |  |
| x &#124; 1s | 1 |  |
| x &#124; x  | x |  |

### Two's Complement and Negative Number
Computers typically store integers in two's complement representaion. A positive number is represented as itself while a negative number is represented as two's complement of its absolute value(with 1 in its sign bit to indicate that a negative value).

The two's complement of N-Bit number (where N is the number of bits used for the number,excluding the sign bit). is the complement of number with respect to 2^N.

Lets look at 4-bit integer -3 as an example. If it is a 4-bit number, we have 1 bit fot sign and 3 bits for the value. We want complement with respect to 2^3, which is 8. The complement of 3(the absolute value of -3) with respect to 8 is 5. 5 in binary is 101. Therefore, -3 in binary as a 4-Bit number is 1101.

In other words, the binary representaion of -K(negative K) as a N-Bit number is ***concat(1, 2^(N-1) - K)***.

***Another way is look at this is that we invert the bits in positive representaion and then add 1.***

4-Bit Integers example:

Positive Number	Negative Number
>
    7 0111			        -1   1111
    6 0110			        -2   1110
    5 0101	        		-3   1101
    4 0100	        		-4   1100
    3 0011		        	-5   1011
    2 0010      			-6   1010
    1 0001		        	-7   1001
    0 0000

### C# In-built Function
**How to convert from Decimal to Binary?**

Lets say you want to convert n to binary: 
- Convert.ToString(n, 2)
- n.ToString("b")
- n.ToString("b8"), We can also define the precision.

**How to convert from Decimal to Hexadecimal?**

Lets say you want to convert n to binary: 
- Convert.ToString(n, 16)
- n.ToString("x")
- n.ToString("x8"), We can also define the precision.

Ref: https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

**How to initialize a number in Binary format ?**
```cs
//Lets say we have to initialize with 7.
var n1 = 0b111;
//OR
int n2 = 0b111;
```

**How to initialize a number in Hexadecimal format ?**
```cs
//Lets say we have to initialize with 12.
var n1 = 0xc;
//OR
int n2 = 0xc;
```

### Bit Manipulation Problems
**Problem 1:<br>We are given two 32-Bits Numbers, N & M and 2 bit positions, i & j. Write a solution to insert M into N such that M starts with j and ends with i in N.<br>Assumptions: N have enough bits to fit all bits of M.<br><br>Example:<br>N = 100000000000<br>M = 10011<br>i = 2<br>j = 6<br>Output: N = 10001001100**

<ins>**Algorithm**</ins>

- Clear the bits if it has 1 in N from i till j
- Shift M i bits
- Merge M & N

<ins>**Code**</ins> 
```cs
public class Solution
{
    public int UpdateBits(int n, int m, int i, int j)
    {
        var n_cleared = ClearBit(n, i, j);
        var m_shifted = m << i;
        return n_cleared | m_shifted;
    }

    private static int ClearBit(int n, int i, int j)
    {
        var allOne = ~0;
        var left = allOne << (j + 1); //j + 1 becuase of 0 indexing
        var right = (1 << i) - 1;
        var mask = left | right;
        return mask & n;
    }
}
```

**Problem 2:<br>Given a real number between 0 and 1 (e.g., 0.72) that is passed in as double , return the Binary representaion. If number cannot be represented accurately in binary with at most 32 characters, return 'ERROR'**

<ins>**Way 1**</ins>
```cs
public class Solution
{
    public string GetBinaryRepresentation(double n)
    {
        const string error = "ERROR";
        if (n <= 0 || n >= 1) return error;
        var result = new StringBuilder(".");

        while(n > 0)
        {
            if (result.Length >= 32)
            {
                return error;
            }

            n = n * 2;

            if (n >= 1)
            {
                result.Append(1);
                n = n - 1;
            }
            else
            {
                result.Append(0);
            }
        }

        return result.ToString();
    }
}
```


<ins>**Way 2**</ins>
```cs
public class Solution
{
    public string GetBinaryRepresentation(double n)
    {
        const string error = "ERROR";
        if (n <= 0 || n >= 1) return error;

        var result = new StringBuilder(".");
        var fraction = 0.5;

        while (n > 0)
        {
            if (result.Length >= 32)
            {
                return error;
            }

            if (n >= fraction)
            {
                n -= fraction;
                result.Append(1);
            }
            else
            {
                result.Append(0);
            }

            fraction = fraction / 2;
        }

        return result.ToString();
    }
}
```

**Problem 3:<br> You have an integer and you can flip exactly one bit from a 0 to a 1. Write a code to find the length of the sequence of 1s you could create.<br>Example<br>Input: 1775 (or: 11011101111)<br>Output: 8**
<br><br>
Ref: https://www.geeksforgeeks.org/find-longest-sequence-1s-binary-representation-one-flip/

```cs
public class Solution
{
    public int LongestSequence(int n)
    {
        const int totalBits = 32;

        if (~n == 0) return totalBits;

        var previous = 0;
        var counter = 0;
        var result = 0;

        for (int i = 0; i < totalBits; i++)
        {
            if (((n >> i) & 1) == 1)
            {
                counter++;
            }
            else
            {
                result = Math.Max(result, previous + 1 + counter);
                previous = counter;
                counter = 0;
            }
        }

        result = Math.Max(result, previous + 1 + counter);

        return result;
    }
}
```


<strong>Problem 4:<br> An n-bit gray code sequence is a sequence of 2n integers where:
- Every integer is in the inclusive range [0, 2n - 1],
- The first integer is 0,
- An integer appears no more than once in the sequence,
- The binary representation of every pair of adjacent integers differs by exactly one bit, and
- The binary representation of the first and last integers differs by exactly one bit.
- Given an integer n, return any valid n-bit gray code sequence.

Example:<br>
Input: n = 2<br>
Output: [0,1,3,2]<br>
Explanation:<br>
The binary representation of [0,1,3,2] is [00,01,11,10].</strong>
<br><br>


Ref: https://leetcode.com/problems/gray-code/description/

<ins>**Way 1**</ins>

```cs
public class Solution {
    public IList<int> GrayCode(int n) 
    {
        var result = new int[(int)Math.Pow(2,n)];
        var index = 1;
        var shift = 0;
        while (index < result.Length)
        {
            for (int j = index - 1; j >= 0; j--) 
            {
                result[index++] = (1 << shift) | result[j];
            }
            shift++;
        }
        return result;
    }
}
```
<br>

**Steps to Generate Gray Code:**
1. Start with a sequence of length \(2^0 = 1\): `[0]`
2. For each subsequent step, apply the rule:
   - Take the current sequence, prefix each number with `0`, and append that to the sequence.
   - Then, take the reversed sequence, prefix each number with `1`, and append it to the end.

<ins>**Way 2**</ins>

```cs
public class Solution 
{
    public IList<int> GrayCode(int n) 
    {
      int[] result = new int[(int)Math.Pow(2, n)];

      for (int i = 0; i < result.Length; i++) 
      {
        result[i] = i ^ (i >> 1);
      }

      return result;
    }
}
```

<strong>Problem 5:<br> Given an integer array nums of unique elements, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:<br>
Input: nums = [1,2,3]<br>
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]<br><br>
Example 2:<br>
Input: nums = [0]<br>
Output: [[],[0]]</strong>
<br><br>


Ref: https://leetcode.com/problems/subsets/description/

Hint: A truth table contains all possible pairs and there will be 2<sup>Count Of Elements</sup> Pairs.

```cs
public class Solution 
{
    public IList<IList<int>> Subsets(int[] nums) 
    {
        var result = new List<IList<int>>();
        for (int i = 0; i < (1 << nums.Length); i++)
        {
            result.Add(nums.Where((num, index) => (1 & (i >> index)) == 1).ToList());
        }
        return result;
    }
}
```

<strong>Problem 6:<br> Given an integer n, return true if it is a power of two. Otherwise, return false. An integer n is a power of two, if there exists an integer x such that n == 2<sup>x</sup>

Example 1:<br>
Input: n = 1<br>
Output: true<br>
Explanation: 2<sup>0</sup> = 1<br>

Example 2:<br>
Input: n = 16<br>
Output: true<br>
Explanation: 2<sup>4</sup> = 16<br>

Example 3:<br>
Input: n = 3<br>
Output: false</strong>
<br><br>


Ref: https://leetcode.com/problems/power-of-two/description/

Hint: All power of 2 will be having 1 in the front and other bits will be 0.


```cs
public class Solution 
{
    public bool IsPowerOfTwo(int n) 
    {
        if (n <= ~0 || n == 0)
        {
            return false;  
        }
        bool one = false;
        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                if (one)
                {
                    return false;
                }
                one = true;
            }
            n >>= 1;
        }
        return true;              
    }
}
```


<strong>Problem 7:<br> The DNA sequence is composed of a series of nucleotides abbreviated as 'A', 'C', 'G', and 'T'.

For example, "ACGAATTCCG" is a DNA sequence.
When studying DNA, it is useful to identify repeated sequences within the DNA.

Given a string s that represents a DNA sequence, return all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule. You may return the answer in any order.

 

Example 1:<br>
Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"<br>
Output: ["AAAAACCCCC","CCCCCAAAAA"]<br>

Example 2:<br>
Input: s = "AAAAAAAAAAAAA"<br>
Output: ["AAAAAAAAAA"]</strong>
<br><br>


Ref: https://leetcode.com/problems/repeated-dna-sequences/description/

Hint:
A DNA sequence consisting of only four characters: 'A', 'C', 'G', and 'T'. These four characters can be represented using 2 bits each:

'A' -> 00<br>
'C' -> 01<br>
'G' -> 10<br>
'T' -> 11<br>

When searching for repeated sequences, storing and comparing these compressed 20-bit integers is faster than working with full strings.


```cs
public class Solution
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var GetMapping = (char nucleotide) => nucleotide switch
        {
            'A' => 0,
            'C' => 1,
            'G' => 2,
            'T' => 3,
            _ => throw new InvalidOperationException("Invalid Character Supplied")
        };

        var result = new List<string>();
        var trackSequence = new Dictionary<int, int>();
        var sequence = 0;
        var mask = (1 << 20) - 1;
        for (int i = 0; i < 9 && i < s.Length; i++)
        {
            sequence <<= 2;
            sequence |= GetMapping(s[i]);
        }

        for (int i = 9; i < s.Length; i++)
        {
            sequence <<= 2;
            sequence |= GetMapping(s[i]);
            sequence &= mask;

            if (trackSequence.ContainsKey(sequence))
            {
                if (trackSequence[sequence] == 1)
                {
                    result.Add(s.Substring(i - 9, 10));
                } 
                trackSequence[sequence]++;
            }
            else
            {
                trackSequence.Add(sequence, 1);
            }
        }
        return result;
    }
}
```


<strong>Problem 8:<br> Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.
 

Example 1:<br>
Input: left = 5, right = 7<br>
Output: 4<br>

Example 2:<br>
Input: left = 0, right = 0<br>
Output: 0</strong>
<br><br>


Ref: https://leetcode.com/problems/bitwise-and-of-numbers-range/description/

```cs
public class Solution 
{
    public int RangeBitwiseAnd(int left, int right) 
    {
        var zeros = 0;
        while (left != right)
        {
            left >>= 1;
            right >>= 1;
            zeros++;
        }
        return left << zeros;
    }
}
```


<strong>Problem 8:<br> Given a string array words, return the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. If no such two words exist, return 0.

Example 1:<br>
Input: words = ["abcw","baz","foo","bar","xtfn","abcdef"]<br>
Output: 16<br>
Explanation: The two words can be "abcw", "xtfn".<br>

Example 2:<br>
Input: words = ["a","ab","abc","d","cd","bcd","abcd"]<br>
Output: 4<br>
Explanation: The two words can be "ab", "cd".<br>

Example 3:<br>
Input: words = ["a","aa","aaa","aaaa"]<br>
Output: 0<br>
Explanation: No such pair of words.<br>
</strong>

Ref: https://leetcode.com/problems/maximum-product-of-word-lengths/description/


```cs
public class Solution 
{
    public int MaxProduct(string[] words) 
    {
        var wordBits = new int[words.Length];
        
        for (var i = 0; i < words.Length; i++)
        {
            foreach (var ch in words[i])
            {
                wordBits[i] |= (1 << (ch - 'a'));
            }
        }

        var result = 0;
        
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if ((wordBits[i] & wordBits[j]) == 0)
                {
                    result = Math.Max(result, words[i].Length * words[j].Length);
                }
            }
        }

        return result;
    }
}
```

<strong>Problem 9:<br>
Given a positive integer n, you can apply one of the following operations:
If n is even, replace n with n / 2.
If n is odd, replace n with either n + 1 or n - 1.
Return the minimum number of operations needed for n to become 1.

 

Example 1:<br>
Input: n = 8<br>
Output: 3<br>
Explanation: 8 -> 4 -> 2 -> 1<br>

Example 2:<br>
Input: n = 7<br>
Output: 4<br>
Explanation: 7 -> 8 -> 4 -> 2 -> 1<br>
or 7 -> 6 -> 3 -> 2 -> 1<br>

Example 3:<br>
Input: n = 4<br>
Output: 2</strong>

Ref: https://leetcode.com/problems/integer-replacement/description/

Hint: Focus on creating even number in case of odd

```cs
public class Solution 
{
    public int IntegerReplacement(int n) 
    {
        var result = 0;
        while (n > 3)
        {
            if (n % 2 == 0)
            {
                n >>= 1;
            }
            else 
            {
                var x1 = (n - 1) >> 1;
                var x2 = ((long)n + 1) >> 1;
                if (x1 % 2 == 0 && x2 % 2 == 0)
                {
                    n = Math.Min(x1, (int)x2);
                }
                else
                {
                    n = x1 % 2 == 0 ? x1 : (int)x2; 
                }
                // We are performing 2 Operation
                // Adding +1 / -1 
                // Shifting bit
                result++;
            }
            result++;
        }
        return result + n - 1;
    }
}
```


<strong>Problem 10:<br>
Bitwise XOR of All Pairings<br><br>
You are given two 0-indexed arrays, nums1 and nums2, consisting of non-negative integers. There exists another array, nums3, which contains the bitwise XOR of all pairings of integers between nums1 and nums2 (every integer in nums1 is paired with every integer in nums2 exactly once).

Return the bitwise XOR of all integers in nums3.

 

Example 1:<br>
Input: nums1 = [2,1,3], nums2 = [10,2,5,0]<br>
Output: 13<br>
Explanation:<br>
A possible nums3 array is [8,0,7,2,11,3,4,1,9,1,6,3].<br>
The bitwise XOR of all these numbers is 13, so we return 13.<br>

Example 2:<br>
Input: nums1 = [1,2], nums2 = [3,4]<br>
Output: 0<br>
Explanation:<br>
All possible pairs of bitwise XORs are nums1[0] ^ nums2[0], nums1[0] ^ nums2[1], nums1[1] ^ nums2[0], and nums1[1] ^ nums2[1].
Thus, one possible nums3 array is [2,5,1,6].<br>
2 ^ 5 ^ 1 ^ 6 = 0, so we return 0.<br>
</strong>

Ref: https://leetcode.com/problems/bitwise-xor-of-all-pairings/description/

```cs
public class Solution 
{
    public int XorAllNums(int[] nums1, int[] nums2) 
    {
        if (nums1.Length % 2 == 0 && nums2.Length % 2 == 0) return 0;
        
        var s1 = 0;
        var s2 = 0;
        
        if (nums1.Length % 2 != 0)
        {
            s1 = XOR(nums2);
        }
        if (nums2.Length % 2 != 0)
        {
            s2 = XOR(nums1);
        }
        return s1 ^ s2;
    }
    private static int XOR(int[] n)
    {
        var result = 0;
        foreach (int i in n) result ^= i;
        return result;
    }
}
```

<strong>Problem 11:<br>
Minimize XOR<br><br>
Given two positive integers num1 and num2, find the positive integer x such that:

x has the same number of set bits as num2, and
The value x XOR num1 is minimal.
Note that XOR is the bitwise XOR operation.

Return the integer x. The test cases are generated such that x is uniquely determined.

The number of set bits of an integer is the number of 1's in its binary representation.

 

Example 1:<br>
Input: num1 = 3, num2 = 5<br>
Output: 3<br>
Explanation:<br>
The binary representations of num1 and num2 are 0011 and 0101, respectively.<br>
The integer 3 has the same number of set bits as num2, and the value 3 XOR 3 = 0 is minimal.<br>

Example 2:<br>
Input: num1 = 1, num2 = 12<br>
Output: 3<br>
Explanation:<br>
The binary representations of num1 and num2 are 0001 and 1100, respectively.<br>
The integer 3 has the same number of set bits as num2, and the value 3 XOR 1 = 2 is minimal.<br>
</strong>

```cs
public class Solution 
{
    public int MinimizeXor(int num1, int num2) 
    {
        var count1 = CountOneBit(num1);
        var count2 = CountOneBit(num2);
        var result = num1;
        if (count1 == count2)
        {
            result = num1;
        }
        else if (count2 > count1)
        {
            var bitsToAdd = count2 - count1;
            var shift = 0;
            while (bitsToAdd > 0)
            {
                if (((result >> shift) & 1) == 0)
                {
                    result |= (1 << shift);
                    bitsToAdd--;
                }
                shift++;
            }
            return result;
        }
        else
        {
            var skip = count1 - count2;
            while (skip-- > 0)
            {
                result &= (result - 1);
            }
        }

        return result;
    }

    private static int CountOneBit(int n)
    {
        int count = 0;
        while (n > 0)
        {
            if ((n & 1) == 1) count++;
            n >>= 1;
        }

        return count;
    }
}
```
