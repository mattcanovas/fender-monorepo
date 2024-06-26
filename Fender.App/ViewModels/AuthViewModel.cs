﻿using Dapper;
using Fender.App.Model;
using Fender.App.Views;
using Npgsql;
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
        return _username != null && _password != null;
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
            ErrorMessage = "Usuário ou senha inválidos, por favor tente novamente.";
            return;
        }
        (Window.GetWindow(App.Current.MainWindow) as MainWindow).MainFrame.Navigate(new HomePage($"Usuário: {user.FirstName} {user.LastName}"));
    }
}