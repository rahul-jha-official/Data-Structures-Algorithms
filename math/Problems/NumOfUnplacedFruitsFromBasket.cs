// LINK - https://leetcode.com/problems/fruits-into-baskets-iii/description

// Topic -  SQUARE ROOT DECOMPOSITION
// We divide the baskets array into √n blocks, each of size m= √n (approximately). For each block, we maintain the maximum value in that block in an auxiliary array.

public class NumOfUnplacedFruitsFromBasket
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var m = (int)Math.Sqrt(baskets.Length);
        var section = (baskets.Length + m - 1) / m;
        var sectionMaxValue = new int[section];
        
        for (int i = 0; i < baskets.Length; i++)
        {
            sectionMaxValue[i / m] = Math.Max(sectionMaxValue[i / m], baskets[i]);
        }

        var unplacedFruitTypeCount = 0;

        foreach (int fruit in fruits)
        {
            var unset = 1;
            for (int sec = 0; sec < section; sec++)
            {
                if (sectionMaxValue[sec] < fruit)
                {
                    continue;
                }
                int choose = 0;
                sectionMaxValue[sec] = 0;
                for (int i = 0; i < m; i++)
                {
                    int pos = sec * m + i;
                    if (pos < baskets.Length && baskets[pos] >= fruit && choose == 0)
                    {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < baskets.Length)
                    {
                        sectionMaxValue[sec] = Math.Max(sectionMaxValue[sec], baskets[pos]);
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
