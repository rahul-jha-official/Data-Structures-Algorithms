// LINK - https://leetcode.com/problems/power-of-three/description

public class PowerOfThree 
{
    public bool IsPowerOfThree(int n) 
    {
        if (n <= 0) return false;
        while (n > 1 && n % 3 == 0)
        {
            n /= 3;
        }
        return n == 1;
    }
}
