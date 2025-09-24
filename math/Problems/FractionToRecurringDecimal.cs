// LINK - https://leetcode.com/problems/fraction-to-recurring-decimal/description/

public class FractionToRecurringDecimal
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (denominator == 0) throw new DivideByZeroException();
        if (numerator == 0) return "0";

        var sb = new StringBuilder();

        // Handle sign
        if ((numerator < 0) ^ (denominator < 0))
            sb.Append('-');

        long num = Math.Abs((long)numerator);
        long den = Math.Abs((long)denominator);

        // Integer part
        sb.Append(num / den);
        num %= den;
        if (num == 0)
            return sb.ToString();

        sb.Append('.');

        // Fractional part
        var map = new Dictionary<long, int>();
        while (num != 0)
        {
            if (map.ContainsKey(num))
            {
                sb.Insert(map[num], "(");
                sb.Append(')');
                break;
            }
            map[num] = sb.Length;
            num *= 10;
            sb.Append(num / den);
            num %= den;
        }

        return sb.ToString();
    }
}
