// Approach 1 - Using LINQ
// Here we are first finding the frequency and after that sorting the collection by it frequency and returning top k elements.
public class TopKFrequentElement 
{
    public int[] TopKFrequent(int[] nums, int k) => nums
            .GroupBy(e => e)
            .ToDictionary(g => g.Key, g => g.Count())
            .OrderByDescending(x => x.Value)
            .Select(x => x.Key)
            .Take(k)
            .ToArray();
}

// Approach 2 - Using Priority Queue
// Here we are first finding the frequency and after that adding the element to a priority queue based on their frequency, and when elements in the queue become more than k the we remove element with less priority.
public class TopKFrequentElement 
{
    public int[] TopKFrequent(int[] nums, int k) 
    {
        var frequency = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!frequency.ContainsKey(nums[i]))
            {
                frequency.Add(nums[i], 0);
            }
            frequency[nums[i]]++;
        }

        var queue = new PriorityQueue<int, int>(k);

        foreach (var item in frequency)
        {
            queue.Enqueue(item.Key, item.Value);
            if (queue.Count > k)
            {
                queue.Dequeue();
            }
        }
        
        var result = new int[queue.Count];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = queue.Dequeue();
        }    
        return result;    
    }
}
