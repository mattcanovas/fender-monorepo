using System.Windows;
using System.Windows.Controls;
using Fender.App.Factory;
using Fender.App.ViewModels;
using Fender.App.Views.Registers;
using Fender.App.Views.Windows;

namespace Fender.App.Views;

public partial class HomePage : Page
{

    public HomePage()
    {
        InitializeComponent();
    }

    private void MenuUsers_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        _homeFrame.Navigate(new UserRegisterPage());
    }

    private void LogoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        (new LogoutDialogWindow()).Show();
    }
}