// LINK - https://leetcode.com/problems/largest-triangle-area/description/

public class LargestTriangleAreaOnPlane
{
    public double LargestTriangleArea(int[][] points)
    {
        var result = 0.0;
        for (var i  = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                for (var k = j + 1; k < points.Length; k++)
                {
                    result = Math.Max(result, Area(points[i], points[j], points[k]));
                }
            }
        }
        return result;
    }

    private static double Area(int[] P, int[] Q, int[] R)
    {
        return 0.5 * Math.Abs(P[0] * Q[1] + Q[0] * R[1] + R[0] * P[1] - P[1] * Q[0] - Q[1] * R[0] - R[1] * P[0]);
    }
}
