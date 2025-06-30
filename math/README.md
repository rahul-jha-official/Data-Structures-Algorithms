# Mathematics
Basic Formulas to remember:
- Sum of N Natural Number = N * (n + 1) / 2
- N<sup>th</sup> of AP = A + (N - 1) * D
- Sum of AP = (N / 2) * (2 * A + (N - 1) * D)
- N<sup>th</sup> of GP = A * R<sup>N - 1</sup>
- Sum of AP = A * (1 - R<sup>N</sup>) / (1 - R)

## Problems:

### Problem 1: Excel Sheet Column Title
Ref: https://leetcode.com/problems/excel-sheet-column-title/description/
```cs
public class Solution 
{
    public string ConvertToTitle(int columnNumber) 
    {
        var result = new StringBuilder();
        while (columnNumber > 0)
        {
            int c = (columnNumber - 1)  % 26;
            result.Insert(0, (char)(65 + c));
            columnNumber = (columnNumber - 1) / 26;
        }
        return result.ToString();
    }
}
```

### Problem 2: Excel Sheet Column Number
Ref: https://leetcode.com/problems/excel-sheet-column-number/description/
```cs
public class Solution 
{
    public int TitleToNumber(string columnTitle) 
    {
        var result = 0;

        for (int i = columnTitle.Length - 1; i >= 0; i--)
        {
            result += (int)Math.Pow(26, columnTitle.Length - i - 1) * (columnTitle[i] - 'A' + 1);
        }
        return result;
    }
}
```

### Problem 3: Pow(x, n)
Ref: https://leetcode.com/problems/powx-n/description/
```cs
public class Solution 
{
    public double MyPow(double x, int n) 
    {
        var result = Math.Pow(x, Math.Abs((long)n));
        return n < 0 ? (1 / result) : result;
    }

    public double Pow(double x, long n) 
    {
        if (x == 1.0 || n == 0) return 1.0;
        if (n == 1) return x;
        var t = Pow(x, n / 2);
        if ((n & 1) == 0) return t * t;
        else return x * t * t;
    }
}
```


