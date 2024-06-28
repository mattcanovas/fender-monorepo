using System.Windows;

namespace Fender.App.Views.Windows;

public partial class CloseDialogWindow : Window
{
    public CloseDialogWindow()
    {
        InitializeComponent();
    }
    private void SimButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void NaoButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
