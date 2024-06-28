using System.Security;
using System.Windows;
using System.Windows.Controls;
using Fender.App.Factory;
using Fender.App.ViewModels;

namespace Fender.App.Views;

public partial class AuthPage : Page
{
    public AuthViewModel VM { get; private set; }
    public AuthPage()
    {
        VM = VMFactory.createAuthViewModel();
        InitializeComponent();
    }

    private void _passwordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = (PasswordBox)sender;
        VM.Password = passwordBox.Password;
    }
}