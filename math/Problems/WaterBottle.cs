// LINK - https://leetcode.com/problems/water-bottles/description/

public class WaterBottle 
{
    public int NumWaterBottles(int numBottles, int numExchange) 
    {
        var drinkableBottle = numBottles;
        var canExchange = numBottles >= numExchange;
        while (canExchange)
        {
            int n = (numBottles / numExchange);
            drinkableBottle += n;
            numBottles = n + (numBottles % numExchange);
            canExchange = numBottles >= numExchange;
        }
        return drinkableBottle;
    }
}
