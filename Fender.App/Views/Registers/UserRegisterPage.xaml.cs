using Fender.App.ViewModels.Registers;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Fender.App.Views.Registers;

public partial class UserRegisterPage : Page
{
    public UserRegistersViewModel VM { get; private set; }
    public UserRegisterPage()
    {
        VM = new UserRegistersViewModel();
        InitializeComponent();
    }
    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

        if (!string.IsNullOrEmpty(displayName))
        {
            e.Column.Header = displayName;
        }

    }

    public static string GetPropertyDisplayName(object descriptor)
    {
        var pd = descriptor as PropertyDescriptor;

        if (pd != null)
        {
            // Check for DisplayName attribute and set the column header accordingly
            var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

            if (displayName != null && displayName != DisplayNameAttribute.Default)
            {
                return displayName.DisplayName;
            }

        }
        else
        {
            var pi = descriptor as PropertyInfo;

            if (pi != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                for (int i = 0; i < attributes.Length; ++i)
                {
                    var displayName = attributes[i] as DisplayNameAttribute;
                    if (displayName != null && displayName != DisplayNameAttribute.Default)
                    {
                        return displayName.DisplayName;
                    }
                }
            }
        }

        return null;
    }

    private void NovoButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService!.Navigate(new NewUserRegisterPage());
    }
}