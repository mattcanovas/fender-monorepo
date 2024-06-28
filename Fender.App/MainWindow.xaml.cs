using System.Windows;
using System.Windows.Controls;
using Fender.App.Views;

namespace Fender.App;

public partial class MainWindow : Window
{
    public Frame _mainFrame { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        _mainFrame = MainFrame;
        _mainFrame.Navigate(new AuthPage());
    }
}