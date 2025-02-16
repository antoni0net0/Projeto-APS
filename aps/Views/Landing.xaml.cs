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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aps.Views
{
    /// <summary>
    /// Interação lógica para Landing.xam
    /// </summary>
    public partial class Landing : Page
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtenha a referência ao Frame
            var frame = (Parent as Page)?.Parent as Frame ??
                        Application.Current.MainWindow.FindName("MainFrame") as Frame;

            // Navegue
            frame?.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Obtenha a referência ao Frame
            var frame = (Parent as Page)?.Parent as Frame ??
                        Application.Current.MainWindow.FindName("MainFrame") as Frame;

            // Navegue
            frame?.Navigate(new Uri("Views/Register.xaml", UriKind.Relative));
        }
    }
}
