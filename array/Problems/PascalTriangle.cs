// Link - https://leetcode.com/problems/pascals-triangle/

public class PascalTriangle 
{
    public IList<IList<int>> Generate(int numRows) 
    {
        var result = new List<IList<int>>(numRows) { new List<int> { 1 } };
        for (int i = 2; i <= numRows; i++)
        {
            var sub = new List<int>(i) { 1 };
            for (int j = 1, index = 0; j < i - 1; j++, index++)
            {
                sub.Add(result[i - 2][index] + result[i - 2][index + 1]);
            }
            sub.Add(1);
            result.Add(sub);
        }
        return result;
    }
}
