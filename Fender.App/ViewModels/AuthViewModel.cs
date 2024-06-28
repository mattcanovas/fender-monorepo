using Dapper;
using Fender.App.Model;
using Fender.App.Views;
using Npgsql;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

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

    private string _password { get; set; }
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    private string _errorMessage { get; set; }
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
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

    private bool CanSignIn()
    {
        if (_username == null || _password == null)
        {
            return false;
        }
        return true;
    }

    private async Task SignIn()
    {
        using var connection = new NpgsqlConnection("Host=localhost; Database=fender_db; Username=postgres; Password=0709");
        User user = await connection.QuerySingleOrDefaultAsync<User>("""
                    SELECT * FROM Users
                    WHERE Username = @Username
                    AND Password = @Password;
                """,
                new { Username = _username, Password = _password });
        if (user == null)
        {
            ErrorMessage = "Usuário inexistente ou senha inválida, por favor, tente novamente.";
            return;
        }
        (Window.GetWindow(App.Current.MainWindow) as MainWindow).MainFrame.Navigate(new HomePage());
    }
}