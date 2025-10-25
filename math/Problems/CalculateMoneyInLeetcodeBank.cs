// LINK - https://leetcode.com/problems/calculate-money-in-leetcode-bank/description/

public class CalculateMoneyInLeetcodeBank 
{
    public int TotalMoney(int days) 
    {
        var a = 1;
        var balance = 0;
        while (days > 0)
        {
            var n = days - 7 >= 0 ? 7 : days;
            balance += (2 * a * n + n * n - n) / 2; 
            days -= 7;
            a++;
        }                
        return balance;
    }
}
