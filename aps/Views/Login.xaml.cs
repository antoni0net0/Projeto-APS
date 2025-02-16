using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using aps_project;

namespace aps.Views
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNome.Text;
            string password = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            int companyId = App.DbService.CheckUser(name, password);

            if(companyId > 0)
            {
                Company? company = App.DbService.GetCompany(companyId);
                if (company == null)
                {
                    MessageBox.Show("Company does not exist");
                    return;
                }

                AppWindow appWindow = new AppWindow(company);
                appWindow.Show();

                Window? currentWindow = Window.GetWindow(this);
                currentWindow?.Close();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas");
            }
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            // Obtenha a referência ao Frame
            var frame = (Parent as Page)?.Parent as Frame ??
                        Application.Current.MainWindow.FindName("MainFrame") as Frame;

            // Navegue
            frame?.Navigate(new Uri("Views/Landing.xaml", UriKind.Relative));
        }
    }
}
