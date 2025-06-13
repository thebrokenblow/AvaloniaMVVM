using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private double _number1;
    private double _number2;
    private double _result;
    private readonly Calculator _calculator = new();

    public double Number1
    {
        get => _number1;
        set
        {
            _number1 = value;
            OnPropertyChanged();
        }
    }

    public double Number2
    {
        get => _number2;
        set
        {
            _number2 = value;
            OnPropertyChanged();
        }
    }

    public double Result
    {
        get => _result;
        private set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    public void Calculate()
    {
        Result = _calculator.Add(Number1, Number2);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}