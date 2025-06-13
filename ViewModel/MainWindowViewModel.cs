using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly MovieService _movieService;
    private IEnumerable<Movie> _movies;
    private int _currentPage = 1;
    private const int PageSize = 10;
    private int _totalPages;

    public MainWindowViewModel()
    {
        _movieService = new MovieService();
        LoadMovies();
    }

    public IEnumerable<Movie> Movies
    {
        get => _movies;
        private set
        {
            _movies = value;
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            if (value < 1 || value > _totalPages) return;
            
            _currentPage = value;
            OnPropertyChanged();
            LoadMovies();
        }
    }

    public int TotalPages
    {
        get => _totalPages;
        private set
        {
            _totalPages = value;
            OnPropertyChanged();
        }
    }

    public void NextPage() => CurrentPage++;
    public void PreviousPage() => CurrentPage--;

    private void LoadMovies()
    {
        var totalCount = _movieService.GetTotalCount();
        TotalPages = (int)Math.Ceiling((double)totalCount / PageSize);
        Movies = _movieService.GetMovies(CurrentPage, PageSize).ToList();
    }
}