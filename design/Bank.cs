// LINK - https://leetcode.com/problems/simple-bank-system/description/

public class Bank 
{
    private readonly long[] _balance;
    public Bank(long[] balance) 
    {
        _balance = balance;
    }
    
    public bool Transfer(int account1, int account2, long money) 
    {
        if (account1 > _balance.Length || account2 > _balance.Length || _balance[account1 - 1] < money)
        {
            return false;
        }

        _balance[account1 - 1] -= money;
        _balance[account2 - 1] += money;
        return true;
    }
    
    public bool Deposit(int account, long money) 
    {
        if (account > _balance.Length)
        {
            return false;
        }
        _balance[account - 1] += money;
        return true;
    }
    
    public bool Withdraw(int account, long money) 
    {
        if (account > _balance.Length || _balance[account - 1] < money)
        {
            return false;
        }
        _balance[account - 1] -= money;
        return true;                
    }
}

/**
 * Your Bank object will be instantiated and called as such:
 * Bank obj = new Bank(balance);
 * bool param_1 = obj.Transfer(account1,account2,money);
 * bool param_2 = obj.Deposit(account,money);
 * bool param_3 = obj.Withdraw(account,money);
 */
