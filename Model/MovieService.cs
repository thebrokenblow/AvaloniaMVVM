namespace Model;

public class MovieService
{
    private readonly List<Movie> _movies;

    public MovieService()
    {
        _movies = GenerateSampleMovies(100);
    }

    public IEnumerable<Movie> GetMovies(int page, int pageSize)
    {
        return _movies
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public int GetTotalCount() => _movies.Count;

    private List<Movie> GenerateSampleMovies(int count)
    {
        var genres = new[] { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };
        var random = new Random();

        return Enumerable.Range(1, count)
            .Select(i => new Movie
            {
                Title = $"Movie {i}",
                Year = 2000 + random.Next(0, 23),
                Genre = genres[random.Next(0, genres.Length)],
                Rating = Math.Round(random.NextDouble() * 5, 1)
            })
            .ToList();
    }

}