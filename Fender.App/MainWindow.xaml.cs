using System.Windows;
using System.Windows.Controls;
using Fender.App.Views;

namespace Fender.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new AuthPage());
    }
}