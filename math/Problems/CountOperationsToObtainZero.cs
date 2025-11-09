// LINK - https://leetcode.com/problems/count-operations-to-obtain-zero/

public class CountOperationsToObtainZero 
{
    public int CountOperations(int num1, int num2) 
    {
        if (num1 == 0 || num2 == 0)
        {
            return 0;
        }
        
        var count = 0;
        while (num1 != num2)
        {
            if (num1 > num2)
            {
                num1 -= num2;
            }
            else
            {
                num2 -= num1;
            }
            count++;
        }        
        return count + 1;
    }
}
