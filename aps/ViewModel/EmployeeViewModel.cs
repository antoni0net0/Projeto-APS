using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using aps.src;
using aps.Views;
using aps_project;

namespace aps.ViewModel
{
    public class EmployeeViewModel : ObservableObject
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public EmployeeViewModel(int companyId)
        {
            LoadEmployees(companyId);
        }

        public void LoadEmployees(int companyId)
        {
            // Fetch transactions from the database
            var loadedEmployees = App.DbService.GetEmployees(companyId);
            Employees.Clear();
            foreach (var employee in loadedEmployees)
            {
                Employees.Add(employee);
            }
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(int employeeId)
        {
            App.DbService.RemoveEmployee(employeeId);
            var employee = Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                Employees.Remove(employee);
            }
        }
        public void CreateUser(int employeeId)
        {
            string user = GenerateRandomString();
            string passwd = GenerateRandomString();

            App.DbService.addUser(user, passwd, employeeId);

            CustomMessageBox.Show($"Usuário adicionado com sucesso! Username: {user}, Senha: {passwd}");
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
