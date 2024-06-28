using System.Windows;
using System.Windows.Controls;
using Fender.App.Views;
using Fender.App.Views.Windows;

namespace Fender.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new AuthPage());
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        (new CloseDialogWindow()).Show();
    }
}