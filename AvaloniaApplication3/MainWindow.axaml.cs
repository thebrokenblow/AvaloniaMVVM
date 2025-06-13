using Avalonia.Controls;
using Avalonia.Interactivity;
using ViewModel;

namespace AvaloniaApplication3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}