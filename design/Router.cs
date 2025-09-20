// LINK - https://leetcode.com/problems/implement-router/description/

public class Router
{
    private readonly int _memoryLimit;
    private readonly Queue<Route> _routes;
    private readonly Dictionary<int, TimeStamp> _destinationMap;
    private readonly HashSet<Route> _existingRoutes;
    public Router(int memoryLimit)
    {
        _memoryLimit = memoryLimit;
        _routes = new Queue<Route>();
        _existingRoutes = new HashSet<Route>();
        _destinationMap = new Dictionary<int, TimeStamp>();
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        var route = new Route(source, destination, timestamp);

        if (_existingRoutes.Contains(route))
        {
            return false;
        }

        if (_routes.Count >= _memoryLimit)
        {
            var ex = _routes.Dequeue();
            _existingRoutes.Remove(ex);
            _destinationMap[ex.destination].StartIndex++;
        }

        
        if (!_destinationMap.ContainsKey(destination))
        {
            _destinationMap[destination] = new TimeStamp();
        }
        _destinationMap[destination].Timestamps.Add(timestamp);
        _routes.Enqueue(route);
        return _existingRoutes.Add(route);
    }

    public int[] ForwardPacket()
    {
        if (_routes.Count == 0)
        {
            return [];
        }
        var route = _routes.Dequeue();
        _existingRoutes.Remove(route);
        _destinationMap[route.destination].StartIndex++;
        return [route.source, route.destination, route.timestamp];
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        if (!_destinationMap.ContainsKey(destination))
        {
            return 0;
        }
        var timestamps = _destinationMap[destination].Timestamps;
        int startIndex = _destinationMap[destination].StartIndex;
        int endIndex = _destinationMap[destination].Timestamps.Count - 1;
        
        if (startIndex > endIndex || startIndex == timestamps.Count || timestamps[startIndex] > endTime || timestamps[endIndex] < startTime)
        {
            return 0;
        }

        while (startIndex < endIndex && timestamps[startIndex] < startTime)
        {
            ++startIndex;
        }

        while (endIndex > 0 && timestamps[endIndex] > endTime)
        {
            --endIndex;
        }

        return endIndex - startIndex + 1;
    }
}

public record Route (int source, int destination, int timestamp);
public class TimeStamp
{
    public int StartIndex { get; set; }
    public List<int> Timestamps { get; set; } = [];
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */
