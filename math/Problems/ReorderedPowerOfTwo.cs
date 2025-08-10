// LINK - https://leetcode.com/problems/reordered-power-of-2/description

public class ReorderedPowerOfTwo 
{
    public bool ReorderedPowerOf2(int n) 
    {
        var nFreq = GetFrequency(n);
        for (int i = 0; i < 32; i++)
        {
            var temp = 1 << i;
            if (Matched(GetFrequency(temp), nFreq))
            {
                return true;
            }         
        }
        return false;                
    }

    private static bool Matched(int[] a, int[] b)
    {
        for (int i = 0; i < 10; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }

    private static int[] GetFrequency(int n)
    {
        var result = new int[10];
        while (n > 0)
        {
            result[n % 10]++;
            n /= 10;
        }
        return result;
    }
}
