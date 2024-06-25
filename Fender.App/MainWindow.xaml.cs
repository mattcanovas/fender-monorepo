using System.Windows;
using Fender.App.Views;

namespace Fender.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _mainFrame.Navigate(new HomePage());
    }
}