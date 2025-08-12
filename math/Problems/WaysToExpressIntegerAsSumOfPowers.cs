// LINK - https://leetcode.com/problems/ways-to-express-an-integer-as-sum-of-powers/description/

public class WaysToExpressIntegerAsSumOfPowers
{
    private const long MOD = 1_000_000_007L;
    private Dictionary<(int i, int sum), long> memo;

    public int NumberOfWays(int n, int x)
    {
        var powers = new List<int>();
        int a = 1;
        int b = (int)Math.Pow(a, x);

        while (b <= n)
        {
            powers.Add(b);
            a++;
            b = (int)Math.Pow(a, x);
        }

        memo = new Dictionary<(int, int), long>();
        long ans = CountWays(powers, 0, 0, n);
        return (int)(ans % MOD);
    }

    private long CountWays(List<int> powers, int i, int sum, int n)
    {
        if (sum == n) return 1;
        if (sum > n || i >= powers.Count) return 0;

        var key = (i, sum);
        if (memo.TryGetValue(key, out var cached)) return cached;

        long include = CountWays(powers, i + 1, sum + powers[i], n);
        long exclude = CountWays(powers, i + 1, sum, n);
        long res = (include + exclude) % MOD;

        memo[key] = res;
        return res;
    }
}
