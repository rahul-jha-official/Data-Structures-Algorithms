// LINK - https://leetcode.com/problems/maximum-69-number/description/

public class FormMaximumNumber 
{
    public int Maximum69Number(int num) 
    {
        var n = Reverse(num);
        var divisor = 1;
        while (n / divisor > 0 && (n / divisor) % 10 != 6)
        {
            divisor *= 10;
        }

        return divisor > num ? num : Reverse(((int)(n / (divisor * 10)) * 10 + 9) * divisor + (n % divisor));
    }
    private static int Reverse(int num)
    {
        var result = 0;
        while (num > 0)
        {
            result = result * 10 + num % 10;
            num /= 10;
        }
        return result;
    }
}
