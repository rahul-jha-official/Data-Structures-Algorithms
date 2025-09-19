// LINK - https://leetcode.com/problems/design-a-food-rating-system/description/

public class FoodRatings
{
    private readonly Dictionary<string, int> foodRating;
    private readonly Dictionary<string, string> foodCuisine;
    private readonly Dictionary<string, SortedSet<(int Rating, string Food)>> cuisineFoods;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        foodRating = new Dictionary<string, int>();
        foodCuisine = new Dictionary<string, string>();
        cuisineFoods = new Dictionary<string, SortedSet<(int Rating, string Food)>>();

        for (int i = 0; i < foods.Length; i++)
        {
            foodRating[foods[i]] = ratings[i];
            foodCuisine[foods[i]] = cuisines[i];

            if (!cuisineFoods.ContainsKey(cuisines[i]))
            {
                cuisineFoods[cuisines[i]] = new SortedSet<(int Rating, string Food)>(
                    Comparer<(int Rating, string Food)>.Create((a, b) =>
                        b.Rating != a.Rating ? b.Rating.CompareTo(a.Rating) : a.Food.CompareTo(b.Food)
                    )
                );
            }
            cuisineFoods[cuisines[i]].Add((ratings[i], foods[i]));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var cuisine = foodCuisine[food];
        var oldRating = foodRating[food];
        cuisineFoods[cuisine].Remove((oldRating, food));
        cuisineFoods[cuisine].Add((newRating, food));
        foodRating[food] = newRating;
    }

    public string HighestRated(string cuisine)
    {
        return cuisineFoods[cuisine].Min.Food;
    }
}
