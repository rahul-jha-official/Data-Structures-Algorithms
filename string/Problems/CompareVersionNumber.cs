// LINK - https://leetcode.com/problems/compare-version-numbers/description/

public class CompareVersionNumber
{
    public int CompareVersion(string version1, string version2)
    {
        var v1 = version1.Split('.').Select(int.Parse).ToArray();
        var v2 = version2.Split('.').Select(int.Parse).ToArray();

        for (int i = 0; i < Math.Max(v1.Length, v2.Length); i++)
        {
            int i1 = i < v1.Length ? v1[i] : 0;
            int i2 = i < v2.Length ? v2[i] : 0;
            if (i2 > i1) return -1;
            else if (i2 < i1) return 1;
            else continue;
        }
        return 0;
    }
}
