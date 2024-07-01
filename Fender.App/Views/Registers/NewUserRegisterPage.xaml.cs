using System.Windows;
using System.Windows.Controls;
using Fender.App.ViewModels.Registers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fender.App.Views.Registers;

public partial class NewUserRegisterPage : Page
{
    public NewUserRegisterViewModel VM { get; set; }
    public NewUserRegisterPage()
    {
        VM = new NewUserRegisterViewModel(); 
        InitializeComponent();
    }

    private void VoltarButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
    private void _passwordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = (PasswordBox)sender;
        VM.Password = passwordBox.Password;
    }
}