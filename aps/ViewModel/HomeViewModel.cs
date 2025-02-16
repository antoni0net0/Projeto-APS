using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aps.src;
using aps.Views;
using aps_project;

namespace aps.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private readonly MoneyViewModel _moneyVm;
        private readonly EmployeeViewModel _employeeVm;
        private readonly Company _company;

        public double TotalTransactionsValue => _moneyVm.Transactions.Sum(t => t.Value);
        public int TotalTransactionsCount => _moneyVm.Transactions.Count;
        public int TotalEmployeesCount => _employeeVm.Employees.Count;
        public string CompanyName => _company.Name;
        public string CompanyCNPJ => _company.Cnpj;

        public HomeViewModel(MoneyViewModel moneyVm, EmployeeViewModel employeeVm)
        {
            _moneyVm = moneyVm;
            _employeeVm = employeeVm;
            _company = AppWindow.LoggedCompany;

            // Subscribe to changes
            _moneyVm.Transactions.CollectionChanged += (s, e) => OnPropertyChanged(nameof(TotalTransactionsValue));
            _employeeVm.Employees.CollectionChanged += (s, e) => OnPropertyChanged(nameof(TotalEmployeesCount));
        }
    }
 }
