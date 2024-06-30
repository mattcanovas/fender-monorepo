using Dapper;
using Fender.App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fender.App.ViewModels.Registers;

public class UserRegistersViewModel : ViewModelBase
{
    private List<User> _users { get; set; }
    public List<User> Users
    {
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged();
        }
    }

    private User _selectedUser { get; set; }
    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged();
        }
    }

    public UserRegistersViewModel()
    {
        Users = _usersTask().ToList();
    }

    private IEnumerable<User> _usersTask()
    {
        using NpgsqlConnection connection = new("Host=localhost; Database=fender_db; Username=postgres; Password=0709");
        return connection.Query<User>("SELECT * FROM USERS;");
    }

    
}
