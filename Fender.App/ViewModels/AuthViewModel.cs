using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fender.App.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private string _username { get; set; }
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }
    private SecureString _password { get; set; }
    public SecureString Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    private ICommand _signInCommand;
    public ICommand SignInCommand
    {
        get
        {
            return _signInCommand ??= new Handler.RelayCommandAsync(() => SignIn(), (o) => CanSignIn());
        }
    }
    private static bool CanSignIn()
    {
        return true;
    }
    private async Task SignIn()
    {
        MessageBox.Show($"{_username}, {_password}");
    }
}