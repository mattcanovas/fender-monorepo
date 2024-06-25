using System.Windows.Controls;
using Fender.App.Views.Registers;

namespace Fender.App.Views;

public partial class HomePage : Page
{
    public HomePage()
    {
        InitializeComponent();
        _homeFrame.Navigate(new UserRegisterPage());
    }
}