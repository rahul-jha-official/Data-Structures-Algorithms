// LINK - https://leetcode.com/problems/count-square-sum-triples/

public class CountSquareSumTriples 
{
    public int CountTriples(int n) 
    {
        var count = 0;
        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                var k = (int)Math.Sqrt(i * i + j * j);
                if (k <= n && (i * i + j * j) == (k * k)) 
                {
                    count++;
                }
            }
        }    
        return count;    
    }
}
