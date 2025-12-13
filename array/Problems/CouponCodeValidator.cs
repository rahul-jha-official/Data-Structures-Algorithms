// LINK - https://leetcode.com/problems/coupon-code-validator/description/

public class CouponCodeValidator 
{
    public IList<string> ValidateCoupons(string[] codes, string[] businessLine, bool[] isActive) 
    {
        var result = new Dictionary<string, List<string>>()
        {
            ["electronics"] = [],
            ["grocery"] = [],
            ["pharmacy"] = [],
            ["restaurant"] = [],
        };

        for (var i = 0; i < codes.Length; i++)
        {
            var valid = isActive[i] && result.ContainsKey(businessLine[i]) && !string.IsNullOrWhiteSpace(codes[i]);
            if (valid)
            {
                foreach (var ch in codes[i])
                {
                    var upper = ch >= 'A' && ch <= 'Z';
                    var lower = ch >= 'a' && ch <= 'z';
                    var digit = ch >= '0' && ch <= '9';
                    var score = ch == '_';
                    if (!(upper || lower || digit || score))
                    {
                        valid = false;
                        break;
                    }
                }
            }

            if (valid)
            {
                result[businessLine[i]].Add(codes[i]);
            }
        }

        foreach (var list in result.Values)
        {
            list.Sort(StringComparer.Ordinal);
        }

        return result.SelectMany(e => e.Value).ToList();        
    }
}
