// LINK - https://leetcode.com/problems/number-of-laser-beams-in-a-bank/

public class NumberOfLaserBeamsInBank 
{
    public int NumberOfBeams(string[] bank) 
    {
        var b = bank.Select(e => {
            var c = 0;
            foreach (var d in e)
            {
                if (d == '1') c++;
            }
            return c;
        }).Where(e => e > 0).ToList();

        var result = 0;
        
        for (var i = 1; i < b.Count; i++)
        {
            result += (b[i] * b[i - 1]);
        }

        return result;
    }
}
