using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aps.src;
using aps.Views;

namespace aps.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MoneyViewCommand { get; set; }
        public RelayCommand EmployeeViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public MoneyViewModel MoneyVM { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; } 

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            MoneyVM = new MoneyViewModel(AppWindow.LoggedCompany.Id);
            EmployeeVM = new EmployeeViewModel(AppWindow.LoggedCompany.Id);
            HomeVM = new HomeViewModel(MoneyVM, EmployeeVM);

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            MoneyViewCommand = new RelayCommand(o =>
            {
                CurrentView = MoneyVM;
            });
            EmployeeViewCommand = new RelayCommand(o =>
            {
                CurrentView = EmployeeVM;
            });
        }
    }
}
