using Dapper;
using Fender.App.Model;
using Npgsql;
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
        using var connection = new NpgsqlConnection("Host=localhost; Database=fender_db; Username=postgres; Password=0709");
        User user = await connection.QuerySingleOrDefaultAsync<User>("""
                    SELECT * FROM Users
                    WHERE Username = @Username
                    AND Password = @Password;
                """,
                new { Username = _username, Password = _password });
        MessageBox.Show($"Usuário detectado: {user.Username}, seja bem vindo {user.FirstName}");
    }
}