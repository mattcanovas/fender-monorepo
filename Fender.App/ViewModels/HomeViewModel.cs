namespace Fender.App.ViewModels;

public class HomeViewModel : ViewModelBase
{

    private string _userLogged { get; set; }
    public string UserLogged { 
        get => _userLogged;
        set {
            _userLogged = value;
            OnPropertyChanged();
        }
    }

}
