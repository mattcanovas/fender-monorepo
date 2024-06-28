using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fender.App.Views.Windows
{
    /// <summary>
    /// Lógica interna para CloseDialogWindow.xaml
    /// </summary>
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
}
