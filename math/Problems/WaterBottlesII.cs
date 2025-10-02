// LINK - https://leetcode.com/problems/water-bottles-ii/description/

public class WaterBottlesII 
{
    public int MaxBottlesDrunk(int numBottles, int numExchange) 
    {
        var result = numBottles;
        var empty = numBottles;
        while (empty >= numExchange) 
        {
            result++;
            empty -= numExchange - 1;
            numExchange++;
        }
        return result;
    }
}
