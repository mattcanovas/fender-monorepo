using System;
using System.Windows.Threading;

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

    public DateTime DateTimeNow => DateTime.Now;
    private DispatcherTimer Timer { get; set; }

    public HomeViewModel()
    {
        Timer = new DispatcherTimer
        {
            Interval = new TimeSpan(0, 0, 0, 1)
        };
        Timer.Tick += Timer_Tick;
        Timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(DateTimeNow));
    }
}
