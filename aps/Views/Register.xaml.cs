using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using aps_project;

namespace aps.Views
{
    /// <summary>
    /// Interação lógica para Register.xam
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtCompanyName.Text;
            string funcao = txtCompanyRole.Text;
            string telefone = txtCompanyPhone.Text;
            string email = txtCompanyEmail.Text;
            string endereco = txtCompanyAddress.Text;
            string cnpj = txtCompanyCnpj.Text;

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(funcao) ||
                string.IsNullOrWhiteSpace(telefone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(endereco) ||
                string.IsNullOrWhiteSpace(cnpj))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            Company newCompany = new Company(nome, email, telefone, endereco, funcao, cnpj);
            int newId = App.DbService.AddCompany(newCompany);

            if (newId > 0)
            {
                Employee adminEmployee = new Employee(0, "Administrator", newId, "0", "Admin", "Admin@admin.com", "1234", "rua");
                int adminId = App.DbService.AddEmployee(adminEmployee);

                string user = GenerateRandomString();
                string passwd = GenerateRandomString();

                App.DbService.addUser(user, passwd, adminId);
                CustomMessageBox.Show($"Empresa registrada com sucesso! Para entrar, usuário: {user}, senha: {passwd}");

                // Obtenha a referência ao Frame
                var frame = (Parent as Page)?.Parent as Frame ??
                            Application.Current.MainWindow.FindName("MainFrame") as Frame;

                // Navegue
                frame?.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Falha ao registrar a empresa.");
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

        public static string GenerateRandomString()
        {
            const string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] password = new char[6];
            for (int i = 0; i < 6; i++)
            {
                password[i] = allowedCharacters[random.Next(allowedCharacters.Length)];
            }

            return new string(password);
        }
    }
}
