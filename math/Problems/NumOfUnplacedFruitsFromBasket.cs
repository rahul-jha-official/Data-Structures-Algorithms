// LINK - https://leetcode.com/problems/fruits-into-baskets-iii/description

// Topic -  SQUARE ROOT DECOMPOSITION
// We divide the baskets array into √n blocks, each of size m= √n (approximately). For each block, we maintain the maximum value in that block in an auxiliary array.

public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var maxElementPerSection = (int)Math.Sqrt(baskets.Length);
        var numberOfSections = (int)Math.Ceiling(baskets.Length / (double)maxElementPerSection);
        var perSectionMaxValue = new int[numberOfSections];
        
        for (int i = 0; i < baskets.Length; i++)
        {
            perSectionMaxValue[i / maxElementPerSection] = Math.Max(perSectionMaxValue[i / maxElementPerSection], baskets[i]);
        }

        var unplacedFruitTypeCount = 0;

        foreach (int fruit in fruits)
        {
            var unset = 1;
            for (int section = 0; section < numberOfSections; section++)
            {
                if (perSectionMaxValue[section] < fruit)
                {
                    continue;
                }
                int choose = 0;
                perSectionMaxValue[section] = 0;
                for (int i = 0; i < maxElementPerSection; i++)
                {
                    int pos = section * maxElementPerSection + i;
                    if (pos < baskets.Length && baskets[pos] >= fruit && choose == 0)
                    {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < baskets.Length)
                    {
                        perSectionMaxValue[section] = Math.Max(perSectionMaxValue[section], baskets[pos]);
                    }
                }
                unset = 0;
                break;
            }
            unplacedFruitTypeCount += unset;
        }
        return unplacedFruitTypeCount;
    }
}
