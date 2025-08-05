// LINK - https://leetcode.com/problems/fruit-into-baskets/description

public class FruitIntoBaskets
{
    public int TotalFruit(int[] fruits)
    {
        var result = 0;
        var dict = new Dictionary<int, int>();
        var index = 0;

        foreach (var fruit in fruits)
        {
            if (!dict.ContainsKey(fruit)) dict.Add(fruit, 0);
            if (dict.Count > 2)
            {
                result = Math.Max(result, GetCurrentSum(dict));
                while (dict.Count() > 2)
                {
                    dict[fruits[index]]--;
                    if (dict[fruits[index]] == 0)
                    {
                        dict.Remove(fruits[index]);
                    }
                    index++;
                }
            }
            dict[fruit]++;
        }
        result = Math.Max(result, GetCurrentSum(dict));
        return result;
    }

    private static int GetCurrentSum(Dictionary<int, int> dict)
    {
        var sum = 0;
        foreach (var val in dict.Values)
        {
            sum += val;
        }
        return sum;
    }
}
