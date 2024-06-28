using System.Windows;
using System.Windows.Controls;
using Fender.App.Views;
using Fender.App.Views.Windows;

namespace Fender.App;

public partial class MainWindow : Window
{
    private bool _disposed = false;
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new AuthPage());
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        (new CloseDialogWindow()).Show();
    }

    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (!_disposed)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            _disposed = !_disposed;
            return;
        }
        Application.Current.MainWindow.WindowState = WindowState.Normal;
        _disposed = !_disposed;
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }
}