// LINK - https://leetcode.com/problems/maximum-average-pass-ratio/description/

public class MaximumAveragePassRatio
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var pq = new PriorityQueue<(int Pass, int Total), double>();
        foreach (var item in classes)
        {
            pq.Enqueue((item[0], item[1]), GetRatio(item[0], item[1]));
        }

        while (extraStudents-- > 0)
        {
            var item = pq.Dequeue();
            pq.Enqueue((++item.Pass, ++item.Total), GetRatio(item.Pass, item.Total));
        }

        var result = 0.0;
        while (pq.Count > 0)
        {
            var item = pq.Dequeue();
            result += (double) item.Pass / item.Total;
        }

        return Math.Round(result / classes.Length, 5);
    }

    private static double GetRatio(double pass, double total)
    {
        var currentRatio = pass / total;
        var newRatio = (pass + 1) / (total + 1);
        return 1.0 - newRatio + currentRatio;
    }
}

