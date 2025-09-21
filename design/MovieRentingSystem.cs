public class MovieRentingSystem
{
    private Dictionary<int, Shop> shopMap = new Dictionary<int, Shop>();
    private Dictionary<int, SortedSet<Entry>> unrentedMovies = new Dictionary<int, SortedSet<Entry>>();
    private SortedSet<Entry> rentedMovies = new SortedSet<Entry>(new EntryComparer());
    public MovieRentingSystem(int n, int[][] entries)
    {
        for (int i = 0; i < n; i++)
            shopMap[i] = new Shop(i);

        foreach (var entry in entries)
        {
            var shopId = entry[0];
            var movieId = entry[1];
            var price = entry[2];

            shopMap[shopId].AddMovie(new Movie(movieId, price));

            var movieEntry = new Entry(shopId, movieId, price);

            if (!unrentedMovies.ContainsKey(movieId))
                unrentedMovies[movieId] = new SortedSet<Entry>(new EntryComparer());

            unrentedMovies[movieId].Add(movieEntry);
        }
    }
    
    public IList<int> Search(int movie)
    {
        if (unrentedMovies.ContainsKey(movie))
        {
            return unrentedMovies[movie]
                .Take(5)
                .Select(e => e.shop)
                .ToList();
        }
        return [];
    }

    public void Rent(int shop, int movie)
    {
        var currentShop = shopMap[shop];
        var moviePrice = currentShop.Rent(movie);

        if (unrentedMovies.ContainsKey(movie))
        {
            unrentedMovies[movie].Remove(new Entry(shop, movie, moviePrice));
            if (unrentedMovies[movie].Count == 0)
                unrentedMovies.Remove(movie);
        }

        rentedMovies.Add(new Entry(shop, movie, moviePrice));
    }

    public void Drop(int shop, int movie)
    {
        var shopObj = shopMap[shop];
        var moviePrice = shopObj.Drop(movie);

        rentedMovies.Remove(new Entry(shop, movie, moviePrice));

        if (!unrentedMovies.ContainsKey(movie))
            unrentedMovies[movie] = new SortedSet<Entry>(new EntryComparer());

        unrentedMovies[movie].Add(new Entry(shop, movie, moviePrice));
    }

    public IList<IList<int>> Report()
    {
        var result = new List<IList<int>>();
        foreach (var entry in rentedMovies)
        {
            result.Add(new List<int> { entry.shop, entry.movie });
            if (result.Count == 5) break;
        }
        return result;
    }
}

public struct Movie
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Movie(int id, int price)
    {
        Id = id;
        Price = price;
    }
}

public struct Entry
{
    public int shop, movie, price;

    public Entry(int shop, int movie, int price)
    {
        this.shop = shop;
        this.movie = movie;
        this.price = price;
    }
}

public class Shop
{
    private int _id;
    private Dictionary<int, Movie> _movieMap;
    private HashSet<int> _rentedMovies;

    public Shop(int id)
    {
        _id = id;
        _movieMap = new Dictionary<int, Movie>();
        _rentedMovies = new HashSet<int>();
    }

    public int Id => _id;

    public void AddMovie(Movie movie)
    {
        if (!_movieMap.ContainsKey(movie.Id))
            _movieMap[movie.Id] = movie;
    }

    public int Rent(int movieId)
    {
        if (_movieMap.ContainsKey(movieId) && !_rentedMovies.Contains(movieId))
        {
            _rentedMovies.Add(movieId);
            return _movieMap[movieId].Price;
        }
        return -1;
    }

    public int Drop(int movieId)
    {
        if (_rentedMovies.Contains(movieId))
        {
            _rentedMovies.Remove(movieId);
            return _movieMap[movieId].Price;
        }
        return -1;
    }
}

public class EntryComparer : IComparer<Entry>
{
    public int Compare(Entry a, Entry b)
    {
        if (a.price != b.price) return a.price - b.price;
        if (a.shop != b.shop) return a.shop - b.shop;
        return a.movie - b.movie;
    }
}
