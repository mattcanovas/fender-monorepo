using System.Windows;

namespace Fender.App.Views.Windows;

public partial class LogoutDialogWindow : Window
{
    public LogoutDialogWindow()
    {
        InitializeComponent();
    }

    private void SimButton_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(App.Current.MainWindow) as MainWindow).MainFrame.Navigate(new AuthPage());
        Close();
    }

    private void NaoButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
