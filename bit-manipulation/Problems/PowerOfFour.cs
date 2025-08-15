// LINK - https://leetcode.com/problems/power-of-four/description/

public class PowerOfFour 
{
    public bool IsPowerOfFour(int n) 
    {
        if (n <= 0) 
        {
            return false;
        }
        else
        {
            if ((n & (n - 1)) != 0) 
            {
                return false;
            }
            else
            {
                var counter = 0;
                while (n != 1)
                {
                    counter++;
                    n >>= 1;
                }
                return (counter & 1) == 0;
            }
        }
            
    }
}
