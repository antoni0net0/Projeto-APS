using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using aps.ViewModel;
using aps_project;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aps.Views
{
    /// <summary>
    /// Lógica interna para AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void Add_Employee(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string role = txtRole.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string cpf = txtCpf.Text;
            string wage = txtWage.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(role) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(cpf) ||
                string.IsNullOrWhiteSpace(wage))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            if (!double.TryParse(wage, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedWage))
            {
                MessageBox.Show("Salário inválido. Insira um número válido (use ponto como separador decimal).");
                return;
            }
            Employee newEmployee = new Employee(parsedWage, role, AppWindow.LoggedCompany.Id, cpf, name, email, phone, address);
            int employeeId = App.DbService.AddEmployee(newEmployee);
            if (employeeId >= 0)
            {
                newEmployee.Id = employeeId;

                // Retrieve the MainViewModel from the MainWindow's DataContext
                if (Application.Current.MainWindow is AppWindow mainWindow &&
                    mainWindow.DataContext is MainViewModel mainVM)
                {
                    // Add the new transaction to the ObservableCollection in MoneyViewModel
                    mainVM.EmployeeVM.AddEmployee(newEmployee);

                    this.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Erro em adicionar novo funcionário");
                return;
            }
        }

        private void Cancel_Employee(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
