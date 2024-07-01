namespace Fender.App.ViewModels.Registers;

public class NewUserRegisterViewModel : ViewModelBase
{
    private string _firstName { get; set; }

    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }
    
    private string _lastName { get; set; }

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }
    
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
}